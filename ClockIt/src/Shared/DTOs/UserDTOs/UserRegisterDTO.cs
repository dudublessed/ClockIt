using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class UserRegisterDTO
    {
        public enum UserType
        {
            Admin,
            User
        }

        public string UserName { get; }
        public string Login { get; }
        public UserPassword Password { get; }
        public UserType Type { get; }
        public int EnterpriseId { get; }

        public UserRegisterDTO(string userName, string login, UserPassword password, UserType type, int enterpriseId)
        {
            UserName = userName;
            Login = login;
            Password = password;
            Type = type;
            EnterpriseId = enterpriseId;
        }
    }
}