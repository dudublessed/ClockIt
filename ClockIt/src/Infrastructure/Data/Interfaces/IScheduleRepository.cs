using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.EmployeeDTOs.ScheduleDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IScheduleRepository
    {
        void RegisterEmployeeSchedule(ScheduleDTO);
    }
}
