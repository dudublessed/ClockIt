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
        Task RegisterMachine(MachineRegisterDTO machine);
        Guid GetLocalMachineGuid();
        Task<MachineModel> GetMachine();
        Task<bool> IsMachineRegistered();
    }
}
