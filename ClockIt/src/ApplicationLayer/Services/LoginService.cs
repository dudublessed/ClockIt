using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;

        public LoginService(IUserService userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;

        }

        public EmployeeModel GetEmployeeByUserContext()
        {
            return _employeeService.GetEmployeeByUserContext();
        }

        public List<ShowUsersDTO> GetEnterpriseEmployeeUsers()
        {
            return _userService.GetEnterpriseEmployeeUsers();
        }

        public bool IsAdminPasswordDefault()
        { 
            var adminPasswordHash = _userService.GetEnterpriseAdminPassword().Trim();;

            return UserPassword.IsPasswordDefault(adminPasswordHash);
        }

        public void VerifyPassword(UserLoginDTO input)
        { 
            string dbHashUserPassword = _userService.GetUserHashPasswordByLogin(input.Login);

            bool isPasswordCorrect = input.Password.IsPasswordCorrect(dbHashUserPassword);

            if (!isPasswordCorrect)
            {
                throw new InvalidOperationException("Senha incorreta.");
            }
        }
    }
}
