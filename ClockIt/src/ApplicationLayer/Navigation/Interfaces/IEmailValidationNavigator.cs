using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface IEmailValidationNavigator
    {
        // Views
        IEmailValidationForm EmailValidationForm { get; }

        // Service
        IEmailService EmailService { get; }
    }
}
