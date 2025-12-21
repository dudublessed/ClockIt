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
        Task CheckIfEnterpriseExists(EnterpriseRegisterDTO enterprise);
        Task<int> RegisterEnterprise(EnterpriseRegisterDTO enterprise);
        Task<string> GetStatesJsonByCountry(string country);
        Task<string> GetCitiesJsonByCountry(string country);
    }
}
