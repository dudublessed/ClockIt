using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IPositionsRepository
    {
        List<PositionsModel> GetEnterprisePositions();
    }
}
