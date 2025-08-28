using ClockIt.src.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IMachineService
    {
        public Guid GetLocalMachineGuid();

        public MachineModel GetMachineByGuid(Guid guid);
    }
}
