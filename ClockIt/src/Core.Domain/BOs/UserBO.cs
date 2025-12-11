using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.Constants;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.BOs
{
    public class UserBO : IUserBO
    {
        public bool ValidatePasswordInput(string password, out string errorMessage)
        {
            if (!ValidationUtils.PasswordHasMinimumLength(password))
            {
                errorMessage = $"A senha deve ter pelo menos {PasswordConstants.MinimumLength} dígitos";
                return false;
            }

            if (ValidationUtils.PasswordExceedsMaximumLength(password))
            {
                errorMessage = $"A senha não pode exceder {PasswordConstants.MaximumLength} dígitos";
                return false;
            }

            if (!ValidationUtils.HasSpecialCharacter(password))
            {
                errorMessage = "A senha deve ter pelo menos um caractere especial";
                return false;
            }

            if (ValidationUtils.HasInvalidCharacter(password))
            {
                errorMessage = "A senha possui caracteres inválidos. Tente novamente.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
