using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly IEnterpriseBO _BO;
        private readonly IEnterpriseRepository _repository;

        public EnterpriseService(IEnterpriseBO enterpriseBO, IEnterpriseRepository repository)
        {
            _BO = enterpriseBO;
            _repository = repository;
        }

        public async Task<EnterpriseModel> GetEnterpriseById(int enterpriseId)
        {
            return await _repository.GetEnterpriseById(enterpriseId);
        }

        public async Task<string> GetEnterpriseNameById(int enterpriseId)
        {
            return await _BO.GetEnterpriseNameById(enterpriseId);
        }
    }
}
