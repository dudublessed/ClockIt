using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.PositionDTOs;

namespace ClockIt.src.Infrastructure.Data.Interfaces
{
    public interface IPositionRepository
    {
        Task RegisterPosition(PositionDTO position);
        Task<List<PositionModel>> GetEnterprisePositions();
    }
}
