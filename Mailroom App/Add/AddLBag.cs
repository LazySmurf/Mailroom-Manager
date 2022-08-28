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

namespace Mailroom_App.Add
{
    public partial class AddLBagForm : Form
    {
        private string RegEx = "^[A-Z0-9]{1,15}$";
        public bool DoUpdate { get; set; }
        public string BagNumber { get; set; }
        public string ShipmentNumber { get; set; }

        private static readonly HttpClient _httpClient = new HttpClient();

        private async void AddBagBtn_Click(object sender, EventArgs e)
        {
            bool IsValid = true;
            DoUpdate = false;
            //We'll do some Front-End Regex to ensure values match our desired format. The same check is done again on back-end as well.
            //We'll also do a ToUpper on the text, as a regular worker in the mailroom office may not know to caps everything.
            Match BagNoMatch = Regex.Match(BagNoTxt.Text.ToUpper(), RegEx);
            //We can get the Airport's correct value by checking the AirportCombo.SelectedIndex value. This will match the associated Enum value.

            if (!BagNoMatch.Success)
            {
                MessageBox.Show("Bag Number \"" + BagNoTxt.Text.ToUpper() + "\" is Invalid.\n\nBag Number must be between 1 and 15 characters (Numbers and Letters allowed)", "Bag Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IsValid = false;
            }
            //If no validation error occurs, we can check if such a bag already exists with this number
            if (IsValid)
            {
                AddBag();
            }
        }

        public async void AddBag()
        {
            HttpClient httpClient = new HttpClient();
            var BagContent = JsonConvert.SerializeObject(new Models.LetterBag
            {
                BagNo = BagNoTxt.Text,
                LetterCount = 0,
                Weight = (decimal)0.000,
                Price = (decimal)0.00,
                ParcelList = new List<string>()
            });
            var buffer = Encoding.UTF8.GetBytes(BagContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = _httpClient.PostAsync(Settings.Default.API_Server + Global.LBagsURI, byteContent).Result;
            httpClient.Dispose();
            if (result.IsSuccessStatusCode)
            {
                AddBagToShipment();
            }
            else
            {
                MessageBox.Show("There was an error adding this bag.", "Error Adding Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public async void AddBagToShipment()
        {
            HttpClient httpClient = new HttpClient();
            string thisShipment = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipmentNumber);
            Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(thisShipment);

            var Bags = new List<string>();
            Bags.AddRange(json.BagList);
            Bags.Add(BagNoTxt.Text);
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
            httpClient.Dispose();
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                DoUpdate = true;
                BagNumber = BagNoTxt.Text;
            }
            else
            {
                MessageBox.Show("There was an error adding this bag to the shipment.\n\n" + result.StatusCode, "Error Adding Bag", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public AddLBagForm()
        {
            InitializeComponent();
            MouseDown += AddLBagForm_MouseDown;
            MouseMove += AddLBagForm_MouseMove;
            TitleLabel.MouseDown += AddLBagForm_MouseDown;
            TitleLabel.MouseMove += AddLBagForm_MouseMove;
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CancelBtn.MouseClick += CloseBox_MouseClick;
        }

        private void AddLBag_Load(object sender, EventArgs e)
        {
            CurveBorder(20);

            //We will set the two textboxes on the form to convert all characters to uppercase
            BagNoTxt.CharacterCasing = CharacterCasing.Upper;

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");
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
        private void AddLBagForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void AddLBagForm_MouseMove(object sender, MouseEventArgs e)
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

        private void BagNoTxt_TextChanged(object sender, EventArgs e)
        {
            Match BagNoMatch = Regex.Match(BagNoTxt.Text.ToUpper(), RegEx);
            ToolTip toolTip = new ToolTip();
            if (BagNoMatch.Success)
            {
                BagNoStatus.Visible = true;
                BagNoStatus.ForeColor = Color.Lime;
                BagNoStatus.Text = "✔";
                toolTip.SetToolTip(BagNoStatus, "Bag Number is Valid");
            }
            else
            {
                BagNoStatus.Visible = true;
                BagNoStatus.ForeColor = Color.Red;
                BagNoStatus.Text = "❌";
                toolTip.SetToolTip(BagNoStatus, "Bag Number is Invalid");
            }
        }
    }
}
