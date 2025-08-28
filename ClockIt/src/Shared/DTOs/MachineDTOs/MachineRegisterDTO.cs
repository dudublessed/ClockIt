using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.MachineDTOs
{
    public class MachineRegisterDTO
    {
        public Guid Guid { get; }
        public int EnterpriseId { get; }

        public MachineRegisterDTO(Guid guid, int enterpriseId)
        {
            Guid = guid;
            EnterpriseId = enterpriseId;
        }

        public static Guid GetLocalMachineGuid()
        {
            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography"))
            {
                string guidString = key?.GetValue("MachineGuid")?.ToString();
                return Guid.TryParse(guidString, out Guid machineGuid) ? machineGuid : Guid.Empty;
            }
        }
    }
}
