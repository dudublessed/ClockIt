using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;
using ClockIt.src.Shared.DTOs.PositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;

        public PositionService(IPositionRepository repository) 
        {
            _repository = repository;
        }

        public async Task RegisterPosition(PositionDTO position)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _repository.RegisterPosition(position);

                scope.Complete();
            }
        }

        public async Task<List<PositionModel>> GetEnterprisePositions()
        {
            var positions = await _repository.GetEnterprisePositions();

            bool enterpriseHasAnyPosition = positions.Any();
            if (!enterpriseHasAnyPosition)
            {
                throw new InvalidOperationException("A sua empresa não possui cargos cadastrados.");
            }

            return positions;
        }
    }
}
