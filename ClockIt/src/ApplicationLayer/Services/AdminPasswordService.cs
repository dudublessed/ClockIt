using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class AdminPasswordService : IAdminPasswordService
    {
        private readonly IAdminPasswordBO _adminPasswordBO;
       
        public AdminPasswordService(IAdminPasswordBO adminPasswordBO)
        {
            _adminPasswordBO = adminPasswordBO;
        }

        public bool DoesPasswordsMatch(PasswordsMatchDTO passwordsMatchCredentials)
        {
            return _adminPasswordBO.IsPasswordInputsMatching(passwordsMatchCredentials);
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO updatePasswordCredentials)
        {
            _adminPasswordBO.UpdateAdminPassword(updatePasswordCredentials);
        }

        public bool ValidatePasswordInput(string passwordInput, out string errorMessage)
        {
            return _adminPasswordBO.ValidatePassword(passwordInput, out errorMessage);
        }
    }
}
