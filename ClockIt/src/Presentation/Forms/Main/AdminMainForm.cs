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
    public partial class AdminMainForm : Form, IAdminMainForm
    {
        public event EventHandler FormShown;

        public event EventHandler ShowCreateUserForm;
        public event EventHandler ShowViewUsersForm;
        public event EventHandler ShowUpdateUserForm;
        public event EventHandler ShowDeleteUserForm;

        public event EventHandler ShowCreatePositionForm;

        public event EventHandler ShowCreateEmployeeForm;

        public AdminMainForm()
        {
            InitializeComponent();

            this.Shown += (s, e) => FormShown?.Invoke(this, EventArgs.Empty);
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }

        private void showCreateUserForm(object sender, EventArgs e)
        {
            ShowCreateUserForm?.Invoke(this, EventArgs.Empty);
        }

        private void showCreatePositionForm(object sender, EventArgs e)
        {
            ShowCreatePositionForm?.Invoke(this, EventArgs.Empty);
        }

        private void showCreateEmployeeForm(object sender, EventArgs e)
        {
            ShowCreateEmployeeForm?.Invoke(this, EventArgs.Empty);
        }
    }
}
