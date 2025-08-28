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

        private IAdminMainService _service;

        public AdminMainPresenter(IAdminMainNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.AdminMainService;
        }

        private void PrepareEventHandlers()
        {
            _view.FormShown -= OnFormLoadedAndDisplayn;
            _view.UserSectionRequested -= DisplayUserTopSection;
            _view.EmployeeSectionRequested -= DisplayEmployeeTopSection;
            _view.SettingsSectionRequested -= DisplaySettingsTopSection;

            _view.FormShown += OnFormLoadedAndDisplayn;
            _view.UserSectionRequested += DisplayUserTopSection;
            _view.EmployeeSectionRequested += DisplayEmployeeTopSection;
            _view.SettingsSectionRequested += DisplaySettingsTopSection;
        }

        public void ShowForm(Form loginForm)
        {
            _view = _navigator.AdminMainForm;

            PrepareEventHandlers();

            FormHelper.OpenFormAndShow(loginForm, (Form)_view);
        }

        private void OnFormLoadedAndDisplayn(object? sender, EventArgs e)
        {
            try
            {

            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void DisplayUserTopSection(object? sender, EventArgs e)
        {
            _view.ShowUserTopSection();
        }

        private void DisplayEmployeeTopSection(object? sender, EventArgs e)
        {
            _view.ShowEmployeeTopSection();
        }

        private void DisplaySettingsTopSection(object? sender, EventArgs e)
        {
            _view.ShowSettingsTopSection();
        }
    }
}
