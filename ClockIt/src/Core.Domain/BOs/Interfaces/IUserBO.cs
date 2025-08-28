using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IUserBO
    {
        void AddUser(UserRegisterDTO user);
        void UpdateAdminPassword(UpdateAdminPasswordDTO updateAdminPasswordCredentials);
        IEnumerable<ShowUsersDTO> GetUsersByEnterpriseId(int enterpriseId);
        string GetAdminPasswordByEnterpriseId(int enterpriseId);
        string GetUserHashPasswordByLoginAndEnterpriseId(string login, int enterpriseId);
    }
}
