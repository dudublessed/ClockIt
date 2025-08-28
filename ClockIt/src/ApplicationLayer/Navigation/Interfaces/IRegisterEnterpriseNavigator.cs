using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface IRegisterEnterpriseNavigator
    {
        // Forms
        IRegisterEnterpriseForm RegisterEnterpriseForm { get; }
        IEmailValidationPresenter EmailValidationPresenter { get; }

        // Services
        IRegisterEnterpriseService RegisterEnterpriseService { get; }
    }
}
