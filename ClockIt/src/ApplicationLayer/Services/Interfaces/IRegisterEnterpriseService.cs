using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IRegisterEnterpriseService
    {
        void CheckEnterpriseExistance(EnterpriseRegisterDTO enterprise);
        void CheckMachineExistance();
        void Register(EnterpriseRegisterDTO enterprise);
        List<StateModel> GetStatesByCountry(string selectedCountry);
        List<CityModel> GetCitiesByCountryAndState(string selectedCountry, string selectedState);
    }
}
