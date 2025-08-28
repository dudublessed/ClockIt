using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IRegisterEnterpriseBO
    {
        void CheckIfEnterpriseExists(EnterpriseRegisterDTO enterprise);
        void CheckIfMachineExists();
        Guid GetLocalMachineGuid();
        int RegisterEnterprise(EnterpriseRegisterDTO enterprise);
        void RegisterMachine(MachineRegisterDTO machine);
        void RegisterAdminUser(UserRegisterDTO admin);
        string GetStatesJsonByCountry(string country);
        string GetCitiesJsonByCountry(string country);
    }
}
