using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class RegisterAdminDTO
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

        public RegisterAdminDTO(string userName, string login, string password, int enterpriseId)
        {
            UserName = userName;
            Login = login;
            Password = UserPassword.CreateNew(password);
            Type = UserType.Admin;
            EnterpriseId = enterpriseId;
        }
    }
}