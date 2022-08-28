using Mailroom_App.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Mailroom_App.Delete
{
    public partial class DelLBagForm : Form
    {
        public bool DoUpdate { get; set; }
        public string BagNumber { get; set; }
        public string ShipmentNumber { get; set; }

        private static readonly HttpClient _httpClient = new HttpClient();
        public Methods.Delete Delete = new Methods.Delete();

        private async void DelBagBtn_Click(object sender, EventArgs e)
        {
            DoUpdate = false;
            /*
             * 1. Get all the parcels inside this bag
             * 2. Iterate through the list and delete each parcel
             * 3. Delete the bag itself
             * 4. Update the shipment to remove the bag from it's list of bags
            */
            DialogResult ConfirmDelete = MessageBox.Show("You are about to delete the Letter Bag \"" + BagNumber + "\"\n\nDeleting this bag will also remove all parcels within the bag. This action cannot be undone.\n\nAre you sure you want to delete this bag?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ConfirmDelete == DialogResult.Yes)
            {
                //Get all the parcels from the current bag
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + BagNumber);
                Models.LetterBag json = JsonConvert.DeserializeObject<Models.LetterBag>(result);
                //Start the delete process, by deleting the parcels from the bag. Inside that method, we'll then call to delete the bag, then update the shipment.
                DeleteParcelsFromBag(json.ParcelList);
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public async void DeleteParcelsFromBag(ICollection<string> letters)
        {
            //We don't need to delete the parcels from the list inside the bag since we're deleting the bag,
            //But we will have to delete the bag from the shipment list later.
            foreach (string letter in letters)
            {
                Delete.Parcel(letter);
            }
            DeleteBag();
        }

        public async void DeleteBag()
        {
            Delete.LetterBag(BagNumber);
            UpdateShipment(ShipmentNumber);
        }

        public async void UpdateShipment(string ShipNo)
        {
            string thisShipment = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipmentNumber);
            Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(thisShipment);

            List<string> Bags = json.BagList;
            Bags.Remove(BagNumber);
            var ShipmentContent = JsonConvert.SerializeObject(new Models.Shipment
            {
                ShipmentNo = ShipmentNumber,
                Airport = json.Airport,
                FlightNo = json.FlightNo,
                FlightDate = json.FlightDate,
                BagList = Bags,
                IsFinalized = json.IsFinalized
            });
            var buffer = Encoding.UTF8.GetBytes(ShipmentContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.ShipmentsURI, byteContent).Result;
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                DoUpdate = true;
            }
            else
            {
                MessageBox.Show("There was an error removing this bag from the shipment.\n\n" + result.StatusCode, "Error Removing Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public DelLBagForm()
        {
            InitializeComponent();
            MouseDown += DelLBagForm_MouseDown;
            MouseMove += DelLBagForm_MouseMove;
            TitleLabel.MouseDown += DelLBagForm_MouseDown;
            TitleLabel.MouseMove += DelLBagForm_MouseMove;
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CancelBtn.MouseClick += CloseBox_MouseClick;
        }

        private async void DelLBag_Load(object sender, EventArgs e)
        {
            CurveBorder(20);

            //We will set the two textboxes on the form to convert all characters to uppercase
            //BagNoTxt.CharacterCasing = CharacterCasing.Upper;

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");

            //Populate the form data
            string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + BagNumber);
            Models.LetterBag json = JsonConvert.DeserializeObject<Models.LetterBag>(result);
            BagNoLbl.Text = json.BagNo;
            LetterCountLbl.Text = json.LetterCount.ToString();
            WeightLbl.Text = json.Weight.ToString();
            PriceLbl.Text = "€" + json.Price.ToString();

            //If the selected shipment is finalized, we will remove the checkmark from the passed shipment number.
            //Now, if a shipment is finalized, we will disable the buttons for each of it's elements as it cannot be
            //edited, however if this functionality were to be added, this is already handled. (Also useful for testing!)
            if (ShipmentNumber.Contains(" ✅"))
            {
                ShipmentNumber = ShipmentNumber.Substring(0,ShipmentNumber.Length - 2);
            }
        }

        private int X1; // These 3 variables are defined here for use with the following functions
        private int Y1; // to allow dragging of the borderless form!
        private Rectangle WR;

        public MouseEventArgs MouseDownEvents(MouseEventArgs e) // When the mouse is down...
        {
            X1 = e.X; // Set X1 to mouse event's X coord
            Y1 = e.Y; // Set Y1 to mouse event's Y coord
            WR = Screen.GetWorkingArea(this); // Set WR as the working area of the current screen that the window is on.
            return e; // Return e (discarded)
        }

        public MouseEventArgs MouseMoveEvents(MouseEventArgs e) // When the mouse moves...
        {
            if (!(e.Button == MouseButtons.Left))
                return e; // If the mouse button isn't the left mouse button, return e, exit function.
            int NewX = Left + (e.X - X1); // NewX is window's left plus mouse's X subtract X1 (lock X coords together)
            int NewY = Top + (e.Y - Y1); // Same but for Y coord (lock Y coords together)
            int W = Width; // W is window's width
            int H = Height; // H is window's height
            if (NewY >= WR.Top - 15 & NewY <= WR.Top + 15) // If we approach an edge, do some logic to see when we're getting close, then set our position to that edge.
            {
                Top = WR.Top;
            }
            else if (NewY + H > WR.Bottom - 15 & NewY + H < WR.Bottom + 15)
            {
                Top = WR.Bottom - H;
            }
            else
            {
                Top = NewY;
            }
            if (NewX >= WR.Left - 15 & NewX <= WR.Left + 15)
            {
                Left = WR.Left;
            }
            else if (NewX + W > WR.Right - 15 & NewX + W < WR.Right + 15)
            {
                Left = WR.Right - W;
            }
            else
            {
                Left = NewX;
            }
            return e; // Return e (discarded again)
        }

        // Give the borders a curve by a set amount, passed when calling the function
        public GraphicsPath CurveBorder(int curve) // We set the variable 'curve' to define how much of a curve we want. 10-30 is usually a decent range.
        {
            var p = new GraphicsPath(); // Create a 2D path
            p.StartFigure(); // Start defining the figure. Rectangle Constructor uses (int32) format Rectangle(int x, int y, int width, int height)
            p.AddArc(new Rectangle(0, 0, curve, curve), 180, 90); // Add Arc, then line, for each corner. 
            p.AddLine(curve, 0, Width - curve, 0);
            p.AddArc(new Rectangle(Width - curve, 0, curve, curve), -90, 90);
            p.AddLine(Width, curve, Width, Height - curve);
            p.AddArc(new Rectangle(Width - curve, Height - curve, curve, curve), 0, 90);
            p.AddLine(Width - curve, Height, curve, Height);
            p.AddArc(new Rectangle(0, Height - curve, curve, curve), 90, 90);
            p.CloseFigure(); // Close figure
            Region = new Region(p); // Set new region as our 2D path
            return p; // Return true (discarded, but could be used for error handling of some kind. not really necessary.)
        }

        //Move Form
        private void DelLBagForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void DelLBagForm_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveEvents(e);
        }

        //Minimize button
        private void MinimizeBox_MouseEnter(object sender, EventArgs e)
        {
            MinimizeBox.BackColor = ColorTranslator.FromHtml("#ffce75");
        }

        private void MinimizeBox_MouseLeave(object sender, EventArgs e)
        {
            MinimizeBox.BackColor = ColorTranslator.FromHtml("#ffbd44");
        }

        private void MinimizeBox_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Close button
        private void CloseBox_MouseEnter(object sender, EventArgs e)
        {
            CloseBox.BackColor = ColorTranslator.FromHtml("#ff7975");
        }

        private void CloseBox_MouseLeave(object sender, EventArgs e)
        {
            CloseBox.BackColor = ColorTranslator.FromHtml("#FF605C");
        }

        private void CloseBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
