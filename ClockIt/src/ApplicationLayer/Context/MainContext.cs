using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.ApplicationLayer.Context
{
    public class MainContext : IMainContext
    {
        public MachineModel Machine { get; private set; }
        public EnterpriseModel Enterprise { get; private set; }

        public void SetMainContext(MachineModel machine, EnterpriseModel enterprise)
        {
            Machine = machine;
            Enterprise = enterprise;
        }

    }
}
