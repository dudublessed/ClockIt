using ClockIt.src.Presentation.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockIt.src.Presentation.Forms.Main.Admin.Position
{
    public partial class CreatePositionForm : Form, ICreatePositionForm
    {
        public string PositionName => positionNameTextBox.Text.Trim();
        public string Description => positionDescriptionTextBox.Text.Trim();

        public event Func<object, EventArgs, Task> CreatePositionRequested;

        public CreatePositionForm()
        {
            InitializeComponent();
        }

        private async void CreatePosition(object sender, EventArgs e)
        {
            await CreatePositionRequested.Invoke(this, EventArgs.Empty);
        }

        public void CleanUserInputFields()
        {
            positionNameTextBox.Text = "";
            positionDescriptionTextBox.Text = "";
        }
    }
}
