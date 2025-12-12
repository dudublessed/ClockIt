using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _repository;

        public RecordService(IRecordRepository repository)
        {
            _repository = repository;
        }

        public void RegisterRecord(RecordDTO record)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _repository.RegisterRecord(record);

                scope.Complete();
            }
        }

        public List<RecordDTO> GetEmployeeTodayRecords()
        {
            return _repository.GetEmployeeTodayRecords();
        }

        public bool EmployeeHasRegisteredAllTodayRecords(int attendanceId)
        {
            return _repository.EmployeeHasRegisteredAllTodayRecords(attendanceId);
        }
    }
}
