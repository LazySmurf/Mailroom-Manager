namespace Mailroom_App.Add
{
    partial class AddPBagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPBagForm));
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.BagNoLbl = new System.Windows.Forms.Label();
            this.BagNoTxt = new System.Windows.Forms.TextBox();
            this.AddBagControlsGrpBx = new System.Windows.Forms.GroupBox();
            this.BagNoStatus = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AddBagBtn = new System.Windows.Forms.Button();
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
            this.TitleLabel.Location = new System.Drawing.Point(124, 10);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(153, 30);
            this.TitleLabel.TabIndex = 18;
            this.TitleLabel.Text = "Add Parcel Bag";
            // 
            // BagNoLbl
            // 
            this.BagNoLbl.Location = new System.Drawing.Point(6, 33);
            this.BagNoLbl.Name = "BagNoLbl";
            this.BagNoLbl.Size = new System.Drawing.Size(364, 13);
            this.BagNoLbl.TabIndex = 13;
            this.BagNoLbl.Text = "Bag Number";
            this.BagNoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BagNoTxt
            // 
            this.BagNoTxt.BackColor = System.Drawing.Color.Gray;
            this.BagNoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BagNoTxt.ForeColor = System.Drawing.Color.White;
            this.BagNoTxt.Location = new System.Drawing.Point(106, 49);
            this.BagNoTxt.Name = "BagNoTxt";
            this.BagNoTxt.Size = new System.Drawing.Size(164, 22);
            this.BagNoTxt.TabIndex = 14;
            this.BagNoTxt.TextChanged += new System.EventHandler(this.BagNoTxt_TextChanged);
            // 
            // AddBagControlsGrpBx
            // 
            this.AddBagControlsGrpBx.Controls.Add(this.BagNoStatus);
            this.AddBagControlsGrpBx.Controls.Add(this.BagNoLbl);
            this.AddBagControlsGrpBx.Controls.Add(this.BagNoTxt);
            this.AddBagControlsGrpBx.ForeColor = System.Drawing.Color.White;
            this.AddBagControlsGrpBx.Location = new System.Drawing.Point(12, 58);
            this.AddBagControlsGrpBx.Name = "AddBagControlsGrpBx";
            this.AddBagControlsGrpBx.Size = new System.Drawing.Size(376, 106);
            this.AddBagControlsGrpBx.TabIndex = 21;
            this.AddBagControlsGrpBx.TabStop = false;
            this.AddBagControlsGrpBx.Text = "Bag Details";
            // 
            // BagNoStatus
            // 
            this.BagNoStatus.AutoSize = true;
            this.BagNoStatus.BackColor = System.Drawing.Color.Gray;
            this.BagNoStatus.Location = new System.Drawing.Point(249, 53);
            this.BagNoStatus.Name = "BagNoStatus";
            this.BagNoStatus.Size = new System.Drawing.Size(19, 13);
            this.BagNoStatus.TabIndex = 22;
            this.BagNoStatus.Text = "❌";
            this.BagNoStatus.Visible = false;
            // 
            // CancelBtn
            // 
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.LightCoral;
            this.CancelBtn.Location = new System.Drawing.Point(12, 185);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 33);
            this.CancelBtn.TabIndex = 23;
            this.CancelBtn.Text = "✖ Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // AddBagBtn
            // 
            this.AddBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBagBtn.ForeColor = System.Drawing.Color.Lime;
            this.AddBagBtn.Location = new System.Drawing.Point(289, 185);
            this.AddBagBtn.Name = "AddBagBtn";
            this.AddBagBtn.Size = new System.Drawing.Size(99, 33);
            this.AddBagBtn.TabIndex = 22;
            this.AddBagBtn.Text = "Add ✔";
            this.AddBagBtn.UseVisualStyleBackColor = true;
            this.AddBagBtn.Click += new System.EventHandler(this.AddBagBtn_Click);
            // 
            // AddPBagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(400, 239);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AddBagControlsGrpBx);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddBagBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPBagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Parcel Bag";
            this.Load += new System.EventHandler(this.AddPBag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            this.AddBagControlsGrpBx.ResumeLayout(false);
            this.AddBagControlsGrpBx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label BagNoLbl;
        private System.Windows.Forms.TextBox BagNoTxt;
        private System.Windows.Forms.GroupBox AddBagControlsGrpBx;
        private System.Windows.Forms.Label BagNoStatus;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button AddBagBtn;
    }
}