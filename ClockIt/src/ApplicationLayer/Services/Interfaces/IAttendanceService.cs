using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IAttendanceService
    {
        void RegisterTodayAttendance(DailyAttendanceDTO dailyAttendance);
        AttendanceModel GetEmployeeTodayAttendance();
        bool EmployeeHasRegisteredTodayAttendance();
    }
}
