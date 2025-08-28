using ClockIt.src.Core.Constants;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockIt.src.Core.Domain.BOs
{
    public class AdminPasswordBO : IAdminPasswordBO
    {
        private readonly IUserBO _userBO; 

        public AdminPasswordBO(IUserBO userBO)
        {
            _userBO = userBO;
        }

        public bool IsPasswordInputsMatching(PasswordsMatchDTO credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentException("Erro ao validar as senhas inseridas. Por favor, tente novamente.");
            }

            return credentials.Password.Value == credentials.ConfirmPassword.Value;
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentException("Erro ao atualizar a senha do administrador. Por favor, tente novamente.");
            }

            _userBO.UpdateAdminPassword(credentials);
        }

        public bool ValidatePassword(string password, out string errorMessage)
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
