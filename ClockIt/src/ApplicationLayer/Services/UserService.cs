using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsUserRegistered(UserDTO user)
        {
            return _repository.IsUserRegistered(user);
        }

        public void RegisterUser(UserDTO user)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                bool userIsAlreadyRegistered = IsUserRegistered(user);
                if (userIsAlreadyRegistered) throw new InvalidOperationException("Este usuário já esta cadastrado");

                _repository.RegisterUser(user);

                scope.Complete();
            }
        }

        public void UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _repository.UpdateAdminPassword(credentials);

                scope.Complete();
            }
        }

        public List<ShowUsersDTO> GetEnterpriseUsers()
        {
            var users = _repository.GetEnterpriseUsers();

            bool hasUserInList = users.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não foi possível encontrar os usuários desta empresa.");
            }

            return users;
        }

        public List<ShowUsersDTO> GetEnterpriseEmployeeUsers()
        {
            var employeeUsers = _repository.GetEnterpriseEmployeeUsers();

            bool hasUserInList = employeeUsers.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não foi possível encontrar os usuários desta empresa.");
            }

            return employeeUsers;
        }

        public List<ShowUsersDTO> GetNotEmployeeUsers()
        {
            var notEmployeeUsers = _repository.GetNotEmployeeUsers();

            bool hasUserInList = notEmployeeUsers.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não há usuários disponíveis para cadastrar um funcionário.");
            }

            return notEmployeeUsers;
        }

        public string GetEnterpriseAdminPassword()
        {
            string adminPassword = _repository.GetEnterpriseAdminPassword();

            if (string.IsNullOrEmpty(adminPassword))
            {
                throw new Exception("Erro ao acessar informações.");
            }

            return adminPassword;
        }

        public string GetUserHashPasswordByLogin(string login)
        {
            string dbUserHashPassword = _repository.GetUserHashPasswordByLogin(login);

            if (string.IsNullOrEmpty(dbUserHashPassword))
            {
                throw new Exception("Não foi possível validar o processo de login.");
            }

            return dbUserHashPassword;
        }

        public bool IsPasswordInputsMatching(PasswordsMatchDTO credentials)
        {
            return credentials.DoesPasswordsMatch();
        }
    }
}
