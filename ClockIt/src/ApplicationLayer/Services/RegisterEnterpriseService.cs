using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Shared.DTOs.UserDTOs;
using Newtonsoft.Json;

namespace ClockIt.src.ApplicationLayer.Services
{
    public class RegisterEnterpriseService : IRegisterEnterpriseService
    {
        private readonly IRegisterEnterpriseBO _BO;

        public RegisterEnterpriseService(IRegisterEnterpriseBO registerEnterpriseBO)
        {
            _BO = registerEnterpriseBO;
        }

        public void CheckEnterpriseExistance(EnterpriseRegisterDTO enterprise)
        {
            _BO.CheckIfEnterpriseExists(enterprise);
        }

        public void CheckMachineExistance()
        {
            _BO.CheckIfMachineExists();
        }

        public void Register(EnterpriseRegisterDTO enterprise)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var registeredEnterpriseId = _BO.RegisterEnterprise(enterprise);

                var localMachineGuid = _BO.GetLocalMachineGuid();
                var machine = new MachineRegisterDTO(localMachineGuid, registeredEnterpriseId);

                _BO.RegisterMachine(machine);

                UserPassword password = UserPassword.CreateNew(UserPassword.DefaultValue);
                var admin = new UserRegisterDTO("Admin", "ADMIN", password, UserRegisterDTO.UserType.Admin, registeredEnterpriseId);

                _BO.RegisterAdminUser(admin);

                scope.Complete();
            }
        }

        public List<StateModel> GetStatesByCountry(string selectedCountry)
        {
            string jsonStates = _BO.GetStatesJsonByCountry(selectedCountry);

            var states = JsonConvert.DeserializeObject<Dictionary<string, List<StateModel>>>(jsonStates);

            return states![selectedCountry];
        }

        public List<CityModel> GetCitiesByCountryAndState(string selectedCountry, string selectedState)
        {
            string jsonCities = _BO.GetCitiesJsonByCountry(selectedCountry);

            var cities = JsonConvert.DeserializeObject<List<CityModel>>(jsonCities);

            return cities!;
        }
    }
}
