using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;

namespace ClockIt.src.Core.Domain.BOs
{
    public class MainBO : IMainBO
    {
        private readonly IMachineBO _machineBO;
        public MainBO(IMachineBO machineBO)
        {
            _machineBO = machineBO;
        }

        public bool VerifyMachineExistance()
        {
            Guid localMachineGuid = _machineBO.GetLocalMachineGuid();

            if (localMachineGuid == Guid.Empty)
            {
                throw new Exception("Erro ao buscar registro. Por favor, tente novamente.");
            }

            var machine = _machineBO.GetMachineByGuid(localMachineGuid);

            bool isMachineRegistered = machine != null;

            return isMachineRegistered;
        }
    }
}
