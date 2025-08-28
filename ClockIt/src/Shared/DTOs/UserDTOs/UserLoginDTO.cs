using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        public string Login { get; }
        public UserPassword Password { get; }
        public int EnterpriseId { get; }

        public UserLoginDTO(string login, string password, int enterpriseId)
        {
            Login = login;
            Password = UserPassword.FromInput(password);
            EnterpriseId = enterpriseId;
        }
    }
}
