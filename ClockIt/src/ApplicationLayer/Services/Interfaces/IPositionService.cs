using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.PositionDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IPositionService
    {
        Task RegisterPosition(PositionDTO position);
        Task<List<PositionModel>> GetEnterprisePositions();
    }
}
