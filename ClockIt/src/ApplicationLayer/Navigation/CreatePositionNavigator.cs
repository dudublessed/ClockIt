using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Navigation
{
    public class CreatePositionNavigator : ICreatePositionNavigator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPositionService _positionService;

        public CreatePositionNavigator(IServiceProvider serviceProvider, IPositionService positionService)
        {
            _serviceProvider = serviceProvider;
            _positionService = positionService;
        }

        public ICreatePositionForm CreatePositionForm => _serviceProvider.GetRequiredService<ICreatePositionForm>();

        public IPositionService PositionService => _positionService;

        public IMainContext MainContext => _serviceProvider.GetRequiredService<IMainContext>();
    }
}
