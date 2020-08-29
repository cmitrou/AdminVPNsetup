namespace NewBridgeClient
{
    partial class SetupProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupProfileForm));
            this.SetupPanel1 = new System.Windows.Forms.Panel();
            this.LocalBridgeChangeLabel = new System.Windows.Forms.RadioButton();
            this.ProfileNameBox = new System.Windows.Forms.TextBox();
            this.ProFileNameLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BridgeInterfaceGpouBox = new System.Windows.Forms.GroupBox();
            this.LocalBridgeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ProfilePanelLabel = new System.Windows.Forms.Label();
            this.ServerGroupBox = new System.Windows.Forms.GroupBox();
            this.ServerNameBox = new System.Windows.Forms.TextBox();
            this.ServerHubLabel = new System.Windows.Forms.Label();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.ServerHubBox = new System.Windows.Forms.TextBox();
            this.ServerPortLabel = new System.Windows.Forms.Label();
            this.ServerPortBox = new System.Windows.Forms.TextBox();
            this.UserDataBox = new System.Windows.Forms.GroupBox();
            this.UserPassBox = new System.Windows.Forms.TextBox();
            this.UserLoginPassword = new System.Windows.Forms.Label();
            this.UserLoginNameBox = new System.Windows.Forms.TextBox();
            this.UserLoginNameLabel = new System.Windows.Forms.Label();
            this.SetupPanel1.SuspendLayout();
            this.BridgeInterfaceGpouBox.SuspendLayout();
            this.ServerGroupBox.SuspendLayout();
            this.UserDataBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetupPanel1
            // 
            this.SetupPanel1.BackColor = System.Drawing.Color.Aquamarine;
            this.SetupPanel1.Controls.Add(this.LocalBridgeChangeLabel);
            this.SetupPanel1.Controls.Add(this.ProfileNameBox);
            this.SetupPanel1.Controls.Add(this.ProFileNameLabel);
            this.SetupPanel1.Controls.Add(this.SaveButton);
            this.SetupPanel1.Controls.Add(this.BridgeInterfaceGpouBox);
            this.SetupPanel1.Controls.Add(this.ProfilePanelLabel);
            this.SetupPanel1.Controls.Add(this.ServerGroupBox);
            this.SetupPanel1.Controls.Add(this.UserDataBox);
            this.SetupPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.SetupPanel1.Location = new System.Drawing.Point(1, 1);
            this.SetupPanel1.Name = "SetupPanel1";
            this.SetupPanel1.Size = new System.Drawing.Size(481, 366);
            this.SetupPanel1.TabIndex = 9;
            // 
            // LocalBridgeChangeLabel
            // 
            this.LocalBridgeChangeLabel.AutoSize = true;
            this.LocalBridgeChangeLabel.Location = new System.Drawing.Point(16, 235);
            this.LocalBridgeChangeLabel.Name = "LocalBridgeChangeLabel";
            this.LocalBridgeChangeLabel.Size = new System.Drawing.Size(140, 17);
            this.LocalBridgeChangeLabel.TabIndex = 15;
            this.LocalBridgeChangeLabel.TabStop = true;
            this.LocalBridgeChangeLabel.Text = "Bridge Interface Change";
            this.LocalBridgeChangeLabel.UseVisualStyleBackColor = true;
            this.LocalBridgeChangeLabel.CheckedChanged += new System.EventHandler(this.LocalBridgeChangeLabel_CheckedChanged);
            // 
            // ProfileNameBox
            // 
            this.ProfileNameBox.Location = new System.Drawing.Point(267, 334);
            this.ProfileNameBox.Name = "ProfileNameBox";
            this.ProfileNameBox.Size = new System.Drawing.Size(120, 20);
            this.ProfileNameBox.TabIndex = 14;
            this.ProfileNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ProfileNameBox.TextChanged += new System.EventHandler(this.ProfileNameBox_TextChanged);
            // 
            // ProFileNameLabel
            // 
            this.ProFileNameLabel.AutoSize = true;
            this.ProFileNameLabel.Location = new System.Drawing.Point(182, 337);
            this.ProFileNameLabel.Name = "ProFileNameLabel";
            this.ProFileNameLabel.Size = new System.Drawing.Size(79, 13);
            this.ProFileNameLabel.TabIndex = 13;
            this.ProFileNameLabel.Text = "1. Profile Name";
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Honeydew;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(60, 332);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(104, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BridgeInterfaceGpouBox
            // 
            this.BridgeInterfaceGpouBox.Controls.Add(this.LocalBridgeLabel);
            this.BridgeInterfaceGpouBox.Controls.Add(this.comboBox1);
            this.BridgeInterfaceGpouBox.Location = new System.Drawing.Point(11, 252);
            this.BridgeInterfaceGpouBox.Name = "BridgeInterfaceGpouBox";
            this.BridgeInterfaceGpouBox.Size = new System.Drawing.Size(460, 74);
            this.BridgeInterfaceGpouBox.TabIndex = 11;
            this.BridgeInterfaceGpouBox.TabStop = false;
            this.BridgeInterfaceGpouBox.Text = "Interface";
            // 
            // LocalBridgeLabel
            // 
            this.LocalBridgeLabel.AutoSize = true;
            this.LocalBridgeLabel.Location = new System.Drawing.Point(118, 13);
            this.LocalBridgeLabel.Name = "LocalBridgeLabel";
            this.LocalBridgeLabel.Size = new System.Drawing.Size(82, 13);
            this.LocalBridgeLabel.TabIndex = 9;
            this.LocalBridgeLabel.Text = "Bridge Interface";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(399, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // ProfilePanelLabel
            // 
            this.ProfilePanelLabel.AutoSize = true;
            this.ProfilePanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfilePanelLabel.Location = new System.Drawing.Point(78, 19);
            this.ProfilePanelLabel.Name = "ProfilePanelLabel";
            this.ProfilePanelLabel.Size = new System.Drawing.Size(298, 55);
            this.ProfilePanelLabel.TabIndex = 8;
            this.ProfilePanelLabel.Text = "Profile Setup";
            // 
            // ServerGroupBox
            // 
            this.ServerGroupBox.Controls.Add(this.ServerNameBox);
            this.ServerGroupBox.Controls.Add(this.ServerHubLabel);
            this.ServerGroupBox.Controls.Add(this.ServerLabel);
            this.ServerGroupBox.Controls.Add(this.ServerHubBox);
            this.ServerGroupBox.Controls.Add(this.ServerPortLabel);
            this.ServerGroupBox.Controls.Add(this.ServerPortBox);
            this.ServerGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerGroupBox.Location = new System.Drawing.Point(60, 77);
            this.ServerGroupBox.Name = "ServerGroupBox";
            this.ServerGroupBox.Size = new System.Drawing.Size(342, 82);
            this.ServerGroupBox.TabIndex = 6;
            this.ServerGroupBox.TabStop = false;
            this.ServerGroupBox.Tag = "notchanged";
            this.ServerGroupBox.Text = "2. Server Data";
            // 
            // ServerNameBox
            // 
            this.ServerNameBox.Location = new System.Drawing.Point(6, 42);
            this.ServerNameBox.Name = "ServerNameBox";
            this.ServerNameBox.Size = new System.Drawing.Size(179, 20);
            this.ServerNameBox.TabIndex = 0;
            this.ServerNameBox.TextChanged += new System.EventHandler(this.ServerNameBox_TextChanged);
            // 
            // ServerHubLabel
            // 
            this.ServerHubLabel.AutoSize = true;
            this.ServerHubLabel.Location = new System.Drawing.Point(267, 26);
            this.ServerHubLabel.Name = "ServerHubLabel";
            this.ServerHubLabel.Size = new System.Drawing.Size(27, 13);
            this.ServerHubLabel.TabIndex = 5;
            this.ServerHubLabel.Text = "Hub";
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(58, 26);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(38, 13);
            this.ServerLabel.TabIndex = 3;
            this.ServerLabel.Text = "Server";
            // 
            // ServerHubBox
            // 
            this.ServerHubBox.Location = new System.Drawing.Point(254, 42);
            this.ServerHubBox.Name = "ServerHubBox";
            this.ServerHubBox.Size = new System.Drawing.Size(61, 20);
            this.ServerHubBox.TabIndex = 2;
            this.ServerHubBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServerHubBox.TextChanged += new System.EventHandler(this.ServerHubBox_TextChanged);
            // 
            // ServerPortLabel
            // 
            this.ServerPortLabel.AutoSize = true;
            this.ServerPortLabel.Location = new System.Drawing.Point(188, 26);
            this.ServerPortLabel.Name = "ServerPortLabel";
            this.ServerPortLabel.Size = new System.Drawing.Size(60, 13);
            this.ServerPortLabel.TabIndex = 4;
            this.ServerPortLabel.Text = "Server Port";
            // 
            // ServerPortBox
            // 
            this.ServerPortBox.Location = new System.Drawing.Point(191, 42);
            this.ServerPortBox.Name = "ServerPortBox";
            this.ServerPortBox.Size = new System.Drawing.Size(57, 20);
            this.ServerPortBox.TabIndex = 1;
            this.ServerPortBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ServerPortBox.TextChanged += new System.EventHandler(this.ServerPortBox_TextChanged);
            // 
            // UserDataBox
            // 
            this.UserDataBox.Controls.Add(this.UserPassBox);
            this.UserDataBox.Controls.Add(this.UserLoginPassword);
            this.UserDataBox.Controls.Add(this.UserLoginNameBox);
            this.UserDataBox.Controls.Add(this.UserLoginNameLabel);
            this.UserDataBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.UserDataBox.Location = new System.Drawing.Point(60, 159);
            this.UserDataBox.Name = "UserDataBox";
            this.UserDataBox.Size = new System.Drawing.Size(245, 70);
            this.UserDataBox.TabIndex = 7;
            this.UserDataBox.TabStop = false;
            this.UserDataBox.Tag = "false";
            this.UserDataBox.Text = "3. User Login";
            // 
            // UserPassBox
            // 
            this.UserPassBox.Location = new System.Drawing.Point(118, 35);
            this.UserPassBox.Name = "UserPassBox";
            this.UserPassBox.Size = new System.Drawing.Size(100, 20);
            this.UserPassBox.TabIndex = 3;
            this.UserPassBox.TextChanged += new System.EventHandler(this.UserPasswordBox_TextChanged);
            // 
            // UserLoginPassword
            // 
            this.UserLoginPassword.AutoSize = true;
            this.UserLoginPassword.Location = new System.Drawing.Point(134, 19);
            this.UserLoginPassword.Name = "UserLoginPassword";
            this.UserLoginPassword.Size = new System.Drawing.Size(0, 13);
            this.UserLoginPassword.TabIndex = 2;
            // 
            // UserLoginNameBox
            // 
            this.UserLoginNameBox.Location = new System.Drawing.Point(3, 35);
            this.UserLoginNameBox.Name = "UserLoginNameBox";
            this.UserLoginNameBox.Size = new System.Drawing.Size(100, 20);
            this.UserLoginNameBox.TabIndex = 1;
            this.UserLoginNameBox.TextChanged += new System.EventHandler(this.UserLoginNameBox_TextChanged);
            // 
            // UserLoginNameLabel
            // 
            this.UserLoginNameLabel.AutoSize = true;
            this.UserLoginNameLabel.Location = new System.Drawing.Point(23, 19);
            this.UserLoginNameLabel.Name = "UserLoginNameLabel";
            this.UserLoginNameLabel.Size = new System.Drawing.Size(60, 13);
            this.UserLoginNameLabel.TabIndex = 0;
            this.UserLoginNameLabel.Text = "User Name";
            // 
            // SetupProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 367);
            this.Controls.Add(this.SetupPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetupProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetupProfileForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupProfileForm_FormClosing);
            this.Load += new System.EventHandler(this.SetupProfileForm_Load);
            this.SetupPanel1.ResumeLayout(false);
            this.SetupPanel1.PerformLayout();
            this.BridgeInterfaceGpouBox.ResumeLayout(false);
            this.BridgeInterfaceGpouBox.PerformLayout();
            this.ServerGroupBox.ResumeLayout(false);
            this.ServerGroupBox.PerformLayout();
            this.UserDataBox.ResumeLayout(false);
            this.UserDataBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SetupPanel1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox BridgeInterfaceGpouBox;
        private System.Windows.Forms.Label LocalBridgeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox ServerGroupBox;
        private System.Windows.Forms.TextBox ServerNameBox;
        private System.Windows.Forms.Label ServerHubLabel;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.TextBox ServerHubBox;
        private System.Windows.Forms.Label ServerPortLabel;
        private System.Windows.Forms.TextBox ServerPortBox;
        private System.Windows.Forms.GroupBox UserDataBox;
        private System.Windows.Forms.Label UserLoginPassword;
        private System.Windows.Forms.TextBox UserLoginNameBox;
        private System.Windows.Forms.Label UserLoginNameLabel;
        public System.Windows.Forms.Label ProfilePanelLabel;
        public System.Windows.Forms.TextBox ProfileNameBox;
        private System.Windows.Forms.Label ProFileNameLabel;
        private System.Windows.Forms.RadioButton LocalBridgeChangeLabel;
        private System.Windows.Forms.TextBox UserPassBox;
    }
}