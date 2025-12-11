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

        void StartHourTimer();

        event EventHandler FormShown;
        event EventHandler ClockIn;

        void ShowEntryRecord();
        void ShowLunchEntryRecord();
        void ShowLunchExitRecord();
        void ShowExitRecord();
        void DisableRecordButton();

    }
}
