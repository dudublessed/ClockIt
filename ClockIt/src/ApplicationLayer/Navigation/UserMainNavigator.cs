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
    public class UserMainNavigator : IUserMainNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserMainService _userMainService;

        public UserMainNavigator(IServiceProvider serviceProvider, IUserMainService userMainService)
        {
            _serviceProvider = serviceProvider;
            _userMainService = userMainService;
        }

        public IUserMainForm UserMainForm => _serviceProvider.GetRequiredService<IUserMainForm>();

        public IUserMainService UserMainService => _serviceProvider.GetRequiredService<IUserMainService>();
    }
}
