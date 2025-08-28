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
    public class UserMainPresenter : IUserMainPresenter
    {
        private readonly IUserMainNavigator _navigator;

        private IUserMainForm _view;

        private IUserMainService _service;

        public UserMainPresenter(IUserMainNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.UserMainService;
        }

        private void PrepareEventHandlers()
        {
            _view.FormShown -= OnFormLoadedAndShown;

            _view.FormShown += OnFormLoadedAndShown;
        }

        public void ShowForm(Form loginForm)
        {
            _view = _navigator.UserMainForm;

            PrepareEventHandlers();

            FormHelper.OpenFormAndShow(loginForm, (Form)_view);
        }

        private void OnFormLoadedAndShown(object? sender, EventArgs e)
        {

        }
    }
}
