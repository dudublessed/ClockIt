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

        private IEmployeeService _service;

        private readonly IEmployeeLoggedContext _employeeContext;

        public EmployeeMainPresenter(IEmployeeMainNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.EmployeeService;

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
            // Verificar se o usuário efetuou registros no respectivo dia
            //
            // Se sim, carregar os registros na tela && desabilitar o botão de registro
        }

        private void RegisterRecord(object? sender, EventArgs e)
        {
            try
            {
                if (_service.EmployeeHasRegisteredTodayAttendance() == false)
                {
                    DailyAttendanceDTO todayAttendance = new DailyAttendanceDTO(_employeeContext.Employee.Id, DateTime.Now.Date);

                    _service.RegisterDailyAttendance(todayAttendance);
                }

                AttendanceModel employeeTodayAttendance = _service.GetEmployeeTodayAttendance();

                DateTimeOffset recordedAt = DateTimeOffset.Now;
                TimeSpan recordHour = DateTime.Now.TimeOfDay;

                if (_view.EntryRecord == TimeSpan.Zero)
                {
                     RecordDTO employeeEntryRecord = new RecordDTO(
                          employeeTodayAttendance.Id,
                          _employeeContext.Employee.Id,
                          "entry",
                          recordedAt,
                          recordHour
                     );

                    _service.RegisterEntryRecord();
                    _view.ShowEntryRecord();
                    return;
                }

                if (_view.LunchEntryRecord == TimeSpan.Zero)
                {
                    RecordDTO employeeEntryRecord = new RecordDTO(
                         employeeTodayAttendance.Id,
                         _employeeContext.Employee.Id,
                         "entry",
                         recordedAt,
                         recordHour
                    );

                    _service.RegisterLunchEntryRecord();
                    _view.ShowLunchEntryRecord();
                    return;
                }

                if (_view.LunchExitRecord == TimeSpan.Zero)
                {
                    _service.RegisterLunchExitRecord();
                    _view.ShowLunchExitRecord();
                    return;
                }

                if (_view.ExitRecord == TimeSpan.Zero)
                {
                    _service.RegisterExitRecord();
                    _view.ShowExitRecord();
                    return;
                }

                //List<RecordDTO> employeeTodayRecords = _service.GetEmployeeTodayRecords();
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
