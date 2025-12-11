using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.AttendanceDTOs
{
    public class DailyAttendanceDTO
    {
        public int EmployeeId { get; }
        public DateTime Date { get; }

        public DailyAttendanceDTO(int employeeId, DateTime date) {
            EmployeeId = employeeId;
            Date = date;   
        }
    }
}
