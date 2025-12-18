using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.EmailDTOs;
using ClockIt.src.Shared.DTOs.EmployeeDTOs;
using ClockIt.src.Shared.DTOs.EmployeeDTOs.ScheduleDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.Presentation.Presenters
{
    public class CreateEmployeePresenter : ICreateEmployeePresenter
    {
        private readonly ICreateEmployeeNavigator _navigator;

        private ICreateEmployeeForm _view;
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly IScheduleService _scheduleService;
        private readonly IMainContext _context;

        public CreateEmployeePresenter(ICreateEmployeeNavigator navigator)
        {
            _navigator = navigator;

            _employeeService = navigator.EmployeeService;
            _userService = navigator.UserService;
            _scheduleService = navigator.ScheduleService;

            _context = navigator.MainContext;
        }

        private void PrepareEventHandlers()
        {
            _view.EnterpriseUsersRequested -= ShowEntepriseUsers;
            _view.EnterprisePositionsRequested -= ShowEnterprisePositions;
            _view.CreateEmployeeRequested -= CreateEmployee;

            _view.EnterpriseUsersRequested += ShowEntepriseUsers;
            _view.EnterprisePositionsRequested += ShowEnterprisePositions;
            _view.CreateEmployeeRequested += CreateEmployee;
        }

        public void ShowDialog()
        {
            _view = _navigator.CreateEmployeeForm;

            PrepareEventHandlers();

            var createEmployeeForm = (Form)_view;
            FormHelper.OpenFormAsDialog(createEmployeeForm);
        }

        private void ShowEntepriseUsers(object? sender, EventArgs e)
        {
            try
            {
                var enterpriseUsers = _userService.GetNotEmployeeUsers();

                _view.EnterpriseUsers = enterpriseUsers;

                _view.ShowEnterpriseUsers();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                FormHelper.CloseForm((Form)_view);
            }
        }

        private void ShowEnterprisePositions(object? sender, EventArgs e)
        {
            try
            {
                var enterprisePositions = _employeeService.GetEnterprisePositions();

                _view.EnterprisePositions = enterprisePositions;

                _view.ShowEnterprisePositions();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                FormHelper.CloseForm((Form)_view);
            }
        }

        private void CreateEmployee(object? sender, EventArgs e)
        {
            try
            {
                var emailValidationCredentials = new EmailValidationDTO(_view.Email, _view.UserName);
                var result = _navigator.EmailValidationPresenter.ShowDialog(emailValidationCredentials);

                if (result != DialogResult.OK)
                {
                    return;
                }

                var userId = _view.EnterpriseUsers
                    .Where(s => s.UserName == _view.UserName)
                    .Select(s => s.Id)
                    .FirstOrDefault();

                var positionId = _view.EnterprisePositions
                    .Where(s => s.Name == _view.Position)
                    .Select(s => s.Id)
                    .FirstOrDefault();

                var employee = new EmployeeDTO(
                    userId,
                    _view.FullName,
                    _view.CPF,
                    _view.BirthDate,
                    _view.Email,
                    positionId
                );

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    _employeeService.RegisterEmployee(employee);

                    int newEmployeeId = _employeeService.GetEmployeeByUserId(userId).Id;

                    var employeeSchedule = new ScheduleDTO(
                        newEmployeeId,
                        _view.EntryTime,
                        _view.LunchEntryTime,
                        _view.LunchExitTime,
                        _view.ExitTime,
                        DateTimeOffset.Now,
                        true
                    );

                    _scheduleService.RegisterEmployeeSchedule(employeeSchedule);

                    scope.Complete();
                }

                MessageBoxHelper.ShowSucess("Funcionário cadastrado com sucesso!");

                _view.CleanScreenInputs();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
