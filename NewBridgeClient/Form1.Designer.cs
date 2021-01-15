namespace NewBridgeClient
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.ServerNameBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.sevpnbridge = new System.ServiceProcess.ServiceController();
            this.dataSet1 = new System.Data.DataSet();
            this.ProfileNameBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectButoon = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.inter_ip = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NetworkConnection = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameBox
            // 
            this.UserNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameBox.Location = new System.Drawing.Point(22, 264);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.ReadOnly = true;
            this.UserNameBox.Size = new System.Drawing.Size(110, 20);
            this.UserNameBox.TabIndex = 1;
            this.UserNameBox.TabStop = false;
            // 
            // ServerNameBox
            // 
            this.ServerNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameBox.Location = new System.Drawing.Point(148, 264);
            this.ServerNameBox.Name = "ServerNameBox";
            this.ServerNameBox.ReadOnly = true;
            this.ServerNameBox.Size = new System.Drawing.Size(198, 20);
            this.ServerNameBox.TabIndex = 2;
            this.ServerNameBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupProfileToolStripMenuItem,
            this.editProfileToolStripMenuItem,
            this.deleteProfileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // setupProfileToolStripMenuItem
            // 
            this.setupProfileToolStripMenuItem.Name = "setupProfileToolStripMenuItem";
            this.setupProfileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setupProfileToolStripMenuItem.Text = "Add Profile";
            this.setupProfileToolStripMenuItem.Click += new System.EventHandler(this.setupProgileToolStripMenuItem_Click);
            // 
            // editProfileToolStripMenuItem
            // 
            this.editProfileToolStripMenuItem.Name = "editProfileToolStripMenuItem";
            this.editProfileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editProfileToolStripMenuItem.Text = "Edit Profile";
            this.editProfileToolStripMenuItem.Click += new System.EventHandler(this.editProfileToolStripMenuItem_Click);
            // 
            // deleteProfileToolStripMenuItem
            // 
            this.deleteProfileToolStripMenuItem.Name = "deleteProfileToolStripMenuItem";
            this.deleteProfileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteProfileToolStripMenuItem.Text = "Delete Profile";
            this.deleteProfileToolStripMenuItem.Click += new System.EventHandler(this.deleteProfileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(160, 23);
            this.toolStripTextBox1.Text = "Bridge Client for VPN Server.";
            // 
            // sevpnbridge
            // 
            this.sevpnbridge.ServiceName = "sevpnbridge";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // ProfileNameBox
            // 
            this.ProfileNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileNameBox.FormattingEnabled = true;
            this.ProfileNameBox.Location = new System.Drawing.Point(22, 208);
            this.ProfileNameBox.Name = "ProfileNameBox";
            this.ProfileNameBox.Size = new System.Drawing.Size(110, 21);
            this.ProfileNameBox.TabIndex = 1;
            this.ProfileNameBox.SelectedIndexChanged += new System.EventHandler(this.ProfileNameBox_SelectedIndexChanged);
            this.ProfileNameBox.Click += new System.EventHandler(this.ProfileNameBox_Enter);
            this.ProfileNameBox.Enter += new System.EventHandler(this.ProfileNameBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "1. Select Profile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "User  Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "VPN Server to Connect";
            // 
            // ConnectButoon
            // 
            this.ConnectButoon.Location = new System.Drawing.Point(22, 315);
            this.ConnectButoon.Name = "ConnectButoon";
            this.ConnectButoon.Size = new System.Drawing.Size(75, 23);
            this.ConnectButoon.TabIndex = 8;
            this.ConnectButoon.Text = "Connect";
            this.ConnectButoon.UseVisualStyleBackColor = true;
            this.ConnectButoon.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(148, 315);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(413, 264);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(24, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Server ON/OFF line";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(413, 315);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(24, 20);
            this.textBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Client Conneted";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NewBridgeClient.Properties.Resources.automotive_electronics;
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "V1.8.0FA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(423, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 16;
            // 
            // inter_ip
            // 
            this.inter_ip.Location = new System.Drawing.Point(294, 208);
            this.inter_ip.Name = "inter_ip";
            this.inter_ip.Size = new System.Drawing.Size(113, 20);
            this.inter_ip.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "2. VPN internal IP";
            // 
            // NetworkConnection
            // 
            this.NetworkConnection.Location = new System.Drawing.Point(188, 208);
            this.NetworkConnection.Name = "NetworkConnection";
            this.NetworkConnection.ReadOnly = true;
            this.NetworkConnection.Size = new System.Drawing.Size(100, 20);
            this.NetworkConnection.TabIndex = 19;
            this.NetworkConnection.TabStop = false;
            this.NetworkConnection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Network Conx.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(416, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "@c.jirkon";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 367);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NetworkConnection);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.inter_ip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ConnectButoon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProfileNameBox);
            this.Controls.Add(this.ServerNameBox);
            this.Controls.Add(this.UserNameBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BridgeClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UserNameBox;
        private System.Windows.Forms.TextBox ServerNameBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.ServiceProcess.ServiceController sevpnbridge;
        private System.Data.DataSet dataSet1;
        private System.Windows.Forms.ToolStripMenuItem editProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProfileToolStripMenuItem;
        public System.Windows.Forms.ComboBox ProfileNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConnectButoon;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inter_ip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NetworkConnection;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

