using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class UserMainService : IUserMainService
    {
        private readonly IUserMainBO _userMainBO;

        public UserMainService(IUserMainBO userMainBO)
        {
            _userMainBO = userMainBO;
        }
    }
}
