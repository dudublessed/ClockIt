using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class MainService : IMainService
    {
        private readonly IMachineService _machineService;
        private readonly IEnterpriseService _enterpriseService;

        private IMainContext _mainContext;

        public MainService(IMachineService machineService, IEnterpriseService enterpriseService, IMainContext mainContext)
        {
            _machineService = machineService;
            _enterpriseService = enterpriseService;
            _mainContext = mainContext;
        }

        public bool IsMachineRegistered()
        {
            return _machineService.IsMachineRegistered();
        }

        public void SetApplicationContext()
        {
            MachineModel contextMachine = _machineService.GetMachine();
            EnterpriseModel contextEnterprise = _enterpriseService.GetEnterpriseById(contextMachine.EnterpriseId);

            _mainContext.SetMainContext(contextMachine, contextEnterprise);
        }
    }
}
