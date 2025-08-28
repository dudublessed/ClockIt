using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class AdminMainNavigator : IAdminMainNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAdminMainService _adminMainService;

        public AdminMainNavigator(IServiceProvider serviceProvider, IAdminMainService adminMainService)
        {
            _serviceProvider = serviceProvider;
            _adminMainService = adminMainService;
        }

        public IAdminMainForm AdminMainForm => _serviceProvider.GetRequiredService<IAdminMainForm>();

        public IAdminMainService AdminMainService => _serviceProvider.GetRequiredService<IAdminMainService>();
    }
}
