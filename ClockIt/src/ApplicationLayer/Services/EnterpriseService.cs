using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class EnterpriseService : IEnterpriseService
    {
        private readonly EnterpriseBO _enterpriseBO;

        public EnterpriseService(EnterpriseBO enterpriseBO)
        {
            _enterpriseBO = enterpriseBO;
        }

        public string GetEnterpriseNameById(int enterpriseId)
        {
            return _enterpriseBO.GetEnterpriseNameById(enterpriseId);
        }
    }
}
