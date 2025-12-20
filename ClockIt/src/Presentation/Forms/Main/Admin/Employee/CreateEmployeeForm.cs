using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Forms.Main.Admin.Employee
{
    public partial class CreateEmployeeForm : Form, ICreateEmployeeForm
    {
        public string UserName => employeeUserCombo.SelectedItem?.ToString() ?? string.Empty;
        public string FullName => employeeNameTextBox.Text.ToUpper().Trim();
        public string CPF => employeeCPFTextBox.Text.Trim();
        public DateTime BirthDate => employeeBirthDatePicker.Value;
        public string Email => employeeEmailTextBox.Text.Trim();
        public string Position => employeePositionCombo.SelectedItem?.ToString() ?? string.Empty;
        public DateTime EntryTime => employeeEntryTimeDatePicker.Value;
        public DateTime LunchEntryTime => employeeLunchEntryTimeDatePicker.Value;
        public DateTime LunchExitTime => employeeLunchExitTimeDatePicker.Value;
        public DateTime ExitTime => employeeExitTimeDatePicker.Value;

        public event EventHandler EnterpriseUsersRequested;
        public event EventHandler EnterprisePositionsRequested;

        public event EventHandler EmployeeNameInputValidationRequested;
        public event EventHandler CpfInputValidationRequested;
        public event EventHandler BirthDateInputValidationRequested;
        public event EventHandler EmailInputValidationRequested;
        public event EventHandler PositionInputValidationRequested;
        public event EventHandler EntryTimeInputValidationRequested;
        public event EventHandler LunchEntryTimeInputValidationRequested;
        public event EventHandler LunchExitTimeInputValidationRequested;
        public event EventHandler ExitTimeInputValidationRequested;

        public event EventHandler CreateEmployeeRequested;

        public List<ShowUsersDTO> EnterpriseUsers { get; set; }
        public List<PositionModel> EnterprisePositions { get; set; }

        public CreateEmployeeForm()
        {
            InitializeComponent();
        }

        private void CreateEmployeeForm_Load(object sender, EventArgs e)
        {
            this.Shown += (s, e) => EnterpriseUsersRequested?.Invoke(this, EventArgs.Empty);
            this.Shown += (s, e) => EnterprisePositionsRequested?.Invoke(this, EventArgs.Empty);
        }

        public void ShowEnterpriseUsers()
        {
            employeeUserCombo.Items.Clear();
            employeeUserCombo.Items.AddRange(EnterpriseUsers.Select(s => s.UserName).ToArray());
            employeeUserCombo.SelectedIndex = -1;
        }

        public void ShowEnterprisePositions()
        {
            employeePositionCombo.Items.Clear();
            employeePositionCombo.Items.AddRange(EnterprisePositions.Select(s => s.Name).ToArray());
            employeePositionCombo.SelectedIndex = -1;
        }

        private void CreateEmployee(object sender, EventArgs e)
        {
            CreateEmployeeRequested?.Invoke(this, EventArgs.Empty);
        }

        public void CleanScreenInputs()
        {
            if (employeeUserCombo != null)
            {
                employeeUserCombo.SelectedIndex = -1;
                employeeUserCombo.SelectedItem = null;
                employeeUserCombo.Text = string.Empty; 
            }
            employeeNameTextBox.Text = "";
            employeeCPFTextBox.Text = "";
            employeeBirthDatePicker.Value = DateTime.Today;
            employeeEmailTextBox.Text = "";

            if (employeePositionCombo != null)
            {
                employeePositionCombo.SelectedIndex = -1;
                employeePositionCombo.SelectedItem = null;
                employeePositionCombo.Text = string.Empty;
            }

            employeeEntryTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            employeeLunchEntryTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            employeeLunchExitTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
            employeeExitTimeDatePicker.Value = new DateTime(2025, 10, 30, 0, 0, 0, 0);
        }
    }
}
