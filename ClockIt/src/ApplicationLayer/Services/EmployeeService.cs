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
        private readonly IPositionsService _positionsService;
        private readonly IAttendanceService _attendanceService;
        private readonly IRecordService _recordService;
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IPositionsService positionsService, 
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

        public List<PositionsModel> GetEnterprisePositions()
        {
            return _positionsService.GetEnterprisePositions();
        }

        public void RegisterDailyAttendance(DailyAttendanceDTO dailyAttendance)
        {
            _attendanceService.RegisterDailyAttendance(dailyAttendance);
        }

        public AttendanceModel GetEmployeeTodayAttendance()
        {
            return _attendanceService.GetEmployeeTodayAttendance();
        }

        //public List<RecordDTO> GetEmployeeTodayRecords()
        //{
        //    return _recordService.GetEmployeeTodayRecords();
        //}

        public bool EmployeeHasRegisteredTodayAttendance()
        {
            return _attendanceService.EmployeeHasRegisteredTodayAttendance();
        }

        public void RegisterEntryRecord()
        {
            _recordService.RegisterEntryRecord();
        }

        public void RegisterLunchEntryRecord()
        {
            _recordService.RegisterLunchEntryRecord();
        }

        public void RegisterLunchExitRecord()
        {
            _recordService.RegisterLunchExitRecord();
        }

        public void RegisterExitRecord()
        {
            _recordService.RegisterExitRecord();
        }
    }
}
