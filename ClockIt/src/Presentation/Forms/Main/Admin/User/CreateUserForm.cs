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

namespace ClockIt.src.Presentation.Forms.Main.Admin.User
{
    public partial class CreateUserForm : Form, ICreateUserForm
    {
        public string UserName => userNameTextBox.Text;
        public string Login => userNameTextBox.Text.Split(' ', 2)[0].ToUpper();
        public string UserPassword => userPasswordTextBox.Text;

        public event EventHandler UserNameInputValidationRequested;
        public event EventHandler UserPasswordInputValidationRequested;

        public event EventHandler CreateUserRequested;

        public CreateUserForm()
        {
            InitializeComponent();
            InitializeInputValidation();
        }

        private void InitializeInputValidation()
        {
            ValidateUserNameInput();
            ValidateUserPasswordInput();
        }

        private void ValidateUserNameInput()
        {
            userNameTextBox.Leave += (s, e) => UserNameInputValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.Leave));
        }

        private void ValidateUserPasswordInput()
        {
            // Implementar validação em forma de texto na UI para mostrar o padrão de senha esperado
            // 
            // userPasswordTextBox.TextChanged += (s, e) => UserPasswordInputValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.TextChanged));
            userPasswordTextBox.Leave += (s, e) => UserPasswordInputValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.Leave));
        }

        private void CreateUser(object sender, EventArgs e)
        {
            CreateUserRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
