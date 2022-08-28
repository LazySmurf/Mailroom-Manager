namespace Mailroom_App.Add
{
    partial class AddParcelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddParcelForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.ParcelNoLbl = new System.Windows.Forms.Label();
            this.ParcelNoTxt = new System.Windows.Forms.TextBox();
            this.AddParcelControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.PriceNumUD = new System.Windows.Forms.NumericUpDown();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.WeightNumUD = new System.Windows.Forms.NumericUpDown();
            this.RecipientStatusLbl = new System.Windows.Forms.Label();
            this.RecipientTxt = new System.Windows.Forms.TextBox();
            this.DestinationStatusLbl = new System.Windows.Forms.Label();
            this.ParcelNoStatusLbl = new System.Windows.Forms.Label();
            this.WeightLbl = new System.Windows.Forms.Label();
            this.DestinationLbl = new System.Windows.Forms.Label();
            this.DestinationTxt = new System.Windows.Forms.TextBox();
            this.RecipientLbl = new System.Windows.Forms.Label();
            this.AddParcelBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.AddParcelControlsGrpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumUD)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(144, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(112, 30);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Add Parcel";
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
            // ParcelNoLbl
            // 
            this.ParcelNoLbl.Location = new System.Drawing.Point(6, 30);
            this.ParcelNoLbl.Name = "ParcelNoLbl";
            this.ParcelNoLbl.Size = new System.Drawing.Size(364, 13);
            this.ParcelNoLbl.TabIndex = 13;
            this.ParcelNoLbl.Text = "Parcel Number";
            this.ParcelNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParcelNoTxt
            // 
            this.ParcelNoTxt.BackColor = System.Drawing.Color.Gray;
            this.ParcelNoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParcelNoTxt.ForeColor = System.Drawing.Color.White;
            this.ParcelNoTxt.Location = new System.Drawing.Point(117, 46);
            this.ParcelNoTxt.Name = "ParcelNoTxt";
            this.ParcelNoTxt.Size = new System.Drawing.Size(143, 22);
            this.ParcelNoTxt.TabIndex = 14;
            this.ParcelNoTxt.TextChanged += new System.EventHandler(this.ParcelNoTxt_TextChanged);
            // 
            // AddParcelControlsGrpBx
            // 
            this.AddParcelControlsGrpBx.Controls.Add(this.PriceNumUD);
            this.AddParcelControlsGrpBx.Controls.Add(this.PriceLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.WeightNumUD);
            this.AddParcelControlsGrpBx.Controls.Add(this.RecipientStatusLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.RecipientTxt);
            this.AddParcelControlsGrpBx.Controls.Add(this.DestinationStatusLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.ParcelNoStatusLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.WeightLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.DestinationLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.DestinationTxt);
            this.AddParcelControlsGrpBx.Controls.Add(this.RecipientLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.ParcelNoLbl);
            this.AddParcelControlsGrpBx.Controls.Add(this.ParcelNoTxt);
            this.AddParcelControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.AddParcelControlsGrpBx.Location = new System.Drawing.Point(12, 54);
            this.AddParcelControlsGrpBx.Name = "AddParcelControlsGrpBx";
            this.AddParcelControlsGrpBx.Size = new System.Drawing.Size(376, 300);
            this.AddParcelControlsGrpBx.TabIndex = 15;
            this.AddParcelControlsGrpBx.TabStop = false;
            this.AddParcelControlsGrpBx.Text = "Parcel Details";
            // 
            // PriceNumUD
            // 
            this.PriceNumUD.BackColor = System.Drawing.Color.Gray;
            this.PriceNumUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriceNumUD.DecimalPlaces = 2;
            this.PriceNumUD.ForeColor = System.Drawing.Color.White;
            this.PriceNumUD.Location = new System.Drawing.Point(117, 250);
            this.PriceNumUD.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.PriceNumUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PriceNumUD.Name = "PriceNumUD";
            this.PriceNumUD.Size = new System.Drawing.Size(143, 22);
            this.PriceNumUD.TabIndex = 30;
            this.PriceNumUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceNumUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // PriceLbl
            // 
            this.PriceLbl.Location = new System.Drawing.Point(6, 234);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(364, 13);
            this.PriceLbl.TabIndex = 29;
            this.PriceLbl.Text = "Price";
            this.PriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeightNumUD
            // 
            this.WeightNumUD.BackColor = System.Drawing.Color.Gray;
            this.WeightNumUD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WeightNumUD.DecimalPlaces = 3;
            this.WeightNumUD.ForeColor = System.Drawing.Color.White;
            this.WeightNumUD.Location = new System.Drawing.Point(117, 198);
            this.WeightNumUD.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.WeightNumUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.WeightNumUD.Name = "WeightNumUD";
            this.WeightNumUD.Size = new System.Drawing.Size(143, 22);
            this.WeightNumUD.TabIndex = 28;
            this.WeightNumUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WeightNumUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // RecipientStatusLbl
            // 
            this.RecipientStatusLbl.AutoSize = true;
            this.RecipientStatusLbl.BackColor = System.Drawing.Color.Gray;
            this.RecipientStatusLbl.Location = new System.Drawing.Point(238, 101);
            this.RecipientStatusLbl.Name = "RecipientStatusLbl";
            this.RecipientStatusLbl.Size = new System.Drawing.Size(19, 13);
            this.RecipientStatusLbl.TabIndex = 25;
            this.RecipientStatusLbl.Text = "❌";
            this.RecipientStatusLbl.Visible = false;
            // 
            // RecipientTxt
            // 
            this.RecipientTxt.BackColor = System.Drawing.Color.Gray;
            this.RecipientTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecipientTxt.ForeColor = System.Drawing.Color.White;
            this.RecipientTxt.Location = new System.Drawing.Point(117, 97);
            this.RecipientTxt.MaxLength = 100;
            this.RecipientTxt.Name = "RecipientTxt";
            this.RecipientTxt.Size = new System.Drawing.Size(143, 22);
            this.RecipientTxt.TabIndex = 24;
            this.RecipientTxt.TextChanged += new System.EventHandler(this.RecipientTxt_TextChanged);
            // 
            // DestinationStatusLbl
            // 
            this.DestinationStatusLbl.AutoSize = true;
            this.DestinationStatusLbl.BackColor = System.Drawing.Color.Gray;
            this.DestinationStatusLbl.Location = new System.Drawing.Point(238, 151);
            this.DestinationStatusLbl.Name = "DestinationStatusLbl";
            this.DestinationStatusLbl.Size = new System.Drawing.Size(19, 13);
            this.DestinationStatusLbl.TabIndex = 23;
            this.DestinationStatusLbl.Text = "❌";
            this.DestinationStatusLbl.Visible = false;
            // 
            // ParcelNoStatusLbl
            // 
            this.ParcelNoStatusLbl.AutoSize = true;
            this.ParcelNoStatusLbl.BackColor = System.Drawing.Color.Gray;
            this.ParcelNoStatusLbl.Location = new System.Drawing.Point(238, 50);
            this.ParcelNoStatusLbl.Name = "ParcelNoStatusLbl";
            this.ParcelNoStatusLbl.Size = new System.Drawing.Size(19, 13);
            this.ParcelNoStatusLbl.TabIndex = 22;
            this.ParcelNoStatusLbl.Text = "❌";
            this.ParcelNoStatusLbl.Visible = false;
            // 
            // WeightLbl
            // 
            this.WeightLbl.Location = new System.Drawing.Point(6, 182);
            this.WeightLbl.Name = "WeightLbl";
            this.WeightLbl.Size = new System.Drawing.Size(364, 13);
            this.WeightLbl.TabIndex = 20;
            this.WeightLbl.Text = "Weight";
            this.WeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DestinationLbl
            // 
            this.DestinationLbl.Location = new System.Drawing.Point(6, 131);
            this.DestinationLbl.Name = "DestinationLbl";
            this.DestinationLbl.Size = new System.Drawing.Size(364, 13);
            this.DestinationLbl.TabIndex = 17;
            this.DestinationLbl.Text = "Destination";
            this.DestinationLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DestinationTxt
            // 
            this.DestinationTxt.BackColor = System.Drawing.Color.Gray;
            this.DestinationTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DestinationTxt.ForeColor = System.Drawing.Color.White;
            this.DestinationTxt.Location = new System.Drawing.Point(117, 147);
            this.DestinationTxt.Name = "DestinationTxt";
            this.DestinationTxt.Size = new System.Drawing.Size(143, 22);
            this.DestinationTxt.TabIndex = 18;
            this.DestinationTxt.TextChanged += new System.EventHandler(this.DestinationTxt_TextChanged);
            // 
            // RecipientLbl
            // 
            this.RecipientLbl.Location = new System.Drawing.Point(6, 81);
            this.RecipientLbl.Name = "RecipientLbl";
            this.RecipientLbl.Size = new System.Drawing.Size(364, 13);
            this.RecipientLbl.TabIndex = 15;
            this.RecipientLbl.Text = "Recipient";
            this.RecipientLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddParcelBtn
            // 
            this.AddParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddParcelBtn.ForeColor = System.Drawing.Color.Lime;
            this.AddParcelBtn.Location = new System.Drawing.Point(289, 371);
            this.AddParcelBtn.Name = "AddParcelBtn";
            this.AddParcelBtn.Size = new System.Drawing.Size(99, 33);
            this.AddParcelBtn.TabIndex = 16;
            this.AddParcelBtn.Text = "Add ✔";
            this.AddParcelBtn.UseVisualStyleBackColor = true;
            this.AddParcelBtn.Click += new System.EventHandler(this.AddParcelBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 371);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 17;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // AddParcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 422);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddParcelBtn);
            this.Controls.Add(this.AddParcelControlsGrpBx);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddParcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Parcel";
            this.Load += new System.EventHandler(this.AddShipmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.AddParcelControlsGrpBx.ResumeLayout(false);
            this.AddParcelControlsGrpBx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriceNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label ParcelNoLbl;
        private System.Windows.Forms.TextBox ParcelNoTxt;
        private System.Windows.Forms.GroupBox AddParcelControlsGrpBx;
        private System.Windows.Forms.Label RecipientLbl;
        private System.Windows.Forms.Label WeightLbl;
        private System.Windows.Forms.Label DestinationLbl;
        private System.Windows.Forms.TextBox DestinationTxt;
        private System.Windows.Forms.Button AddParcelBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label DestinationStatusLbl;
        private System.Windows.Forms.Label ParcelNoStatusLbl;
        private System.Windows.Forms.Label RecipientStatusLbl;
        private System.Windows.Forms.TextBox RecipientTxt;
        private System.Windows.Forms.NumericUpDown WeightNumUD;
        private System.Windows.Forms.NumericUpDown PriceNumUD;
        private System.Windows.Forms.Label PriceLbl;
    }
}