using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs
{
    public class RecordDTO
    {
        public int AttendanceId { get; }
        public int EmployeeId { get; }
        public string RecordType { get; }
        public DateTimeOffset RecordedAt { get; }
        public TimeSpan RecordHour { get; }

        public RecordDTO(int attendanceId, int employeeId, string recordType, DateTimeOffset recordedAt, TimeSpan recordHour)
        {
            AttendanceId = attendanceId;
            EmployeeId = employeeId;
            RecordType = recordType;
            RecordedAt = recordedAt;
            RecordHour = recordHour;
        }
    }
}
