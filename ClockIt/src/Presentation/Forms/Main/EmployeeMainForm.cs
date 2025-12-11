using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Shared.Utils;

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
            EntryRecord = TimeSpan.Zero;
            LunchEntryRecord = TimeSpan.Zero;
            LunchExitRecord = TimeSpan.Zero;
            ExitRecord = TimeSpan.Zero;

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

        private void RegisterTime(object sender, EventArgs e)
        {
            ClockIn?.Invoke(this, EventArgs.Empty);
        }

        public void ShowEntryRecord()
        {
            entryRecordLabel.Text = EntryRecord.ToString(@"hh\:mm\:ss");
            entryRecordLabel.Visible = true;
        }

        public void ShowLunchEntryRecord()
        {
            lunchEntryRecordLabel.Text = LunchEntryRecord.ToString(@"hh\:mm\:ss");
            lunchEntryRecordLabel.Visible = true;
        }

        public void ShowLunchExitRecord()
        {
            lunchExitRecordLabel.Text = LunchEntryRecord.ToString(@"hh\:mm\:ss");
            lunchExitRecordLabel.Visible = true;
        }

        public void ShowExitRecord()
        {
            exitRecordLabel.Text = LunchExitRecord.ToString(@"hh\:mm\:ss");
            exitRecordLabel.Visible = true;
        }

        public void DisableRecordButton()
        {
            clockInButton.Enabled = false;
            MessageBoxHelper.ShowInfo("Todos os registros do dia já foram efetuados");
        }
    }
}
