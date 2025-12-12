using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class EmployeeMainNavigator : IEmployeeMainNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEmployeeService _employeeService;
        private readonly IAttendanceService _attendanceService;
        private readonly IRecordService _recordService;

        public EmployeeMainNavigator(IServiceProvider serviceProvider, 
            IEmployeeService employeeService, 
            IAttendanceService attendanceService,
            IRecordService recordService)
        {
            _serviceProvider = serviceProvider;
            _employeeService = employeeService;
            _attendanceService = attendanceService;
            _recordService = recordService;

        }

        public IEmployeeMainForm EmployeeMainForm => _serviceProvider.GetRequiredService<IEmployeeMainForm>();

        public IEmployeeService EmployeeService => _employeeService;
        public IAttendanceService AttendanceService => _attendanceService;
        public IRecordService RecordService => _recordService;

        public IEmployeeLoggedContext EmployeeLoggedContext => _serviceProvider.GetRequiredService<IEmployeeLoggedContext>();
    }
}
