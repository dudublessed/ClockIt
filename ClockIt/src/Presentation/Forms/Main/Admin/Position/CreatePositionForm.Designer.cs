namespace ClockIt.src.Presentation.Forms.Main.Admin.Position
{
    partial class CreatePositionForm
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
            createPositionFormTitle = new Label();
            positionNameLabel = new Label();
            positionNameTextBox = new TextBox();
            positionDescriptionLabel = new Label();
            positionDescriptionTextBox = new TextBox();
            createPositionButton = new Button();
            SuspendLayout();
            // 
            // createPositionFormTitle
            // 
            createPositionFormTitle.BackColor = this.BackColor;
            createPositionFormTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            createPositionFormTitle.Location = new Point(122, 19);
            createPositionFormTitle.Name = "createPositionFormTitle";
            createPositionFormTitle.Size = new Size(190, 20);
            createPositionFormTitle.TabIndex = 4;
            createPositionFormTitle.Text = "Cadastro de Cargo";
            // 
            // positionNameLabel
            // 
            positionNameLabel.BackColor = this.BackColor;
            positionNameLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            positionNameLabel.Location = new Point(122, 71);
            positionNameLabel.Name = "positionNameLabel";
            positionNameLabel.Size = new Size(165, 18);
            positionNameLabel.TabIndex = 6;
            positionNameLabel.Text = "Nome: ";
            // 
            // positionNameTextBox
            // 
            positionNameTextBox.BackColor = Color.FromArgb(250, 250, 250);
            positionNameTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            positionNameTextBox.Location = new Point(122, 92);
            positionNameTextBox.MaxLength = 23;
            positionNameTextBox.Name = "positionNameTextBox";
            positionNameTextBox.Size = new Size(200, 23);
            positionNameTextBox.TabIndex = 5;
            // 
            // positionDescriptionLabel
            // 
            positionDescriptionLabel.BackColor = this.BackColor;
            positionDescriptionLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            positionDescriptionLabel.Location = new Point(122, 135);
            positionDescriptionLabel.Name = "positionDescriptionLabel";
            positionDescriptionLabel.Size = new Size(165, 18);
            positionDescriptionLabel.TabIndex = 6;
            positionDescriptionLabel.Text = "Descrição (Opcional):";
            // 
            // positionDescriptionTextBox
            // 
            positionDescriptionTextBox.BackColor = Color.FromArgb(250, 250, 250);
            positionDescriptionTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            positionDescriptionTextBox.Location = new Point(122, 156);
            positionDescriptionTextBox.MaxLength = 23;
            positionDescriptionTextBox.Name = "positionDescriptionTextBox";
            positionDescriptionTextBox.Size = new Size(200, 23);
            positionDescriptionTextBox.TabIndex = 5;
            // 
            // createPositionButton
            // 
            createPositionButton.BackColor = Color.FromArgb(250, 250, 250);
            createPositionButton.Cursor = Cursors.Hand;
            createPositionButton.Font = new Font("Arial", 9F, FontStyle.Bold);
            createPositionButton.Location = new Point(122, 213);
            createPositionButton.Name = "createPositionButton";
            createPositionButton.Size = new Size(200, 30);
            createPositionButton.TabIndex = 7;
            createPositionButton.Text = "Criar Cargo";
            createPositionButton.UseVisualStyleBackColor = false;
            createPositionButton.Click += CreatePosition;
            // 
            // CreatePositionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(429, 268);
            Controls.Add(createPositionFormTitle);
            Controls.Add(positionNameLabel);
            Controls.Add(positionNameTextBox);
            Controls.Add(positionDescriptionLabel);
            Controls.Add(positionDescriptionTextBox);
            Controls.Add(createPositionButton);
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrator - Create Position";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createPositionFormTitle;
        private Label positionNameLabel;
        private TextBox positionNameTextBox;
        private Label positionDescriptionLabel;
        private TextBox positionDescriptionTextBox;
        private Button createPositionButton;
    }
}