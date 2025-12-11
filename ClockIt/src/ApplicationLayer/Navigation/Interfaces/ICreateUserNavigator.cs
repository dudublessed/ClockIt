using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface ICreateUserNavigator
    {
        // Forms
        ICreateUserForm CreateUserForm { get; }

        // Services
        IUserService UserService { get; }

        // Context
        IMainContext MainContext { get; }
    }
}
