using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.BOs
{
    public class EnterpriseBO : IEnterpriseBO
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseBO(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public async Task<int> AddEnterprise(EnterpriseRegisterDTO enterprise)
        {
            var generatedEnterpriseId = await _enterpriseRepository.RegisterEnterprise(enterprise);

            if (generatedEnterpriseId == 0)
            {
                throw new Exception("Falha ao cadastrar a empresa. Por favor, tente novamente.");
            }

            return generatedEnterpriseId;
        }

        public async Task<string> GetEnterpriseNameById(int enterpriseId)
        {
            string enterpriseName = await _enterpriseRepository.GetEnterpriseNameById(enterpriseId);

            if (string.IsNullOrEmpty(enterpriseName))
            {
                throw new Exception("Não foi possível achar a empresa. Por favor, tente novamente.");
            }

            return enterpriseName;
        }

        public async Task<bool> ExistsEnterprise(EnterpriseRegisterDTO enterprise)
        {
            return await _enterpriseRepository.ExistsEnterprise(enterprise);
        }
    }
}
