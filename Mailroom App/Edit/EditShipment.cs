using Mailroom_App.Properties;
using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class EditShipmentForm : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public string ShipNo { get; set; } //This is the property to which a value is assigned when this window is called.
        public bool DoUpdate { get; set; } //This value will be true if the update goes through, and we will read this when the update is complete on the parent window.

        
        private async void EditShipmentBtn_Click(object sender, EventArgs e)
        {
            bool IsValid = true;
            DoUpdate = false;

            //Get the shipment being edited's info, so we can grab the BagList without overwriting it (since we handle bags through the main UI)
            string thisShipment = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipNo);
            Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(thisShipment);

            //Create the HttpContent object to be passed to _httpClient.PutAsync(uri, HttpContent)
            var ShipmentContent = JsonConvert.SerializeObject(new Models.Shipment
            {
                ShipmentNo = ShipNo,
                Airport = (Models.Airport)AirportCombo.SelectedIndex,
                FlightNo = FlightNoTxt.Text,
                FlightDate = FlightDateTimePicker.Value,
                BagList = json.BagList,
                IsFinalized = IsFinalizedChkBx.Checked
            });
            var buffer = System.Text.Encoding.UTF8.GetBytes(ShipmentContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //Try to do the edit request
            try
            {
                var result = _httpClient.PutAsync(Settings.Default.API_Server + Global.ShipmentsURI, byteContent).Result;
                DialogResult = DialogResult.OK;
                DoUpdate = true;
                if (IsFinalizedChkBx.Checked)
                {
                    ShipNo = ShipNo + " ✅";
                }
                //Close();
            }
            catch (Exception ex) //Throw an error if it occurs, but don't close the window or crash out of application
            {
                MessageBox.Show("There was an error submitting the Shipment.\n\nDetails:\n\n" + ex);
                //throw;
            }
        }

        //This method gets the data for the selected shipment and fills in the details on the form so we can edit them.
        public async void GetShipNo(string ShipNo)
        {
            string result = await _httpClient.GetStringAsync(Settings.Default.API_Server + Global.ShipmentsURI + "/" + ShipNo);
            Models.Shipment json = JsonConvert.DeserializeObject<Models.Shipment>(result);

            SelectedShipNoLbl.Text = json.ShipmentNo;
            AirportCombo.SelectedItem = json.Airport;
            FlightNoTxt.Text = json.FlightNo;
            FlightDateTimePicker.Value = json.FlightDate;
            IsFinalizedChkBx.Checked = json.IsFinalized;
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

        public EditShipmentForm()
        {
            InitializeComponent();
            MouseDown += EditShipmentForm_MouseDown;
            MouseMove += EditShipmentForm_MouseMove;
            TitleLabel.MouseDown += EditShipmentForm_MouseDown;
            TitleLabel.MouseMove += EditShipmentForm_MouseMove;
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            CancelBtn.MouseClick += CloseBox_MouseClick;
        }

        private async void EditShipment_Load(object sender, EventArgs e)
        {
            CurveBorder(20);

            //Configure the DateTimePicker object to match the format we want and make sure we can't set the date before today.
            //FlightDateTimePicker.MinDate = DateTime.Now.AddSeconds(-1);
            FlightDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            FlightDateTimePicker.Format = DateTimePickerFormat.Custom;
            FlightDateTimePicker.CustomFormat = "ddd MMM d, yyyy @ h:mm tt";

            //Set the Airport list to the values of the Airport enum model, so we can dynamically set which airports are allowed values.
            AirportCombo.DataSource = Enum.GetValues(typeof(Models.Airport));

            //We will set the textbox on the form to convert all characters to uppercase
            FlightNoTxt.CharacterCasing = CharacterCasing.Upper;

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");
            toolTip.SetToolTip(SelectedShipNoLbl, "Shipment Number cannot be edited once created");

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
        private void EditShipmentForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void EditShipmentForm_MouseMove(object sender, MouseEventArgs e)
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

        private void FlightNoTxt_TextChanged(object sender, EventArgs e)
        {
            Match FlightNoMatch = Regex.Match(FlightNoTxt.Text.ToUpper(), "^[A-Z]{2}[0-9]{4}$");
            ToolTip toolTip = new ToolTip();
            if (FlightNoMatch.Success)
            {
                FlightNoStatus.Visible = true;
                FlightNoStatus.ForeColor = Color.Lime;
                FlightNoStatus.Text = "✔";
                toolTip.SetToolTip(FlightNoStatus, "Flight Number is Valid");
            }
            else
            {
                FlightNoStatus.Visible = true;
                FlightNoStatus.ForeColor = Color.Red;
                FlightNoStatus.Text = "❌";
                toolTip.SetToolTip(FlightNoStatus, "Flight Number is Invalid");
            }
        }

        private void IsFinalizedChkBx_CheckedChanged(object sender, EventArgs e)
        {
            //Change the Checkbox Text based on whether or not the shipment is finalized
            if (IsFinalizedChkBx.Checked == true)
            {
                IsFinalizedChkBx.Text = "Finalized";
            } else
            {
                IsFinalizedChkBx.Text = "Not Finalized";
            }
            //Recenter the checkbox
            IsFinalizedChkBx.Location = new Point((EditShipmentControlsGrpBx.Width - IsFinalizedChkBx.Width) / 2, IsFinalizedChkBx.Location.Y);
        }
    }
}
