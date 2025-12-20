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
            _view.UpdateEmployeeNameLabel(_employeeContext.Employee.FullName);

            VerifyEmployeeTodayAttendance();
        }

        private void RegisterRecord(object? sender, EventArgs e)
        {
            try
            {
                VerifyEmployeeTodayAttendance();

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
                TimeSpan recordHour = DateTime.Now.TimeOfDay;

                if (_view.EntryRecord == TimeSpan.MinValue)
                {
                     RecordDTO employeeEntryRecord = new RecordDTO(
                          EmployeeTodayAttendance.Id,
                          _employeeContext.Employee.Id,
                          "entry",
                          recordedAt,
                          recordHour
                     );

                    _recordService.RegisterRecord(employeeEntryRecord);
                    _view.StartHourTimer();
                    _view.ShowEntryRecord(recordHour);
                    return;
                }

                if (_view.LunchEntryRecord == TimeSpan.MinValue)
                {
                    RecordDTO employeeLunchEntryRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "lunch_entry",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeLunchEntryRecord);
                    _view.StartHourTimer();
                    _view.ShowLunchEntryRecord(recordHour);
                    return;
                }

                if (_view.LunchExitRecord == TimeSpan.MinValue)
                {
                    RecordDTO employeeLunchExitRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "lunch_exit",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeLunchExitRecord);
                    _view.StartHourTimer();
                    _view.ShowLunchExitRecord(recordHour);
                    return;
                }

                if (_view.ExitRecord == TimeSpan.MinValue)
                {
                    RecordDTO employeeExitRecord = new RecordDTO(
                         EmployeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "exit",
                         recordedAt,
                         recordHour
                    );

                    _recordService.RegisterRecord(employeeExitRecord);
                    _view.StartHourTimer();
                    _view.ShowExitRecord(recordHour);
                }

                _view.DisableRecordButton();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return;
            }
        }

        private void VerifyEmployeeTodayAttendance()
        {
            EmployeeHasRegisteredTodayAttendance = _attendanceService.EmployeeHasRegisteredTodayAttendance();
            if (EmployeeHasRegisteredTodayAttendance)
            {
                EmployeeTodayAttendance = _attendanceService.GetEmployeeTodayAttendance();
            }

            if (EmployeeHasRegisteredTodayAttendance == true)
            {
                ShowEmployeeTodayRegisteredRecords();

                if (_recordService.EmployeeHasRegisteredAllTodayRecords(EmployeeTodayAttendance.Id) == true)
                {
                    _view.DisableRecordButton();
                }
            }
        }

        private void ShowEmployeeTodayRegisteredRecords()
        {
            List<RecordDTO> employeeTodayRecords = _recordService.GetEmployeeTodayRecords(EmployeeTodayAttendance.Id);

            foreach (var record in employeeTodayRecords)
            {
                if (record.RecordHour == TimeSpan.MinValue)
                {
                    continue;
                }

                switch (record.RecordType.ToLower())
                {
                    case "entry":
                        _view.ShowEntryRecord(record.RecordHour);
                        break;
                    case "lunch_entry":
                        _view.ShowLunchEntryRecord(record.RecordHour);
                        break;
                    case "lunch_exit":
                        _view.ShowLunchExitRecord(record.RecordHour);
                        break;
                    case "exit":
                        _view.ShowExitRecord(record.RecordHour);
                        break;
                }
            }
        }
    }
}
