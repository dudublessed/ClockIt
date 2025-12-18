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
        TimeSpan EntryRecord { get; }
        TimeSpan LunchEntryRecord { get; }
        TimeSpan LunchExitRecord { get; }
        TimeSpan ExitRecord { get; }

        event EventHandler FormShown;
        event EventHandler ClockIn;

        void StartHourTimer();
        void UpdateEmployeeNameLabel(string employeeName);
        void ShowEntryRecord(TimeSpan recordHour);
        void ShowLunchEntryRecord(TimeSpan recordHour);
        void ShowLunchExitRecord(TimeSpan recordHour);
        void ShowExitRecord(TimeSpan recordHour);
        void DisableRecordButton();

    }
}
