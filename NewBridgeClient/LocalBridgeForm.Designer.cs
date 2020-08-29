namespace NewBridgeClient
{
    partial class LocalBridgeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalBridgeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.AvailableInterfaces = new System.Windows.Forms.CheckedListBox();
            this.SaveLocalBridgeButton = new System.Windows.Forms.Button();
            this.AddLocalBridgeButton = new System.Windows.Forms.Button();
            this.DeleteLocalBridgeButton = new System.Windows.Forms.Button();
            this.L_HubNameBox = new System.Windows.Forms.TextBox();
            this.L_HubNameBoxLabel = new System.Windows.Forms.Label();
            this.L_LocalBridgeBox = new System.Windows.Forms.TextBox();
            this.L_LocalBridgeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Bridge Interface ";
            // 
            // AvailableInterfaces
            // 
            this.AvailableInterfaces.CheckOnClick = true;
            this.AvailableInterfaces.FormattingEnabled = true;
            this.AvailableInterfaces.Location = new System.Drawing.Point(12, 126);
            this.AvailableInterfaces.Name = "AvailableInterfaces";
            this.AvailableInterfaces.Size = new System.Drawing.Size(531, 109);
            this.AvailableInterfaces.TabIndex = 1;
            this.AvailableInterfaces.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // SaveLocalBridgeButton
            // 
            this.SaveLocalBridgeButton.Location = new System.Drawing.Point(468, 252);
            this.SaveLocalBridgeButton.Name = "SaveLocalBridgeButton";
            this.SaveLocalBridgeButton.Size = new System.Drawing.Size(75, 23);
            this.SaveLocalBridgeButton.TabIndex = 2;
            this.SaveLocalBridgeButton.Text = "Save";
            this.SaveLocalBridgeButton.UseVisualStyleBackColor = true;
            this.SaveLocalBridgeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddLocalBridgeButton
            // 
            this.AddLocalBridgeButton.Location = new System.Drawing.Point(12, 252);
            this.AddLocalBridgeButton.Name = "AddLocalBridgeButton";
            this.AddLocalBridgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddLocalBridgeButton.TabIndex = 3;
            this.AddLocalBridgeButton.Text = "Add";
            this.AddLocalBridgeButton.UseVisualStyleBackColor = true;
            this.AddLocalBridgeButton.Click += new System.EventHandler(this.AddLocalBridgeButton_Click);
            // 
            // DeleteLocalBridgeButton
            // 
            this.DeleteLocalBridgeButton.Location = new System.Drawing.Point(105, 252);
            this.DeleteLocalBridgeButton.Name = "DeleteLocalBridgeButton";
            this.DeleteLocalBridgeButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteLocalBridgeButton.TabIndex = 4;
            this.DeleteLocalBridgeButton.Text = "Delete";
            this.DeleteLocalBridgeButton.UseVisualStyleBackColor = true;
            this.DeleteLocalBridgeButton.Click += new System.EventHandler(this.DeleteLocalBridgeButton_Click);
            // 
            // L_HubNameBox
            // 
            this.L_HubNameBox.Location = new System.Drawing.Point(12, 84);
            this.L_HubNameBox.Name = "L_HubNameBox";
            this.L_HubNameBox.Size = new System.Drawing.Size(117, 20);
            this.L_HubNameBox.TabIndex = 5;
            // 
            // L_HubNameBoxLabel
            // 
            this.L_HubNameBoxLabel.AutoSize = true;
            this.L_HubNameBoxLabel.Location = new System.Drawing.Point(12, 68);
            this.L_HubNameBoxLabel.Name = "L_HubNameBoxLabel";
            this.L_HubNameBoxLabel.Size = new System.Drawing.Size(27, 13);
            this.L_HubNameBoxLabel.TabIndex = 6;
            this.L_HubNameBoxLabel.Text = "Hub";
            // 
            // L_LocalBridgeBox
            // 
            this.L_LocalBridgeBox.Location = new System.Drawing.Point(135, 84);
            this.L_LocalBridgeBox.Name = "L_LocalBridgeBox";
            this.L_LocalBridgeBox.Size = new System.Drawing.Size(408, 20);
            this.L_LocalBridgeBox.TabIndex = 7;
            // 
            // L_LocalBridgeLabel
            // 
            this.L_LocalBridgeLabel.AutoSize = true;
            this.L_LocalBridgeLabel.Location = new System.Drawing.Point(132, 68);
            this.L_LocalBridgeLabel.Name = "L_LocalBridgeLabel";
            this.L_LocalBridgeLabel.Size = new System.Drawing.Size(154, 13);
            this.L_LocalBridgeLabel.TabIndex = 8;
            this.L_LocalBridgeLabel.Text = "Local Bridge Network Interface";
            // 
            // LocalBridgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 367);
            this.Controls.Add(this.L_LocalBridgeLabel);
            this.Controls.Add(this.L_LocalBridgeBox);
            this.Controls.Add(this.L_HubNameBoxLabel);
            this.Controls.Add(this.L_HubNameBox);
            this.Controls.Add(this.DeleteLocalBridgeButton);
            this.Controls.Add(this.AddLocalBridgeButton);
            this.Controls.Add(this.SaveLocalBridgeButton);
            this.Controls.Add(this.AvailableInterfaces);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LocalBridgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Local Bridge Interface";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocalBridgeForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveLocalBridgeButton;
        private System.Windows.Forms.Button AddLocalBridgeButton;
        private System.Windows.Forms.Button DeleteLocalBridgeButton;
        public System.Windows.Forms.TextBox L_HubNameBox;
        private System.Windows.Forms.Label L_HubNameBoxLabel;
        private System.Windows.Forms.TextBox L_LocalBridgeBox;
        private System.Windows.Forms.Label L_LocalBridgeLabel;
        public System.Windows.Forms.CheckedListBox AvailableInterfaces;
    }
}