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
        Task CheckEnterpriseExistance(EnterpriseRegisterDTO enterprise);
        Task CheckMachineExistance();
        Task Register(EnterpriseRegisterDTO enterprise);
        Task<List<StateModel>> GetStatesByCountry(string selectedCountry);
        Task<List<CityModel>> GetCitiesByCountryAndState(string selectedCountry, string selectedState);
    }
}
