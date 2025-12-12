using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.AttendanceDTOs;
using ClockIt.src.Shared.DTOs.AttendanceDTOs.RecordDTOs;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Presenters
{
    public class EmployeeMainPresenter : IEmployeeMainPresenter
    {
        private readonly IEmployeeMainNavigator _navigator;

        private IEmployeeMainForm _view;

        private readonly IEmployeeService _service;
        private readonly IAttendanceService _attendanceService;
        private readonly IRecordService _recordService;


        private readonly IEmployeeLoggedContext _employeeContext;

        private bool EmployeeHasRegisteredTodayAttendance = false;
        private bool EmployeeHasRegisteredAllTodayRecords = false;

        private AttendanceModel? EmployeeTodayAttendance = null;

        public EmployeeMainPresenter(IEmployeeMainNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.EmployeeService;
            _attendanceService = navigator.AttendanceService;
            _recordService = navigator.RecordService;

            _employeeContext = navigator.EmployeeLoggedContext;
        }

        private void PrepareEventHandlers()
        {
            _view.FormShown -= OnFormLoadedAndShown;
            _view.ClockIn -= RegisterRecord;

            _view.FormShown += OnFormLoadedAndShown;
            _view.ClockIn += RegisterRecord;
        }

        public void ShowForm(Form loginForm)
        {
            _view = _navigator.EmployeeMainForm;

            PrepareEventHandlers();

            FormHelper.OpenFormAndShow(loginForm, (Form)_view);
        }

        private void OnFormLoadedAndShown(object? sender, EventArgs e)
        {
            _view.StartHourTimer();

            EmployeeHasRegisteredTodayAttendance = _attendanceService.EmployeeHasRegisteredTodayAttendance();
            if (EmployeeHasRegisteredTodayAttendance)
            {
                EmployeeTodayAttendance = _attendanceService.GetEmployeeTodayAttendance();
            }

            if (EmployeeTodayAttendance != null)
            {
                EmployeeHasRegisteredAllTodayRecords = _recordService.EmployeeHasRegisteredAllTodayRecords(EmployeeTodayAttendance.Id);
            }

            if (EmployeeHasRegisteredTodayAttendance == true && EmployeeHasRegisteredAllTodayRecords == true)
            {
                List<RecordDTO> employeeTodayRecords = _recordService.GetEmployeeTodayRecords();
                _view.ShowEmployeeTodayRecords(employeeTodayRecords);
                _view.DisableRecordButton();
            }
        }

        private void RegisterRecord(object? sender, EventArgs e)
        {
            try
            {
                if (EmployeeHasRegisteredTodayAttendance == false)
                {
                    DailyAttendanceDTO todayAttendance = new DailyAttendanceDTO(_employeeContext.Employee.Id, DateTime.Now.Date);

                    _attendanceService.RegisterTodayAttendance(todayAttendance);
                }

                if (EmployeeTodayAttendance == null)
                {
                    EmployeeTodayAttendance = _attendanceService.GetEmployeeTodayAttendance();
                }

                DateTimeOffset recordedAt = DateTimeOffset.Now;
                DateTime recordHour = DateTime.Now;

                if (_view.EntryRecord == DateTime.MinValue)
                {
                     RecordDTO employeeEntryRecord = new RecordDTO(
                          EmployeeTodayAttendance.Id,
                          _employeeContext.Employee.Id,
                          "entry",
                          recordedAt,
                          recordHour
                     );

                    _recordService.RegisterRecord(employeeEntryRecord);
                    _view.ShowEntryRecord();
                    return;
                }

                if (_view.LunchEntryRecord == DateTime.MinValue)
                {
                    RecordDTO employeeLunchEntryRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "lunch_entry",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeLunchEntryRecord);
                    _view.ShowLunchEntryRecord();
                    return;
                }

                if (_view.LunchExitRecord == DateTime.MinValue)
                {
                    RecordDTO employeeLunchExitRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "lunch_exit",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeLunchExitRecord);
                    _view.ShowLunchExitRecord();
                    return;
                }

                if (_view.ExitRecord == DateTime.MinValue)
                {
                    RecordDTO employeeExitRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "exit",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeExitRecord);
                    _view.ShowExitRecord();
                    return;
                }

                List<RecordDTO> employeeTodayRecords = _recordService.GetEmployeeTodayRecords();
                _view.ShowEmployeeTodayRecords(employeeTodayRecords);
                _view.DisableRecordButton();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return;
            }
        }
    }
}
