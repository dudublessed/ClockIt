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
        MachineModel GetMachineByGuid(Guid guid);
        void AddMachine(MachineRegisterDTO machine);
        //void UpdateMachine(MachineModel machine);
        //void DeleteMachine(Guid guid);
        bool ExistsMachine(Guid guid);
    }
}
