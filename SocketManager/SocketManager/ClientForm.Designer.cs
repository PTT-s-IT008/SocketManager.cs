
namespace SocketManager
{
    partial class ClientForm
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userlistPanel = new System.Windows.Forms.Panel();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.typeBox = new System.Windows.Forms.TextBox();
            this.chatBtn = new System.Windows.Forms.Button();
            this.stickerBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(114, 12);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(311, 22);
            this.usernameBox.TabIndex = 0;
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(114, 40);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(311, 22);
            this.IPBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "CONNECT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userlistPanel
            // 
            this.userlistPanel.Location = new System.Drawing.Point(13, 87);
            this.userlistPanel.Name = "userlistPanel";
            this.userlistPanel.Size = new System.Drawing.Size(200, 350);
            this.userlistPanel.TabIndex = 5;
            // 
            // chatPanel
            // 
            this.chatPanel.Location = new System.Drawing.Point(233, 87);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(500, 300);
            this.chatPanel.TabIndex = 6;
            // 
            // typeBox
            // 
            this.typeBox.Location = new System.Drawing.Point(275, 415);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(400, 22);
            this.typeBox.TabIndex = 7;
            // 
            // chatBtn
            // 
            this.chatBtn.Location = new System.Drawing.Point(697, 415);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(36, 23);
            this.chatBtn.TabIndex = 8;
            this.chatBtn.Text = ">";
            this.chatBtn.UseVisualStyleBackColor = true;
            // 
            // stickerBtn
            // 
            this.stickerBtn.Location = new System.Drawing.Point(233, 415);
            this.stickerBtn.Name = "stickerBtn";
            this.stickerBtn.Size = new System.Drawing.Size(36, 23);
            this.stickerBtn.TabIndex = 9;
            this.stickerBtn.Text = ":)";
            this.stickerBtn.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(779, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(300, 300);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.stickerBtn);
            this.Controls.Add(this.chatBtn);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.chatPanel);
            this.Controls.Add(this.userlistPanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.usernameBox);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.Shown += new System.EventHandler(this.ClientForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel userlistPanel;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.TextBox typeBox;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.Button stickerBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}