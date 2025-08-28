using ClockIt.src.Shared.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ClockIt.src.Presentation.Forms.Start
{
    partial class AdminPasswordForm
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
            updateAdminPasswordLabel = new Label();
            firstDescriptionLabel = new Label();
            secondDescriptionLabel = new Label();
            enterAdminPasswordLabel = new Label();
            enterAdminPasswordText = new TextBox();
            enterPasswordErrorLabel = new Label();
            firstViewPassword = new Button();
            confirmAdminPasswordLabel = new Label();
            confirmAdminPasswordText = new TextBox();
            confirmPasswordErrorLabel = new Label();
            secondViewPassword = new Button();
            updatePasswordButton = new Button();

            Font errorLabel = new Font("Segoe UI", 9, FontStyle.Bold);

            SuspendLayout();
            // 
            // updateAdminPasswordLabel
            // 
            updateAdminPasswordLabel.BackColor = Color.Transparent;
            updateAdminPasswordLabel.Font = new Font("Satoshi Black Italic", 19F, FontStyle.Bold);
            updateAdminPasswordLabel.ForeColor = Color.FromArgb(0, 0, 0);
            updateAdminPasswordLabel.Location = new Point(110, 30);
            updateAdminPasswordLabel.Name = "updateAdminPasswordLabel";
            updateAdminPasswordLabel.Size = new Size(200, 30);
            updateAdminPasswordLabel.TabIndex = 0;
            updateAdminPasswordLabel.Text = "Crie sua senha";
            // 
            // firstDescriptionLabel
            // 
            firstDescriptionLabel.BackColor = Color.Transparent;
            firstDescriptionLabel.Font = new Font("Satoshi Black Italic", 11F);
            firstDescriptionLabel.ForeColor = Color.FromArgb(55, 55, 55);
            firstDescriptionLabel.Location = new Point(45, 75);
            firstDescriptionLabel.Name = "firstDescriptionLabel";
            firstDescriptionLabel.Size = new Size(330, 20);
            firstDescriptionLabel.TabIndex = 1;
            firstDescriptionLabel.Text = "Essa vai ser a senha do administrador, beleza?";
            // 
            // secondDescriptionLabel
            // 
            secondDescriptionLabel.BackColor = Color.Transparent;
            secondDescriptionLabel.Font = new Font("Satoshi Black Italic", 10F);
            secondDescriptionLabel.ForeColor = Color.FromArgb(55, 55, 55);
            secondDescriptionLabel.Location = new Point(127, 100);
            secondDescriptionLabel.Name = "secondDescriptionLabel";
            secondDescriptionLabel.Size = new Size(165, 20);
            secondDescriptionLabel.TabIndex = 1;
            secondDescriptionLabel.Text = "Guarda essa senha!";
            // 
            // enterAdminPasswordLabel
            // 
            enterAdminPasswordLabel.BackColor = Color.Transparent;
            enterAdminPasswordLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterAdminPasswordLabel.Location = new Point(110, 140);
            enterAdminPasswordLabel.Name = "enterAdminPasswordLabel";
            enterAdminPasswordLabel.Size = new Size(140, 18);
            enterAdminPasswordLabel.TabIndex = 2;
            enterAdminPasswordLabel.Text = "Digite a senha: ";
            // 
            // enterAdminPasswordText
            // 
            enterAdminPasswordText.BackColor = Color.FromArgb(250, 250, 250);
            enterAdminPasswordText.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterAdminPasswordText.Location = new Point(110, 160);
            enterAdminPasswordText.MaxLength = 20;
            enterAdminPasswordText.Name = "enterAdminPasswordText";
            enterAdminPasswordText.Size = new Size(200, 23);
            enterAdminPasswordText.UseSystemPasswordChar = true;
            enterAdminPasswordText.TabIndex = 2;
            //
            // enterPasswordErrorLabel
            //
            enterPasswordErrorLabel.BackColor = Color.Transparent;
            enterPasswordErrorLabel.Font = errorLabel;
            enterPasswordErrorLabel.Location = new Point(110, 185);
            enterPasswordErrorLabel.ForeColor = Color.FromArgb(229, 57, 53);
            enterPasswordErrorLabel.Name = "enterPasswordErrorLabel";
            enterPasswordErrorLabel.Size = new Size(200, 34);
            enterPasswordErrorLabel.TabIndex = 4;
            //
            // firstViewPassword
            //
            string pathToPasswordIcon = FileHelper.FindFileInProject("eye_solid.png");
            Image passwordIcon = Image.FromFile(pathToPasswordIcon);
            Image resizedPasswordIcon = new Bitmap(passwordIcon, new Size(18, 18));

            firstViewPassword.BackColor = Color.FromArgb(250, 250, 250);
            firstViewPassword.Location = new Point(280, 161);
            firstViewPassword.Name = "firstViewPassword";
            firstViewPassword.Size = new Size(30, 20);
            firstViewPassword.FlatStyle = FlatStyle.Flat;
            firstViewPassword.FlatAppearance.BorderSize = 0;
            firstViewPassword.Image = resizedPasswordIcon;
            firstViewPassword.ImageAlign = ContentAlignment.MiddleCenter;
            firstViewPassword.Click += ControlPasswordView;
            // 
            // confirmAdminPasswordLabel
            // 
            confirmAdminPasswordLabel.BackColor = Color.Transparent;
            confirmAdminPasswordLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            confirmAdminPasswordLabel.Location = new Point(110, 200);
            confirmAdminPasswordLabel.Name = "confirmAdminPasswordLabel";
            confirmAdminPasswordLabel.Size = new Size(140, 18);
            confirmAdminPasswordLabel.TabIndex = 3;
            confirmAdminPasswordLabel.Text = "Confirme a senha: ";
            // 
            // confirmAdminPasswordText
            // 
            confirmAdminPasswordText.BackColor = Color.FromArgb(250, 250, 250);
            confirmAdminPasswordText.Font = new Font("Arial", 10F, FontStyle.Bold);
            confirmAdminPasswordText.Location = new Point(110, 220);
            confirmAdminPasswordText.MaxLength = 20;
            confirmAdminPasswordText.Name = "confirmAdminPasswordText";
            confirmAdminPasswordText.Size = new Size(200, 23);
            confirmAdminPasswordText.UseSystemPasswordChar = true;
            confirmAdminPasswordText.TabIndex = 3;
            //
            // confirmPasswordErrorLabel
            //
            confirmPasswordErrorLabel.BackColor = Color.Transparent;
            confirmPasswordErrorLabel.Font = errorLabel;
            confirmPasswordErrorLabel.Location = new Point(110, 245);
            confirmPasswordErrorLabel.ForeColor = Color.FromArgb(229, 57, 53);
            confirmPasswordErrorLabel.Name = "confirmPasswordErrorLabel";
            confirmPasswordErrorLabel.Size = new Size(200, 17);
            confirmPasswordErrorLabel.TabIndex = 3;
            //
            // secondViewPassword
            //
            secondViewPassword.BackColor = Color.FromArgb(250, 250, 250);
            secondViewPassword.Location = new Point(280, 221);
            secondViewPassword.Name = "secondViewPassword";
            secondViewPassword.Size = new Size(30, 20);
            secondViewPassword.FlatStyle = FlatStyle.Flat;
            secondViewPassword.FlatAppearance.BorderSize = 0;
            secondViewPassword.Image = resizedPasswordIcon;
            secondViewPassword.ImageAlign = ContentAlignment.MiddleCenter;
            secondViewPassword.Click += ControlPasswordView;
            // 
            // updatePasswordButton
            // 
            updatePasswordButton.BackColor = Color.FromArgb(250, 250, 250);
            updatePasswordButton.Cursor = Cursors.Hand;
            updatePasswordButton.Font = new Font("Arial", 9F, FontStyle.Bold);
            updatePasswordButton.Location = new Point(110, 270);
            updatePasswordButton.Name = "updatePasswordButton";
            updatePasswordButton.Size = new Size(200, 30);
            updatePasswordButton.TabIndex = 4;
            updatePasswordButton.Text = "Definir";
            updatePasswordButton.UseVisualStyleBackColor = false;
            updatePasswordButton.Click += UpdateAdminPassword;
            // 
            // AdminPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 330);
            Controls.Add(updateAdminPasswordLabel);
            Controls.Add(firstDescriptionLabel);
            Controls.Add(secondDescriptionLabel);
            Controls.Add(enterAdminPasswordLabel);
            Controls.Add(enterAdminPasswordText);
            Controls.Add(enterPasswordErrorLabel);
            Controls.Add(firstViewPassword);
            Controls.Add(confirmAdminPasswordLabel);
            Controls.Add(confirmAdminPasswordText);
            Controls.Add(confirmPasswordErrorLabel);
            Controls.Add(secondViewPassword);
            Controls.Add(updatePasswordButton);
            Controls.SetChildIndex(firstViewPassword, 0);
            Controls.SetChildIndex(secondViewPassword, 0);
            enterPasswordErrorLabel.Hide();
            confirmPasswordErrorLabel.Hide();
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt";
            Load += AdminPasswordForm_Load;
            FormClosing += AdminPasswordForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label updateAdminPasswordLabel;
        private Label firstDescriptionLabel;
        private Label secondDescriptionLabel;

        private Label enterAdminPasswordLabel;
        private TextBox enterAdminPasswordText;
        private Label enterPasswordErrorLabel;
        private Button firstViewPassword;

        private Label confirmAdminPasswordLabel;
        private TextBox confirmAdminPasswordText;
        private Label confirmPasswordErrorLabel;
        private Button secondViewPassword;

        private Button updatePasswordButton;
    }
}