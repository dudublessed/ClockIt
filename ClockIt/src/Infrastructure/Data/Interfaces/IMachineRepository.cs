using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IMachineRepository
    {
        Task<MachineModel> GetMachineByGuid(Guid guid);
        Task AddMachine(MachineRegisterDTO machine);
        //void UpdateMachine(MachineModel machine);
        //void DeleteMachine(Guid guid);
        Task<bool> IsMachineRegistered(Guid guid);
    }
}
