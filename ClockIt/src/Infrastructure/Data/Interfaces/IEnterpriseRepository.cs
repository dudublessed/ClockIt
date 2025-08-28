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
        int AddEnterprise(EnterpriseRegisterDTO enterprise);
        //void UpdateEnterprise(EnterpriseModel enterprise);
        //void DeleteEnterprise(int id);
        EnterpriseModel GetEnterpriseById(int id);
        int GetEnterpriseIdByName(string enterpriseName);
        //List<EnterpriseModel> GetAllEnterprises();
        string GetEnterpriseNameById(int enterpriseId);
        bool ExistsEnterprise(EnterpriseRegisterDTO enterprise);

    }
}
