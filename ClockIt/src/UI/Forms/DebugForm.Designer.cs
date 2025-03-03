using System;
using System.Windows.Forms;
using System.Drawing;

namespace ClockIt.src.UI.Forms
{
    partial class DebugForm : Form
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private TextBox textBoxMessage;
        private Button btnClose;

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

        private void InitializeComponent()
        {
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.textBoxMessage.Location = new System.Drawing.Point(12, 12);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessage.Size = new System.Drawing.Size(360, 150);
            this.textBoxMessage.TabIndex = 0;

            this.btnClose.Location = new System.Drawing.Point(150, 170);
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.btnClose);
            this.Name = "ErrorMessageForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Error Details:";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}