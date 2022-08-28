namespace Mailroom_App
{
    partial class MailroomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailroomForm));
            this.ShipmentsListBox = new System.Windows.Forms.ListBox();
            this.ShipmentsGrpBx = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShipmentsRTB = new System.Windows.Forms.RichTextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LetterBagGrpBx = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LBagsRTB = new System.Windows.Forms.RichTextBox();
            this.LBagsListBox = new System.Windows.Forms.ListBox();
            this.ParcelGrpBx = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ParcelsRTB = new System.Windows.Forms.RichTextBox();
            this.ParcelsListBox = new System.Windows.Forms.ListBox();
            this.MinimizeBox = new System.Windows.Forms.PictureBox();
            this.CloseBox = new System.Windows.Forms.PictureBox();
            this.MailroomIcon = new System.Windows.Forms.PictureBox();
            this.TopmostCheckBx = new System.Windows.Forms.CheckBox();
            this.HelpBtn = new System.Windows.Forms.Button();
            this.deselectAllBtn = new System.Windows.Forms.Button();
            this.secretInfoBox = new System.Windows.Forms.PictureBox();
            this.updateServerBox = new System.Windows.Forms.PictureBox();
            this.EditShipmentsBtn = new System.Windows.Forms.Button();
            this.DeleteShipmentBtn = new System.Windows.Forms.Button();
            this.AddShipmentBtn = new System.Windows.Forms.Button();
            this.DeselectShipmentBtn = new System.Windows.Forms.Button();
            this.PBagsListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PBagsRTB = new System.Windows.Forms.RichTextBox();
            this.ParcelBagGrpBx = new System.Windows.Forms.GroupBox();
            this.DeselectPBagBtn = new System.Windows.Forms.Button();
            this.AddPBagBtn = new System.Windows.Forms.Button();
            this.EditPBagBtn = new System.Windows.Forms.Button();
            this.DeletePBagBtn = new System.Windows.Forms.Button();
            this.DeselectParcelBtn = new System.Windows.Forms.Button();
            this.AddParcelBtn = new System.Windows.Forms.Button();
            this.EditParcelBtn = new System.Windows.Forms.Button();
            this.DeleteParcelBtn = new System.Windows.Forms.Button();
            this.DeselectLBagBtn = new System.Windows.Forms.Button();
            this.AddLBagBtn = new System.Windows.Forms.Button();
            this.EditLBagBtn = new System.Windows.Forms.Button();
            this.DeleteLBagBtn = new System.Windows.Forms.Button();
            this.secretFizzBuzzBox = new System.Windows.Forms.PictureBox();
            this.ShipmentsGrpBx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LetterBagGrpBx.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ParcelGrpBx.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailroomIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretInfoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateServerBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.ParcelBagGrpBx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secretFizzBuzzBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ShipmentsListBox
            // 
            this.ShipmentsListBox.BackColor = System.Drawing.Color.Gray;
            this.ShipmentsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShipmentsListBox.ForeColor = System.Drawing.Color.White;
            this.ShipmentsListBox.FormattingEnabled = true;
            this.ShipmentsListBox.Location = new System.Drawing.Point(3, 25);
            this.ShipmentsListBox.Name = "ShipmentsListBox";
            this.ShipmentsListBox.Size = new System.Drawing.Size(332, 145);
            this.ShipmentsListBox.TabIndex = 0;
            this.ShipmentsListBox.SelectedIndexChanged += new System.EventHandler(this.ShipmentsListBox_SelectedIndexChanged);
            // 
            // ShipmentsGrpBx
            // 
            this.ShipmentsGrpBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShipmentsGrpBx.Controls.Add(this.groupBox1);
            this.ShipmentsGrpBx.Controls.Add(this.ShipmentsListBox);
            this.ShipmentsGrpBx.ForeColor = System.Drawing.Color.White;
            this.ShipmentsGrpBx.Location = new System.Drawing.Point(12, 34);
            this.ShipmentsGrpBx.Name = "ShipmentsGrpBx";
            this.ShipmentsGrpBx.Size = new System.Drawing.Size(682, 174);
            this.ShipmentsGrpBx.TabIndex = 1;
            this.ShipmentsGrpBx.TabStop = false;
            this.ShipmentsGrpBx.Text = "Shipments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShipmentsRTB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(341, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // ShipmentsRTB
            // 
            this.ShipmentsRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ShipmentsRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShipmentsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShipmentsRTB.ForeColor = System.Drawing.Color.White;
            this.ShipmentsRTB.Location = new System.Drawing.Point(3, 18);
            this.ShipmentsRTB.Name = "ShipmentsRTB";
            this.ShipmentsRTB.ReadOnly = true;
            this.ShipmentsRTB.Size = new System.Drawing.Size(332, 132);
            this.ShipmentsRTB.TabIndex = 0;
            this.ShipmentsRTB.Text = "";
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(277, 2);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(191, 30);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Mailroom Manager";
            // 
            // LetterBagGrpBx
            // 
            this.LetterBagGrpBx.Controls.Add(this.groupBox2);
            this.LetterBagGrpBx.Controls.Add(this.LBagsListBox);
            this.LetterBagGrpBx.ForeColor = System.Drawing.Color.White;
            this.LetterBagGrpBx.Location = new System.Drawing.Point(12, 239);
            this.LetterBagGrpBx.Name = "LetterBagGrpBx";
            this.LetterBagGrpBx.Size = new System.Drawing.Size(337, 174);
            this.LetterBagGrpBx.TabIndex = 3;
            this.LetterBagGrpBx.TabStop = false;
            this.LetterBagGrpBx.Text = "Letter Bags";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LBagsRTB);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(166, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 153);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // LBagsRTB
            // 
            this.LBagsRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LBagsRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBagsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBagsRTB.ForeColor = System.Drawing.Color.White;
            this.LBagsRTB.Location = new System.Drawing.Point(3, 18);
            this.LBagsRTB.Name = "LBagsRTB";
            this.LBagsRTB.ReadOnly = true;
            this.LBagsRTB.Size = new System.Drawing.Size(162, 132);
            this.LBagsRTB.TabIndex = 0;
            this.LBagsRTB.Text = "";
            // 
            // LBagsListBox
            // 
            this.LBagsListBox.BackColor = System.Drawing.Color.Gray;
            this.LBagsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBagsListBox.ForeColor = System.Drawing.Color.White;
            this.LBagsListBox.FormattingEnabled = true;
            this.LBagsListBox.Location = new System.Drawing.Point(3, 25);
            this.LBagsListBox.Name = "LBagsListBox";
            this.LBagsListBox.Size = new System.Drawing.Size(157, 145);
            this.LBagsListBox.TabIndex = 0;
            this.LBagsListBox.SelectedIndexChanged += new System.EventHandler(this.LBagsListBox_SelectedIndexChanged);
            // 
            // ParcelGrpBx
            // 
            this.ParcelGrpBx.Controls.Add(this.groupBox4);
            this.ParcelGrpBx.Controls.Add(this.ParcelsListBox);
            this.ParcelGrpBx.ForeColor = System.Drawing.Color.White;
            this.ParcelGrpBx.Location = new System.Drawing.Point(12, 445);
            this.ParcelGrpBx.Name = "ParcelGrpBx";
            this.ParcelGrpBx.Size = new System.Drawing.Size(682, 174);
            this.ParcelGrpBx.TabIndex = 2;
            this.ParcelGrpBx.TabStop = false;
            this.ParcelGrpBx.Text = "Parcels";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ParcelsRTB);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(341, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 153);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // ParcelsRTB
            // 
            this.ParcelsRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ParcelsRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ParcelsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParcelsRTB.ForeColor = System.Drawing.Color.White;
            this.ParcelsRTB.Location = new System.Drawing.Point(3, 18);
            this.ParcelsRTB.Name = "ParcelsRTB";
            this.ParcelsRTB.ReadOnly = true;
            this.ParcelsRTB.Size = new System.Drawing.Size(332, 132);
            this.ParcelsRTB.TabIndex = 0;
            this.ParcelsRTB.Text = "";
            // 
            // ParcelsListBox
            // 
            this.ParcelsListBox.BackColor = System.Drawing.Color.Gray;
            this.ParcelsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ParcelsListBox.ForeColor = System.Drawing.Color.White;
            this.ParcelsListBox.FormattingEnabled = true;
            this.ParcelsListBox.Location = new System.Drawing.Point(3, 26);
            this.ParcelsListBox.Name = "ParcelsListBox";
            this.ParcelsListBox.Size = new System.Drawing.Size(332, 145);
            this.ParcelsListBox.TabIndex = 0;
            this.ParcelsListBox.SelectedIndexChanged += new System.EventHandler(this.ParcelsListBox_SelectedIndexChanged);
            // 
            // MinimizeBox
            // 
            this.MinimizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(189)))), ((int)(((byte)(68)))));
            this.MinimizeBox.Image = ((System.Drawing.Image)(resources.GetObject("MinimizeBox.Image")));
            this.MinimizeBox.Location = new System.Drawing.Point(26, 7);
            this.MinimizeBox.Name = "MinimizeBox";
            this.MinimizeBox.Size = new System.Drawing.Size(10, 10);
            this.MinimizeBox.TabIndex = 10;
            this.MinimizeBox.TabStop = false;
            // 
            // CloseBox
            // 
            this.CloseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(96)))), ((int)(((byte)(92)))));
            this.CloseBox.Image = ((System.Drawing.Image)(resources.GetObject("CloseBox.Image")));
            this.CloseBox.Location = new System.Drawing.Point(10, 7);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(10, 10);
            this.CloseBox.TabIndex = 9;
            this.CloseBox.TabStop = false;
            // 
            // MailroomIcon
            // 
            this.MailroomIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MailroomIcon.BackgroundImage")));
            this.MailroomIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MailroomIcon.Location = new System.Drawing.Point(254, 6);
            this.MailroomIcon.Name = "MailroomIcon";
            this.MailroomIcon.Size = new System.Drawing.Size(25, 25);
            this.MailroomIcon.TabIndex = 11;
            this.MailroomIcon.TabStop = false;
            // 
            // TopmostCheckBx
            // 
            this.TopmostCheckBx.AutoSize = true;
            this.TopmostCheckBx.Location = new System.Drawing.Point(15, 636);
            this.TopmostCheckBx.Name = "TopmostCheckBx";
            this.TopmostCheckBx.Size = new System.Drawing.Size(102, 17);
            this.TopmostCheckBx.TabIndex = 20;
            this.TopmostCheckBx.Text = "Always On Top";
            this.TopmostCheckBx.UseVisualStyleBackColor = true;
            this.TopmostCheckBx.CheckedChanged += new System.EventHandler(this.TopmostCheckBx_CheckedChanged);
            // 
            // HelpBtn
            // 
            this.HelpBtn.BackColor = System.Drawing.Color.Gray;
            this.HelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpBtn.Location = new System.Drawing.Point(665, 629);
            this.HelpBtn.Name = "HelpBtn";
            this.HelpBtn.Size = new System.Drawing.Size(26, 29);
            this.HelpBtn.TabIndex = 19;
            this.HelpBtn.Text = "❔";
            this.HelpBtn.UseVisualStyleBackColor = false;
            this.HelpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // deselectAllBtn
            // 
            this.deselectAllBtn.BackColor = System.Drawing.Color.Gray;
            this.deselectAllBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deselectAllBtn.Location = new System.Drawing.Point(300, 629);
            this.deselectAllBtn.Name = "deselectAllBtn";
            this.deselectAllBtn.Size = new System.Drawing.Size(107, 29);
            this.deselectAllBtn.TabIndex = 18;
            this.deselectAllBtn.Text = "Deselect All";
            this.deselectAllBtn.UseVisualStyleBackColor = false;
            this.deselectAllBtn.Visible = false;
            this.deselectAllBtn.Click += new System.EventHandler(this.deselectAllBtn_Click);
            // 
            // secretInfoBox
            // 
            this.secretInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.secretInfoBox.BackColor = System.Drawing.Color.Transparent;
            this.secretInfoBox.Location = new System.Drawing.Point(697, 657);
            this.secretInfoBox.Name = "secretInfoBox";
            this.secretInfoBox.Size = new System.Drawing.Size(10, 10);
            this.secretInfoBox.TabIndex = 17;
            this.secretInfoBox.TabStop = false;
            this.secretInfoBox.Click += new System.EventHandler(this.secretInfoBox_Click);
            // 
            // updateServerBox
            // 
            this.updateServerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(202)))), ((int)(((byte)(78)))));
            this.updateServerBox.Image = ((System.Drawing.Image)(resources.GetObject("updateServerBox.Image")));
            this.updateServerBox.Location = new System.Drawing.Point(688, 7);
            this.updateServerBox.Name = "updateServerBox";
            this.updateServerBox.Size = new System.Drawing.Size(10, 10);
            this.updateServerBox.TabIndex = 18;
            this.updateServerBox.TabStop = false;
            // 
            // EditShipmentsBtn
            // 
            this.EditShipmentsBtn.BackColor = System.Drawing.Color.Gray;
            this.EditShipmentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditShipmentsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(26)))));
            this.EditShipmentsBtn.Location = new System.Drawing.Point(627, 29);
            this.EditShipmentsBtn.Name = "EditShipmentsBtn";
            this.EditShipmentsBtn.Size = new System.Drawing.Size(24, 24);
            this.EditShipmentsBtn.TabIndex = 28;
            this.EditShipmentsBtn.Text = "✎";
            this.EditShipmentsBtn.UseVisualStyleBackColor = false;
            this.EditShipmentsBtn.Visible = false;
            this.EditShipmentsBtn.Click += new System.EventHandler(this.EditShipmentsBtn_Click);
            // 
            // DeleteShipmentBtn
            // 
            this.DeleteShipmentBtn.BackColor = System.Drawing.Color.Gray;
            this.DeleteShipmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteShipmentBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteShipmentBtn.Location = new System.Drawing.Point(597, 29);
            this.DeleteShipmentBtn.Name = "DeleteShipmentBtn";
            this.DeleteShipmentBtn.Size = new System.Drawing.Size(24, 24);
            this.DeleteShipmentBtn.TabIndex = 27;
            this.DeleteShipmentBtn.Text = "✘";
            this.DeleteShipmentBtn.UseVisualStyleBackColor = false;
            this.DeleteShipmentBtn.Visible = false;
            this.DeleteShipmentBtn.Click += new System.EventHandler(this.DeleteShipmentBtn_Click);
            // 
            // AddShipmentBtn
            // 
            this.AddShipmentBtn.BackColor = System.Drawing.Color.Gray;
            this.AddShipmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddShipmentBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddShipmentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(215)))), ((int)(((byte)(40)))));
            this.AddShipmentBtn.Location = new System.Drawing.Point(657, 29);
            this.AddShipmentBtn.Name = "AddShipmentBtn";
            this.AddShipmentBtn.Size = new System.Drawing.Size(24, 24);
            this.AddShipmentBtn.TabIndex = 29;
            this.AddShipmentBtn.Text = "➕";
            this.AddShipmentBtn.UseVisualStyleBackColor = false;
            this.AddShipmentBtn.Visible = false;
            this.AddShipmentBtn.Click += new System.EventHandler(this.AddShipmentBtn_Click);
            // 
            // DeselectShipmentBtn
            // 
            this.DeselectShipmentBtn.BackColor = System.Drawing.Color.Gray;
            this.DeselectShipmentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectShipmentBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectShipmentBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.DeselectShipmentBtn.Location = new System.Drawing.Point(567, 29);
            this.DeselectShipmentBtn.Name = "DeselectShipmentBtn";
            this.DeselectShipmentBtn.Size = new System.Drawing.Size(24, 24);
            this.DeselectShipmentBtn.TabIndex = 30;
            this.DeselectShipmentBtn.Text = "⌘";
            this.DeselectShipmentBtn.UseVisualStyleBackColor = false;
            this.DeselectShipmentBtn.Visible = false;
            this.DeselectShipmentBtn.Click += new System.EventHandler(this.DeselectShipmentBtn_Click);
            // 
            // PBagsListBox
            // 
            this.PBagsListBox.BackColor = System.Drawing.Color.Gray;
            this.PBagsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBagsListBox.ForeColor = System.Drawing.Color.White;
            this.PBagsListBox.FormattingEnabled = true;
            this.PBagsListBox.Location = new System.Drawing.Point(3, 25);
            this.PBagsListBox.Name = "PBagsListBox";
            this.PBagsListBox.Size = new System.Drawing.Size(157, 145);
            this.PBagsListBox.TabIndex = 0;
            this.PBagsListBox.SelectedIndexChanged += new System.EventHandler(this.PBagsListBox_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PBagsRTB);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(165, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(169, 153);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details";
            // 
            // PBagsRTB
            // 
            this.PBagsRTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PBagsRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PBagsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBagsRTB.ForeColor = System.Drawing.Color.White;
            this.PBagsRTB.Location = new System.Drawing.Point(3, 18);
            this.PBagsRTB.Name = "PBagsRTB";
            this.PBagsRTB.ReadOnly = true;
            this.PBagsRTB.Size = new System.Drawing.Size(163, 132);
            this.PBagsRTB.TabIndex = 0;
            this.PBagsRTB.Text = "";
            // 
            // ParcelBagGrpBx
            // 
            this.ParcelBagGrpBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParcelBagGrpBx.Controls.Add(this.groupBox3);
            this.ParcelBagGrpBx.Controls.Add(this.PBagsListBox);
            this.ParcelBagGrpBx.ForeColor = System.Drawing.Color.White;
            this.ParcelBagGrpBx.Location = new System.Drawing.Point(357, 239);
            this.ParcelBagGrpBx.Name = "ParcelBagGrpBx";
            this.ParcelBagGrpBx.Size = new System.Drawing.Size(337, 174);
            this.ParcelBagGrpBx.TabIndex = 4;
            this.ParcelBagGrpBx.TabStop = false;
            this.ParcelBagGrpBx.Text = "Parcel Bags";
            // 
            // DeselectPBagBtn
            // 
            this.DeselectPBagBtn.BackColor = System.Drawing.Color.Gray;
            this.DeselectPBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectPBagBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectPBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.DeselectPBagBtn.Location = new System.Drawing.Point(567, 234);
            this.DeselectPBagBtn.Name = "DeselectPBagBtn";
            this.DeselectPBagBtn.Size = new System.Drawing.Size(24, 24);
            this.DeselectPBagBtn.TabIndex = 34;
            this.DeselectPBagBtn.Text = "⌘";
            this.DeselectPBagBtn.UseVisualStyleBackColor = false;
            this.DeselectPBagBtn.Visible = false;
            this.DeselectPBagBtn.Click += new System.EventHandler(this.DeselectPBagBtn_Click);
            // 
            // AddPBagBtn
            // 
            this.AddPBagBtn.BackColor = System.Drawing.Color.Gray;
            this.AddPBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPBagBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(215)))), ((int)(((byte)(40)))));
            this.AddPBagBtn.Location = new System.Drawing.Point(657, 234);
            this.AddPBagBtn.Name = "AddPBagBtn";
            this.AddPBagBtn.Size = new System.Drawing.Size(24, 24);
            this.AddPBagBtn.TabIndex = 33;
            this.AddPBagBtn.Text = "➕";
            this.AddPBagBtn.UseVisualStyleBackColor = false;
            this.AddPBagBtn.Visible = false;
            this.AddPBagBtn.Click += new System.EventHandler(this.AddPBagBtn_Click);
            // 
            // EditPBagBtn
            // 
            this.EditPBagBtn.BackColor = System.Drawing.Color.Gray;
            this.EditPBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditPBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(26)))));
            this.EditPBagBtn.Location = new System.Drawing.Point(627, 234);
            this.EditPBagBtn.Name = "EditPBagBtn";
            this.EditPBagBtn.Size = new System.Drawing.Size(24, 24);
            this.EditPBagBtn.TabIndex = 32;
            this.EditPBagBtn.Text = "✎";
            this.EditPBagBtn.UseVisualStyleBackColor = false;
            this.EditPBagBtn.Visible = false;
            // 
            // DeletePBagBtn
            // 
            this.DeletePBagBtn.BackColor = System.Drawing.Color.Gray;
            this.DeletePBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeletePBagBtn.ForeColor = System.Drawing.Color.Red;
            this.DeletePBagBtn.Location = new System.Drawing.Point(597, 234);
            this.DeletePBagBtn.Name = "DeletePBagBtn";
            this.DeletePBagBtn.Size = new System.Drawing.Size(24, 24);
            this.DeletePBagBtn.TabIndex = 31;
            this.DeletePBagBtn.Text = "✘";
            this.DeletePBagBtn.UseVisualStyleBackColor = false;
            this.DeletePBagBtn.Visible = false;
            this.DeletePBagBtn.Click += new System.EventHandler(this.DeletePBagBtn_Click);
            // 
            // DeselectParcelBtn
            // 
            this.DeselectParcelBtn.BackColor = System.Drawing.Color.Gray;
            this.DeselectParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectParcelBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectParcelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.DeselectParcelBtn.Location = new System.Drawing.Point(567, 440);
            this.DeselectParcelBtn.Name = "DeselectParcelBtn";
            this.DeselectParcelBtn.Size = new System.Drawing.Size(24, 24);
            this.DeselectParcelBtn.TabIndex = 38;
            this.DeselectParcelBtn.Text = "⌘";
            this.DeselectParcelBtn.UseVisualStyleBackColor = false;
            this.DeselectParcelBtn.Visible = false;
            this.DeselectParcelBtn.Click += new System.EventHandler(this.DeselectParcelBtn_Click);
            // 
            // AddParcelBtn
            // 
            this.AddParcelBtn.BackColor = System.Drawing.Color.Gray;
            this.AddParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddParcelBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddParcelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(215)))), ((int)(((byte)(40)))));
            this.AddParcelBtn.Location = new System.Drawing.Point(657, 440);
            this.AddParcelBtn.Name = "AddParcelBtn";
            this.AddParcelBtn.Size = new System.Drawing.Size(24, 24);
            this.AddParcelBtn.TabIndex = 37;
            this.AddParcelBtn.Text = "➕";
            this.AddParcelBtn.UseVisualStyleBackColor = false;
            this.AddParcelBtn.Visible = false;
            this.AddParcelBtn.Click += new System.EventHandler(this.AddParcelBtn_Click);
            // 
            // EditParcelBtn
            // 
            this.EditParcelBtn.BackColor = System.Drawing.Color.Gray;
            this.EditParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditParcelBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(26)))));
            this.EditParcelBtn.Location = new System.Drawing.Point(627, 440);
            this.EditParcelBtn.Name = "EditParcelBtn";
            this.EditParcelBtn.Size = new System.Drawing.Size(24, 24);
            this.EditParcelBtn.TabIndex = 36;
            this.EditParcelBtn.Text = "✎";
            this.EditParcelBtn.UseVisualStyleBackColor = false;
            this.EditParcelBtn.Visible = false;
            this.EditParcelBtn.Click += new System.EventHandler(this.EditParcelBtn_Click);
            // 
            // DeleteParcelBtn
            // 
            this.DeleteParcelBtn.BackColor = System.Drawing.Color.Gray;
            this.DeleteParcelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteParcelBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteParcelBtn.Location = new System.Drawing.Point(597, 440);
            this.DeleteParcelBtn.Name = "DeleteParcelBtn";
            this.DeleteParcelBtn.Size = new System.Drawing.Size(24, 24);
            this.DeleteParcelBtn.TabIndex = 35;
            this.DeleteParcelBtn.Text = "✘";
            this.DeleteParcelBtn.UseVisualStyleBackColor = false;
            this.DeleteParcelBtn.Visible = false;
            this.DeleteParcelBtn.Click += new System.EventHandler(this.DeleteParcelBtn_Click);
            // 
            // DeselectLBagBtn
            // 
            this.DeselectLBagBtn.BackColor = System.Drawing.Color.Gray;
            this.DeselectLBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeselectLBagBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectLBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(216)))), ((int)(((byte)(228)))));
            this.DeselectLBagBtn.Location = new System.Drawing.Point(223, 233);
            this.DeselectLBagBtn.Name = "DeselectLBagBtn";
            this.DeselectLBagBtn.Size = new System.Drawing.Size(24, 24);
            this.DeselectLBagBtn.TabIndex = 42;
            this.DeselectLBagBtn.Text = "⌘";
            this.DeselectLBagBtn.UseVisualStyleBackColor = false;
            this.DeselectLBagBtn.Visible = false;
            this.DeselectLBagBtn.Click += new System.EventHandler(this.DeselectLBagBtn_Click);
            // 
            // AddLBagBtn
            // 
            this.AddLBagBtn.BackColor = System.Drawing.Color.Gray;
            this.AddLBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddLBagBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddLBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(215)))), ((int)(((byte)(40)))));
            this.AddLBagBtn.Location = new System.Drawing.Point(313, 233);
            this.AddLBagBtn.Name = "AddLBagBtn";
            this.AddLBagBtn.Size = new System.Drawing.Size(24, 24);
            this.AddLBagBtn.TabIndex = 41;
            this.AddLBagBtn.Text = "➕";
            this.AddLBagBtn.UseVisualStyleBackColor = false;
            this.AddLBagBtn.Visible = false;
            this.AddLBagBtn.Click += new System.EventHandler(this.AddLBagBtn_Click);
            // 
            // EditLBagBtn
            // 
            this.EditLBagBtn.BackColor = System.Drawing.Color.Gray;
            this.EditLBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditLBagBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(177)))), ((int)(((byte)(26)))));
            this.EditLBagBtn.Location = new System.Drawing.Point(283, 233);
            this.EditLBagBtn.Name = "EditLBagBtn";
            this.EditLBagBtn.Size = new System.Drawing.Size(24, 24);
            this.EditLBagBtn.TabIndex = 40;
            this.EditLBagBtn.Text = "✎";
            this.EditLBagBtn.UseVisualStyleBackColor = false;
            this.EditLBagBtn.Visible = false;
            // 
            // DeleteLBagBtn
            // 
            this.DeleteLBagBtn.BackColor = System.Drawing.Color.Gray;
            this.DeleteLBagBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteLBagBtn.ForeColor = System.Drawing.Color.Red;
            this.DeleteLBagBtn.Location = new System.Drawing.Point(253, 233);
            this.DeleteLBagBtn.Name = "DeleteLBagBtn";
            this.DeleteLBagBtn.Size = new System.Drawing.Size(24, 24);
            this.DeleteLBagBtn.TabIndex = 39;
            this.DeleteLBagBtn.Text = "✘";
            this.DeleteLBagBtn.UseVisualStyleBackColor = false;
            this.DeleteLBagBtn.Visible = false;
            this.DeleteLBagBtn.Click += new System.EventHandler(this.DeleteLBagBtn_Click);
            // 
            // secretFizzBuzzBox
            // 
            this.secretFizzBuzzBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.secretFizzBuzzBox.BackColor = System.Drawing.Color.Transparent;
            this.secretFizzBuzzBox.Location = new System.Drawing.Point(-1, 657);
            this.secretFizzBuzzBox.Name = "secretFizzBuzzBox";
            this.secretFizzBuzzBox.Size = new System.Drawing.Size(10, 10);
            this.secretFizzBuzzBox.TabIndex = 43;
            this.secretFizzBuzzBox.TabStop = false;
            this.secretFizzBuzzBox.Click += new System.EventHandler(this.secretFizzBuzzBox_Click);
            // 
            // MailroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(706, 666);
            this.Controls.Add(this.secretFizzBuzzBox);
            this.Controls.Add(this.DeletePBagBtn);
            this.Controls.Add(this.DeleteLBagBtn);
            this.Controls.Add(this.DeselectLBagBtn);
            this.Controls.Add(this.AddLBagBtn);
            this.Controls.Add(this.EditLBagBtn);
            this.Controls.Add(this.DeselectParcelBtn);
            this.Controls.Add(this.AddParcelBtn);
            this.Controls.Add(this.EditParcelBtn);
            this.Controls.Add(this.DeleteParcelBtn);
            this.Controls.Add(this.DeselectPBagBtn);
            this.Controls.Add(this.AddPBagBtn);
            this.Controls.Add(this.EditPBagBtn);
            this.Controls.Add(this.TopmostCheckBx);
            this.Controls.Add(this.HelpBtn);
            this.Controls.Add(this.deselectAllBtn);
            this.Controls.Add(this.DeselectShipmentBtn);
            this.Controls.Add(this.AddShipmentBtn);
            this.Controls.Add(this.EditShipmentsBtn);
            this.Controls.Add(this.DeleteShipmentBtn);
            this.Controls.Add(this.updateServerBox);
            this.Controls.Add(this.secretInfoBox);
            this.Controls.Add(this.MailroomIcon);
            this.Controls.Add(this.MinimizeBox);
            this.Controls.Add(this.CloseBox);
            this.Controls.Add(this.ParcelGrpBx);
            this.Controls.Add(this.ParcelBagGrpBx);
            this.Controls.Add(this.LetterBagGrpBx);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.ShipmentsGrpBx);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MailroomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mailroom Manager";
            this.Load += new System.EventHandler(this.MailroomForm_Load);
            this.ShipmentsGrpBx.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.LetterBagGrpBx.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ParcelGrpBx.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailroomIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secretInfoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateServerBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ParcelBagGrpBx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secretFizzBuzzBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ShipmentsListBox;
        private System.Windows.Forms.GroupBox ShipmentsGrpBx;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.GroupBox LetterBagGrpBx;
        private System.Windows.Forms.ListBox LBagsListBox;
        private System.Windows.Forms.GroupBox ParcelGrpBx;
        private System.Windows.Forms.ListBox ParcelsListBox;
        internal System.Windows.Forms.PictureBox MinimizeBox;
        internal System.Windows.Forms.PictureBox CloseBox;
        private System.Windows.Forms.PictureBox MailroomIcon;
        private System.Windows.Forms.Button deselectAllBtn;
        private System.Windows.Forms.PictureBox secretInfoBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox ShipmentsRTB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox LBagsRTB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox ParcelsRTB;
        private System.Windows.Forms.Button HelpBtn;
        private System.Windows.Forms.CheckBox TopmostCheckBx;
        internal System.Windows.Forms.PictureBox updateServerBox;
        private System.Windows.Forms.Button EditShipmentsBtn;
        private System.Windows.Forms.Button DeleteShipmentBtn;
        private System.Windows.Forms.Button AddShipmentBtn;
        private System.Windows.Forms.Button DeselectShipmentBtn;
        private System.Windows.Forms.ListBox PBagsListBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox PBagsRTB;
        private System.Windows.Forms.GroupBox ParcelBagGrpBx;
        private System.Windows.Forms.Button DeselectPBagBtn;
        private System.Windows.Forms.Button AddPBagBtn;
        private System.Windows.Forms.Button EditPBagBtn;
        private System.Windows.Forms.Button DeletePBagBtn;
        private System.Windows.Forms.Button DeselectParcelBtn;
        private System.Windows.Forms.Button AddParcelBtn;
        private System.Windows.Forms.Button EditParcelBtn;
        private System.Windows.Forms.Button DeleteParcelBtn;
        private System.Windows.Forms.Button DeselectLBagBtn;
        private System.Windows.Forms.Button AddLBagBtn;
        private System.Windows.Forms.Button EditLBagBtn;
        private System.Windows.Forms.Button DeleteLBagBtn;
        private System.Windows.Forms.PictureBox secretFizzBuzzBox;
    }
}

