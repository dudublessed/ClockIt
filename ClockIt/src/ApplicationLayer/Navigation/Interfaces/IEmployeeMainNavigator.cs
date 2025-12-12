using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface IEmployeeMainNavigator
    {
        // Forms
        IEmployeeMainForm EmployeeMainForm { get; }

        // Services
        IEmployeeService EmployeeService { get; }
        IAttendanceService AttendanceService { get; }
        IRecordService RecordService { get; }

        // Context
        IEmployeeLoggedContext EmployeeLoggedContext { get; }
    }
}
