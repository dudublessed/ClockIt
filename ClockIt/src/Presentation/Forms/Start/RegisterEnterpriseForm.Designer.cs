namespace ClockIt.src.Presentation.Forms.Start
{
    partial class RegisterEnterpriseForm
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
            registerLabel = new Label();
            descriptionLabel = new Label();
            enterpriseNameLabel = new Label();
            enterpriseNameText = new TextBox();
            enterpriseEmailLabel = new Label();
            enterpriseEmailText = new TextBox();
            enterpriseCountryLabel = new Label();
            enterpriseCountryCombo = new ComboBox();
            enterpriseStateLabel = new Label();
            enterpriseStateCombo = new ComboBox();
            enterpriseCityLabel = new Label();
            enterpriseCityCombo = new ComboBox();
            registerButton = new Button();
            SuspendLayout();
            // 
            // registerLabel
            // 
            registerLabel.BackColor = Color.Transparent;
            registerLabel.Font = new Font("Satoshi Black Italic", 20F, FontStyle.Bold);
            registerLabel.ForeColor = Color.FromArgb(0, 0, 0);
            registerLabel.Location = new Point(162, 30);
            registerLabel.Name = "registerLabel";
            registerLabel.Size = new Size(175, 35);
            registerLabel.TabIndex = 0;
            registerLabel.Text = "Cadastre-se";
            // 
            // descriptionLabel
            // 
            descriptionLabel.BackColor = Color.Transparent;
            descriptionLabel.Font = new Font("Satoshi Black Italic", 12F);
            descriptionLabel.ForeColor = Color.FromArgb(55, 55, 55);
            descriptionLabel.Location = new Point(110, 70);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(280, 30);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Precisamos conhecer você melhor!";
            // 
            // enterpriseNameLabel
            // 
            enterpriseNameLabel.BackColor = Color.Transparent;
            enterpriseNameLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseNameLabel.Location = new Point(150, 115);
            enterpriseNameLabel.Name = "enterpriseNameLabel";
            enterpriseNameLabel.Size = new Size(140, 18);
            enterpriseNameLabel.TabIndex = 2;
            enterpriseNameLabel.Text = "Nome da Empresa: ";
            // 
            // enterpriseNameText
            // 
            enterpriseNameText.BackColor = Color.FromArgb(250, 250, 250);
            enterpriseNameText.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseNameText.Location = new Point(150, 135);
            enterpriseNameText.MaxLength = 23;
            enterpriseNameText.Name = "enterpriseNameText";
            enterpriseNameText.Size = new Size(200, 23);
            enterpriseNameText.TabIndex = 2;
            // 
            // enterpriseEmailLabel
            // 
            enterpriseEmailLabel.BackColor = Color.Transparent;
            enterpriseEmailLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseEmailLabel.Location = new Point(150, 170);
            enterpriseEmailLabel.Name = "enterpriseEmailLabel";
            enterpriseEmailLabel.Size = new Size(140, 18);
            enterpriseEmailLabel.TabIndex = 2;
            enterpriseEmailLabel.Text = "Email: ";
            // 
            // enterpriseEmailText
            // 
            enterpriseEmailText.BackColor = Color.FromArgb(250, 250, 250);
            enterpriseEmailText.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseEmailText.Location = new Point(150, 190);
            enterpriseEmailText.MaxLength = 40;
            enterpriseEmailText.Name = "enterpriseEmailText";
            enterpriseEmailText.Size = new Size(200, 23);
            enterpriseEmailText.TabIndex = 2;
            // 
            // enterpriseCountryLabel
            // 
            enterpriseCountryLabel.BackColor = Color.Transparent;
            enterpriseCountryLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseCountryLabel.Location = new Point(150, 225);
            enterpriseCountryLabel.Name = "enterpriseCountryLabel";
            enterpriseCountryLabel.Size = new Size(200, 23);
            enterpriseCountryLabel.TabIndex = 3;
            enterpriseCountryLabel.Text = "Selecione um país: ";
            // 
            // enterpriseCountryCombo
            // 
            enterpriseCountryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            enterpriseCountryCombo.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseCountryCombo.Location = new Point(150, 245);
            enterpriseCountryCombo.Name = "enterpriseCountryCombo";
            enterpriseCountryCombo.Size = new Size(200, 24);
            enterpriseCountryCombo.TabIndex = 3;
            enterpriseCountryCombo.SelectedIndexChanged += ShowStatesByCountry;
            // 
            // enterpriseStateLabel
            // 
            enterpriseStateLabel.BackColor = Color.Transparent;
            enterpriseStateLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseStateLabel.Location = new Point(150, 280);
            enterpriseStateLabel.Name = "enterpriseStateLabel";
            enterpriseStateLabel.Size = new Size(200, 23);
            enterpriseStateLabel.TabIndex = 4;
            enterpriseStateLabel.Text = "Selecione um estado: ";
            // 
            // enterpriseStateCombo
            // 
            enterpriseStateCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            enterpriseStateCombo.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseStateCombo.Location = new Point(150, 300);
            enterpriseStateCombo.Name = "enterpriseStateCombo";
            enterpriseStateCombo.Size = new Size(200, 24);
            enterpriseStateCombo.TabIndex = 4;
            enterpriseStateCombo.SelectedIndexChanged += ShowCitiesByState;
            // 
            // enterpriseCityLabel
            // 
            enterpriseCityLabel.BackColor = Color.Transparent;
            enterpriseCityLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseCityLabel.Location = new Point(150, 335);
            enterpriseCityLabel.Name = "enterpriseCityLabel";
            enterpriseCityLabel.Size = new Size(200, 23);
            enterpriseCityLabel.TabIndex = 5;
            enterpriseCityLabel.Text = "Selecione uma cidade: ";
            // 
            // enterpriseCityCombo
            // 
            enterpriseCityCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            enterpriseCityCombo.Font = new Font("Arial", 10F, FontStyle.Bold);
            enterpriseCityCombo.Location = new Point(150, 355);
            enterpriseCityCombo.Name = "enterpriseCityCombo";
            enterpriseCityCombo.Size = new Size(200, 24);
            enterpriseCityCombo.TabIndex = 5;
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.FromArgb(250, 250, 250);
            registerButton.Cursor = Cursors.Hand;
            registerButton.Font = new Font("Arial", 9F, FontStyle.Bold);
            registerButton.Location = new Point(150, 400);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(200, 30);
            registerButton.TabIndex = 6;
            registerButton.Text = "Registrar";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += SubmitRegistration;
            // 
            // RegisterEnterpriseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 445);
            Controls.Add(registerLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(enterpriseNameLabel);
            Controls.Add(enterpriseNameText);
            Controls.Add(enterpriseEmailLabel);
            Controls.Add(enterpriseEmailText);
            Controls.Add(enterpriseCountryLabel);
            Controls.Add(enterpriseCountryCombo);
            Controls.Add(enterpriseStateLabel);
            Controls.Add(enterpriseStateCombo);
            Controls.Add(enterpriseCityLabel);
            Controls.Add(enterpriseCityCombo);
            Controls.Add(registerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterEnterpriseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt";
            Load += RegisterEnterpriseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label registerLabel;
        private Label descriptionLabel;

        private Label enterpriseNameLabel;
        private TextBox enterpriseNameText;

        private Label enterpriseEmailLabel;
        private TextBox enterpriseEmailText;

        private Label enterpriseCountryLabel;
        private ComboBox enterpriseCountryCombo;

        private Label enterpriseStateLabel;
        private ComboBox enterpriseStateCombo;

        private Label enterpriseCityLabel;
        private ComboBox enterpriseCityCombo;

        private Button registerButton;
    }
}