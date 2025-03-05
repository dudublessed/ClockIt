using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Models
{
    class EmployeeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }

    }
}
