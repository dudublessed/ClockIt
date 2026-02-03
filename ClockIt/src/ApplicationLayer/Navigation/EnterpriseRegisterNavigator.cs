using System;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class EnterpriseRegisterNavigator : IEnterpriseRegisterNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRegisterEnterpriseService _registerEnterpriseService;

        public EnterpriseRegisterNavigator(IServiceProvider serviceProvider,
            IRegisterEnterpriseService registerEnterpriseService)
        {
            _serviceProvider = serviceProvider;
            _registerEnterpriseService = registerEnterpriseService;
        }

        public IEnterpriseRegisterForm EnterpriseRegisterForm => _serviceProvider.GetRequiredService<IEnterpriseRegisterForm>();
        public IEmailValidationPresenter EmailValidationPresenter => _serviceProvider.GetRequiredService<IEmailValidationPresenter>();
        public IRegisterEnterpriseService RegisterEnterpriseService => _registerEnterpriseService;
    }
}
