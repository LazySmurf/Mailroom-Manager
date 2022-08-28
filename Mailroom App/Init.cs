using Mailroom_App.Properties;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Mailroom_App
{
    public partial class MailroomForm : Form
    {

        

        //Draw a drop shadow on the form to help it stand out from the background.
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

        //Handle when a setting is changed... There was some logic here, but it's unused right now.
        //The plan is/was to have this tell the rest of the application to target a new server when changed,
        //but instead it requires an app restart at this moment, as the initial call to the server is done
        //on app startup. This can be changed fairly easily, but for now, it's perfectly functional the way it is.
        void SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            
        }

        //Startup logic and event registers.
        public MailroomForm()
        {
            InitializeComponent();
            Settings.Default.SettingChanging += SettingChanging;
            //MouseDown and MouseMove events for the custom dragging of borderless form
            //Custom dragging function supports snapping to screen edges!
            //We have to include the events for each element we want to be draggable.
            //So, we set every background element on the form to be draggable, but not
            //buttons or lists, since they're interactable, and we don't want accidental clicks.
            MouseDown += MailroomForm_MouseDown;
            MouseMove += MailroomForm_MouseMove;
            TitleLabel.MouseDown += MailroomForm_MouseDown;
            TitleLabel.MouseMove += MailroomForm_MouseMove;
            MailroomIcon.MouseDown += MailroomForm_MouseDown;
            MailroomIcon.MouseMove += MailroomForm_MouseMove;
            ShipmentsGrpBx.MouseDown += MailroomForm_MouseDown;
            ShipmentsGrpBx.MouseMove += MailroomForm_MouseMove;
            LetterBagGrpBx.MouseDown += MailroomForm_MouseDown;
            LetterBagGrpBx.MouseMove += MailroomForm_MouseMove;
            ParcelBagGrpBx.MouseDown += MailroomForm_MouseDown;
            ParcelBagGrpBx.MouseMove += MailroomForm_MouseMove;
            ParcelGrpBx.MouseDown += MailroomForm_MouseDown;
            ParcelGrpBx.MouseMove += MailroomForm_MouseMove;

            //Enter, Leave, Click events for custom Minimize and Close buttons
            //Custom buttons are coloured programmatically!
            MinimizeBox.MouseEnter += MinimizeBox_MouseEnter;
            MinimizeBox.MouseLeave += MinimizeBox_MouseLeave;
            MinimizeBox.MouseClick += MinimizeBox_MouseClick;
            CloseBox.MouseEnter += CloseBox_MouseEnter;
            CloseBox.MouseLeave += CloseBox_MouseLeave;
            CloseBox.MouseClick += CloseBox_MouseClick;
            updateServerBox.MouseEnter += updateServerBox_MouseEnter;
            updateServerBox.MouseLeave += updateServerBox_MouseLeave;
            updateServerBox.MouseClick += updateServerBox_MouseClick;

            FormClosing += MailroomForm_FormClosing;
        }

        private async void MailroomForm_Load(object sender, EventArgs e)
        {
            //Call custom CurveBorder function on load, to round the edges of the form.
            CurveBorder(20);

            DeselectLBagBtn.Location = new Point(DeleteLBagBtn.Location.X, DeleteLBagBtn.Location.Y);
            DeleteLBagBtn.Location = new Point(EditLBagBtn.Location.X, EditLBagBtn.Location.Y);

            DeselectPBagBtn.Location = new Point(DeletePBagBtn.Location.X, DeletePBagBtn.Location.Y);
            DeletePBagBtn.Location = new Point(EditPBagBtn.Location.X, EditPBagBtn.Location.Y);

            //Set some tooltips
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(MinimizeBox, "Minimize");
            toolTip.SetToolTip(CloseBox, "Close");
            toolTip.SetToolTip(updateServerBox, "Set API Server Address");
            toolTip.SetToolTip(HelpBtn, "Help With How To Use Mailroom Manager");

            toolTip.SetToolTip(DeleteShipmentBtn, "Delete Shipment");
            toolTip.SetToolTip(EditShipmentsBtn, "Edit Shipment");
            toolTip.SetToolTip(AddShipmentBtn, "Add Shipment");
            toolTip.SetToolTip(DeselectShipmentBtn, "Deselect Shipment");

            toolTip.SetToolTip(DeleteLBagBtn, "Delete Letter Bag");
            toolTip.SetToolTip(EditLBagBtn, "Edit Letter Bag");
            toolTip.SetToolTip(AddLBagBtn, "Add Letter Bag");
            toolTip.SetToolTip(DeselectLBagBtn, "Deselect Letter Bag");

            toolTip.SetToolTip(DeletePBagBtn, "Delete Parcel Bag");
            toolTip.SetToolTip(EditPBagBtn, "Edit Parcel Bag");
            toolTip.SetToolTip(AddPBagBtn, "Add Parcel Bag");
            toolTip.SetToolTip(DeselectParcelBtn, "Deselect Parcel Bag");

            toolTip.SetToolTip(DeleteParcelBtn, "Delete Parcel");
            toolTip.SetToolTip(EditParcelBtn, "Edit Parcel");
            toolTip.SetToolTip(AddParcelBtn, "Add Parcel");
            toolTip.SetToolTip(DeleteParcelBtn, "Deselect Parcel");

            //Check the App settings
            //Retain the TopMost setting from the user.
            if (Settings.Default.TopMost == true) {
                TopmostCheckBx.Checked = true;
                TopMost = true;
            } else {
                TopmostCheckBx.Checked = false;
                TopMost = false;
            }
            //Check if the API Server is set, and if it is, display it in the application title
            if (Settings.Default.API_Server != String.Empty && Settings.Default.API_Server != null) {
                Text = "Mailroom Manager - " + Settings.Default.API_Server;
            }
            //If first program launch, center the program to the screen. Otherwise, get the last position of the window and open it again where it was.
            if (Settings.Default.FirstLaunch == true && Settings.Default.LastX == 0 && Settings.Default.LastY == 0)
            {
                CenterToScreen();
                Settings.Default.FirstLaunch = false;
                Settings.Default.Save();
            }
            else
            {
                Location = new Point(Settings.Default.LastX, Settings.Default.LastY);
            }

            //Call anything in the main program logic's Load method.
            await GetShipments();
        }

        private void MailroomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.LastX = this.Location.X;
            Settings.Default.LastY = this.Location.Y;
            Settings.Default.Save();
        }


        // Core UI Logic below.

        private int X1; // These 3 variables are defined here for use with the following functions
        private int Y1; // to allow dragging of the borderless form!
        private Rectangle WR;

        // Handle the elements that you can use to click and drag the window, and also handles snapping to the edges of the screen.
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

        private void TopmostCheckBx_CheckedChanged(object sender, EventArgs e)
        {
            if (TopmostCheckBx.Checked)
            {
                TopMost = true;
                Settings.Default.TopMost = true;
                Settings.Default.Save();
            }
            else
            {
                TopMost = false;
                Settings.Default.TopMost = false;
                Settings.Default.Save();
            }
        }

        private void API_Error()
        {
            MessageBox.Show("There was an error connecting to the API Server.\n\nPlease check your API Server address is correct within Mailroom Manager.\nIf it is set incorrectly, set it to the correct address, press save, and restart the application.\nOtherwise, your API Server may be down or refusing connections from your current address.\n\nPlease ensure both Mailroom Manager and your API Server are configured correctly.", "Server Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        //Mouse Events

        //Move Form
        private void MailroomForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEvents(e);
        }

        private void MailroomForm_MouseMove(object sender, MouseEventArgs e)
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
            Close();
        }

        //Update API Server Address button
        private void updateServerBox_MouseEnter(object sender, EventArgs e)
        {
            updateServerBox.BackColor = ColorTranslator.FromHtml("#34e377");
        }

        private void updateServerBox_MouseLeave(object sender, EventArgs e)
        {
            updateServerBox.BackColor = ColorTranslator.FromHtml("#00CA4E");
        }

        private void updateServerBox_MouseClick(object sender, MouseEventArgs e)
        {
            ServerConfig serverConfig = new ServerConfig();
            serverConfig.ShowDialog(this);
        }

        //Help button MessageBox
        private void HelpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mailroom Manager - How To Use\n\nIf you have items within your database, they will be displayed within the lists on the left side of each panel.\nTo view information about a particular shipment, bag, or parcel, click that item in the list, and it's details will be displayed in the Details panel to the right.\n\nTo add an item to the lists, click the + button within that panel.\nWhen an item is selected, you can also edit or remove items.\n\nTo deselect your current selection, press the blue ⌘ button within that panel.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

    }
}
