using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BCrypt.Net;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Core.Domain.ValueObjects
{
    public class UserPassword
    {
        public string Value { get; }

        public const string DefaultValue = "mA$p01MlLIO!";

        private UserPassword(string value)
        {
            Value = value;
        }

        public static UserPassword CreateNew(string rawPassword)
        {
            rawPassword = rawPassword.Trim();

            ValidatePassword(rawPassword);

            string hashedPassword = HashPassword(rawPassword);

            return new UserPassword(hashedPassword);
        }

        public static UserPassword FromInput(string rawPassword)
        {
            return new UserPassword(rawPassword);
        }

        private static void ValidatePassword(string password)
        {
           bool isPasswordEmpty = string.IsNullOrWhiteSpace(password);
           bool isValid = 
               !isPasswordEmpty 
               && ValidationUtils.HasSpecialCharacter(password) 
               && ValidationUtils.PasswordHasMinimumLength(password)
               && !ValidationUtils.PasswordExceedsMaximumLength(password)
               && !ValidationUtils.HasInvalidCharacter(password);

           if (!isValid)
            {
                throw new ArgumentException("A senha inserida é inválida. Por favor, tente novamente.");
            }
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public static bool IsPasswordDefault(string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(DefaultValue, hashedPassword);
        }

        public bool IsPasswordCorrect(string databaseHashPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(Value, databaseHashPassword);
        }

        public override string ToString() => Value;
    }
}
