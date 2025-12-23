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
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.Presentation.Presenters
{
    public class LoginPresenter : ILoginPresenter
    {
        private readonly ILoginNavigator _navigator;

        private ILoginForm _view;

        private readonly ILoginService _service;

        private readonly IMainContext _context;
        private readonly IUserLoggedContext _userContext;
        private readonly IEmployeeLoggedContext _employeeContext;

        private List<ShowUsersDTO> Users;

        public LoginPresenter(ILoginNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.LoginService;

            _context = navigator.MainContext;
            _userContext = navigator.UserLoggedContext;
            _employeeContext = navigator.EmployeeLoggedContext;
        }

        private void PrepareEventHandlers()
        {
            _view.FormShown -= LoadFormOnShown;
            _view.FormActivated -= LoadEnterpriseUsers;
            _view.LoginRequested -= HandleLoginRequest;

            _view.FormShown += LoadFormOnShown;
            _view.FormActivated += LoadEnterpriseUsers;
            _view.LoginRequested += HandleLoginRequest;
        }

        public void ShowForm()
        {
            _view = _navigator.LoginForm;

            PrepareEventHandlers();
            FormHelper.OpenFormAndExit((Form)_view);
        }

        private async Task LoadFormOnShown(object? sender, EventArgs e)
        {
            try
            {
                await LoadEnterpriseUsers(sender, e);

                bool hasOnlyAdmin = (Users.Count == 1);
                bool isAdminPasswordDefault = await _service.IsAdminPasswordDefault();

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

        private async Task LoadEnterpriseUsers(object? sender, EventArgs e)
        {
            _view.EnterpriseName = _context.Enterprise.Name;

            Users = await _service.GetEnterpriseEmployeeUsers();

            _view.ClearInputFields();
            await _view.ShowUsers(Users);
        }

        private async Task HandleLoginRequest(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.Login) || string.IsNullOrEmpty(_view.InputPassword))
                {
                    MessageBoxHelper.ShowWarning("Por favor, preencha os campos.");
                }

                var inputDTO = new UserLoginDTO(_view.Login, _view.InputPassword, _context.Enterprise.Id);

                await _service.VerifyPassword(inputDTO);

                SetUserLogged();

                bool isAdmin = _view.Login == "ADMIN";
                if (isAdmin)
                {
                    _navigator.AdminMainPresenter.ShowForm((Form)_view);
                    return;
                }

                await SetEmployeeLogged();

                _navigator.EmployeeMainPresenter.ShowForm((Form)_view);
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void SetUserLogged()
        {
            try
            {
                UserLoggedDTO userLogged = Users
                    .Where(u => u.Login == _view.Login)
                    .Select(u => new UserLoggedDTO(u.Id, u.UserName, u.Login))
                    .First();

                _userContext.SetUserLoggedContext(userLogged);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private async Task SetEmployeeLogged()
        {
            try
            {
                EmployeeModel employeeLogged = await _service.GetEmployeeByUserContext();

                _employeeContext.SetEmployeeLoggedContext(employeeLogged);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
