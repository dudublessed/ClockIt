using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class CreateUserNavigator : ICreateUserNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserService _userService;

        public CreateUserNavigator(IServiceProvider serviceProvider, IUserService userService)
        {
            _serviceProvider = serviceProvider;
            _userService = userService;
        }

        public ICreateUserForm CreateUserForm => _serviceProvider.GetRequiredService<ICreateUserForm>();

        public IUserService UserService => _userService;

        public IMainContext MainContext => _serviceProvider.GetRequiredService<IMainContext>();
    }
}
