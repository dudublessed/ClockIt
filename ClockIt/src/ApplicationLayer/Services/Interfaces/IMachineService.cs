using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IMachineService
    {
        void RegisterMachine(MachineRegisterDTO machine);
        Guid GetLocalMachineGuid();
        MachineModel GetMachine();
        bool IsMachineRegistered();
    }
}
