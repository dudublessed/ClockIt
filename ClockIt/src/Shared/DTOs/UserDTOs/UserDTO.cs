using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class UserDTO
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

        public UserDTO(string userName, string login, string password, UserType type, int enterpriseId)
        {
            ValidateUserNameInput(userName);
            ValidateUserTypeInut(type);
            ValidateEnterpriseIdInput(enterpriseId);

            UserName = userName;
            Login = login;
            Password = UserPassword.CreateNew(password);
            Type = type;
            EnterpriseId = enterpriseId;
        }

        private void ValidateUserNameInput(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName)) throw new ArgumentException("O nome de usuário não é válido");
        }

        private void ValidateUserTypeInut(UserType type)
        {
            if (!Enum.IsDefined(typeof(UserType), type)) throw new ArgumentException("O tipo de usuário não é válido.");
        }

        private void ValidateEnterpriseIdInput(int enterpriseId)
        {
            if (enterpriseId <= 0) throw new ArgumentException("Não foi possível cadastrar o usuário para esta empresa.");
        }
    }
}
