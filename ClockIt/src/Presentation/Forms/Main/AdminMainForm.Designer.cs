namespace ClockIt.src.Presentation.Forms.Main
{
    partial class AdminMainForm
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
            leftSectionLine = new Panel();
            companyLabel = new Label();
            userButton = new Button();
            employeeButton = new Button();
            reportButton = new Button();
            settingsButton = new Button();
            topSectionLine = new Panel();
            createUserButton = new Button();
            updateUserButton = new Button();
            deleteUserButton = new Button();
            createEmployeeButton = new Button();
            updateEmployeeButton = new Button();
            deleteEmployeeButton = new Button();
            SuspendLayout();
            // 
            // leftSectionLine
            // 
            leftSectionLine.BackColor = Color.FromArgb(220, 220, 220);
            leftSectionLine.Location = new Point(210, 0);
            leftSectionLine.Name = "leftSectionLine";
            leftSectionLine.Size = new Size(2, 550);
            leftSectionLine.TabIndex = 0;
            // 
            // companyLabel
            // 
            companyLabel.BackColor = Color.Transparent;
            companyLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            companyLabel.ForeColor = Color.Black;
            companyLabel.Location = new Point(15, 15);
            companyLabel.Name = "companyLabel";
            companyLabel.Size = new Size(176, 45);
            companyLabel.TabIndex = 0;
            companyLabel.Text = "TEST / TEST LTDA";
            companyLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userButton
            // 
            userButton.BackColor = Color.Transparent;
            userButton.FlatAppearance.BorderSize = 0;
            userButton.FlatStyle = FlatStyle.Flat;
            userButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            userButton.Location = new Point(15, 200);
            userButton.Name = "userButton";
            userButton.Size = new Size(175, 25);
            userButton.TabIndex = 1;
            userButton.Text = "Usuário";
            userButton.UseVisualStyleBackColor = false;
            userButton.Click += userButtonClicked;
            // 
            // employeeButton
            // 
            employeeButton.BackColor = Color.Transparent;
            employeeButton.FlatAppearance.BorderSize = 0;
            employeeButton.FlatStyle = FlatStyle.Flat;
            employeeButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeButton.Location = new Point(15, 245);
            employeeButton.Name = "employeeButton";
            employeeButton.Size = new Size(175, 25);
            employeeButton.TabIndex = 2;
            employeeButton.Text = "Funcionário";
            employeeButton.UseVisualStyleBackColor = false;
            employeeButton.Click += employeeButtonClicked;
            // 
            // reportButton
            // 
            reportButton.BackColor = Color.Transparent;
            reportButton.FlatAppearance.BorderSize = 0;
            reportButton.FlatStyle = FlatStyle.Flat;
            reportButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            reportButton.Location = new Point(15, 290);
            reportButton.Name = "reportButton";
            reportButton.Size = new Size(175, 25);
            reportButton.TabIndex = 3;
            reportButton.Text = "Relatório";
            reportButton.UseVisualStyleBackColor = false;
            reportButton.Click += reportButtonClicked;
            // 
            // settingsButton
            // 
            settingsButton.BackColor = Color.Transparent;
            settingsButton.FlatAppearance.BorderSize = 0;
            settingsButton.FlatStyle = FlatStyle.Flat;
            settingsButton.Font = new Font("Arial", 10F, FontStyle.Bold);
            settingsButton.Location = new Point(15, 335);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(175, 25);
            settingsButton.TabIndex = 3;
            settingsButton.Text = "Configurações";
            settingsButton.UseVisualStyleBackColor = false;
            settingsButton.Click += settingsButtonClicked;
            // 
            // topSectionLine
            // 
            topSectionLine.BackColor = Color.Transparent;
            topSectionLine.Location = new Point(210, 60);
            topSectionLine.Name = "topSectionLine";
            topSectionLine.Size = new Size(690, 2);
            topSectionLine.TabIndex = 0;
            // 
            // AdminMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(900, 550);
            Controls.Add(leftSectionLine);
            Controls.Add(companyLabel);
            Controls.Add(userButton);
            Controls.Add(employeeButton);
            Controls.Add(reportButton);
            Controls.Add(settingsButton);
            Controls.Add(topSectionLine);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminMainForm";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt - Admin";
            Load += AdminMainForm_Load;
            ResumeLayout(false);
        }

        #endregion
        // Left Section
        private Panel leftSectionLine;

        private Label companyLabel;

        private Button userButton;
        private Button employeeButton;
        private Button reportButton;
        private Button settingsButton;

        // Top Section        
        private Panel topSectionLine;

        private Button createUserButton;
        private Button updateUserButton;
        private Button deleteUserButton;

        private Button createEmployeeButton;
        private Button updateEmployeeButton;
        private Button deleteEmployeeButton;
        private Button employeeRecordsButton;
    }
}