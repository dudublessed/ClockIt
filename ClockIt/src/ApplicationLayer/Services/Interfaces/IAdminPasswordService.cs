using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IAdminPasswordService
    {
        bool DoesPasswordsMatch(PasswordsMatchDTO passwordsMatchCredentials);
        void UpdateAdminPassword(UpdateAdminPasswordDTO updatePasswordCredentials);
        bool ValidatePasswordInput(string passwordInput, out string errorMessage);
    }
}
