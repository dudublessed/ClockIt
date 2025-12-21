using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IEnterpriseRepository
    {
        Task<int> RegisterEnterprise(EnterpriseRegisterDTO enterprise);
        //void UpdateEnterprise(EnterpriseModel enterprise);
        //void DeleteEnterprise(int id);
        Task<EnterpriseModel> GetEnterpriseById(int id);
        Task<int> GetEnterpriseIdByName(string enterpriseName);
        //List<EnterpriseModel> GetAllEnterprises();
        Task<string> GetEnterpriseNameById(int enterpriseId);
        Task<bool> ExistsEnterprise(EnterpriseRegisterDTO enterprise);

    }
}
