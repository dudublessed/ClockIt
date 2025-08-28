using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Core.Domain.BOs
{
    public class UserBO : IUserBO
    {
        private readonly IUserRepository _userRepository;

        public UserBO(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserRegisterDTO user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            _userRepository.UpdateAdminPassword(credentials);
        }

        public IEnumerable<ShowUsersDTO> GetUsersByEnterpriseId(int enterpriseId)
        {
            var users = _userRepository.GetUsersByEnterpriseId(enterpriseId);

            bool hasUserInList = users.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não foi possível encontrar os usuários. Por favor, tente novamente.");
            }

            return users;
        }

        public string GetAdminPasswordByEnterpriseId(int enterpriseId)
        {
            string adminPassword = _userRepository.GetAdminPasswordByEnterpriseId(enterpriseId);

            if (string.IsNullOrEmpty(adminPassword))
            {
                throw new Exception("Erro ao acessar informações. 9336");
            }

            return adminPassword;
        }

        public string GetUserHashPasswordByLoginAndEnterpriseId(string login, int enterpriseId)
        {
            string dbUserHashPassword = _userRepository.GetPasswordHashByLoginAndEnterpriseId(login, enterpriseId);

            if (string.IsNullOrEmpty(dbUserHashPassword))
            {
                throw new Exception("Não foi possível validar o processo de login. Por favor, tente novamente.");
            }

            return dbUserHashPassword;
        }
    }
}
