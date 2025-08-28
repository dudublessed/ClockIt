using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IEnterpriseBO
    {
        int AddEnterprise(EnterpriseRegisterDTO enterprise);
        string GetEnterpriseNameById(int enterpriseId);
        bool ExistsEnterprise(EnterpriseRegisterDTO enterprise);
    }
}
