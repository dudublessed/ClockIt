using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class CreateEmployeeNavigator : ICreateEmployeeNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IScheduleService _scheduleService;

        public CreateEmployeeNavigator(IServiceProvider serviceProvider, 
            IEmployeeService employeeService, 
            IUserService userService,
            IScheduleService scheduleService)
        {
            _serviceProvider = serviceProvider;
            _employeeService = employeeService;
            _userService = userService;
            _scheduleService = scheduleService;
        }

        public ICreateEmployeeForm CreateEmployeeForm => _serviceProvider.GetRequiredService<ICreateEmployeeForm>();

        public IEmailValidationPresenter EmailValidationPresenter => _serviceProvider.GetRequiredService<IEmailValidationPresenter>();
        public IEmployeeService EmployeeService => _employeeService;
        public IUserService UserService => _userService;
        public IScheduleService ScheduleService => _scheduleService;

        public IMainContext MainContext => _serviceProvider.GetRequiredService<IMainContext>();
    }
}
