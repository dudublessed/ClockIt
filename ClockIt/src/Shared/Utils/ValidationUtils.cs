using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClockIt.src.Shared.Constants;

namespace ClockIt.src.Shared.Utils
{
    public static class ValidationUtils
    {
        public static bool PasswordsMatch(string firstPassword, string secondPassword)
        {
            return firstPassword == secondPassword;
        }

        public static bool HasSpecialCharacter(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9]");
        }

        public static bool PasswordHasMinimumLength(string password)
        {
            return password.Length >= PasswordConstants.MinimumLength;
        }

        public static bool PasswordExceedsMaximumLength(string password)
        {
            return password.Length > PasswordConstants.MaximumLength;
        }

        //public static bool BCryptVerifyPassword(string plainPassword, string hashedPassword)
        //{
        //    if (string.IsNullOrEmpty(plainPassword) || string.IsNullOrEmpty(hashedPassword))
        //    {
        //        return false;
        //    }

        //    return BCrypt.Net.BCrypt.EnhancedVerify(plainPassword, hashedPassword);
        //}

        public static bool HasInvalidCharacter(string input)
        {
            return Regex.IsMatch(input, @"[^a-zA-Z0-9!@#$%&*-]");
        }

        public static bool IsEmailFormatCorrect(string email)
        {
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }
    }
}
