namespace ChatApp
{
    partial class ChatSessionWindow
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.ipBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(46, 12);
            this.usernameTextBox.MaxLength = 32;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(149, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // ipBox
            // 
            this.ipBox.Location = new System.Drawing.Point(46, 91);
            this.ipBox.Name = "ipBox";
            this.ipBox.Size = new System.Drawing.Size(149, 20);
            this.ipBox.TabIndex = 1;
            this.ipBox.Text = "192.168.0.32";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(46, 117);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(149, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(46, 38);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(149, 23);
            this.createButton.TabIndex = 3;
            this.createButton.Text = "Create Server";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // ChatSessionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 155);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ipBox);
            this.Controls.Add(this.usernameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatSessionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChatSessionWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox ipBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button createButton;
    }
}