using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Presenters
{
    public class AdminMainPresenter : IAdminMainPresenter
    {
        private readonly IAdminMainNavigator _navigator;

        private IAdminMainForm _view;

        public AdminMainPresenter(IAdminMainNavigator navigator)
        {
            _navigator = navigator;
        }

        private void PrepareEventHandlers()
        {
            _view.ShowCreateUserForm -= ShowCreateUserForm;
            _view.ShowCreatePositionForm -= ShowCreatePositionForm;
            _view.ShowCreateEmployeeForm -= ShowCreateEmployeeForm;

            _view.ShowCreateUserForm += ShowCreateUserForm;
            _view.ShowCreatePositionForm += ShowCreatePositionForm;
            _view.ShowCreateEmployeeForm += ShowCreateEmployeeForm;
        }

        public void ShowForm(Form loginForm)
        {
            _view = _navigator.AdminMainForm;

            PrepareEventHandlers();

            FormHelper.OpenFormAndShow(loginForm, (Form)_view);
        }

        private void OnFormLoadedAndShown(object? sender, EventArgs e)
        {
            try
            {

            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void ShowCreateUserForm(object? sender, EventArgs e)
        {
            _navigator.CreateUserPresenter.ShowDialog();
        }

        private void ShowCreatePositionForm(object? sender, EventArgs e)
        {
            _navigator.CreatePositionPresenter.ShowDialog();
        }

        private void ShowCreateEmployeeForm(object? sender, EventArgs e)
        {
            _navigator.CreateEmployeePresenter.ShowDialog();
        }
    }
}
