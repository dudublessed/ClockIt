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

        private readonly ILoginNavigator _loginNavigator;
        private readonly IRegisterEnterpriseNavigator _registerEnterpriseNavigator;

        private readonly IMainService _mainService;

        public MainPresenter(
            IServiceProvider serviceProvider,
            ILoginNavigator loginNavigator, 
            IRegisterEnterpriseNavigator registerEnterpriseNavigator, 
            IMainService mainService)
        {
            _serviceProvider = serviceProvider;

            _loginNavigator = loginNavigator;
            _registerEnterpriseNavigator = registerEnterpriseNavigator;

            _mainService = mainService;
        }

        public void Start()
        {
            try
            {
                bool isMachineRegistered = _mainService.IsMachineRegistered();

                if (!isMachineRegistered)
                {
                    var registerPresenter = _serviceProvider.GetRequiredService<IRegisterEnterprisePresenter>();
                    registerPresenter.ShowForm();
                    return;
                }

                var loginPresenter = _serviceProvider.GetRequiredService<ILoginPresenter>();
                loginPresenter.ShowForm();

            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
