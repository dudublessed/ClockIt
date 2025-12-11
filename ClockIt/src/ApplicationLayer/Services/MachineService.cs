using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Infrastructure.Data.Repositories;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineBO _BO;
        private readonly IMachineRepository _repository;

        public MachineService(IMachineBO machineBO, IMachineRepository repository)
        {
            _BO = machineBO;
            _repository = repository;
        }

        public void RegisterMachine(MachineRegisterDTO machine)
        {
            _repository.AddMachine(machine);
        }

        public Guid GetLocalMachineGuid()
        {
            var guid = MachineModel.GetLocalMachineGuid();

            _BO.ValidateMachineGuid(guid);

            return guid;
        }

        public MachineModel GetMachine()
        {
            var guid = GetLocalMachineGuid();

            return _repository.GetMachineByGuid(guid);
        }

        public bool IsMachineRegistered()
        {
            Guid guid = GetLocalMachineGuid();

            return _repository.IsMachineRegistered(guid);
        }
    }
}
