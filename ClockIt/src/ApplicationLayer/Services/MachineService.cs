using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Infrastructure.Data.Repositories;
using ClockIt.src.Core.Domain.BOs;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.ApplicationLayer.Services.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class MachineService : IMachineService
    {
        private readonly MachineBO _machineBO;

        public MachineService(MachineBO machineBO)
        {
            _machineBO = machineBO;
        }

        public Guid GetLocalMachineGuid()
        {
           return _machineBO.GetLocalMachineGuid();
        }

        public MachineModel GetMachineByGuid(Guid guid)
        {
            return _machineBO.GetMachineByGuid(guid);
        }
    }
}
