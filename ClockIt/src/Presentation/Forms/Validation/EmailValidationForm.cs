using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using ClockIt.src.ApplicationLayer.Services;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Shared.Utils;
using ClockIt.src.Shared.DTOs.EmailDTOs;

namespace ClockIt.src.Presentation.Forms.Validation
{
    public partial class EmailValidationForm : Form, IEmailValidationForm
    {
        private Timer timer;
        private TimeSpan timeSpan;

        public string Email { get; private set; }
        public string Name { get; private set; }
        public string CodeInput => validationCodeRichBox.Text;

        public event EventHandler FormLoaded;
        public event EventHandler CodeSubmited;
        public event EventHandler NewCodeRequested;

        public EmailValidationForm()
        {
            InitializeComponent();

            this.Load += (s, e) => FormLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void EmailValidationForm_Load(object sender, EventArgs e)
        {

        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void AdjustFieldsOnVisual()
        {
            informativeRichText.SelectionAlignment = HorizontalAlignment.Center;

            validationCodeRichBox.SelectionAlignment = HorizontalAlignment.Center;

            resendCodeLinkLabel.DisabledLinkColor = Color.Purple;
        }

        public void StartCodeExpirationTimer(Action onFinished = null)
        {
            timeSpan = TimeSpan.FromMinutes(5);

            timer = new Timer
            {
                Interval = 1000
            };

            timerValidationLabel.ForeColor = Color.Black;

            timer.Tick += (sender, e) =>
            {
                timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));

                timerValidationLabel.Text = timeSpan.ToString("mm\\:ss");

                if (timeSpan <= TimeSpan.Zero)
                {
                    timer.Stop();
                    timer.Dispose();

                    timerValidationLabel.ForeColor = Color.Red;
                    onFinished?.Invoke();
                }
            };

            timer.Start();
        }

        public void ReSendValidationEmailCode(object sender, EventArgs e)
        {
            NewCodeRequested?.Invoke(this, EventArgs.Empty);
        }

        public void TimeOutLink()
        {
            resendCodeLinkLabel.Enabled = false;
            resendCodeLinkLabel.Cursor = Cursors.Default;

            StartCodeExpirationTimer(() =>
            {
                resendCodeLinkLabel.Enabled = true;
                resendCodeLinkLabel.Cursor = Cursors.Hand;
            });
        }

        private void SubmitCode(object sender, EventArgs e)
        {
            CodeSubmited?.Invoke(this, EventArgs.Empty);
        }

        private void ValidateCodeInput(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || e.KeyChar == ' ')
            {
                e.Handled = true; 
            }
        }

        private void AdjustCodeInputRichBox(object sender, EventArgs e)
        {
            if (validationCodeRichBox.TextLength == 0)
            {
                validationCodeRichBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }
    }
}
