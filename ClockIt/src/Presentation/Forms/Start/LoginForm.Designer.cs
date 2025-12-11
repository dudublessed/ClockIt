using ClockIt.src.Shared.Utils;
using System.Diagnostics;
using System.Drawing.Text;

namespace ClockIt.src.Presentation.Forms.Start
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            topPanel = new Panel();
            welcomeLabel = new Label();
            companyLabel = new Label();
            divisionLine = new Panel();
            usersContainer = new Panel();
            bottomLine = new Panel();
            loginContainer = new Panel();
            nameLabel = new Label();
            nameBox = new TextBox();
            passwordLabel = new Label();
            passwordBox = new TextBox();
            topPanel.SuspendLayout();
            loginContainer.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            resources.ApplyResources(topPanel, "topPanel");
            topPanel.BackColor = Color.FromArgb(230, 230, 230);
            topPanel.Controls.Add(welcomeLabel);
            topPanel.Controls.Add(companyLabel);
            topPanel.Name = "topPanel";
            // 
            // welcomeLabel
            // 
            resources.ApplyResources(welcomeLabel, "welcomeLabel");
            welcomeLabel.BackColor = Color.FromArgb(230, 230, 230);
            welcomeLabel.ForeColor = Color.FromArgb(0, 0, 0);
            welcomeLabel.Name = "welcomeLabel";
            // 
            // companyLabel
            // 
            resources.ApplyResources(companyLabel, "companyLabel");
            companyLabel.BackColor = Color.FromArgb(230, 230, 230);
            companyLabel.ForeColor = Color.FromArgb(0, 0, 0);
            companyLabel.Name = "companyLabel";
            // 
            // divisionLine
            // 
            resources.ApplyResources(divisionLine, "divisionLine");
            divisionLine.BackColor = Color.FromArgb(0, 0, 0);
            divisionLine.Name = "divisionLine";
            // 
            // usersContainer
            // 
            resources.ApplyResources(usersContainer, "usersContainer");
            usersContainer.BackColor = Color.FromArgb(245, 245, 245);
            usersContainer.Name = "usersContainer";
            // 
            // bottomLine
            // 
            resources.ApplyResources(bottomLine, "bottomLine");
            bottomLine.BackColor = Color.FromArgb(0, 0, 0);
            bottomLine.Name = "bottomLine";
            // 
            // loginContainer
            // 
            resources.ApplyResources(loginContainer, "loginContainer");
            loginContainer.BackColor = Color.FromArgb(230, 230, 230);
            loginContainer.Controls.Add(nameLabel);
            loginContainer.Controls.Add(nameBox);
            loginContainer.Controls.Add(passwordLabel);
            loginContainer.Controls.Add(passwordBox);
            loginContainer.Name = "loginContainer";
            // 
            // nameLabel
            // 
            resources.ApplyResources(nameLabel, "nameLabel");
            nameLabel.BackColor = Color.FromArgb(230, 230, 230);
            nameLabel.Name = "nameLabel";
            // 
            // nameBox
            // 
            resources.ApplyResources(nameBox, "nameBox");
            nameBox.BackColor = Color.FromArgb(220, 220, 220);
            nameBox.BorderStyle = BorderStyle.FixedSingle;
            nameBox.Name = "nameBox";
            nameBox.Enabled = false;
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.BackColor = Color.FromArgb(230, 230, 230);
            passwordLabel.Name = "passwordLabel";
            // 
            // passwordBox
            // 
            resources.ApplyResources(passwordBox, "passwordBox");
            passwordBox.BackColor = Color.FromArgb(245, 245, 245);
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.Name = "passwordBox";
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.KeyDown += IsKeyDownEnter;
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            Controls.Add(topPanel);
            Controls.Add(divisionLine);
            Controls.Add(usersContainer);
            Controls.Add(bottomLine);
            Controls.Add(loginContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "LoginForm";
            SizeGripStyle = SizeGripStyle.Show;
            Load += LoginForm_Load;
            this.MaximizeBox = false;
            topPanel.ResumeLayout(false);
            loginContainer.ResumeLayout(false);
            loginContainer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Top Section
        private Panel topPanel;
        private Label welcomeLabel;
        private Label companyLabel;
        private Panel divisionLine;

        // Middle Section
        private Panel usersContainer;

        // Bottom Section
        private Panel bottomLine;
        private Panel loginContainer;
        private Label nameLabel;
        private TextBox nameBox;
        private Label passwordLabel;
        private TextBox passwordBox;
    }
}
