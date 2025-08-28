using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class UpdateAdminPasswordDTO
    {
        public string Login { get; }
        public UserPassword Password { get; }

        public UpdateAdminPasswordDTO(string password)
        {
            Login = "ADMIN";
            Password = UserPassword.CreateNew(password);
        }
    }
}
