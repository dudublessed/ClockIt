using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface ILoginNavigator
    {
        // Forms
        ILoginForm LoginForm { get; }
        IAdminPasswordPresenter AdminPasswordPresenter { get; }
        IAdminMainPresenter AdminMainPresenter { get; }
        IEmployeeMainPresenter EmployeeMainPresenter { get; }

        // Services
        ILoginService LoginService { get; }

        // Context
        IMainContext MainContext { get; }
        IUserLoggedContext UserLoggedContext { get; }
        IEmployeeLoggedContext EmployeeLoggedContext { get; }
    }
}
