using System.Windows.Forms;

namespace ToolsVPN
{
    partial class ToolsVPN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsVPN));
            this.ServerIPHost = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.Label();
            this.Connectto = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.PassWord = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.User = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.HostName = new System.Windows.Forms.TextBox();
            this._connect_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerIPHost
            // 
            this.ServerIPHost.AutoSize = true;
            this.ServerIPHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIPHost.Location = new System.Drawing.Point(6, 44);
            this.ServerIPHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerIPHost.Name = "ServerIPHost";
            this.ServerIPHost.Size = new System.Drawing.Size(84, 13);
            this.ServerIPHost.TabIndex = 1;
            this.ServerIPHost.Text = "Server IP/Host :";
            // 
            // ServerPort
            // 
            this.ServerPort.AutoSize = true;
            this.ServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerPort.Location = new System.Drawing.Point(24, 65);
            this.ServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(66, 13);
            this.ServerPort.TabIndex = 2;
            this.ServerPort.Text = "Server Port :";
            // 
            // Connectto
            // 
            this.Connectto.AutoSize = true;
            this.Connectto.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.Connectto.Location = new System.Drawing.Point(77, 9);
            this.Connectto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Connectto.Name = "Connectto";
            this.Connectto.Size = new System.Drawing.Size(100, 20);
            this.Connectto.TabIndex = 0;
            this.Connectto.Text = "Connect To:";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(24, 106);
            this.UserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(66, 13);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "User Name :";
            // 
            // PassWord
            // 
            this.PassWord.AutoSize = true;
            this.PassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWord.Location = new System.Drawing.Point(31, 135);
            this.PassWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(59, 13);
            this.PassWord.TabIndex = 4;
            this.PassWord.Text = "Password :";
            // 
            // Port
            // 
            this.Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Port.Location = new System.Drawing.Point(98, 62);
            this.Port.Margin = new System.Windows.Forms.Padding(4);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(60, 20);
            this.Port.TabIndex = 6;
            this.Port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // User
            // 
            this.User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User.Location = new System.Drawing.Point(98, 103);
            this.User.Margin = new System.Windows.Forms.Padding(4);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(79, 20);
            this.User.TabIndex = 7;
            // 
            // Pass
            // 
            this.Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pass.Location = new System.Drawing.Point(98, 135);
            this.Pass.Margin = new System.Windows.Forms.Padding(4);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(79, 20);
            this.Pass.TabIndex = 8;
            // 
            // HostName
            // 
            this.HostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostName.Location = new System.Drawing.Point(98, 41);
            this.HostName.Margin = new System.Windows.Forms.Padding(4);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(145, 20);
            this.HostName.TabIndex = 5;
            this.HostName.TextChanged += new System.EventHandler(this.HostName_TextChanged);
            // 
            // _connect_button
            // 
            this._connect_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this._connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._connect_button.Location = new System.Drawing.Point(34, 186);
            this._connect_button.Margin = new System.Windows.Forms.Padding(4);
            this._connect_button.Name = "_connect_button";
            this._connect_button.Size = new System.Drawing.Size(78, 29);
            this._connect_button.TabIndex = 9;
            this._connect_button.Text = "Connect";
            this._connect_button.UseVisualStyleBackColor = false;
            this._connect_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this._connect_button_MouseClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(130, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 31);
            this.button2.TabIndex = 10;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ToolsVPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 223);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._connect_button);
            this.Controls.Add(this.HostName);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.User);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Connectto);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.ServerIPHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ToolsVPN";
            this.Text = "     ToolsVPN";
            this.Load += new System.EventHandler(this.ToolsVPN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIPHost;
        private System.Windows.Forms.Label ServerPort;
        private System.Windows.Forms.Label Connectto;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label PassWord;
        public System.Windows.Forms.TextBox Port;
        public TextBox HostName;
        private Button _connect_button;
        private Button button2;
        public TextBox User;
        public TextBox Pass;
    }
}

