namespace ClockIt.src.Presentation.Forms.Main.Admin.Employee
{
    partial class CreateEmployeeForm
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
            employeeNameLabel = new Label();
            employeeNameTextBox = new TextBox();
            employeeCPFLabel = new Label();
            employeeCPFTextBox = new TextBox();
            employeeBirthLabel = new Label();
            employeeBirthDatePicker = new DateTimePicker();
            employeeEmailLabel = new Label();
            employeeEmailTextBox = new TextBox();
            employeePositionLabel = new Label();
            employeePositionCombo = new ComboBox();
            employeeEntryTimeLabel = new Label();
            employeeEntryTimeDatePicker = new DateTimePicker();
            employeeLunchEntryTimeLabel = new Label();
            employeeLunchEntryTimeDatePicker = new DateTimePicker();
            employeeLunchExitTimeLabel = new Label();
            employeeLunchExitTimeDatePicker = new DateTimePicker();
            employeeExitTimeLabel = new Label();
            employeeExitTimeDatePicker = new DateTimePicker();
            createEmployeeButton = new Button();
            employeeUserLabel = new Label();
            employeeUserCombo = new ComboBox();
            SuspendLayout();
            // 
            // createUserFormTitle
            // 
            createUserFormTitle.BackColor = Color.Transparent;
            createUserFormTitle.Font = new Font("Arial", 13F, FontStyle.Bold);
            createUserFormTitle.Location = new Point(98, 23);
            createUserFormTitle.Name = "createUserFormTitle";
            createUserFormTitle.Size = new Size(223, 20);
            createUserFormTitle.TabIndex = 13;
            createUserFormTitle.Text = "Cadastro de Funcionário";
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.BackColor = Color.Transparent;
            employeeNameLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeNameLabel.Location = new Point(112, 133);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new Size(140, 18);
            employeeNameLabel.TabIndex = 10;
            employeeNameLabel.Text = "Nome Completo: ";
            // 
            // employeeNameTextBox
            // 
            employeeNameTextBox.BackColor = Color.FromArgb(250, 250, 250);
            employeeNameTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeNameTextBox.Location = new Point(112, 154);
            employeeNameTextBox.MaxLength = 75;
            employeeNameTextBox.Name = "employeeNameTextBox";
            employeeNameTextBox.Size = new Size(200, 23);
            employeeNameTextBox.TabIndex = 8;
            // 
            // employeeCPFLabel
            // 
            employeeCPFLabel.BackColor = Color.Transparent;
            employeeCPFLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeCPFLabel.Location = new Point(112, 195);
            employeeCPFLabel.Name = "employeeCPFLabel";
            employeeCPFLabel.Size = new Size(140, 18);
            employeeCPFLabel.TabIndex = 11;
            employeeCPFLabel.Text = "CPF: ";
            // 
            // employeeCPFTextBox
            // 
            employeeCPFTextBox.BackColor = Color.FromArgb(250, 250, 250);
            employeeCPFTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeCPFTextBox.Location = new Point(112, 216);
            employeeCPFTextBox.MaxLength = 23;
            employeeCPFTextBox.Name = "employeeCPFTextBox";
            employeeCPFTextBox.Size = new Size(200, 23);
            employeeCPFTextBox.TabIndex = 9;
            // 
            // employeeBirthLabel
            // 
            employeeBirthLabel.BackColor = Color.Transparent;
            employeeBirthLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeBirthLabel.Location = new Point(112, 259);
            employeeBirthLabel.Name = "employeeBirthLabel";
            employeeBirthLabel.Size = new Size(155, 18);
            employeeBirthLabel.TabIndex = 15;
            employeeBirthLabel.Text = "Data de Nascimento:";
            // 
            // employeeBirthDatePicker
            // 
            employeeBirthDatePicker.BackColor = Color.FromArgb(250, 250, 250);
            employeeBirthDatePicker.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeBirthDatePicker.Format = DateTimePickerFormat.Short;
            employeeBirthDatePicker.Location = new Point(112, 280);
            employeeBirthDatePicker.Name = "employeeBirthDatePicker";
            employeeBirthDatePicker.Size = new Size(200, 23);
            employeeBirthDatePicker.TabIndex = 14;
            // 
            // employeeEmailLabel
            // 
            employeeEmailLabel.BackColor = Color.Transparent;
            employeeEmailLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeEmailLabel.Location = new Point(112, 326);
            employeeEmailLabel.Name = "employeeEmailLabel";
            employeeEmailLabel.Size = new Size(155, 18);
            employeeEmailLabel.TabIndex = 17;
            employeeEmailLabel.Text = "Email:";
            // 
            // employeeEmailTextBox
            // 
            employeeEmailTextBox.BackColor = Color.FromArgb(250, 250, 250);
            employeeEmailTextBox.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeEmailTextBox.Location = new Point(112, 347);
            employeeEmailTextBox.MaxLength = 75;
            employeeEmailTextBox.Name = "employeeEmailTextBox";
            employeeEmailTextBox.Size = new Size(200, 23);
            employeeEmailTextBox.TabIndex = 16;
            // 
            // employeePositionLabel
            // 
            employeePositionLabel.BackColor = Color.Transparent;
            employeePositionLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeePositionLabel.Location = new Point(112, 394);
            employeePositionLabel.Name = "employeePositionLabel";
            employeePositionLabel.Size = new Size(155, 18);
            employeePositionLabel.TabIndex = 19;
            employeePositionLabel.Text = "Cargo:";
            // 
            // employeePositionCombo
            // 
            employeePositionCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            employeePositionCombo.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeePositionCombo.Location = new Point(112, 415);
            employeePositionCombo.MaxLength = 23;
            employeePositionCombo.Name = "employeePositionCombo";
            employeePositionCombo.Size = new Size(200, 24);
            employeePositionCombo.TabIndex = 18;
            // 
            // employeeEntryTimeLabel
            // 
            employeeEntryTimeLabel.BackColor = Color.Transparent;
            employeeEntryTimeLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeEntryTimeLabel.Location = new Point(112, 458);
            employeeEntryTimeLabel.Name = "employeeEntryTimeLabel";
            employeeEntryTimeLabel.Size = new Size(155, 18);
            employeeEntryTimeLabel.TabIndex = 21;
            employeeEntryTimeLabel.Text = "Horário de Entrada:";
            // 
            // employeeEntryTimeDatePicker
            // 
            employeeEntryTimeDatePicker.BackColor = Color.FromArgb(250, 250, 250);
            employeeEntryTimeDatePicker.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeEntryTimeDatePicker.Format = DateTimePickerFormat.Time;
            employeeEntryTimeDatePicker.Location = new Point(112, 479);
            employeeEntryTimeDatePicker.Name = "employeeEntryTimeDatePicker";
            employeeEntryTimeDatePicker.ShowUpDown = true;
            employeeEntryTimeDatePicker.Size = new Size(200, 23);
            employeeEntryTimeDatePicker.TabIndex = 20;
            employeeEntryTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            // 
            // employeeLunchEntryTimeLabel
            // 
            employeeLunchEntryTimeLabel.BackColor = Color.Transparent;
            employeeLunchEntryTimeLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeLunchEntryTimeLabel.Location = new Point(112, 521);
            employeeLunchEntryTimeLabel.Name = "employeeLunchEntryTimeLabel";
            employeeLunchEntryTimeLabel.Size = new Size(220, 18);
            employeeLunchEntryTimeLabel.TabIndex = 21;
            employeeLunchEntryTimeLabel.Text = "Horário de Entrada do Almoço:";
            // 
            // employeeLunchEntryTimeDatePicker
            // 
            employeeLunchEntryTimeDatePicker.BackColor = Color.FromArgb(250, 250, 250);
            employeeLunchEntryTimeDatePicker.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeLunchEntryTimeDatePicker.Format = DateTimePickerFormat.Time;
            employeeLunchEntryTimeDatePicker.Location = new Point(112, 542);
            employeeLunchEntryTimeDatePicker.Name = "employeeLunchEntryTimeDatePicker";
            employeeLunchEntryTimeDatePicker.ShowUpDown = true;
            employeeLunchEntryTimeDatePicker.Size = new Size(200, 23);
            employeeLunchEntryTimeDatePicker.TabIndex = 20;
            employeeLunchEntryTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            // 
            // employeeLunchExitTimeLabel
            // 
            employeeLunchExitTimeLabel.BackColor = Color.Transparent;
            employeeLunchExitTimeLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeLunchExitTimeLabel.Location = new Point(112, 584);
            employeeLunchExitTimeLabel.Name = "employeeLunchExitTimeLabel";
            employeeLunchExitTimeLabel.Size = new Size(205, 18);
            employeeLunchExitTimeLabel.TabIndex = 21;
            employeeLunchExitTimeLabel.Text = "Horário de Saída do Almoço:";
            // 
            // employeeLunchExitTimeDatePicker
            // 
            employeeLunchExitTimeDatePicker.BackColor = Color.FromArgb(250, 250, 250);
            employeeLunchExitTimeDatePicker.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeLunchExitTimeDatePicker.Format = DateTimePickerFormat.Time;
            employeeLunchExitTimeDatePicker.Location = new Point(112, 605);
            employeeLunchExitTimeDatePicker.Name = "employeeLunchExitTimeDatePicker";
            employeeLunchExitTimeDatePicker.ShowUpDown = true;
            employeeLunchExitTimeDatePicker.Size = new Size(200, 23);
            employeeLunchExitTimeDatePicker.TabIndex = 20;
            employeeLunchExitTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            // 
            // employeeExitTimeLabel
            // 
            employeeExitTimeLabel.BackColor = Color.Transparent;
            employeeExitTimeLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeExitTimeLabel.Location = new Point(112, 647);
            employeeExitTimeLabel.Name = "employeeExitTimeLabel";
            employeeExitTimeLabel.Size = new Size(155, 18);
            employeeExitTimeLabel.TabIndex = 23;
            employeeExitTimeLabel.Text = "Horário de Saída:";
            // 
            // employeeExitTimeDatePicker
            // 
            employeeExitTimeDatePicker.BackColor = Color.FromArgb(250, 250, 250);
            employeeExitTimeDatePicker.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeExitTimeDatePicker.Format = DateTimePickerFormat.Time;
            employeeExitTimeDatePicker.Location = new Point(112, 668);
            employeeExitTimeDatePicker.Name = "employeeExitTimeDatePicker";
            employeeExitTimeDatePicker.ShowUpDown = true;
            employeeExitTimeDatePicker.Size = new Size(200, 23);
            employeeExitTimeDatePicker.TabIndex = 22;
            employeeExitTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            // 
            // createEmployeeButton
            // 
            createEmployeeButton.BackColor = Color.FromArgb(250, 250, 250);
            createEmployeeButton.Cursor = Cursors.Hand;
            createEmployeeButton.Font = new Font("Arial", 9F, FontStyle.Bold);
            createEmployeeButton.Location = new Point(112, 720);
            createEmployeeButton.Name = "createEmployeeButton";
            createEmployeeButton.Size = new Size(200, 30);
            createEmployeeButton.TabIndex = 12;
            createEmployeeButton.Text = "Criar Funcionário";
            createEmployeeButton.UseVisualStyleBackColor = false;
            createEmployeeButton.Click += CreateEmployee;
            // 
            // employeeUserLabel
            // 
            employeeUserLabel.BackColor = Color.Transparent;
            employeeUserLabel.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeUserLabel.Location = new Point(112, 71);
            employeeUserLabel.Name = "employeeUserLabel";
            employeeUserLabel.Size = new Size(155, 18);
            employeeUserLabel.TabIndex = 25;
            employeeUserLabel.Text = "Usuário:";
            // 
            // employeeUserCombo
            // 
            employeeUserCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            employeeUserCombo.Font = new Font("Arial", 10F, FontStyle.Bold);
            employeeUserCombo.Location = new Point(112, 92);
            employeeUserCombo.MaxLength = 23;
            employeeUserCombo.Name = "employeeUserCombo";
            employeeUserCombo.Size = new Size(200, 24);
            employeeUserCombo.TabIndex = 24;
            // 
            // CreateEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(430, 770);
            Controls.Add(employeeUserLabel);
            Controls.Add(employeeUserCombo);
            Controls.Add(createUserFormTitle);
            Controls.Add(employeeNameLabel);
            Controls.Add(employeeNameTextBox);
            Controls.Add(employeeCPFLabel);
            Controls.Add(employeeCPFTextBox);
            Controls.Add(employeeBirthLabel);
            Controls.Add(employeeBirthDatePicker);
            Controls.Add(employeeEmailLabel);
            Controls.Add(employeeEmailTextBox);
            Controls.Add(employeePositionLabel);
            Controls.Add(employeePositionCombo);
            Controls.Add(employeeEntryTimeLabel);
            Controls.Add(employeeEntryTimeDatePicker);
            Controls.Add(employeeLunchEntryTimeLabel);
            Controls.Add(employeeLunchEntryTimeDatePicker);
            Controls.Add(employeeLunchExitTimeLabel);
            Controls.Add(employeeLunchExitTimeDatePicker);
            Controls.Add(employeeExitTimeLabel);
            Controls.Add(employeeExitTimeDatePicker);
            Controls.Add(createEmployeeButton);
            MaximizeBox = false;
            Name = "CreateEmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrator - Create Employee";
            Load += CreateEmployeeForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label createUserFormTitle;

        private Label employeeUserLabel;
        private ComboBox employeeUserCombo;
        private Label employeeNameLabel;
        private TextBox employeeNameTextBox;
        private Label employeeCPFLabel;
        private TextBox employeeCPFTextBox;
        private Label employeeBirthLabel;
        private DateTimePicker employeeBirthDatePicker;
        private Label employeeEmailLabel;
        private TextBox employeeEmailTextBox;
        private Label employeePositionLabel;
        private ComboBox employeePositionCombo;
        private Label employeeEntryTimeLabel;
        private DateTimePicker employeeEntryTimeDatePicker;
        private Label employeeLunchEntryTimeLabel;
        private DateTimePicker employeeLunchEntryTimeDatePicker;
        private Label employeeExitTimeLabel;
        private DateTimePicker employeeExitTimeDatePicker;
        private Label employeeLunchExitTimeLabel;
        private DateTimePicker employeeLunchExitTimeDatePicker;

        private Button createEmployeeButton;
    }
}