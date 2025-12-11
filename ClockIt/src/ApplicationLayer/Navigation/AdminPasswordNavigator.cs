using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class AdminPasswordNavigator : IAdminPasswordNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAdminService _adminPasswordService;

        public AdminPasswordNavigator(IServiceProvider serviceProvider, IAdminService adminPasswordService)
        {
            _serviceProvider = serviceProvider;
            _adminPasswordService = adminPasswordService;
        }

        public IAdminPasswordForm AdminPasswordForm => _serviceProvider.GetRequiredService<IAdminPasswordForm>();

        public IAdminService AdminPasswordService => _adminPasswordService;
    }
}
