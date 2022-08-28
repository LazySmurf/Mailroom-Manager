using Mailroom_App.Models;
using Mailroom_App.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailroom_App.Delete
{
    public partial class DelParcelForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public string ParcelNumber { get; set; } //This is the property to which a value is assigned when this window is called.
        public bool DoUpdate { get; set; } //This value will be true if the update goes through, and we will read this when the update is complete on the parent window.
        public bool IsLBag { get; set; }
        public string BagNumber { get; set; }
        public decimal totalWeight { get; set; }
        public decimal totalPrice { get; set; }

        public Methods.Delete Delete = new Methods.Delete();
        private async void DelParcelBtn_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmDelete = MessageBox.Show("You are about to delete the Parcel \"" + ParcelNumber + "\"\n\nThis action cannot be undone.\n\nAre you sure you want to delete this parcel?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ConfirmDelete == DialogResult.Yes)
            {
                Delete.Parcel(ParcelNumber);
                if (IsLBag)
                {
                    RemoveParcelFromLBag();
                }
                else
                {
                    RemoveParcelFromPBag();
                }
            } else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public async void RemoveParcelFromLBag()
        {
            //Update this letterbag to contain the new Price/Weight values
            string thisBag = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + BagNumber);
            Models.LetterBag json = JsonConvert.DeserializeObject<Models.LetterBag>(thisBag);

            //Store the parcels in a new collection, then remove the deleted parcel from that collection.
            //We will then recalculate the bag's weight and price values based on the remaining parcels,
            //then, we will update the bag with the new weight and price values, as well as the new
            //collection of parcels and the count of parcels within that collection.
            ICollection<string> parcels = json.ParcelList;
            parcels.Remove(ParcelNumber);

            //Perform the calculation
            if (parcels.Count > 0)
            {
                CalculateLBagStats(parcels);
            } else
            {
                totalWeight = (decimal)0.000;
                totalPrice = (decimal)0.00;
            }

            var LBagContent = JsonConvert.SerializeObject(new Models.LetterBag
            {
                BagNo = json.BagNo, //BagNo stays the same
                LetterCount = parcels.Count, //Re-count the parcels
                Weight = totalWeight, //Store the new weight and price
                Price = totalPrice,
                ParcelList = parcels //Store the new list of parcels
            });
            var buffer = Encoding.UTF8.GetBytes(LBagContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.LBagsURI, byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                DoUpdate = true;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("There was an error updating this bag.\n\n" + result.StatusCode, "Error Adding Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculateLBagStats(ICollection<string> letters)
        {
            totalWeight = (decimal)0.000;
            totalPrice = (decimal)0.00;
            //For each parcel in the list, grab that parcel and add it's values to the total
            foreach (string letter in letters)
            {
                var task = Task.Run(() => _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + letter));
                task.Wait(); //Wait for the task to complete, so we don't try to do the calculation before the task returns a value
                string thisLetter = task.Result;
                Models.Parcel json = JsonConvert.DeserializeObject<Models.Parcel>(thisLetter);

                totalWeight += json.Weight;
                totalPrice += json.Price;
            }
            //Round the numbers so that they have the correct number of decimal places
            Math.Round(totalWeight, 3);
            Math.Round(totalPrice, 2);
        }

        public async void RemoveParcelFromPBag()
        {
            //Update this letterbag to contain the new Price/Weight values
            string thisBag = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.PBagsURI + "/" + BagNumber);
            Models.ParcelBag json = JsonConvert.DeserializeObject<Models.ParcelBag>(thisBag);

            //Store the parcels in a new collection, then remove the deleted parcel from that collection.
            //We will then recalculate the bag's weight and price values based on the remaining parcels,
            //then, we will update the bag with the new weight and price values, as well as the new
            //collection of parcels and the count of parcels within that collection.
            ICollection<string> parcels = json.ParcelNos;
            parcels.Remove(ParcelNumber);

            var LBagContent = JsonConvert.SerializeObject(new Models.ParcelBag
            {
                BagNo = json.BagNo, //BagNo stays the same
                ParcelNos = parcels //Store the new list of parcels
            });
            var buffer = Encoding.UTF8.GetBytes(LBagContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.PBagsURI, byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                DoUpdate = true;
            }
            else
            {
                MessageBox.Show("There was an error updating this bag.\n\n" + result.StatusCode, "Error Adding Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public DelParcelForm()
        {
            InitializeComponent();
            MouseDown += DelShipmentForm_MouseDown;
            MouseMove += DelShipmentForm_MouseMove;
            TitleLabel.MouseDown += DelShipmentForm_MouseDown;
            TitleLabel.MouseMove += DelShipmentForm_MouseMove;
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CancelBtn.MouseClick += CloseBox_MouseClick;
        }

        private async void DelShipmentForm_Load(object sender, EventArgs e)
        {
            CurveBorder(20);

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");

            //Populate the labels with this shipment's info
            string thisParcel = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + ParcelNumber);
            Models.Parcel json = JsonConvert.DeserializeObject<Models.Parcel>(thisParcel);
            SelectedParcelNoLbl.Text = json.ParcelNumber;
            SelectedRecipientLbl.Text = json.Recipient;
            SelectedDestinationLbl.Text = json.Destination;
            SelectedWeightLbl.Text = json.Weight.ToString();
            SelectedPriceLbl.Text = "€" + json.Price.ToString();
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
        private void DelShipmentForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void DelShipmentForm_MouseMove(object sender, MouseEventArgs e)
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
            DialogResult = DialogResult.Cancel;
        }
    }
}
