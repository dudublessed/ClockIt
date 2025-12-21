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

        private readonly IEmployeeRepository _repository;

        public EmployeeService(IPositionService positionsService, 
            IEmployeeRepository repository)
        {
            _positionsService = positionsService;
            _repository = repository;
        }

        public async Task RegisterEmployee(EmployeeDTO employee)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _repository.RegisterEmployee(employee);

                scope.Complete();
            }
        }

        public async Task<EmployeeModel> GetEmployeeByUserId(int userId)
        {
            return await _repository.GetEmployeeByUserId(userId);
        }

        public async Task<EmployeeModel> GetEmployeeByUserContext()
        {
            return await _repository.GetEmployeeByUserContext();
        }

        public async Task<List<PositionModel>> GetEnterprisePositions()
        {
            return await _positionsService.GetEnterprisePositions();
        }
    }
}
