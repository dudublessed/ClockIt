using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.ApplicationLayer.Context.Interfaces
{
    public interface IMainContext
    {
        MachineModel Machine { get; }
        EnterpriseModel Enterprise { get; }

        void SetMainContext(MachineModel machine, EnterpriseModel enterprise);
    }
}
