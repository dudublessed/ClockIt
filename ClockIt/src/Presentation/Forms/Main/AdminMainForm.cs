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


namespace ClockIt.src.Presentation.Forms.Main
{
    public partial class AdminMainForm : Form, IAdminMainForm
    {
        public event EventHandler FormShown;
        public event EventHandler UserSectionRequested;
        public event EventHandler EmployeeSectionRequested;
        public event EventHandler SettingsSectionRequested;

        public AdminMainForm()
        {
            InitializeComponent();

            this.Shown += (s, e) => FormShown?.Invoke(this, EventArgs.Empty);
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void userButtonClicked(object sender, EventArgs e)
        {
            UnselectAllVisually();
            this.Click += (s, e) => UserSectionRequested?.Invoke(this, EventArgs.Empty);
            userButton.BackColor = Color.LightGray;
            topSectionLine.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void employeeButtonClicked(object sender, EventArgs e)
        {
            UnselectAllVisually();
            this.Click += (s, e) => EmployeeSectionRequested?.Invoke(this, EventArgs.Empty);
            employeeButton.BackColor = Color.LightGray;
            topSectionLine.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void reportButtonClicked(object sender, EventArgs e)
        {
            UnselectAllVisually();
            this.Click += (s, e) => EmployeeSectionRequested?.Invoke(this, EventArgs.Empty);
            reportButton.BackColor = Color.LightGray;
            topSectionLine.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void settingsButtonClicked(object sender, EventArgs e)
        {
            UnselectAllVisually();
            this.Click += (s, e) => SettingsSectionRequested?.Invoke(this, EventArgs.Empty);
            settingsButton.BackColor = Color.LightGray;
            topSectionLine.BackColor = Color.FromArgb(220, 220, 220);
        }

        private void UnselectAllVisually()
        {
            userButton.BackColor = Color.Transparent;
            employeeButton.BackColor = Color.Transparent;
            settingsButton.BackColor = Color.Transparent;
        }

        public void ShowUserTopSection()
        {

        }

        public void ShowEmployeeTopSection()
        {

        }

        public void ShowSettingsTopSection()
        {

        }
    }
}
