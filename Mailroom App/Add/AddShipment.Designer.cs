namespace Mailroom_App.Add
{
    partial class AddShipmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddShipmentForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.ShipmentNoLbl = new System.Windows.Forms.Label();
            this.ShipmentNoTxt = new System.Windows.Forms.TextBox();
            this.AddShipmentControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.FlightDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FlightNoLbl = new System.Windows.Forms.Label();
            this.FlightNoTxt = new System.Windows.Forms.TextBox();
            this.AirportCombo = new System.Windows.Forms.ComboBox();
            this.AirportLbl = new System.Windows.Forms.Label();
            this.AddShipmentBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.ShipNoStatus = new System.Windows.Forms.Label();
            this.FlightNoStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.AddShipmentControlsGrpBx.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(128, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(145, 30);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Add Shipment";
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBox.Image")));
            this.MinimizeBox.Location = new System.Drawing.Point(29, 9);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(10, 10);
            this.MinimizeBox.TabIndex = 12;
            this.MinimizeBox.TabStop = false;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.CloseBox.Image = ((System.Drawing.Image)(resources.GetObject("CloseBox.Image")));
            this.CloseBox.Location = new System.Drawing.Point(13, 9);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(10, 10);
            this.CloseBox.TabIndex = 11;
            this.CloseBox.TabStop = false;
            // 
            // ShipmentNoLbl
            // 
            this.ShipmentNoLbl.Location = new System.Drawing.Point(6, 33);
            this.ShipmentNoLbl.Name = "ShipmentNoLbl";
            this.ShipmentNoLbl.Size = new System.Drawing.Size(364, 13);
            this.ShipmentNoLbl.TabIndex = 13;
            this.ShipmentNoLbl.Text = "Shipment Number";
            this.ShipmentNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShipmentNoTxt
            // 
            this.ShipmentNoTxt.BackColor = System.Drawing.Color.Gray;
            this.ShipmentNoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShipmentNoTxt.ForeColor = System.Drawing.Color.White;
            this.ShipmentNoTxt.Location = new System.Drawing.Point(117, 49);
            this.ShipmentNoTxt.Name = "ShipmentNoTxt";
            this.ShipmentNoTxt.Size = new System.Drawing.Size(143, 22);
            this.ShipmentNoTxt.TabIndex = 14;
            this.ShipmentNoTxt.TextChanged += new System.EventHandler(this.ShipmentNoTxt_TextChanged);
            // 
            // AddShipmentControlsGrpBx
            // 
            this.AddShipmentControlsGrpBx.Controls.Add(this.FlightNoStatus);
            this.AddShipmentControlsGrpBx.Controls.Add(this.ShipNoStatus);
            this.AddShipmentControlsGrpBx.Controls.Add(this.FlightDateTimePicker);
            this.AddShipmentControlsGrpBx.Controls.Add(this.label1);
            this.AddShipmentControlsGrpBx.Controls.Add(this.FlightNoLbl);
            this.AddShipmentControlsGrpBx.Controls.Add(this.FlightNoTxt);
            this.AddShipmentControlsGrpBx.Controls.Add(this.AirportCombo);
            this.AddShipmentControlsGrpBx.Controls.Add(this.AirportLbl);
            this.AddShipmentControlsGrpBx.Controls.Add(this.ShipmentNoLbl);
            this.AddShipmentControlsGrpBx.Controls.Add(this.ShipmentNoTxt);
            this.AddShipmentControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.AddShipmentControlsGrpBx.Location = new System.Drawing.Point(12, 54);
            this.AddShipmentControlsGrpBx.Name = "AddShipmentControlsGrpBx";
            this.AddShipmentControlsGrpBx.Size = new System.Drawing.Size(376, 258);
            this.AddShipmentControlsGrpBx.TabIndex = 15;
            this.AddShipmentControlsGrpBx.TabStop = false;
            this.AddShipmentControlsGrpBx.Text = "Shipment Details";
            // 
            // FlightDateTimePicker
            // 
            this.FlightDateTimePicker.CustomFormat = "h:mm tt ddd MMM d, yyyy";
            this.FlightDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FlightDateTimePicker.Location = new System.Drawing.Point(87, 201);
            this.FlightDateTimePicker.Name = "FlightDateTimePicker";
            this.FlightDateTimePicker.Size = new System.Drawing.Size(203, 22);
            this.FlightDateTimePicker.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Flight Date";
            // 
            // FlightNoLbl
            // 
            this.FlightNoLbl.Location = new System.Drawing.Point(6, 134);
            this.FlightNoLbl.Name = "FlightNoLbl";
            this.FlightNoLbl.Size = new System.Drawing.Size(364, 13);
            this.FlightNoLbl.TabIndex = 17;
            this.FlightNoLbl.Text = "Flight Number";
            this.FlightNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlightNoTxt
            // 
            this.FlightNoTxt.BackColor = System.Drawing.Color.Gray;
            this.FlightNoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlightNoTxt.ForeColor = System.Drawing.Color.White;
            this.FlightNoTxt.Location = new System.Drawing.Point(117, 150);
            this.FlightNoTxt.Name = "FlightNoTxt";
            this.FlightNoTxt.Size = new System.Drawing.Size(143, 22);
            this.FlightNoTxt.TabIndex = 18;
            this.FlightNoTxt.TextChanged += new System.EventHandler(this.FlightNoTxt_TextChanged);
            // 
            // AirportCombo
            // 
            this.AirportCombo.BackColor = System.Drawing.Color.Gray;
            this.AirportCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AirportCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AirportCombo.ForeColor = System.Drawing.Color.White;
            this.AirportCombo.FormattingEnabled = true;
            this.AirportCombo.Location = new System.Drawing.Point(117, 100);
            this.AirportCombo.Name = "AirportCombo";
            this.AirportCombo.Size = new System.Drawing.Size(143, 21);
            this.AirportCombo.TabIndex = 16;
            // 
            // AirportLbl
            // 
            this.AirportLbl.AutoSize = true;
            this.AirportLbl.Location = new System.Drawing.Point(167, 84);
            this.AirportLbl.Name = "AirportLbl";
            this.AirportLbl.Size = new System.Drawing.Size(43, 13);
            this.AirportLbl.TabIndex = 15;
            this.AirportLbl.Text = "Airport";
            // 
            // AddShipmentBtn
            // 
            this.AddShipmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddShipmentBtn.ForeColor = System.Drawing.Color.Lime;
            this.AddShipmentBtn.Location = new System.Drawing.Point(289, 327);
            this.AddShipmentBtn.Name = "AddShipmentBtn";
            this.AddShipmentBtn.Size = new System.Drawing.Size(99, 33);
            this.AddShipmentBtn.TabIndex = 16;
            this.AddShipmentBtn.Text = "Add ✔";
            this.AddShipmentBtn.UseVisualStyleBackColor = true;
            this.AddShipmentBtn.Click += new System.EventHandler(this.AddShipmentBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 327);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 17;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // ShipNoStatus
            // 
            this.ShipNoStatus.AutoSize = true;
            this.ShipNoStatus.BackColor = System.Drawing.Color.Gray;
            this.ShipNoStatus.Location = new System.Drawing.Point(238, 53);
            this.ShipNoStatus.Name = "ShipNoStatus";
            this.ShipNoStatus.Size = new System.Drawing.Size(19, 13);
            this.ShipNoStatus.TabIndex = 22;
            this.ShipNoStatus.Text = "❌";
            this.ShipNoStatus.Visible = false;
            // 
            // FlightNoStatus
            // 
            this.FlightNoStatus.AutoSize = true;
            this.FlightNoStatus.BackColor = System.Drawing.Color.Gray;
            this.FlightNoStatus.Location = new System.Drawing.Point(238, 154);
            this.FlightNoStatus.Name = "FlightNoStatus";
            this.FlightNoStatus.Size = new System.Drawing.Size(19, 13);
            this.FlightNoStatus.TabIndex = 23;
            this.FlightNoStatus.Text = "❌";
            this.FlightNoStatus.Visible = false;
            // 
            // AddShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 375);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddShipmentBtn);
            this.Controls.Add(this.AddShipmentControlsGrpBx);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddShipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Shipment";
            this.Load += new System.EventHandler(this.AddShipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.AddShipmentControlsGrpBx.ResumeLayout(false);
            this.AddShipmentControlsGrpBx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label ShipmentNoLbl;
        private System.Windows.Forms.TextBox ShipmentNoTxt;
        private System.Windows.Forms.GroupBox AddShipmentControlsGrpBx;
        private System.Windows.Forms.ComboBox AirportCombo;
        private System.Windows.Forms.Label AirportLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FlightNoLbl;
        private System.Windows.Forms.TextBox FlightNoTxt;
        private System.Windows.Forms.DateTimePicker FlightDateTimePicker;
        private System.Windows.Forms.Button AddShipmentBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label FlightNoStatus;
        private System.Windows.Forms.Label ShipNoStatus;
    }
}