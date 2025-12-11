namespace ClockIt.src.Presentation.Forms.Main
{
    partial class EmployeeMainForm
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
            userPanelLabel = new Label();
            leftPanel = new Panel();
            userTodayClockInsLabel = new Label();
            entryRecordLabel = new Label();
            lunchEntryRecordLabel = new Label();
            lunchExitRecordLabel = new Label();
            exitRecordLabel = new Label();
            rightPanel = new Panel();
            actualDateLabel = new Label();
            clockInButton = new Button();
            actualHourLabel = new Label();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            SuspendLayout();
            // 
            // userPanelLabel
            // 
            userPanelLabel.BackColor = Color.Transparent;
            userPanelLabel.Font = new Font("Arial", 14F, FontStyle.Bold);
            userPanelLabel.Location = new Point(214, 36);
            userPanelLabel.Name = "userPanelLabel";
            userPanelLabel.Size = new Size(350, 22);
            userPanelLabel.TabIndex = 5;
            userPanelLabel.Text = "NOME DE PESSOA TESTE ABODABI";
            userPanelLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(userTodayClockInsLabel);
            leftPanel.Controls.Add(entryRecordLabel);
            leftPanel.Controls.Add(lunchEntryRecordLabel);
            leftPanel.Controls.Add(lunchExitRecordLabel);
            leftPanel.Controls.Add(exitRecordLabel);
            leftPanel.Location = new Point(121, 132);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(249, 212);
            leftPanel.BackColor = Color.WhiteSmoke;
            leftPanel.TabIndex = 7;
            // 
            // userTodayClockInsLabel
            // 
            userTodayClockInsLabel.BackColor = Color.Transparent;
            userTodayClockInsLabel.Font = new Font("Arial", 13F);
            userTodayClockInsLabel.Location = new Point(38, 15);
            userTodayClockInsLabel.Name = "userTodayClockInsLabel";
            userTodayClockInsLabel.Size = new Size(165, 22);
            userTodayClockInsLabel.TabIndex = 8;
            userTodayClockInsLabel.Text = "Marcações de Hoje";
            userTodayClockInsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // entryRecordLabel
            // 
            entryRecordLabel.BackColor = Color.Transparent;
            entryRecordLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            entryRecordLabel.ForeColor = Color.FromArgb(15, 100, 220);
            entryRecordLabel.Location = new Point(38, 60);
            entryRecordLabel.Name = "entryRecordLabel";
            entryRecordLabel.Size = new Size(165, 22);
            entryRecordLabel.TabIndex = 9;
            entryRecordLabel.Text = "00:00:00";
            entryRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lunchEntryRecordLabel
            // 
            lunchEntryRecordLabel.BackColor = Color.Transparent;
            lunchEntryRecordLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            lunchEntryRecordLabel.ForeColor = Color.FromArgb(15, 100, 220);
            lunchEntryRecordLabel.Location = new Point(38, 90);
            lunchEntryRecordLabel.Name = "lunchEntryRecordLabel";
            lunchEntryRecordLabel.Size = new Size(165, 22);
            lunchEntryRecordLabel.TabIndex = 9;
            lunchEntryRecordLabel.Text = "00:00:00";
            lunchEntryRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lunchExitRecordLabel
            // 
            lunchExitRecordLabel.BackColor = Color.Transparent;
            lunchExitRecordLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            lunchExitRecordLabel.ForeColor = Color.FromArgb(15, 100, 220);
            lunchExitRecordLabel.Location = new Point(38, 120);
            lunchExitRecordLabel.Name = "lunchExitRecordLabel";
            lunchExitRecordLabel.Size = new Size(165, 22);
            lunchExitRecordLabel.TabIndex = 9;
            lunchExitRecordLabel.Text = "00:00:00";
            lunchExitRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exitRecordLabel
            // 
            exitRecordLabel.BackColor = Color.Transparent;
            exitRecordLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            exitRecordLabel.ForeColor = Color.FromArgb(15, 100, 220);
            exitRecordLabel.Location = new Point(38, 150);
            exitRecordLabel.Name = "exitRecordLabel";
            exitRecordLabel.Size = new Size(165, 22);
            exitRecordLabel.TabIndex = 9;
            exitRecordLabel.Text = "00:00:00";
            exitRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(actualDateLabel);
            rightPanel.Controls.Add(clockInButton);
            rightPanel.Controls.Add(actualHourLabel);
            rightPanel.Location = new Point(435, 177);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(249, 117);
            rightPanel.BackColor = Color.WhiteSmoke;
            rightPanel.TabIndex = 9;
            // 
            // actualDateLabel
            // 
            actualDateLabel.BackColor = Color.Transparent;
            actualDateLabel.Font = new Font("Arial", 12F, FontStyle.Bold);
            actualDateLabel.ForeColor = Color.FromArgb(35, 125, 235);
            actualDateLabel.Location = new Point(40, 15);
            actualDateLabel.Name = "actualDateLabel";
            actualDateLabel.Size = new Size(175, 22);
            actualDateLabel.TabIndex = 10;
            actualDateLabel.Text = "Seg., 01 Jan. 2025";
            actualDateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // actualHourLabel
            // 
            actualHourLabel.BackColor = Color.Transparent;
            actualHourLabel.Font = new Font("Arial", 13F, FontStyle.Bold);
            actualHourLabel.ForeColor = Color.FromArgb(15, 100, 220);
            actualHourLabel.Location = new Point(82, 38);
            actualHourLabel.Name = "actualHourLabel";
            actualHourLabel.Size = new Size(90, 22);
            actualHourLabel.TabIndex = 11;
            actualHourLabel.Text = "00:00:00";
            actualHourLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clockInButton
            // 
            clockInButton.BackColor = Color.FromArgb(15, 100, 220);
            clockInButton.Cursor = Cursors.Hand;
            clockInButton.FlatStyle = FlatStyle.Flat;
            clockInButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clockInButton.ForeColor = Color.GhostWhite;
            clockInButton.Location = new Point(27, 74);
            clockInButton.Name = "clockInButton";
            clockInButton.Size = new Size(200, 30);
            clockInButton.TabIndex = 12;
            clockInButton.Text = "Marcar ponto";
            clockInButton.UseVisualStyleBackColor = false;
            clockInButton.Click += RegisterTime;
            // 
            // UserMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userPanelLabel);
            Controls.Add(leftPanel);
            Controls.Add(rightPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ClockIt - User Panel";
            Load += UserMainForm_Load;
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label userPanelLabel;
        private Panel leftPanel;
        private Label userTodayClockInsLabel;
        private Label entryRecordLabel;
        private Label lunchEntryRecordLabel;
        private Label lunchExitRecordLabel;
        private Label exitRecordLabel;
        private Panel rightPanel;
        private Label actualHourLabel;
        private Button clockInButton;
        private Label actualDateLabel;
    }
}