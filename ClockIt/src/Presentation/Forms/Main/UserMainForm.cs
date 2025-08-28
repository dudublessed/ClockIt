using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.Presentation.Forms.Main
{
    public partial class UserMainForm : Form, IUserMainForm
    {
        public event EventHandler FormShown;

        public UserMainForm()
        {
            InitializeComponent();

            this.Shown += (s, e) => FormShown?.Invoke(this, EventArgs.Empty);
        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
