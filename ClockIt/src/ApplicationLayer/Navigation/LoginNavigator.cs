using System;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class LoginNavigator : ILoginNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoginService _loginService;

        public LoginNavigator(
            IServiceProvider serviceProvider,
            ILoginService loginService)
        {
            _serviceProvider = serviceProvider;
            _loginService = loginService;
        }

        public ILoginForm LoginForm => _serviceProvider.GetRequiredService<ILoginForm>();
        public IAdminPasswordPresenter AdminPasswordPresenter => _serviceProvider.GetRequiredService<IAdminPasswordPresenter>();

        public IAdminMainPresenter AdminMainPresenter => _serviceProvider.GetRequiredService<IAdminMainPresenter>();
        public IUserMainForm UserMainForm => _serviceProvider.GetRequiredService<IUserMainForm>();

        public ILoginService LoginService => _loginService;
    }
}
