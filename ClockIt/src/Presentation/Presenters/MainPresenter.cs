using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.Presentation.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly IMainService _service;

        public MainPresenter(
            IServiceProvider serviceProvider,
            IMainService mainService)
        {
            _serviceProvider = serviceProvider;

            _service = mainService;
        }

        public async Task Start()
        {
            try
            {
                bool isMachineRegistered = await _service.IsMachineRegistered();
                if (!isMachineRegistered)
                {
                    ShowRegistrationForm();
                    return;
                }

                await _service.SetApplicationContext();
                ShowLoginForm();
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                Environment.Exit(0);
            }
        }

        private void ShowRegistrationForm()
        {
            var registerPresenter = _serviceProvider.GetRequiredService<IRegisterEnterprisePresenter>();
            registerPresenter.ShowForm();
        }

        private void ShowLoginForm()
        {
            var loginPresenter = _serviceProvider.GetRequiredService<ILoginPresenter>();
            loginPresenter.ShowForm();
        }
    }
}
