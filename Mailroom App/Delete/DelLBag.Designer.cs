namespace Mailroom_App.Delete
{
    partial class DelLBagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelLBagForm));
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.BagNoTitleLbl = new System.Windows.Forms.Label();
            this.AddBagControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.WeightLbl = new System.Windows.Forms.Label();
            this.WeightTitleLbl = new System.Windows.Forms.Label();
            this.LetterCountLbl = new System.Windows.Forms.Label();
            this.LetterCountTitleLbl = new System.Windows.Forms.Label();
            this.BagNoLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.DelBagBtn = new System.Windows.Forms.Button();
            this.PriceLbl = new System.Windows.Forms.Label();
            this.PriceTitleLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            this.AddBagControlsGrpBx.SuspendLayout();
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
            this.TitleLabel.Location = new System.Drawing.Point(114, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(173, 30);
            this.TitleLabel.TabIndex = 18;
            this.TitleLabel.Text = "Delete Letter Bag";
            // 
            // BagNoTitleLbl
            // 
            this.BagNoTitleLbl.Location = new System.Drawing.Point(6, 33);
            this.BagNoTitleLbl.Name = "BagNoTitleLbl";
            this.BagNoTitleLbl.Size = new System.Drawing.Size(364, 13);
            this.BagNoTitleLbl.TabIndex = 13;
            this.BagNoTitleLbl.Text = "Bag Number";
            this.BagNoTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddBagControlsGrpBx
            // 
            this.AddBagControlsGrpBx.Controls.Add(this.PriceLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.PriceTitleLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.WeightLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.WeightTitleLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.LetterCountLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.LetterCountTitleLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.BagNoLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.BagNoTitleLbl);
            this.AddBagControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.AddBagControlsGrpBx.Location = new System.Drawing.Point(12, 58);
            this.AddBagControlsGrpBx.Name = "AddBagControlsGrpBx";
            this.AddBagControlsGrpBx.Size = new System.Drawing.Size(376, 235);
            this.AddBagControlsGrpBx.TabIndex = 21;
            this.AddBagControlsGrpBx.TabStop = false;
            this.AddBagControlsGrpBx.Text = "Bag Details";
            // 
            // WeightLbl
            // 
            this.WeightLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLbl.Location = new System.Drawing.Point(6, 138);
            this.WeightLbl.Name = "WeightLbl";
            this.WeightLbl.Size = new System.Drawing.Size(364, 23);
            this.WeightLbl.TabIndex = 37;
            this.WeightLbl.Text = "9999999999";
            this.WeightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeightTitleLbl
            // 
            this.WeightTitleLbl.Location = new System.Drawing.Point(6, 125);
            this.WeightTitleLbl.Name = "WeightTitleLbl";
            this.WeightTitleLbl.Size = new System.Drawing.Size(364, 13);
            this.WeightTitleLbl.TabIndex = 36;
            this.WeightTitleLbl.Text = "Weight";
            this.WeightTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LetterCountLbl
            // 
            this.LetterCountLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterCountLbl.Location = new System.Drawing.Point(6, 92);
            this.LetterCountLbl.Name = "LetterCountLbl";
            this.LetterCountLbl.Size = new System.Drawing.Size(364, 23);
            this.LetterCountLbl.TabIndex = 35;
            this.LetterCountLbl.Text = "9999999999";
            this.LetterCountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LetterCountTitleLbl
            // 
            this.LetterCountTitleLbl.Location = new System.Drawing.Point(6, 79);
            this.LetterCountTitleLbl.Name = "LetterCountTitleLbl";
            this.LetterCountTitleLbl.Size = new System.Drawing.Size(364, 13);
            this.LetterCountTitleLbl.TabIndex = 34;
            this.LetterCountTitleLbl.Text = "# of Letters";
            this.LetterCountTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BagNoLbl
            // 
            this.BagNoLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BagNoLbl.Location = new System.Drawing.Point(6, 46);
            this.BagNoLbl.Name = "BagNoLbl";
            this.BagNoLbl.Size = new System.Drawing.Size(364, 23);
            this.BagNoLbl.TabIndex = 33;
            this.BagNoLbl.Text = "XXXXXXXXXXXXXXX";
            this.BagNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 309);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 23;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // DelBagBtn
            // 
            this.DelBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelBagBtn.ForeColor = System.Drawing.Color.Lime;
            this.DelBagBtn.Location = new System.Drawing.Point(289, 309);
            this.DelBagBtn.Name = "DelBagBtn";
            this.DelBagBtn.Size = new System.Drawing.Size(99, 33);
            this.DelBagBtn.TabIndex = 22;
            this.DelBagBtn.Text = "Add ✔";
            this.DelBagBtn.UseVisualStyleBackColor = true;
            this.DelBagBtn.Click += new System.EventHandler(this.DelBagBtn_Click);
            // 
            // PriceLbl
            // 
            this.PriceLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceLbl.Location = new System.Drawing.Point(6, 184);
            this.PriceLbl.Name = "PriceLbl";
            this.PriceLbl.Size = new System.Drawing.Size(364, 23);
            this.PriceLbl.TabIndex = 39;
            this.PriceLbl.Text = "9999999999";
            this.PriceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PriceTitleLbl
            // 
            this.PriceTitleLbl.Location = new System.Drawing.Point(6, 171);
            this.PriceTitleLbl.Name = "PriceTitleLbl";
            this.PriceTitleLbl.Size = new System.Drawing.Size(364, 13);
            this.PriceTitleLbl.TabIndex = 38;
            this.PriceTitleLbl.Text = "Price";
            this.PriceTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DelLBagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 363);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AddBagControlsGrpBx);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DelBagBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelLBagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Letter Bag";
            this.Load += new System.EventHandler(this.DelLBag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.AddBagControlsGrpBx.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label BagNoTitleLbl;
        private System.Windows.Forms.GroupBox AddBagControlsGrpBx;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button DelBagBtn;
        private System.Windows.Forms.Label BagNoLbl;
        private System.Windows.Forms.Label WeightLbl;
        private System.Windows.Forms.Label WeightTitleLbl;
        private System.Windows.Forms.Label LetterCountLbl;
        private System.Windows.Forms.Label LetterCountTitleLbl;
        private System.Windows.Forms.Label PriceLbl;
        private System.Windows.Forms.Label PriceTitleLbl;
    }
}