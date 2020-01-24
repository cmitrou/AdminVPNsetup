namespace UserFilesEncryption
{
    partial class VPN_UserSettingsFileEncDecr
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
            this.btEncodeFile = new System.Windows.Forms.Button();
            this.btDecodeFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btEncodeFile
            // 
            this.btEncodeFile.Location = new System.Drawing.Point(12, 22);
            this.btEncodeFile.Name = "btEncodeFile";
            this.btEncodeFile.Size = new System.Drawing.Size(140, 23);
            this.btEncodeFile.TabIndex = 3;
            this.btEncodeFile.Text = "Encode File";
            this.btEncodeFile.UseVisualStyleBackColor = true;
            this.btEncodeFile.Click += new System.EventHandler(this.btEncodeFile_Click);
            // 
            // btDecodeFile
            // 
            this.btDecodeFile.Location = new System.Drawing.Point(188, 22);
            this.btDecodeFile.Name = "btDecodeFile";
            this.btDecodeFile.Size = new System.Drawing.Size(140, 23);
            this.btDecodeFile.TabIndex = 4;
            this.btDecodeFile.Text = "Decode File";
            this.btDecodeFile.UseVisualStyleBackColor = true;
            this.btDecodeFile.Click += new System.EventHandler(this.btDecodeFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // VPN_UserSettingsFileEncDecr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 70);
            this.Controls.Add(this.btDecodeFile);
            this.Controls.Add(this.btEncodeFile);
            this.Name = "VPN_UserSettingsFileEncDecr";
            this.Text = "VPN Users Settings Encr. Decr. File";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btEncodeFile;
        private System.Windows.Forms.Button btDecodeFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

