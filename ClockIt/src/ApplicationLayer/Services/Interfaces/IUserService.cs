using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUserRegistered(UserDTO user);
        void RegisterUser(UserDTO user);
        void UpdateAdminPassword(UpdateAdminPasswordDTO credentials);
        List<ShowUsersDTO> GetEnterpriseUsers();
        List<ShowUsersDTO> GetEnterpriseEmployeeUsers();
        List<ShowUsersDTO> GetNotEmployeeUsers();
        string GetEnterpriseAdminPassword();
        string GetUserHashPasswordByLogin(string login);
        bool IsPasswordInputsMatching(PasswordsMatchDTO credentials);
    }
}
