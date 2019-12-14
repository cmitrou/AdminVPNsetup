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
            this.ServerIPHost = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ServerIPHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.ServerIPHost.Location = new System.Drawing.Point(-2, 57);
            this.ServerIPHost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerIPHost.Name = "ServerIPHost";
            this.ServerIPHost.Size = new System.Drawing.Size(120, 20);
            this.ServerIPHost.TabIndex = 0;
            this.ServerIPHost.Text = "Server IP/Host :";
            // 
            // ServerPort
            // 
            this.ServerPort.AutoSize = true;
            this.ServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.ServerPort.Location = new System.Drawing.Point(22, 93);
            this.ServerPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(96, 20);
            this.ServerPort.TabIndex = 1;
            this.ServerPort.Text = "Server Port :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connect To:";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(21, 144);
            this.UserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(97, 20);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "User Name :";
            // 
            // PassWord
            // 
            this.PassWord.AutoSize = true;
            this.PassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.PassWord.Location = new System.Drawing.Point(33, 182);
            this.PassWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassWord.Name = "PassWord";
            this.PassWord.Size = new System.Drawing.Size(86, 20);
            this.PassWord.TabIndex = 4;
            this.PassWord.Text = "Password :";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(122, 89);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(83, 26);
            this.Port.TabIndex = 6;
            // 
            // User
            // 
            this.User.Location = new System.Drawing.Point(122, 144);
            this.User.Name = "User";
            this.User.Size = new System.Drawing.Size(155, 26);
            this.User.TabIndex = 7;
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(123, 178);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(154, 26);
            this.Pass.TabIndex = 8;
            // 
            // HostName
            // 
            this.HostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.HostName.Location = new System.Drawing.Point(123, 55);
            this.HostName.Name = "HostName";
            this.HostName.Size = new System.Drawing.Size(271, 25);
            this.HostName.TabIndex = 10;
            // 
            // _connect_button
            // 
            this._connect_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this._connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this._connect_button.Location = new System.Drawing.Point(57, 234);
            this._connect_button.Name = "_connect_button";
            this._connect_button.Size = new System.Drawing.Size(112, 35);
            this._connect_button.TabIndex = 13;
            this._connect_button.Text = "Connect";
            this._connect_button.UseVisualStyleBackColor = false;
            this._connect_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this._connect_button_MouseClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(197, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 14;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // ToolsVPN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 321);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._connect_button);
            this.Controls.Add(this.HostName);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.User);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.PassWord);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.ServerIPHost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ToolsVPN";
            this.Text = "                                                     ToolsVPN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIPHost;
        private System.Windows.Forms.Label ServerPort;
        private System.Windows.Forms.Label label1;
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

