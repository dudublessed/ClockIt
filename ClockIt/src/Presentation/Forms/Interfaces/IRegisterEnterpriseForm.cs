using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface IRegisterEnterpriseForm
    {
        string EnterpriseName { get; }
        string Email { get; }
        string SelectedCountry { get; }
        string SelectedState { get; }
        string SelectedCity { get; }

        string[] Countries { get; }
        List<StateModel> States { get; set; }
        List<CityModel> Cities { get; set; }

        void ShowCountries();

        void RestartApplication();

        event EventHandler FormShown;
        event EventHandler RegistrationRequested;

        event EventHandler LoadStatesByCountry;
        event EventHandler LoadCitiesByState;
    }
}
