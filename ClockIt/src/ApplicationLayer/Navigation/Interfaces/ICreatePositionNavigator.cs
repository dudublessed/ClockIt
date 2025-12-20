using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface ICreatePositionNavigator
    {
        // Forms
        ICreatePositionForm CreatePositionForm { get; }

        // Services
        IPositionService PositionService { get; }

        // Context
        IMainContext MainContext { get; }
    }
}
