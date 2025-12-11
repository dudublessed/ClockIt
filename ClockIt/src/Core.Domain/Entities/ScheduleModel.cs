using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class ScheduleModel
    {
        public int Id { get; }
        public int EmployeeId { get; }
        public DateTime EntryTime { get; }
        public DateTime LunchEntryTime { get; }
        public DateTime LunchExitTime { get; }
        public DateTime ExitTime { get; }
        public DateTimeOffset CreatedAt { get; }
        public bool Active { get; }

        public ScheduleModel(int id, int employeeId, DateTime entryTime, DateTime lunchEntryTime, DateTime lunchExitTime, DateTime exitTime, DateTimeOffset createdAt, bool active)
        {
            Id = id;
            EmployeeId = employeeId;
            EntryTime = entryTime;
            LunchEntryTime = lunchEntryTime;
            LunchExitTime = lunchExitTime;
            ExitTime = exitTime;
            CreatedAt = createdAt;
            Active = active;
        }
    }
}
