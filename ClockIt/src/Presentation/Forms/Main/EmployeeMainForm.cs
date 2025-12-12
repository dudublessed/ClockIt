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
        public DateTime EntryRecord { get; private set; }
        public DateTime LunchEntryRecord { get; private set; }
        public DateTime LunchExitRecord { get; private set; }
        public DateTime ExitRecord { get; private set; }

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
            EntryRecord = DateTime.MinValue;
            LunchEntryRecord = DateTime.MinValue;
            LunchExitRecord = DateTime.MinValue;
            ExitRecord = DateTime.MinValue;

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

        private void RegisterRecord(object sender, EventArgs e)
        {
            ClockIn?.Invoke(this, EventArgs.Empty);
        }

        public void ShowEmployeeTodayRecords(List<RecordDTO> employeeTodayRecords)
        {
            entryRecordLabel.Text = EntryRecord.ToString(@"hh\:mm\:ss");
            lunchEntryRecordLabel.Text = LunchEntryRecord.ToString(@"hh\:mm\:ss");
            lunchExitRecordLabel.Text = LunchExitRecord.ToString(@"hh\:mm\:ss");
            exitRecordLabel.Text = ExitRecord.ToString(@"hh\:mm\:ss");
            entryRecordLabel.Visible = true;
            lunchEntryRecordLabel.Visible = true;
            lunchExitRecordLabel.Visible = true;
            exitRecordLabel.Visible = true;
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
