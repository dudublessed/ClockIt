using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Presenters
{
    public class AdminPasswordPresenter : IAdminPasswordPresenter
    {
        private readonly IAdminPasswordNavigator _navigator;

        private IAdminPasswordForm _view;

        private readonly IAdminService _service;

        public AdminPasswordPresenter(IAdminPasswordNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.AdminPasswordService;
        }

        private void PrepareEventHandlers()
        {
            _view.FirstPasswordValidationRequested -= ValidateFirstPasswordInput;
            _view.SecondPasswordValidationRequested -= ValidateSecondPasswordInput;
            _view.UpdateAdminPasswordRequested -= UpdateAdminPassword;

            _view.FirstPasswordValidationRequested += ValidateFirstPasswordInput;
            _view.SecondPasswordValidationRequested += ValidateSecondPasswordInput;
            _view.UpdateAdminPasswordRequested += UpdateAdminPassword;
        }

        public void ShowDialog()
        {
            try
            {
                _view = _navigator.AdminPasswordForm;

                PrepareEventHandlers();

                var adminPasswordForm = (Form)_view;
                FormHelper.OpenFormAsDialog(adminPasswordForm);
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            };
        }

        private void ValidateFirstPasswordInput(object? sender, TriggeredByEventArgs e)
        {
            try
            {
               bool isFirstPasswordEmpty = (string.IsNullOrEmpty(_view.Password) || string.IsNullOrWhiteSpace(_view.Password));

               switch (e.TriggeredBy)
               {
                    case ValidationTrigger.TextChanged:
                        if (isFirstPasswordEmpty)
                        {
                            _view.HideFirstPasswordError();
                            _view.AdjustFormLayout(false);
                            return;
                        }

                        string errorMessage = string.Empty;

                        bool passwordIsValid = _service.ValidatePasswordInput(_view.Password, out errorMessage);

                        if (passwordIsValid)
                        {
                            _view.HideFirstPasswordError();
                            _view.AdjustFormLayout(false);
                            return;
                        }

                        _view.SetPasswordMessageAndShowError(errorMessage);
                        _view.AdjustFormLayout(true);
                        break;
                    case ValidationTrigger.Leave:
                        _view.AdjustFormLayout(isFirstPasswordEmpty, adjustOffset: 6);

                        if (!isFirstPasswordEmpty)
                        {
                            _view.HideFirstPasswordError();
                            return;
                        }

                        _view.SetPasswordMessageAndShowError("Este campo é obrigatório");
                        break;
               }

            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return;
            }
        }

        private void ValidateSecondPasswordInput(object? sender, TriggeredByEventArgs e)
        {
            try
            {
                switch (e.TriggeredBy)
                {
                    case ValidationTrigger.TextChanged:
                        bool isFirstPasswordEmpty = string.IsNullOrWhiteSpace(_view.Password);
                        if (isFirstPasswordEmpty || ValidationUtils.PasswordsMatch(_view.Password, _view.ConfirmPassword))
                        {
                            _view.HideSecondPasswordError();
                            return;
                        }

                        _view.SetConfirmPasswordMessageAndShowError("As senhas não coincidem");
                        break;
                    case ValidationTrigger.Leave:
                        bool isSecondPasswordEmpty = string.IsNullOrWhiteSpace(_view.ConfirmPassword);
                        if (!isSecondPasswordEmpty)
                        {
                            _view.HideSecondPasswordError();
                            return;
                        }

                        _view.SetConfirmPasswordMessageAndShowError("Este campo é obrigatório");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return;
            }
        }

        private void UpdateAdminPassword(object? sender, EventArgs e)
        {
            try
            {
                var passwords = new PasswordsMatchDTO(_view.Password, _view.ConfirmPassword);
                if (!passwords.DoesPasswordsMatch())
                {
                    MessageBoxHelper.ShowWarning("As senhas não coincidem.");
                    return;
                }

                var updateAdminPasswordDTO = new UpdateAdminPasswordDTO(_view.Password);
                _service.UpdateAdminPassword(updateAdminPasswordDTO);

                MessageBoxHelper.ShowSucess("Perfeito! A senha do administrador foi definida com sucesso!");
                FormHelper.SetFormDialogOk((Form)_view);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return;
            }
        }
    }
}
