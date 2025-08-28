using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class EmployeeModel
    {
        public int Id { get; }
        public int UserId { get; }
        public DateTime EntryTime { get; }
        public DateTime ExitTime { get; }

        public EmployeeModel(int id, int userId, DateTime entryTime, DateTime exitTime)
        {
            Id = id;
            UserId = userId;
            EntryTime = entryTime;
            ExitTime = exitTime;
        }

    }
}
