using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Models
{
    class TimeRecordModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime EntryRecord { get; set; }
        public DateTime ExitRecord { get; set; }
    }
}
