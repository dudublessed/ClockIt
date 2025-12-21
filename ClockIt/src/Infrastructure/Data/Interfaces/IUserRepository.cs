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
        Task RegisterUser(UserDTO user);
        // void FindUser();
        // void UpdateUser(UserModel user);
        // void DeleteUser(int userId);

        Task<bool> IsUserRegistered(UserDTO user);
        Task UpdateAdminPassword(UpdateAdminPasswordDTO credentials);
        Task<string> GetEnterpriseAdminPassword();
        Task<List<ShowUsersDTO>> GetEnterpriseUsers();
        Task<List<ShowUsersDTO>> GetEnterpriseEmployeeUsers();
        Task<List<ShowUsersDTO>> GetNotEmployeeUsers();
        Task<string> GetUserHashPasswordByLogin(string login);
    }
}
