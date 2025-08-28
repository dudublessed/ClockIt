using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class MainService : IMainService
    {
        private readonly IMainBO _mainBO;

        public MainService(IMainBO mainBO)
        {
            _mainBO = mainBO;
        }

        public bool IsMachineRegistered()
        {
            return _mainBO.VerifyMachineExistance();
        }
    }
}
