using Mailroom_App.Models;
using Mailroom_App.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Mailroom_App.Delete
{
    public partial class DelShipmentForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public string ShipNo { get; set; } //This is the property to which a value is assigned when this window is called.
        public bool DoUpdate { get; set; } = false; //This value will be true if the update goes through, and we will read this when the update is complete on the parent window.
        public bool IsFinalized { get; set; }
        public List<string> LBagsInShipment { get; set; } = new List<string>();
        public List<string> PBagsInShipment { get; set; } = new List<string>();
        public List<string> ParcelsInShipment { get; set; } = new List<string>();

        Methods.Delete Delete = new Methods.Delete();

        private async void DelShipmentBtn_Click(object sender, EventArgs e)
        {
            DialogResult ConfirmDelete = MessageBox.Show("You are about to delete the Shipment \"" + ShipNo + "\"\n\nDeleting this shipment will also remove all bags and parcels within the bag. This action cannot be undone.\n\nAre you sure you want to delete this shipment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ConfirmDelete == DialogResult.Yes)
            {
                string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipNo);
                Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(result);

                CategorizeBags(json.BagList);
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public async void CategorizeBags(List<string> Bags)
        {
            foreach (string bag in Bags)
            {
                try
                {
                    string LetterBagInfo = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + bag);
                    Models.LetterBag LBagJson = JsonConvert.DeserializeObject<Models.LetterBag>(LetterBagInfo);
                    LBagsInShipment.Add(LBagJson.BagNo);
                    foreach (string letter in LBagJson.ParcelList)
                    {
                        ParcelsInShipment.Add(letter);
                    }
                }
                catch (Exception)
                {
                    string ParcelBagInfo = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.PBagsURI + "/" + bag);
                    Models.ParcelBag PBagJson = JsonConvert.DeserializeObject<Models.ParcelBag>(ParcelBagInfo);
                    PBagsInShipment.Add(PBagJson.BagNo);
                    foreach (string parcel in PBagJson.ParcelNos)
                    {
                        ParcelsInShipment.Add(parcel);
                    }
                }
            }
            //We should now have a list of all ParcelBags, LetterBags, and Parcels within the shipment.
            //Now we can recursively delete them all, then delete the shipment.
            DeleteAllParcels();

            /*//For Debugging -- Displays a list of each set of items. Uncomment to see all the items to be deleted.
            string allLBags = string.Join(", ", LBagsInShipment);
            string allPBags = string.Join(", ", PBagsInShipment);
            string allParcs = string.Join(", ", ParcelsInShipment);
            MessageBox.Show("LBags:\n" + allLBags + "\n\nPBags:\n" + allPBags + "\n\nParcels:\n" + allParcs, "Debug Display");
            */
        }

        public void DeleteAllParcels()
        {
            //Since Parcels are the objects at the bottom of the tier list, we will delete those first, and work our way up.
            //Parcels -> Bags -> Shipment
            foreach (string parcel in ParcelsInShipment)
            {
                Delete.Parcel(parcel);
            }
            DeleteAllBags();
        }

        public void DeleteAllBags()
        {
            foreach (string LBag in LBagsInShipment)
            {
                Delete.LetterBag(LBag);
            }
            foreach (string PBag in PBagsInShipment)
            {
                Delete.ParcelBag(PBag);
            }
            DeleteShipmentAndExit();
        }

        public void DeleteShipmentAndExit()
        {
            Delete.Shipment(ShipNo);
            DialogResult = DialogResult.OK;
            DoUpdate = true;
        }

        //This method gets the data for the selected shipment and fills in the details on the form so we can delete them.
        public async void GetShipNo(string ShipNo)
        {
            string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipNo);
            Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(result);

            SelectedShipNoLbl.Text = json.ShipmentNo;
            SelectedAirportLbl.Text = json.Airport.ToString();
            SelectedFlightNoLbl.Text = json.FlightNo;
            SelectedFlightDateLbl.Text = json.FlightDate.ToString("dd/MM/yyyy @ H:mm:ss tt K");
            IsFinalized = json.IsFinalized;
            IsFinalizedChkBx.Checked = IsFinalized;
            //Change the Checkbox Text based on whether or not the shipment is finalized
            if (json.IsFinalized == true)
            {
                IsFinalizedChkBx.Text = "Finalized";
            }
            else
            {
                IsFinalizedChkBx.Text = "Not Finalized";
            }
            //Recenter the checkbox
            IsFinalizedChkBx.Location = new Point((DelShipmentControlsGrpBx.Width - IsFinalizedChkBx.Width) / 2, IsFinalizedChkBx.Location.Y);
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

        public DelShipmentForm()
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

        private void DelShipmentForm_Load(object sender, EventArgs e)
        {
            CurveBorder(20);

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");

            GetShipNo(ShipNo); //Call the function to populate the form fields and pass it the Shipment # that was passed from the parent window.
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

        private void IsFinalizedChkBx_CheckedChanged(object sender, EventArgs e)
        {
            IsFinalizedChkBx.Checked = IsFinalized;
        }
    }
}
