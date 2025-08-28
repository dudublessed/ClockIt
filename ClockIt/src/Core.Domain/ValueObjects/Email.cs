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
    public class Email
    {
        public string Value { get; }

        public Email(string email)
        {
            ValidateEmail(email);

            Value = email;
        }

        private void ValidateEmail(string email)
        {
            bool isEmailEmpty = string.IsNullOrWhiteSpace(email);
            bool isValid =
                !isEmailEmpty
                && ValidationUtils.IsEmailFormatCorrect(email);

            if (!isValid)
            {
                throw new ArgumentException("O email inserido é inválido. Por favor, tente novamente.");
            }
        }

        public override string ToString() => Value;
    }
}
