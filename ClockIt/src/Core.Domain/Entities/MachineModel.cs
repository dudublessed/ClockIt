using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ClockIt.src.Core.Domain.Entities
{
    public class MachineModel
    {
        public int Id { get; }
        public Guid Guid { get; }
        public int EnterpriseId { get; }
    
        public MachineModel(int id, Guid guid, int enterpriseId)
        {
            Id = id;
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
