using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.EmployeeDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task RegisterEmployee(EmployeeDTO employee);
        Task<EmployeeModel> GetEmployeeByUserId(int userId);
        Task<EmployeeModel> GetEmployeeByUserContext();
    }
}
