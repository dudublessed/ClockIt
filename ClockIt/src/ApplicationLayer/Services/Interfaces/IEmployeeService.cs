using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using ClockIt.src.Shared.DTOs.EmployeeDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task RegisterEmployee(EmployeeDTO employee);
        Task<EmployeeModel> GetEmployeeByUserId(int userId);
        Task<EmployeeModel> GetEmployeeByUserContext();
        Task<List<PositionModel>> GetEnterprisePositions();
    }
}
