namespace Mailroom_App.Edit
{
    partial class EditShipmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditShipmentForm));
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ShipmentNoLbl = new System.Windows.Forms.Label();
            this.EditShipmentControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.IsFinalizedChkBx = new System.Windows.Forms.CheckBox();
            this.FlightNoStatus = new System.Windows.Forms.Label();
            this.FlightDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FlightDateLabel = new System.Windows.Forms.Label();
            this.FlightNoLbl = new System.Windows.Forms.Label();
            this.FlightNoTxt = new System.Windows.Forms.TextBox();
            this.AirportCombo = new System.Windows.Forms.ComboBox();
            this.AirportLbl = new System.Windows.Forms.Label();
            this.SelectedShipNoLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.EditShipmentBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.EditShipmentControlsGrpBx.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBox.Image")));
            this.MinimizeBox.Location = new System.Drawing.Point(29, 13);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(10, 10);
            this.MinimizeBox.TabIndex = 20;
            this.MinimizeBox.TabStop = false;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.CloseBox.Image = ((System.Drawing.Image)(resources.GetObject("CloseBox.Image")));
            this.CloseBox.Location = new System.Drawing.Point(13, 13);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(10, 10);
            this.CloseBox.TabIndex = 19;
            this.CloseBox.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(129, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(142, 30);
            this.TitleLabel.TabIndex = 18;
            this.TitleLabel.Text = "Edit Shipment";
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
            // EditShipmentControlsGrpBx
            // 
            this.EditShipmentControlsGrpBx.Controls.Add(this.IsFinalizedChkBx);
            this.EditShipmentControlsGrpBx.Controls.Add(this.FlightNoStatus);
            this.EditShipmentControlsGrpBx.Controls.Add(this.FlightDateTimePicker);
            this.EditShipmentControlsGrpBx.Controls.Add(this.FlightDateLabel);
            this.EditShipmentControlsGrpBx.Controls.Add(this.FlightNoLbl);
            this.EditShipmentControlsGrpBx.Controls.Add(this.FlightNoTxt);
            this.EditShipmentControlsGrpBx.Controls.Add(this.AirportCombo);
            this.EditShipmentControlsGrpBx.Controls.Add(this.AirportLbl);
            this.EditShipmentControlsGrpBx.Controls.Add(this.ShipmentNoLbl);
            this.EditShipmentControlsGrpBx.Controls.Add(this.SelectedShipNoLbl);
            this.EditShipmentControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.EditShipmentControlsGrpBx.Location = new System.Drawing.Point(12, 58);
            this.EditShipmentControlsGrpBx.Name = "EditShipmentControlsGrpBx";
            this.EditShipmentControlsGrpBx.Size = new System.Drawing.Size(376, 279);
            this.EditShipmentControlsGrpBx.TabIndex = 21;
            this.EditShipmentControlsGrpBx.TabStop = false;
            this.EditShipmentControlsGrpBx.Text = "Shipment Details";
            // 
            // IsFinalizedChkBx
            // 
            this.IsFinalizedChkBx.AutoCheck = false;
            this.IsFinalizedChkBx.AutoSize = true;
            this.IsFinalizedChkBx.Location = new System.Drawing.Point(141, 239);
            this.IsFinalizedChkBx.Name = "IsFinalizedChkBx";
            this.IsFinalizedChkBx.Size = new System.Drawing.Size(94, 17);
            this.IsFinalizedChkBx.TabIndex = 24;
            this.IsFinalizedChkBx.Text = "Not Finalized";
            this.IsFinalizedChkBx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsFinalizedChkBx.UseVisualStyleBackColor = true;
            this.IsFinalizedChkBx.CheckedChanged += new System.EventHandler(this.IsFinalizedChkBx_CheckedChanged);
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
            // FlightDateTimePicker
            // 
            this.FlightDateTimePicker.CustomFormat = "h:mm tt ddd MMM d, yyyy";
            this.FlightDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FlightDateTimePicker.Location = new System.Drawing.Point(87, 201);
            this.FlightDateTimePicker.Name = "FlightDateTimePicker";
            this.FlightDateTimePicker.Size = new System.Drawing.Size(203, 22);
            this.FlightDateTimePicker.TabIndex = 21;
            // 
            // FlightDateLabel
            // 
            this.FlightDateLabel.AutoSize = true;
            this.FlightDateLabel.Location = new System.Drawing.Point(156, 185);
            this.FlightDateLabel.Name = "FlightDateLabel";
            this.FlightDateLabel.Size = new System.Drawing.Size(64, 13);
            this.FlightDateLabel.TabIndex = 20;
            this.FlightDateLabel.Text = "Flight Date";
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
            // SelectedShipNoLbl
            // 
            this.SelectedShipNoLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedShipNoLbl.Location = new System.Drawing.Point(6, 46);
            this.SelectedShipNoLbl.Name = "SelectedShipNoLbl";
            this.SelectedShipNoLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedShipNoLbl.TabIndex = 25;
            this.SelectedShipNoLbl.Text = "XXX-XXXXXX";
            this.SelectedShipNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 352);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 23;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // EditShipmentBtn
            // 
            this.EditShipmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditShipmentBtn.ForeColor = System.Drawing.Color.Lime;
            this.EditShipmentBtn.Location = new System.Drawing.Point(289, 352);
            this.EditShipmentBtn.Name = "EditShipmentBtn";
            this.EditShipmentBtn.Size = new System.Drawing.Size(99, 33);
            this.EditShipmentBtn.TabIndex = 22;
            this.EditShipmentBtn.Text = "Edit ✔";
            this.EditShipmentBtn.UseVisualStyleBackColor = true;
            this.EditShipmentBtn.Click += new System.EventHandler(this.EditShipmentBtn_Click);
            // 
            // EditShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.EditShipmentControlsGrpBx);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.EditShipmentBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditShipmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Shipment";
            this.Load += new System.EventHandler(this.EditShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.EditShipmentControlsGrpBx.ResumeLayout(false);
            this.EditShipmentControlsGrpBx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ShipmentNoLbl;
        private System.Windows.Forms.GroupBox EditShipmentControlsGrpBx;
        private System.Windows.Forms.CheckBox IsFinalizedChkBx;
        private System.Windows.Forms.Label FlightNoStatus;
        private System.Windows.Forms.DateTimePicker FlightDateTimePicker;
        private System.Windows.Forms.Label FlightDateLabel;
        private System.Windows.Forms.Label FlightNoLbl;
        private System.Windows.Forms.TextBox FlightNoTxt;
        private System.Windows.Forms.ComboBox AirportCombo;
        private System.Windows.Forms.Label AirportLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button EditShipmentBtn;
        private System.Windows.Forms.Label SelectedShipNoLbl;
    }
}