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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailroom_App.Edit
{
    public partial class EditParcelForm : Form
    {
        //Define the dialog window properties
        public bool DoUpdate { get; set; }
        public string BagNumber { get; set; }
        public bool IsLBag { get; set; }
        public string ParcelNumber { get; set; }
        public decimal totalWeight { get; set; }
        public decimal totalPrice { get; set; }

        //Define our regex statements
        private string RecipientRegEx = "^[A-Za-z0-9]{1}[A-Za-z0-9\\s]{0,99}$";
        private string DestinationRegEx = "^[A-Z]{2}$";

        private static readonly HttpClient _httpClient = new HttpClient();

        private void EditParcelBtn_Click(object sender, EventArgs e)
        {
            //Set DoUpdate to true by default, and flip it to false if any of our validation checks go wrong.
            DoUpdate = true;
            //Check that the Recipient is valid
            if (!Regex.Match(RecipientTxt.Text, RecipientRegEx).Success)
            {
                MessageBox.Show("The Recipient is invalid. It must be between 1 and 100 characters and contain only letters and numbers.", "Invalid Recipient", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DoUpdate = false;
                return;
            }
            //Check that the Destination is valid
            if (!Regex.Match(DestinationTxt.Text.ToUpper(), DestinationRegEx).Success)
            {
                MessageBox.Show("The Destination is invalid. It must be exactly 2 letters that form a country code.", "Invalid Destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DoUpdate = false;
                return;
            }

            if (DoUpdate)
            {
                EditParcel();
            }
        }

        public void EditParcel()
        {
            /* We will verify the correct number of decimal places for the weight and price values by using Math.Round();
             * The NumericUpDown control we're using should already ensure that each value has the correct decimal places,
             * but to ensure the API is recieving values it likes to store, we will just double-check with this method.
             * 
             * The first value we pass is the decimal value, the second is the integer number of decimal places to keep.
             */
            decimal weight = Math.Round(WeightNumUD.Value, 3);
            decimal price = Math.Round(PriceNumUD.Value, 2);

            var ParcelContent = JsonConvert.SerializeObject(new Models.Parcel
            {
                ParcelNumber = ParcelNumber,
                Recipient = RecipientTxt.Text,
                Destination = DestinationTxt.Text,
                Weight = weight,
                Price = price,
                IsLetter = IsLBag //If the selected bag was a LetterBag, then IsLBag will be true, else false, so we can determine the parcel type via API
            });
            var buffer = Encoding.UTF8.GetBytes(ParcelContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.ParcelsURI, byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                if (IsLBag)
                {
                    UpdateLetterBag();
                } //We only need to update the bag if the parcel is a letter, since the Parcel model only requires the Bag Number and the Parcel List. If you wanted the same data for both, you could simply adjust the model.
                else
                {
                    DialogResult = DialogResult.OK;
                    DoUpdate = true;
                }
            }
            else
            {
                MessageBox.Show("There was an error editing this parcel.\n\nDetails:\n\n" + result.StatusCode, "Error Editing Parcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public async void UpdateLetterBag()
        {
            //Update this letterbag to contain the new Price/Weight values
            string thisBag = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.LBagsURI + "/" + BagNumber);
            Models.LetterBag json = JsonConvert.DeserializeObject<Models.LetterBag>(thisBag);

            //Start calculating the total weight & price of all parcels in the bag.
            CalculateLBagStats(json.ParcelList);

            var LBagContent = JsonConvert.SerializeObject(new Models.LetterBag
            {
                BagNo = json.BagNo,
                LetterCount = json.LetterCount,
                Weight = totalWeight, //Only update the weight and price values for the bag
                Price = totalPrice,
                ParcelList = json.ParcelList
            });
            var buffer = Encoding.UTF8.GetBytes(LBagContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.LBagsURI, byteContent).Result;

            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                DoUpdate = true;
            }
            else
            {
                MessageBox.Show("There was an error adding this bag to the shipment.\n\n" + result.StatusCode, "Error Adding Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public EditParcelForm()
        {
            InitializeComponent();
            MouseDown += AddParcelForm_MouseDown;
            MouseMove += AddParcelForm_MouseMove;
            TitleLabel.MouseDown += AddParcelForm_MouseDown;
            TitleLabel.MouseMove += AddParcelForm_MouseMove;
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CancelBtn.MouseClick += CloseBox_MouseClick;
        }

        private async void AddShipmentForm_Load(object sender, EventArgs e)
        {
            CurveBorder(20);
            //If we had a model for destination country codes, we could fill a dropdown menu with those instead of using a textbox.

            //We will set the textbox on the form to convert all characters to uppercase
            DestinationTxt.CharacterCasing = CharacterCasing.Upper;

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");

            //Set the form fields to contain the data of the selected parcel
            string thisParcel = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ParcelsURI + "/" + ParcelNumber);
            Models.Parcel json = JsonConvert.DeserializeObject<Models.Parcel>(thisParcel);
            SelectedParcelNoLbl.Text = json.ParcelNumber;
            RecipientTxt.Text = json.Recipient;
            DestinationTxt.Text = json.Destination;
            WeightNumUD.Value = json.Weight;
            PriceNumUD.Value = json.Price;
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
        private void AddParcelForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void AddParcelForm_MouseMove(object sender, MouseEventArgs e)
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

        private void RecipientTxt_TextChanged(object sender, EventArgs e)
        {
            Match RecipientMatch = Regex.Match(RecipientTxt.Text, RecipientRegEx);
            ToolTip toolTip = new ToolTip();
            if (RecipientMatch.Success)
            {
                RecipientStatusLbl.Visible = true;
                RecipientStatusLbl.ForeColor = Color.Lime;
                RecipientStatusLbl.Text = "✔";
                toolTip.SetToolTip(RecipientStatusLbl, "Recipient is Valid");
            }
            else
            {
                RecipientStatusLbl.Visible = true;
                RecipientStatusLbl.ForeColor = Color.Red;
                RecipientStatusLbl.Text = "❌";
                toolTip.SetToolTip(RecipientStatusLbl, "Recipient is Invalid");
            }
        }

        private void DestinationTxt_TextChanged(object sender, EventArgs e)
        {
            Match DestinationMatch = Regex.Match(DestinationTxt.Text.ToUpper(), DestinationRegEx);
            ToolTip toolTip = new ToolTip();
            if (DestinationMatch.Success)
            {
                DestinationStatusLbl.Visible = true;
                DestinationStatusLbl.ForeColor = Color.Lime;
                DestinationStatusLbl.Text = "✔";
                toolTip.SetToolTip(DestinationStatusLbl, "Destination is Valid");
            }
            else
            {
                DestinationStatusLbl.Visible = true;
                DestinationStatusLbl.ForeColor = Color.Red;
                DestinationStatusLbl.Text = "❌";
                toolTip.SetToolTip(DestinationStatusLbl, "Destination is Invalid");
            }
        }
    }
}
