using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;
using ClockIt.src.Shared.DTOs.EmployeeDTOs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IPositionService _positionsService;
        private readonly IAttendanceService _attendanceService;
        private readonly IRecordService _recordService;

        private readonly IEmployeeRepository _repository;

        public EmployeeService(IPositionService positionsService, 
            IAttendanceService attendanceService, 
            IRecordService recordService, 
            IEmployeeRepository repository)
        {
            _positionsService = positionsService;
            _attendanceService = attendanceService;

            _repository = repository;
        }

        public void RegisterEmployee(EmployeeDTO employee)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _repository.RegisterEmployee(employee);

                scope.Complete();
            }
        }

        public EmployeeModel GetEmployeeByUserId(int userId)
        {
            return _repository.GetEmployeeByUserId(userId);
        }

        public EmployeeModel GetEmployeeByUserContext()
        {
            return _repository.GetEmployeeByUserContext();
        }

        public List<PositionModel> GetEnterprisePositions()
        {
            return _positionsService.GetEnterprisePositions();
        }
    }
}
