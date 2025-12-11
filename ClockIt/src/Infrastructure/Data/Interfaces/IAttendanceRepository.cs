using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IAttendanceRepository
    {
        void RegisterDailyAttendance(DailyAttendanceDTO dailyAttendance);
        AttendanceModel GetEmployeeTodayAttendance();
        bool EmployeeHasRegisteredTodayAttendance();
    }
}
