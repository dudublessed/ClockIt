using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.Core.Domain.BOs
{
    public class MachineBO : IMachineBO
    {

        public void ValidateMachineGuid(Guid guid)
        {
            if (guid == Guid.Empty)
            {
                throw new Exception("Máquina não detectada. Por favor, tente novamente.");
            }
        }

    }
}
