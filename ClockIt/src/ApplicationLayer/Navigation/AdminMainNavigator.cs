using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class AdminMainNavigator : IAdminMainNavigator
    {
        private readonly IServiceProvider _serviceProvider;

        public AdminMainNavigator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAdminMainForm AdminMainForm => _serviceProvider.GetRequiredService<IAdminMainForm>();
        public ICreateUserPresenter CreateUserPresenter => _serviceProvider.GetRequiredService<ICreateUserPresenter>();
        public ICreateEmployeePresenter CreateEmployeePresenter => _serviceProvider.GetRequiredService<ICreateEmployeePresenter>();
    }
}
