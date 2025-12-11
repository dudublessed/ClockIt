using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IPositionsService
    {
        List<PositionsModel> GetEnterprisePositions();
    }
}
