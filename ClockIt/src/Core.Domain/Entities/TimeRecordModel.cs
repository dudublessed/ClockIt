using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class TimeRecordModel
    {
        public int Id { get; }
        public int EmployeeId { get; }
        public DateTime RecordDate { get; }
        public DateTime EntryRecord { get; }
        public DateTime LunchEntryRecord { get; }
        public DateTime LunchExitRecord { get; }
        public DateTime ExitRecord { get; }

        public TimeRecordModel(int id, int employeeId, DateTime recordDate, DateTime entryRecord, DateTime lunchEntryRecord, DateTime lunchExitRecord, DateTime exitRecord)
        {
            Id = id;
            EmployeeId = employeeId;
            RecordDate = recordDate;
            EntryRecord = entryRecord;
            LunchEntryRecord = lunchEntryRecord;
            LunchExitRecord = lunchExitRecord;
            ExitRecord = exitRecord;
        }
    }
}
