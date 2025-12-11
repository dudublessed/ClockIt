using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Infrastructure.Data.Repositories;
using ClockIt.src.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserBO _userBO;
        private readonly IUserRepository _userRepository;
       
        public AdminService(IUserBO userBO, IUserRepository userRepository)
        {
            _userBO = userBO;
            _userRepository = userRepository;
        }

        public bool DoesPasswordsMatch(PasswordsMatchDTO credentials)
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

            _userRepository.UpdateAdminPassword(credentials);
        }

        public bool ValidatePasswordInput(string passwordInput, out string errorMessage)
        {
            return _userBO.ValidatePasswordInput(passwordInput, out errorMessage);
        }
    }
}
