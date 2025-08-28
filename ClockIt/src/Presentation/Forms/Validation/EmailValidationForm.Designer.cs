namespace ClockIt.src.Presentation.Forms.Validation
{
    partial class EmailValidationForm
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
            validationCodeLabel = new Label();
            informativeRichText = new RichTextBox();
            validationCodeRichBox = new RichTextBox();
            timerValidationLabel = new Label();
            validateEmailButton = new Button();
            resendCodeLabel = new Label();
            resendCodeLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // validationCodeLabel
            // 
            validationCodeLabel.BackColor = Color.Transparent;
            validationCodeLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            validationCodeLabel.ForeColor = Color.Black;
            validationCodeLabel.Location = new Point(44, 20);
            validationCodeLabel.Name = "validationCodeLabel";
            validationCodeLabel.Size = new Size(183, 25);
            validationCodeLabel.TabIndex = 1;
            validationCodeLabel.Text = "Verificação de Email";
            // 
            // informativeRichText
            // 
            informativeRichText.BackColor = Color.FromArgb(245, 245, 245);
            informativeRichText.BorderStyle = BorderStyle.None;
            informativeRichText.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            informativeRichText.ForeColor = Color.Gray;
            informativeRichText.Location = new Point(35, 60);
            informativeRichText.Name = "informativeRichText";
            informativeRichText.ReadOnly = true;
            informativeRichText.ScrollBars = RichTextBoxScrollBars.None;
            informativeRichText.Size = new Size(200, 34);
            informativeRichText.TabIndex = 2;
            validationCodeRichBox.SelectionAlignment = HorizontalAlignment.Center;
            informativeRichText.TabStop = false;
            informativeRichText.Text = "Insira o código enviado para o seu email";
            // 
            // validationCodeRichBox
            // 
            validationCodeRichBox.BackColor = Color.FromArgb(240, 240, 240);
            validationCodeRichBox.BorderStyle = BorderStyle.None;
            validationCodeRichBox.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            validationCodeRichBox.Location = new Point(35, 115);
            validationCodeRichBox.Name = "validationCodeRichBox";
            validationCodeRichBox.ScrollBars = RichTextBoxScrollBars.None;
            validationCodeRichBox.Size = new Size(200, 35);
            validationCodeRichBox.TabIndex = 3;
            validationCodeRichBox.TabStop = false;
            validationCodeRichBox.ForeColor = Color.FromArgb(26, 115, 232);
            validationCodeRichBox.Text = "000000";
            validationCodeRichBox.SelectionAlignment = HorizontalAlignment.Center;
            validationCodeRichBox.MaxLength = 6;
            validationCodeRichBox.KeyPress += ValidateCodeInput;
            validationCodeRichBox.TextChanged += AdjustCodeInputRichBox;
            // 
            // timerValidationLabel
            // 
            timerValidationLabel.BackColor = Color.Transparent;
            timerValidationLabel.Font = new Font("Segoe UI", 9.1F);
            timerValidationLabel.ForeColor = Color.Black;
            timerValidationLabel.Location = new Point(33, 155);
            timerValidationLabel.Name = "timerValidationLabel";
            timerValidationLabel.Size = new Size(183, 17);
            timerValidationLabel.TabIndex = 4;
            timerValidationLabel.Text = "00:00";
            // 
            // validateEmailButton
            // 
            validateEmailButton.BackColor = Color.FromArgb(26, 115, 232);
            validateEmailButton.Cursor = Cursors.Hand;
            validateEmailButton.FlatStyle = FlatStyle.Flat;
            validateEmailButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            validateEmailButton.ForeColor = Color.GhostWhite;
            validateEmailButton.Location = new Point(35, 195);
            validateEmailButton.Name = "validateEmailButton";
            validateEmailButton.Size = new Size(200, 30);
            validateEmailButton.TabIndex = 6;
            validateEmailButton.Text = "Verificar";
            validateEmailButton.UseVisualStyleBackColor = false;
            validateEmailButton.Click += SubmitCode;
            // 
            // resendCodeLabel
            // 
            resendCodeLabel.BackColor = Color.Transparent;
            resendCodeLabel.Font = new Font("Segoe UI", 8.1F, FontStyle.Bold);
            resendCodeLabel.ForeColor = Color.Gray;
            resendCodeLabel.Location = new Point(48, 233);
            resendCodeLabel.Name = "resendCodeLabel";
            resendCodeLabel.Size = new Size(78, 14);
            resendCodeLabel.TabIndex = 7;
            resendCodeLabel.Text = "Não recebeu?";
            // 
            // resendCodeLinkLabel
            // 
            resendCodeLinkLabel.ActiveLinkColor = Color.Red;
            resendCodeLinkLabel.BackColor = Color.Transparent;
            resendCodeLinkLabel.Cursor = Cursors.Hand;
            resendCodeLinkLabel.Font = new Font("Segoe UI", 8.1F, FontStyle.Bold);
            resendCodeLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            resendCodeLinkLabel.LinkColor = Color.DarkSlateGray;
            resendCodeLinkLabel.Location = new Point(123, 233);
            resendCodeLinkLabel.Name = "resendCodeLinkLabel";
            resendCodeLinkLabel.Size = new Size(108, 14);
            resendCodeLinkLabel.TabIndex = 8;
            resendCodeLinkLabel.TabStop = true;
            resendCodeLinkLabel.Text = "Enviar novo código";
            resendCodeLinkLabel.DisabledLinkColor = Color.Purple;
            resendCodeLinkLabel.LinkClicked += ReSendValidationEmailCode;
            // 
            // EmailValidationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(270, 270);
            Controls.Add(validationCodeLabel);
            Controls.Add(informativeRichText);
            Controls.Add(validationCodeRichBox);
            Controls.Add(timerValidationLabel);
            Controls.Add(validateEmailButton);
            Controls.Add(resendCodeLabel);
            Controls.Add(resendCodeLinkLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmailValidationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt";
            Load += EmailValidationForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label validationCodeLabel;
        private RichTextBox informativeRichText;

        private RichTextBox validationCodeRichBox;
        private Label timerValidationLabel;
        private Label errorValidationLabel;

        private Button validateEmailButton;

        private Label resendCodeLabel;
        private LinkLabel resendCodeLinkLabel;
    }
}