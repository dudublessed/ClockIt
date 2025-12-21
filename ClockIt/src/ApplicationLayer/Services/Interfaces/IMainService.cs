using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IMainService
    {
        Task<bool> IsMachineRegistered();
        Task SetApplicationContext();
    }
}
