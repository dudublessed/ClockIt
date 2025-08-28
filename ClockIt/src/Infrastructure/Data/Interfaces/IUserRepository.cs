using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserRegisterDTO user);
        string GetAdminPasswordByEnterpriseId(int enterpriseId);
        void UpdateAdminPassword(UpdateAdminPasswordDTO credentials);
        IEnumerable<ShowUsersDTO> GetUsersByEnterpriseId(int enterpriseId);
        string GetPasswordHashByLoginAndEnterpriseId(string login, int enterpriseId);
    }
}
