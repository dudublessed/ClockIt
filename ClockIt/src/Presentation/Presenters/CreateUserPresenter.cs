using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClockIt.src.Presentation.Presenters
{
    public class CreateUserPresenter : ICreateUserPresenter
    {
        private readonly ICreateUserNavigator _navigator;

        private ICreateUserForm _view;
        private readonly IUserService _service;
        private readonly IMainContext _context;

        public CreateUserPresenter(ICreateUserNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.UserService;

            _context = navigator.MainContext;
        }

        private void PrepareEventHandlers()
        {
            _view.UserNameInputValidationRequested -= ValidateUserNameInput;
            _view.UserPasswordInputValidationRequested -= ValidateUserPasswordInput;
            _view.CreateUserRequested -= CreateUser;

            _view.UserNameInputValidationRequested += ValidateUserNameInput;
            _view.UserPasswordInputValidationRequested += ValidateUserPasswordInput;
            _view.CreateUserRequested += CreateUser;
        }

        public void ShowDialog()
        {
            _view = _navigator.CreateUserForm;

            PrepareEventHandlers();

            var createUserForm = (Form)_view;
            FormHelper.OpenFormAsDialog(createUserForm);
        }

        private void ValidateUserNameInput(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.UserName) || string.IsNullOrWhiteSpace(_view.UserName)) throw new ArgumentException("Por favor, informe o nome do usuário.");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void ValidateUserPasswordInput(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.UserPassword) || string.IsNullOrWhiteSpace(_view.UserPassword)) throw new ArgumentException("Por favor, insira uma senha.");
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void CreateUser(object? sender, EventArgs e)
        {
            try
            {
                var user = new UserDTO(
                    _view.UserName,
                    _view.Login,
                    _view.UserPassword,
                    UserDTO.UserType.User,
                    _context.Enterprise.Id);

                _service.RegisterUser(user);

                MessageBoxHelper.ShowSucess("Usuário cadastrado com sucesso!");

                _view.CleanUserInputFields();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
