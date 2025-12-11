using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        void RegisterUser(UserDTO user);
        // void FindUser();
        // void UpdateUser(UserModel user);
        // void DeleteUser(int userId);

        bool IsUserRegistered(UserDTO user);
        void UpdateAdminPassword(UpdateAdminPasswordDTO credentials);
        string GetEnterpriseAdminPassword();
        List<ShowUsersDTO> GetEnterpriseUsers();
        List<ShowUsersDTO> GetEnterpriseEmployeeUsers();
        List<ShowUsersDTO> GetNotEmployeeUsers();
        string GetUserHashPasswordByLogin(string login);
    }
}
