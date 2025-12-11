using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.ApplicationLayer.Context
{
    public class EmployeeLoggedContext : IEmployeeLoggedContext
    {
        public EmployeeModel Employee { get; private set; }

        public void SetEmployeeLoggedContext(EmployeeModel employee)
        {
            Employee = employee;
        }
    }
}
