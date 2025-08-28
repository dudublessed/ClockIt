using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Presenters
{
    public class LoginPresenter : ILoginPresenter
    {
        private readonly ILoginNavigator _navigator;

        private ILoginForm _view;

        private readonly ILoginService _service;

        private int _enterpriseId;

        public LoginPresenter(ILoginNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.LoginService;
        }

        private void PrepareEventHandlers()
        {
            _view.FormShown -= OnFormLoadedAndShown;
            _view.LoginRequested -= HandleLoginRequest;

            _view.FormShown += OnFormLoadedAndShown;
            _view.LoginRequested += HandleLoginRequest;
        }

        public void ShowForm()
        {
            _view = _navigator.LoginForm;

            PrepareEventHandlers();
            FormHelper.OpenFormAndExit((Form)_view);
        }

        private void OnFormLoadedAndShown(object? sender, EventArgs e)
        {
            try
            {
                _view.EnterpriseName = _service.GetEnterpriseName();

                _enterpriseId = _service.GetEnterpriseId();

                var users = _service.GetUsers(_enterpriseId).ToList();

                _view.ShowUsers(users);

                bool hasOnlyAdmin = (users.Count == 1);
                bool isAdminPasswordDefault = _service.IsAdminPasswordDefault();

                if (hasOnlyAdmin && isAdminPasswordDefault)
                {
                    _navigator.AdminPasswordPresenter.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void HandleLoginRequest(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.Login) || string.IsNullOrEmpty(_view.InputPassword))
                {
                    MessageBoxHelper.ShowWarning("Por favor, preencha os campos.");
                }

                var inputDTO = new UserLoginDTO(_view.Login, _view.InputPassword, _enterpriseId);

                _service.VerifyPassword(inputDTO);

                bool isUserAdmin = _view.Login == "ADMIN";
                if (isUserAdmin)
                {
                    _navigator.AdminMainPresenter.ShowForm((Form)_view);
                    return;
                }

                _view.OpenUserMainForm(_navigator.UserMainForm);
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
