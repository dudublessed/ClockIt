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

        public async Task<bool> IsUserRegistered(UserDTO user)
        {
            return await _repository.IsUserRegistered(user);
        }

        public async Task RegisterUser(UserDTO user)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                bool userIsAlreadyRegistered = await IsUserRegistered(user);
                if (userIsAlreadyRegistered)
                {
                    throw new InvalidOperationException("Este usuário já esta cadastrado");
                }

                await _repository.RegisterUser(user);

                scope.Complete();
            }
        }

        public async Task UpdateAdminPassword(UpdateAdminPasswordDTO credentials)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _repository.UpdateAdminPassword(credentials);

                scope.Complete();
            }
        }

        public async Task<List<ShowUsersDTO>> GetEnterpriseUsers()
        {
            var users = await _repository.GetEnterpriseUsers();

            bool hasUserInList = users.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não foi possível encontrar os usuários desta empresa.");
            }

            return users;
        }

        public async Task<List<ShowUsersDTO>> GetEnterpriseEmployeeUsers()
        {
            var employeeUsers = await _repository.GetEnterpriseEmployeeUsers();

            bool hasUserInList = employeeUsers.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não foi possível encontrar os usuários desta empresa.");
            }

            return employeeUsers;
        }

        public async Task<List<ShowUsersDTO>> GetNotEmployeeUsers()
        {
            var notEmployeeUsers = await _repository.GetNotEmployeeUsers();

            bool hasUserInList = notEmployeeUsers.Any();
            if (!hasUserInList)
            {
                throw new Exception("Não há usuários disponíveis para cadastrar um funcionário.");
            }

            return notEmployeeUsers;
        }

        public async Task<string> GetEnterpriseAdminPassword()
        {
            string adminPassword = await _repository.GetEnterpriseAdminPassword();

            if (string.IsNullOrEmpty(adminPassword))
            {
                throw new Exception("Erro ao acessar informações.");
            }

            return adminPassword;
        }

        public async Task<string> GetUserHashPasswordByLogin(string login)
        {
            string dbUserHashPassword = await _repository.GetUserHashPasswordByLogin(login);

            if (string.IsNullOrEmpty(dbUserHashPassword))
            {
                throw new Exception("Não foi possível validar o processo de login.");
            }

            return dbUserHashPassword;
        }
    }
}
