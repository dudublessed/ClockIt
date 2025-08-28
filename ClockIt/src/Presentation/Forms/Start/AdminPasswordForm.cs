using ClockIt.src.Core.Constants;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClockIt.src.Presentation.Forms.Start
{
    public partial class AdminPasswordForm : Form, IAdminPasswordForm
    {
        public string Password => enterAdminPasswordText.Text;
        public string ConfirmPassword => confirmAdminPasswordText.Text;

        public bool ForceCloseMainForm { get; private set; } = false;

        private Dictionary<Control, Point> originalFieldsLocations = new Dictionary<Control, Point>();

        private Size enterPasswordErrorLabelSize;
        private Size originalClientSize;

        public event EventHandler UpdateAdminPasswordRequested;

        public event EventHandler<TriggeredByEventArgs> FirstPasswordValidationRequested;
        public event EventHandler<TriggeredByEventArgs> SecondPasswordValidationRequested;

        public AdminPasswordForm()
        {
            InitializeComponent();
        }

        private void AdminPasswordForm_Load(object sender, EventArgs e)
        {
            originalFieldsLocations[confirmAdminPasswordLabel] = confirmAdminPasswordLabel.Location;
            originalFieldsLocations[confirmAdminPasswordText] = confirmAdminPasswordText.Location;
            originalFieldsLocations[confirmPasswordErrorLabel] = confirmPasswordErrorLabel.Location;
            originalFieldsLocations[updatePasswordButton] = updatePasswordButton.Location;
            originalFieldsLocations[secondViewPassword] = secondViewPassword.Location;

            enterPasswordErrorLabelSize = enterPasswordErrorLabel.Size;
            originalClientSize = this.ClientSize;

            ValidatePasswordInput();
        }

        private void AdminPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                var confirm = MessageBoxHelper.ShowLeave("Tem certeza que deseja sair sem alterar a senha?");

                if (confirm == DialogResult.No)
                {
                    e.Cancel = true;
                } else
                {
                    ForceCloseMainForm = true;
                }
            }
        }

        public void SetPasswordMessageAndShowError(string errorMessage)
        {
            SetPasswordErrorLabelMessage(errorMessage);
            ShowFirstPasswordError();
        }

        public void SetConfirmPasswordMessageAndShowError(string errorMessage)
        {
            SetConfirmPasswordErrorLabelMessage(errorMessage);
            ShowSecondPasswordError();
        }

        private void SetPasswordErrorLabelMessage(string errorMessage)
        {
            enterPasswordErrorLabel.Text = errorMessage;
        }

        private void SetConfirmPasswordErrorLabelMessage(string errorMessage)
        {
            confirmPasswordErrorLabel.Text = errorMessage;
        }

        private void ShowFirstPasswordError()
        {
            enterPasswordErrorLabel.Show();
        }

        private void ShowSecondPasswordError()
        {
            confirmPasswordErrorLabel.Show();
        }

        public void HideFirstPasswordError()
        {
            enterPasswordErrorLabel.Hide();
        }

        public void HideSecondPasswordError()
        {
            confirmPasswordErrorLabel.Hide();
        }

        private void UpdateAdminPassword(object sender, EventArgs e)
        {
            UpdateAdminPasswordRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ControlPasswordView(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            bool isFirstViewButton = (btn.Name == "firstViewPassword");
            TextBox textbox = (isFirstViewButton)
                ? enterAdminPasswordText
                : confirmAdminPasswordText;

            bool isPasswordHidden = textbox.UseSystemPasswordChar;

            textbox.UseSystemPasswordChar = (isPasswordHidden == true) ? false : true;
        }

        private void ValidatePasswordInput()
        {
            confirmAdminPasswordText.TextChanged += (s, e) => SecondPasswordValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.TextChanged));
            confirmAdminPasswordText.Leave += (s, e) => SecondPasswordValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.Leave));

            enterAdminPasswordText.TextChanged += (s, e) => FirstPasswordValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.TextChanged));
            enterAdminPasswordText.Leave += (s, e) => FirstPasswordValidationRequested?.Invoke(this, new TriggeredByEventArgs(ValidationTrigger.Leave));
        }

        public void AdjustFormLayout(bool hasError, int adjustOffset)
        {
            int offset = hasError ? adjustOffset : 0;

            confirmAdminPasswordLabel.Location = new Point(
                originalFieldsLocations[confirmAdminPasswordLabel].X,
                originalFieldsLocations[confirmAdminPasswordLabel].Y + offset);

            confirmAdminPasswordText.Location = new Point(
                originalFieldsLocations[confirmAdminPasswordText].X,
                originalFieldsLocations[confirmAdminPasswordText].Y + offset);

            confirmPasswordErrorLabel.Location = new Point(
                originalFieldsLocations[confirmPasswordErrorLabel].X,
                originalFieldsLocations[confirmPasswordErrorLabel].Y + offset);

            updatePasswordButton.Location = new Point(
                originalFieldsLocations[updatePasswordButton].X,
                originalFieldsLocations[updatePasswordButton].Y + offset);

            secondViewPassword.Location = new Point(
                originalFieldsLocations[secondViewPassword].X,
                originalFieldsLocations[secondViewPassword].Y + offset);

            bool isAdjustLow = offset < 10;

            int normalHeight = 34;
            int minimalHeight = 17;
            int enterPasswordErrorLabelHeight = (isAdjustLow) ? minimalHeight : normalHeight;

            enterPasswordErrorLabel.Size = new Size(
                enterPasswordErrorLabel.Width,
                enterPasswordErrorLabelHeight);

            ClientSize = new Size(originalClientSize.Width, originalClientSize.Height + offset);
        }
    }
}
