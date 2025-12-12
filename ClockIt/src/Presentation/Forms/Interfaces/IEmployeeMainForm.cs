using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface IEmployeeMainForm
    {
        DateTime EntryRecord { get; }
        DateTime LunchEntryRecord { get; }
        DateTime LunchExitRecord { get; }
        DateTime ExitRecord { get; }

        event EventHandler FormShown;
        event EventHandler ClockIn;

        void StartHourTimer();
        void ShowEmployeeTodayRecords(List<RecordDTO> employeeTodayRecords);
        void ShowEntryRecord();
        void ShowLunchEntryRecord();
        void ShowLunchExitRecord();
        void ShowExitRecord();
        void DisableRecordButton();

    }
}
