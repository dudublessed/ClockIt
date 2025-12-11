using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class AttendanceModel
    {
        public int Id { get; }
        public int EmployeeId { get; }
        public DateTime Date { get; }

        public AttendanceModel(int id, int employeeId, DateTime date)
        {
            Id = id;
            EmployeeId = employeeId;
            Date = date;
        }
    }
}
