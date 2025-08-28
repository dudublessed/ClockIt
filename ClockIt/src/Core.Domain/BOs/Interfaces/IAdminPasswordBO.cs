using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IAdminPasswordBO
    {
        bool IsPasswordInputsMatching(PasswordsMatchDTO passwordsMatchingCredentials);
        void UpdateAdminPassword(UpdateAdminPasswordDTO updatePasswordCredentials);

        bool ValidatePassword(string password, out string errorMessage);
    }
}
