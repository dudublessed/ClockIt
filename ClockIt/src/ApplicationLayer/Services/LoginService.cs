using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginBO _loginBO;

        public LoginService(ILoginBO loginBO)
        {
            _loginBO = loginBO;
        }

        public int GetEnterpriseId()
        {
            return _loginBO.GetEnterpriseIdByLocalMachine();
        }

        public string GetEnterpriseName()
        {
            return _loginBO.GetEnterpriseNameByLocalMachine();
        }

        public IEnumerable<ShowUsersDTO> GetUsers(int enterpriseId)
        {
            return _loginBO.GetUsersByEnterpriseId(enterpriseId);
        }

        public bool IsAdminPasswordDefault()
        {
            return _loginBO.IsAdminPasswordDefault();
        }

        public void VerifyPassword(UserLoginDTO input)
        {
            _loginBO.VerifyPassword(input);
        }
    }
}
