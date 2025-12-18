using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockIt.src.Presentation.Forms.Main
{
    public partial class EmployeeMainForm : Form, IEmployeeMainForm
    {
        public TimeSpan EntryRecord { get; private set; }
        public TimeSpan LunchEntryRecord { get; private set; }
        public TimeSpan LunchExitRecord { get; private set; }
        public TimeSpan ExitRecord { get; private set; }

        private System.Windows.Forms.Timer hourTimer;

        public event EventHandler FormShown;
        public event EventHandler ClockIn;

        public EmployeeMainForm()
        {
            InitializeComponent();

            this.Shown += (s, e) => FormShown?.Invoke(this, EventArgs.Empty);
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            ResetTodayRecords();   
        }

        private void ResetTodayRecords()
        {
            EntryRecord = TimeSpan.MinValue;
            LunchEntryRecord = TimeSpan.MinValue;
            LunchExitRecord = TimeSpan.MinValue;
            ExitRecord = TimeSpan.MinValue;

            entryRecordLabel.Text = "00:00:00";
            entryRecordLabel.Visible = false;

            lunchEntryRecordLabel.Text = "00:00:00";
            lunchEntryRecordLabel.Visible = false;

            lunchExitRecordLabel.Text = "00:00:00";
            lunchExitRecordLabel.Visible = false;

            exitRecordLabel.Text = "00:00:00";
            exitRecordLabel.Visible = false;
        }

        public void StartHourTimer()
        {
            hourTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            hourTimer.Tick += (s, e) => UpdateDateTimeLabels();
            hourTimer.Start();

            UpdateDateTimeLabels();

            this.FormClosed += (s, e) =>
            {
                hourTimer?.Stop();
                hourTimer?.Dispose();
                hourTimer = null;
            };
        }

        private void UpdateDateTimeLabels()
        {
            actualDateLabel.Text = DateTime.Today.ToString("ddd, dd MMM yyyy");
            actualHourLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public void UpdateEmployeeNameLabel(string employeeName)
        {
            userPanelLabel.Text = employeeName;
        }

        private void RegisterRecord(object sender, EventArgs e)
        {
            ClockIn?.Invoke(this, EventArgs.Empty);
        }

        public void ShowEntryRecord(TimeSpan recordHour)
        {
            EntryRecord = recordHour;
            entryRecordLabel.Text = EntryRecord.ToString(@"hh\:mm\:ss");
            entryRecordLabel.Visible = true;
        }

        public void ShowLunchEntryRecord(TimeSpan recordHour)
        {
            LunchEntryRecord = recordHour;
            lunchEntryRecordLabel.Text = LunchEntryRecord.ToString(@"hh\:mm\:ss");
            lunchEntryRecordLabel.Visible = true;
        }

        public void ShowLunchExitRecord(TimeSpan recordHour)
        {
            LunchExitRecord = recordHour;
            lunchExitRecordLabel.Text = LunchExitRecord.ToString(@"hh\:mm\:ss");
            lunchExitRecordLabel.Visible = true;
        }

        public void ShowExitRecord(TimeSpan recordHour)
        {
            ExitRecord = recordHour;
            exitRecordLabel.Text = ExitRecord.ToString(@"hh\:mm\:ss");
            exitRecordLabel.Visible = true;
        }

        public void DisableRecordButton()
        {
            clockInButton.Enabled = false;
            clockInButton.BackColor = Color.Gray;

            MessageBoxHelper.ShowInfo("Todos os registros do dia já foram efetuados");
        }
    }
}
