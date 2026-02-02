using System;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class UserLoginNavigator : IUserLoginNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoginService _loginService;

        public UserLoginNavigator(
            IServiceProvider serviceProvider,
            ILoginService loginService)
        {
            _serviceProvider = serviceProvider;
            _loginService = loginService;
        }

        public IUserLoginForm UserLoginForm => _serviceProvider.GetRequiredService<IUserLoginForm>();
        public IAdminPasswordPresenter AdminPasswordPresenter => _serviceProvider.GetRequiredService<IAdminPasswordPresenter>();

        public IAdminMainPresenter AdminMainPresenter => _serviceProvider.GetRequiredService<IAdminMainPresenter>();
        public IEmployeeMainPresenter EmployeeMainPresenter => _serviceProvider.GetRequiredService<IEmployeeMainPresenter>();

        public ILoginService LoginService => _loginService;

        public IMainContext MainContext => _serviceProvider.GetRequiredService<IMainContext>();
        public IEmployeeLoggedContext EmployeeLoggedContext => _serviceProvider.GetRequiredService<IEmployeeLoggedContext>();
        public IUserLoggedContext UserLoggedContext => _serviceProvider.GetRequiredService<IUserLoggedContext>();
    }
}
