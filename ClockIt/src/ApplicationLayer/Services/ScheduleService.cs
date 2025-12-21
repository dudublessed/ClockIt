using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.EmployeeDTOs.ScheduleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _repository = scheduleRepository;
        }

        public async Task RegisterEmployeeSchedule(ScheduleDTO schedule)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _repository.RegisterEmployeeSchedule(schedule);

                scope.Complete();
            }
        }
    }
}
