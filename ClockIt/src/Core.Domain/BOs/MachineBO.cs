using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Infrastructure.Data.Interfaces;

namespace ClockIt.src.Core.Domain.BOs
{
    public class MachineBO : IMachineBO
    {
        private readonly IMachineRepository _machineRepository;

        public MachineBO(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public void AddMachine(MachineRegisterDTO machine)
        {
            _machineRepository.AddMachine(machine);
        }

        public Guid GetLocalMachineGuid()
        {
            var guid = MachineModel.GetLocalMachineGuid();

            if (guid == Guid.Empty)
            {
                throw new Exception("Máquina não detectada. Por favor, tente novamente.");
            }

            return guid;
        }

        public MachineModel GetMachineByGuid(Guid guid)
        {
            return _machineRepository.GetMachineByGuid(guid);
        }

        public bool ExistsMachine()
        {
            var guid = GetLocalMachineGuid();

            return _machineRepository.ExistsMachine(guid);
        }
    }
}
