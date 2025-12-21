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
        private readonly IMachineService _machineService;
        private readonly IEnterpriseService _enterpriseService;
        private readonly IUserService _userService;

        private readonly IRegisterEnterpriseBO _BO;

        public RegisterEnterpriseService(IMachineService machineService, IEnterpriseService enterpriseService, IUserService userService, IRegisterEnterpriseBO registerEnterpriseBO)
        {
            _enterpriseService = enterpriseService;
            _machineService = machineService;
            _userService = userService;

            _BO = registerEnterpriseBO;
        }

        public async Task CheckEnterpriseExistance(EnterpriseRegisterDTO enterprise)
        {
            await _BO.CheckIfEnterpriseExists(enterprise);
        }

        public async Task CheckMachineExistance()
        {
            await _machineService.IsMachineRegistered();
        }

        public async Task Register(EnterpriseRegisterDTO enterprise)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var registeredEnterpriseId = await _BO.RegisterEnterprise(enterprise);

                var localMachineGuid = _machineService.GetLocalMachineGuid();
                var machine = new MachineRegisterDTO(localMachineGuid, registeredEnterpriseId);
                await _machineService.RegisterMachine(machine);

                var admin = new UserDTO("Admin", "ADMIN", "mA$p01MlLIO!", UserDTO.UserType.Admin, registeredEnterpriseId);

                await _userService.RegisterUser(admin);

                scope.Complete();
            }
        }

        public async Task<List<StateModel>> GetStatesByCountry(string selectedCountry)
        {
            string jsonStates = await _BO.GetStatesJsonByCountry(selectedCountry);

            var states = JsonConvert.DeserializeObject<Dictionary<string, List<StateModel>>>(jsonStates);

            return states![selectedCountry];
        }

        public async Task<List<CityModel>> GetCitiesByCountryAndState(string selectedCountry, string selectedState)
        {
            string jsonCities = await _BO.GetCitiesJsonByCountry(selectedCountry);

            var cities = JsonConvert.DeserializeObject<List<CityModel>>(jsonCities);

            return cities!;
        }
    }
}
