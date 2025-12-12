using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;

        public AttendanceService(IAttendanceRepository repository)
        {
            _repository = repository;
        }

        public void RegisterTodayAttendance(DailyAttendanceDTO dailyAttendance)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _repository.RegisterTodayAttendance(dailyAttendance);

                scope.Complete();
            }
        }

        public AttendanceModel GetEmployeeTodayAttendance()
        {
            return _repository.GetEmployeeTodayAttendance();
        }

        public bool EmployeeHasRegisteredTodayAttendance()
        {
            return _repository.EmployeeHasRegisteredTodayAttendance();
        }
    }
}
