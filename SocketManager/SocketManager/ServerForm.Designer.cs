﻿
namespace SocketManager
{
    partial class ServerForm
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
            this.debugScreen = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // debugScreen
            // 
            this.debugScreen.BackColor = System.Drawing.Color.Black;
            this.debugScreen.Font = new System.Drawing.Font("Lucida Console", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugScreen.ForeColor = System.Drawing.Color.SpringGreen;
            this.debugScreen.Location = new System.Drawing.Point(13, 129);
            this.debugScreen.Name = "debugScreen";
            this.debugScreen.Size = new System.Drawing.Size(775, 309);
            this.debugScreen.TabIndex = 0;
            this.debugScreen.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(775, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "CREATE SERVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 22);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(354, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Render Userlist";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.debugScreen);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Shown += new System.EventHandler(this.ServerForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox debugScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}