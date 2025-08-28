using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IMachineBO
    {
        void AddMachine(MachineRegisterDTO machine);
        Guid GetLocalMachineGuid();
        MachineModel GetMachineByGuid(Guid guid);
        bool ExistsMachine();
    }
}
