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
            ValidatePasswordInputs(password, confirmPassword);

            Password = UserPassword.FromInput(password);
            ConfirmPassword = UserPassword.FromInput(confirmPassword);
        }

        private void ValidatePasswordInputs(string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)) throw new ArgumentException("Nenhuma senha inserida.");
        }

        public bool DoesPasswordsMatch()
        {
            return Password.Value == ConfirmPassword.Value;
        }
    } 
}
