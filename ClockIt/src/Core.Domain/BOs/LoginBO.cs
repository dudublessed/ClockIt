using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.Core.Domain.BOs
{
    public class LoginBO : ILoginBO
    {
        private readonly IMachineBO _machineBO;
        private readonly IEnterpriseBO _enterpriseBO;
        private readonly IUserBO _userBO;

        public LoginBO(IMachineBO machineBO, IEnterpriseBO enterpriseBO, IUserBO userBO)
        {
            _machineBO = machineBO;
            _enterpriseBO = enterpriseBO;
            _userBO = userBO;
        }

        public int GetEnterpriseIdByLocalMachine()
        {
            Guid guid = _machineBO.GetLocalMachineGuid();

            var machine = _machineBO.GetMachineByGuid(guid);

            if (machine == null)
            {
                throw new InvalidOperationException("Esta máquina não está registrada no sistema.");
            }

            return machine.EnterpriseId;
        }

        public string GetEnterpriseNameByLocalMachine()
        {
            int enterpriseId = GetEnterpriseIdByLocalMachine();

            return _enterpriseBO.GetEnterpriseNameById(enterpriseId);
        }

        public IEnumerable<ShowUsersDTO> GetUsersByEnterpriseId(int enterpriseId)
        {
            return _userBO.GetUsersByEnterpriseId(enterpriseId);
        }

        public bool IsAdminPasswordDefault()
        {
            int enterpriseId = GetEnterpriseIdByLocalMachine();

            var adminPasswordHash = _userBO.GetAdminPasswordByEnterpriseId(enterpriseId).Trim();

            return UserPassword.IsPasswordDefault(adminPasswordHash);
        }

        public void VerifyPassword(UserLoginDTO input)
        {
            string dbHashUserPassword = _userBO.GetUserHashPasswordByLoginAndEnterpriseId(input.Login, input.EnterpriseId);

            bool isPasswordCorrect = input.Password.IsPasswordCorrect(dbHashUserPassword);

            if (!isPasswordCorrect)
            {
                throw new InvalidOperationException("Senha incorreta.");
            }
        }
    }
}
