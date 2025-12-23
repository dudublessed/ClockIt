using ClockIt.src.Presentation.Visual;

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
            userPanelLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            userPanelLabel.ForeColor = Color.FromArgb(17, 24, 39);
            userPanelLabel.Location = new Point(150, 36);
            userPanelLabel.Name = "userPanelLabel";
            userPanelLabel.Size = new Size(500, 22);
            userPanelLabel.TabIndex = 5;
            userPanelLabel.Text = "NOME DE PESSOA TESTE ABODABI";
            userPanelLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.FromArgb(229, 231, 235);
            leftPanel.BorderStyle = BorderStyle.FixedSingle;
            leftPanel.Controls.Add(userTodayClockInsLabel);
            leftPanel.Controls.Add(entryRecordLabel);
            leftPanel.Controls.Add(lunchEntryRecordLabel);
            leftPanel.Controls.Add(lunchExitRecordLabel);
            leftPanel.Controls.Add(exitRecordLabel);
            leftPanel.Location = new Point(121, 132);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(249, 212);
            leftPanel.TabIndex = 7;
            // 
            // userTodayClockInsLabel
            // 
            userTodayClockInsLabel.BackColor = Color.Transparent;
            userTodayClockInsLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            userTodayClockInsLabel.ForeColor = Color.FromArgb(17, 24, 39);
            userTodayClockInsLabel.Location = new Point(25, 15);
            userTodayClockInsLabel.Name = "userTodayClockInsLabel";
            userTodayClockInsLabel.Size = new Size(200, 22);
            userTodayClockInsLabel.TabIndex = 8;
            userTodayClockInsLabel.Text = "Marcações de Hoje";
            userTodayClockInsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // entryRecordLabel
            // 
            entryRecordLabel.BackColor = Color.Transparent;
            entryRecordLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            entryRecordLabel.ForeColor = Color.FromArgb(26, 115, 232);
            entryRecordLabel.Location = new Point(41, 60);
            entryRecordLabel.Name = "entryRecordLabel";
            entryRecordLabel.Size = new Size(165, 22);
            entryRecordLabel.TabIndex = 9;
            entryRecordLabel.Text = "00:00:00";
            entryRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lunchEntryRecordLabel
            // 
            lunchEntryRecordLabel.BackColor = Color.Transparent;
            lunchEntryRecordLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lunchEntryRecordLabel.ForeColor = Color.FromArgb(26, 115, 232);
            lunchEntryRecordLabel.Location = new Point(41, 90);
            lunchEntryRecordLabel.Name = "lunchEntryRecordLabel";
            lunchEntryRecordLabel.Size = new Size(165, 22);
            lunchEntryRecordLabel.TabIndex = 9;
            lunchEntryRecordLabel.Text = "00:00:00";
            lunchEntryRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lunchExitRecordLabel
            // 
            lunchExitRecordLabel.BackColor = Color.Transparent;
            lunchExitRecordLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lunchExitRecordLabel.ForeColor = Color.FromArgb(26, 115, 232);
            lunchExitRecordLabel.Location = new Point(41, 120);
            lunchExitRecordLabel.Name = "lunchExitRecordLabel";
            lunchExitRecordLabel.Size = new Size(165, 22);
            lunchExitRecordLabel.TabIndex = 9;
            lunchExitRecordLabel.Text = "00:00:00";
            lunchExitRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // exitRecordLabel
            // 
            exitRecordLabel.BackColor = Color.Transparent;
            exitRecordLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            exitRecordLabel.ForeColor = Color.FromArgb(26, 115, 232);
            exitRecordLabel.Location = new Point(41, 150);
            exitRecordLabel.Name = "exitRecordLabel";
            exitRecordLabel.Size = new Size(165, 22);
            exitRecordLabel.TabIndex = 9;
            exitRecordLabel.Text = "00:00:00";
            exitRecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(229, 231, 235);
            rightPanel.BorderStyle = BorderStyle.FixedSingle;
            rightPanel.Controls.Add(actualDateLabel);
            rightPanel.Controls.Add(clockInButton);
            rightPanel.Controls.Add(actualHourLabel);
            rightPanel.Location = new Point(422, 132);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(249, 212);
            rightPanel.TabIndex = 9;
            // 
            // actualDateLabel
            // 
            actualDateLabel.BackColor = Color.Transparent;
            actualDateLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            actualDateLabel.ForeColor = Color.FromArgb(26, 115, 232);
            actualDateLabel.Location = new Point(37, 45);
            actualDateLabel.Name = "actualDateLabel";
            actualDateLabel.Size = new Size(175, 27);
            actualDateLabel.TabIndex = 10;
            actualDateLabel.Text = "Seg., 01 Jan. 2025";
            actualDateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // actualHourLabel
            // 
            actualHourLabel.BackColor = Color.Transparent;
            actualHourLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            actualHourLabel.ForeColor = Color.FromArgb(26, 115, 232);
            actualHourLabel.Location = new Point(75, 85);
            actualHourLabel.Name = "actualHourLabel";
            actualHourLabel.Size = new Size(100, 30);
            actualHourLabel.TabIndex = 11;
            actualHourLabel.Text = "00:00:00";
            actualHourLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clockInButton
            // 
            clockInButton.BackColor = Color.FromArgb(26, 115, 232);
            clockInButton.Cursor = Cursors.Hand;
            clockInButton.FlatStyle = FlatStyle.Flat;
            clockInButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clockInButton.ForeColor = Color.WhiteSmoke;
            clockInButton.Location = new Point(27, 145);
            clockInButton.Name = "clockInButton";
            clockInButton.Size = new Size(200, 30);
            clockInButton.TabIndex = 12;
            clockInButton.Text = "Marcar ponto";
            clockInButton.UseVisualStyleBackColor = true;
            clockInButton.Click += RegisterRecord;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(229, 231, 235);
            ClientSize = new Size(800, 429);
            Controls.Add(userPanelLabel);
            Controls.Add(leftPanel);
            Controls.Add(rightPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EmployeeMainForm";
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