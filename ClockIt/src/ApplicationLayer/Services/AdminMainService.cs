using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class AdminMainService : IAdminMainService
    {
        private readonly IAdminMainBO _adminMainBO;

        public AdminMainService(IAdminMainBO adminMainBO)
        {
            _adminMainBO = adminMainBO;
        }
    }
}
