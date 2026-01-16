namespace ClockIt.src.Presentation.Forms.Main.Admin.User
{
    partial class CreateUserForm
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
            createUserFormTitle = new Label();
            userNameLabel = new Label();
            userNameTextBox = new TextBox();
            userPasswordLabel = new Label();
            userPasswordTextBox = new TextBox();
            createUserButton = new Button();
            SuspendLayout();
            // 
            // createUserFormTitle
            // 
            createUserFormTitle.BackColor = this.BackColor;
            createUserFormTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            createUserFormTitle.Location = new Point(122, 19);
            createUserFormTitle.Name = "createUserFormTitle";
            createUserFormTitle.Size = new Size(190, 20);
            createUserFormTitle.TabIndex = 4;
            createUserFormTitle.Text = "Cadastro de Usuário";
            // 
            // userNameLabel
            // 
            userNameLabel.BackColor = this.BackColor;
            userNameLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            userNameLabel.Location = new Point(122, 71);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(140, 18);
            userNameLabel.TabIndex = 6;
            userNameLabel.Text = "Nome do Usuário: ";
            // 
            // userNameTextBox
            // 
            userNameTextBox.BackColor = Color.FromArgb(250, 250, 250);
            userNameTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            userNameTextBox.Location = new Point(122, 92);
            userNameTextBox.MaxLength = 23;
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(200, 23);
            userNameTextBox.TabIndex = 5;
            // 
            // userPasswordLabel
            // 
            userPasswordLabel.BackColor = this.BackColor;
            userPasswordLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            userPasswordLabel.Location = new Point(122, 135);
            userPasswordLabel.Name = "userPasswordLabel";
            userPasswordLabel.Size = new Size(140, 18);
            userPasswordLabel.TabIndex = 6;
            userPasswordLabel.Text = "Senha do Usuário: ";
            // 
            // userPasswordTextBox
            // 
            userPasswordTextBox.BackColor = Color.FromArgb(250, 250, 250);
            userPasswordTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            userPasswordTextBox.Location = new Point(122, 156);
            userPasswordTextBox.MaxLength = 23;
            userPasswordTextBox.Name = "userPasswordTextBox";
            userPasswordTextBox.Size = new Size(200, 23);
            userPasswordTextBox.TabIndex = 5;
            // 
            // createUserButton
            // 
            createUserButton.BackColor = Color.FromArgb(250, 250, 250);
            createUserButton.Cursor = Cursors.Hand;
            createUserButton.Font = new Font("Arial", 9F, FontStyle.Bold);
            createUserButton.Location = new Point(122, 213);
            createUserButton.Name = "createUserButton";
            createUserButton.Size = new Size(200, 30);
            createUserButton.TabIndex = 7;
            createUserButton.Text = "Criar Usuário";
            createUserButton.UseVisualStyleBackColor = false;
            createUserButton.Click += CreateUser;
            // 
            // CreateUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(429, 268);
            Controls.Add(createUserFormTitle);
            Controls.Add(userNameLabel);
            Controls.Add(userNameTextBox);
            Controls.Add(userPasswordLabel);
            Controls.Add(userPasswordTextBox);
            Controls.Add(createUserButton);
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "CreateUserForm";
            Text = "Administrator - Create User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createUserFormTitle;
        private Label userNameLabel;
        private TextBox userNameTextBox;
        private Label userPasswordLabel;
        private TextBox userPasswordTextBox;
        private Button createUserButton;
    }
}