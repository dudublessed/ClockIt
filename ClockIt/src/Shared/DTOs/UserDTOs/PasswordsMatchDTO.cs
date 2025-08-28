using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class PasswordsMatchDTO
    {
        public UserPassword Password { get; }
        public UserPassword ConfirmPassword { get; }

        public PasswordsMatchDTO(string password, string confirmPassword)
        {
            Password = UserPassword.FromInput(password);
            ConfirmPassword = UserPassword.FromInput(confirmPassword);
        }
    }
}
