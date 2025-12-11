using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface IAdminPasswordNavigator
    {
        // Views
        IAdminPasswordForm AdminPasswordForm { get; }

        // Service
        IAdminService AdminPasswordService { get; }
    }
}
