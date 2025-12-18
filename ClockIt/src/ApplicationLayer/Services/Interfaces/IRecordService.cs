using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IRecordService
    {
        void RegisterRecord(RecordDTO record);
        List<RecordDTO> GetEmployeeTodayRecords(int attendanceId);
        bool EmployeeHasRegisteredAllTodayRecords(int attendanceId);
    }
}
