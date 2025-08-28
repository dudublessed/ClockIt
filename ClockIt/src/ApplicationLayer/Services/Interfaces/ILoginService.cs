using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface ILoginService
    {
        int GetEnterpriseId();
        string GetEnterpriseName();
        IEnumerable<ShowUsersDTO> GetUsers(int enterpriseId);
        bool IsAdminPasswordDefault();
        void VerifyPassword(UserLoginDTO input);

    }
}
