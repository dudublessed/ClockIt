using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Infrastructure.Data.Interfaces;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class PositionsService : IPositionsService
    {
        private readonly IPositionsRepository _repository;

        public PositionsService(IPositionsRepository repository) 
        {
            _repository = repository;
        }

        public List<PositionsModel> GetEnterprisePositions()
        {
            var positions = _repository.GetEnterprisePositions();

            bool enterpriseHasAnyPosition = positions.Any();
            if (!enterpriseHasAnyPosition)
            {
                throw new InvalidOperationException("A sua empresa não possui cargos cadastrados.");
            }

            return _repository.GetEnterprisePositions();
        }
    }
}
