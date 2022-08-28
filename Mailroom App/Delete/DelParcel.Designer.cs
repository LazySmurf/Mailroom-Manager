namespace Mailroom_App.Delete
{
    partial class DelParcelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelParcelForm));
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DelParcelControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.SelectedPriceLbl = new System.Windows.Forms.Label();
            this.SelectedWeightLbl = new System.Windows.Forms.Label();
            this.SelectedDestinationLbl = new System.Windows.Forms.Label();
            this.SelectedRecipientLbl = new System.Windows.Forms.Label();
            this.SelectedParcelNoLbl = new System.Windows.Forms.Label();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.WeightLbl = new System.Windows.Forms.Label();
            this.DestinationLbl = new System.Windows.Forms.Label();
            this.RecipientLbl = new System.Windows.Forms.Label();
            this.ParcelNoLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DeleteParcelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.DelParcelControlsGrpBx.SuspendLayout();
            this.SuspendLayout();
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBox.Image")));
            this.MinimizeBox.Location = new System.Drawing.Point(29, 16);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(10, 10);
            this.MinimizeBox.TabIndex = 26;
            this.MinimizeBox.TabStop = false;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.CloseBox.Image = ((System.Drawing.Image)(resources.GetObject("CloseBox.Image")));
            this.CloseBox.Location = new System.Drawing.Point(13, 16);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(10, 10);
            this.CloseBox.TabIndex = 25;
            this.CloseBox.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(133, 13);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(134, 30);
            this.TitleLabel.TabIndex = 24;
            this.TitleLabel.Text = "Delete Parcel";
            // 
            // DelParcelControlsGrpBx
            // 
            this.DelParcelControlsGrpBx.Controls.Add(this.SelectedPriceLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.SelectedWeightLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.SelectedDestinationLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.SelectedRecipientLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.SelectedParcelNoLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.PriceLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.WeightLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.DestinationLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.RecipientLbl);
            this.DelParcelControlsGrpBx.Controls.Add(this.ParcelNoLbl);
            this.DelParcelControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.DelParcelControlsGrpBx.Location = new System.Drawing.Point(12, 61);
            this.DelParcelControlsGrpBx.Name = "DelParcelControlsGrpBx";
            this.DelParcelControlsGrpBx.Size = new System.Drawing.Size(376, 300);
            this.DelParcelControlsGrpBx.TabIndex = 27;
            this.DelParcelControlsGrpBx.TabStop = false;
            this.DelParcelControlsGrpBx.Text = "Parcel Details";
            // 
            // SelectedPriceLbl
            // 
            this.SelectedPriceLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedPriceLbl.Location = new System.Drawing.Point(6, 251);
            this.SelectedPriceLbl.Name = "SelectedPriceLbl";
            this.SelectedPriceLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedPriceLbl.TabIndex = 46;
            this.SelectedPriceLbl.Text = "€0.01";
            this.SelectedPriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedWeightLbl
            // 
            this.SelectedWeightLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedWeightLbl.Location = new System.Drawing.Point(6, 199);
            this.SelectedWeightLbl.Name = "SelectedWeightLbl";
            this.SelectedWeightLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedWeightLbl.TabIndex = 45;
            this.SelectedWeightLbl.Text = "0.001";
            this.SelectedWeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedDestinationLbl
            // 
            this.SelectedDestinationLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedDestinationLbl.Location = new System.Drawing.Point(6, 148);
            this.SelectedDestinationLbl.Name = "SelectedDestinationLbl";
            this.SelectedDestinationLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedDestinationLbl.TabIndex = 44;
            this.SelectedDestinationLbl.Text = "EE";
            this.SelectedDestinationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedRecipientLbl
            // 
            this.SelectedRecipientLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedRecipientLbl.Location = new System.Drawing.Point(6, 98);
            this.SelectedRecipientLbl.Name = "SelectedRecipientLbl";
            this.SelectedRecipientLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedRecipientLbl.TabIndex = 43;
            this.SelectedRecipientLbl.Text = "John Smith";
            this.SelectedRecipientLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectedParcelNoLbl
            // 
            this.SelectedParcelNoLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedParcelNoLbl.Location = new System.Drawing.Point(6, 47);
            this.SelectedParcelNoLbl.Name = "SelectedParcelNoLbl";
            this.SelectedParcelNoLbl.Size = new System.Drawing.Size(364, 23);
            this.SelectedParcelNoLbl.TabIndex = 32;
            this.SelectedParcelNoLbl.Text = "LLNNNNNNLL";
            this.SelectedParcelNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceLbl
            // 
            this.PriceLbl.Location = new System.Drawing.Point(6, 238);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(364, 13);
            this.PriceLbl.TabIndex = 42;
            this.PriceLbl.Text = "Price";
            this.PriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeightLbl
            // 
            this.WeightLbl.Location = new System.Drawing.Point(6, 186);
            this.WeightLbl.Name = "WeightLbl";
            this.WeightLbl.Size = new System.Drawing.Size(364, 13);
            this.WeightLbl.TabIndex = 36;
            this.WeightLbl.Text = "Weight";
            this.WeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DestinationLbl
            // 
            this.DestinationLbl.Location = new System.Drawing.Point(6, 135);
            this.DestinationLbl.Name = "DestinationLbl";
            this.DestinationLbl.Size = new System.Drawing.Size(364, 13);
            this.DestinationLbl.TabIndex = 34;
            this.DestinationLbl.Text = "Destination";
            this.DestinationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RecipientLbl
            // 
            this.RecipientLbl.Location = new System.Drawing.Point(6, 85);
            this.RecipientLbl.Name = "RecipientLbl";
            this.RecipientLbl.Size = new System.Drawing.Size(364, 13);
            this.RecipientLbl.TabIndex = 33;
            this.RecipientLbl.Text = "Recipient";
            this.RecipientLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParcelNoLbl
            // 
            this.ParcelNoLbl.Location = new System.Drawing.Point(6, 34);
            this.ParcelNoLbl.Name = "ParcelNoLbl";
            this.ParcelNoLbl.Size = new System.Drawing.Size(364, 13);
            this.ParcelNoLbl.TabIndex = 31;
            this.ParcelNoLbl.Text = "Parcel Number";
            this.ParcelNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 375);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 29;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteParcelBtn
            // 
            this.DeleteParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteParcelBtn.ForeColor = System.Drawing.Color.Lime;
            this.DeleteParcelBtn.Location = new System.Drawing.Point(289, 375);
            this.DeleteParcelBtn.Name = "DeleteParcelBtn";
            this.DeleteParcelBtn.Size = new System.Drawing.Size(99, 33);
            this.DeleteParcelBtn.TabIndex = 28;
            this.DeleteParcelBtn.Text = "Delete ✔";
            this.DeleteParcelBtn.UseVisualStyleBackColor = true;
            this.DeleteParcelBtn.Click += new System.EventHandler(this.DelParcelBtn_Click);
            // 
            // DelParcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 422);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.DelParcelControlsGrpBx);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DeleteParcelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelParcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Parcel";
            this.Load += new System.EventHandler(this.DelShipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.DelParcelControlsGrpBx.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.GroupBox DelParcelControlsGrpBx;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button DeleteParcelBtn;
        private System.Windows.Forms.Label PriceLbl;
        private System.Windows.Forms.Label WeightLbl;
        private System.Windows.Forms.Label DestinationLbl;
        private System.Windows.Forms.Label RecipientLbl;
        private System.Windows.Forms.Label ParcelNoLbl;
        private System.Windows.Forms.Label SelectedPriceLbl;
        private System.Windows.Forms.Label SelectedWeightLbl;
        private System.Windows.Forms.Label SelectedDestinationLbl;
        private System.Windows.Forms.Label SelectedRecipientLbl;
        private System.Windows.Forms.Label SelectedParcelNoLbl;
    }
}