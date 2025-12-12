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
    public interface ICreateEmployeeNavigator
    {
        ICreateEmployeeForm CreateEmployeeForm { get; }
        IEmailValidationPresenter EmailValidationPresenter { get; }

        IEmployeeService EmployeeService { get; }
        IUserService UserService { get; }
        IScheduleService ScheduleService { get; }

        IMainContext MainContext { get; }
    }
}
