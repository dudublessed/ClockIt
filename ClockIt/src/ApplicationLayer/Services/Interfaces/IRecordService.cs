using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IRecordService
    {
        void RegisterEntryRecord();
        void RegisterLunchEntryRecord();
        void RegisterLunchExitRecord();
        void RegisterExitRecord();
    }
}
