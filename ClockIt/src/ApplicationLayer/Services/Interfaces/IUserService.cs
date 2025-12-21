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
        Task<bool> IsUserRegistered(UserDTO user);
        Task RegisterUser(UserDTO user);
        Task UpdateAdminPassword(UpdateAdminPasswordDTO credentials);
        Task<List<ShowUsersDTO>> GetEnterpriseUsers();
        Task<List<ShowUsersDTO>> GetEnterpriseEmployeeUsers();
        Task<List<ShowUsersDTO>> GetNotEmployeeUsers();
        Task<string> GetEnterpriseAdminPassword();
        Task<string> GetUserHashPasswordByLogin(string login);
    }
}
