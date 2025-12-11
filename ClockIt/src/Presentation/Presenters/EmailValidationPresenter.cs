using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.EmailDTOs;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Presenters
{
    public class EmailValidationPresenter : IEmailValidationPresenter
    {
        private readonly IEmailValidationNavigator _navigator;

        private IEmailValidationForm _view;
        private readonly IEmailService _service;

        public EmailValidationPresenter(IEmailValidationNavigator navigator) {
            _navigator = navigator;

            _service = navigator.EmailService;
        }

        private void PrepareEventHandlers()
        {
            _view.FormLoaded -= OnFormLoaded;
            _view.CodeSubmited -= OnCodeSubmited;
            _view.NewCodeRequested -= OnNewCodeRequested;

            _view.FormLoaded += OnFormLoaded;
            _view.CodeSubmited += OnCodeSubmited;
            _view.NewCodeRequested += OnNewCodeRequested;
        }

        private void SetEmailViewInfo(EmailValidationDTO credentials)
        {
            _view.SetEmail(credentials.Email.Value);
            _view.SetName(credentials.Name);
        }

        public DialogResult ShowDialog(EmailValidationDTO credentials)
        {
            _view = _navigator.EmailValidationForm;

            SetEmailViewInfo(credentials);
            PrepareEventHandlers();

            var emailValidationForm = (Form)_view;
            FormHelper.OpenFormAsDialog(emailValidationForm);

            if (emailValidationForm.DialogResult != DialogResult.OK)
            {
                return DialogResult.None;
            }

            return DialogResult.OK;
        }

        private void OnFormLoaded(object? sender, EventArgs e) {
            try
            {
                var credentials = new EmailValidationDTO(_view.Email, _view.Name);
                _service.SendVerificationCode(credentials);

                _view.StartCodeExpirationTimer();

                _view.AdjustFieldsOnVisual();
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                FormHelper.SetFormDialogCancel((Form)_view);
                FormHelper.CloseForm((Form)_view);
            }
        }

        private void OnCodeSubmited(object? sender, EventArgs e)
        {
            try
            {
                string codeInput = _view.CodeInput;

                _service.ValidateInputCode(codeInput);

                MessageBoxHelper.ShowSucess("Email verificado com sucesso!");

                FormHelper.SetFormDialogOk((Form)_view);
                FormHelper.CloseForm((Form)_view);
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void OnNewCodeRequested(object? sender, EventArgs e) {
            try
            {
                var credentials = new EmailValidationDTO(_view.Email, _view.Name);

                _service.ReSendVerificationCode(credentials);

                _view.TimeOutLink();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
