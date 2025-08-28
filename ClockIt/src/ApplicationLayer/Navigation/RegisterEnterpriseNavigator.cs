using System;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class RegisterEnterpriseNavigator : IRegisterEnterpriseNavigator
    {
        private readonly IServiceProvider _serviceProvider;

        public RegisterEnterpriseNavigator(IServiceProvider serviceProvider,
            IRegisterEnterpriseService registerEnterpriseService)
        {
            _serviceProvider = serviceProvider;
            RegisterEnterpriseService = registerEnterpriseService;
        }

        public IRegisterEnterpriseForm RegisterEnterpriseForm => _serviceProvider.GetRequiredService<IRegisterEnterpriseForm>();
        public IEmailValidationPresenter EmailValidationPresenter => _serviceProvider.GetRequiredService<IEmailValidationPresenter>();
        public IRegisterEnterpriseService RegisterEnterpriseService { get; }
    }
}
