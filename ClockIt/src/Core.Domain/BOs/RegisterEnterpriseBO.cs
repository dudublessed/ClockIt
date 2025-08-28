using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Core.Domain.BOs
{
    public class RegisterEnterpriseBO : IRegisterEnterpriseBO
    {
        private readonly IMachineBO _machineBO;
        private readonly IEnterpriseBO _enterpriseBO;
        private readonly IUserBO _userBO;

        public RegisterEnterpriseBO(IMachineBO machineBO, IEnterpriseBO enterpriseBO, IUserBO userBO)
        {
            _machineBO = machineBO;
            _enterpriseBO = enterpriseBO;
            _userBO = userBO;
        }

        public void CheckIfEnterpriseExists(EnterpriseRegisterDTO enterprise)
        {
            bool isEnterpriseRegistered = _enterpriseBO.ExistsEnterprise(enterprise);

            if (isEnterpriseRegistered)
            {
                throw new Exception("Esta empresa já está registrada. Verifique os dados.");
            }
        }

        public void CheckIfMachineExists()
        {
            bool isMachineRegistered = _machineBO.ExistsMachine();

            if (isMachineRegistered)
            {
                throw new Exception("Esta máquina já está registrada.");
            }
        }

        public Guid GetLocalMachineGuid()
        {
            return _machineBO.GetLocalMachineGuid();
        }

        public int RegisterEnterprise(EnterpriseRegisterDTO enterprise)
        {
            return _enterpriseBO.AddEnterprise(enterprise);
        }

        public void RegisterMachine(MachineRegisterDTO machine)
        {
            _machineBO.AddMachine(machine);
        }

        public void RegisterAdminUser(UserRegisterDTO admin)
        {
            _userBO.AddUser(admin);
        }

        private string GetFile(string jsonFile)
        {
            string filePath = null;

            filePath = FileHelper.FindFileInProject(jsonFile);

            if (!File.Exists(filePath))
            {
                throw new Exception("O arquivo não existe ou não pode ser encontrado.");
            }

            return filePath;
        }

        private string GetStatesFileByCountry(string country)
        {
            string statesFile = null;

            switch (country)
            {
                case "Brasil":
                    statesFile = GetFile("br_states.json");
                    break;
            }

            if (string.IsNullOrEmpty(statesFile))
            {
                throw new Exception("Não foi possível verificar os estados disponíveis.");
            }

            return statesFile;
        }

        public string GetStatesJsonByCountry(string country)
        {
            string statesFile = GetStatesFileByCountry(country);

            string jsonStates = File.ReadAllText(statesFile);

            if (string.IsNullOrEmpty(jsonStates))
            {
                throw new Exception("Não há estados para este país.");
            }

            return jsonStates;
        }

        private string GetCitiesFileByState(string country)
        {
            string citiesFile = null;

            switch (country)
            {
                case "Brasil":
                    citiesFile = GetFile("br_cities.json");
                    break;
            }

            if (string.IsNullOrEmpty(citiesFile))
            {
                throw new Exception("Não foi possível verificar as cidades disponíveis.");
            }

            return citiesFile;
        }

        public string GetCitiesJsonByCountry(string country)
        {
            string citiesFile = GetCitiesFileByState(country);

            string jsonCities = File.ReadAllText(citiesFile);

            if (string.IsNullOrEmpty(jsonCities))
            {
                throw new Exception("Não há cidades para este país.");
            }

            return jsonCities;
        }
    }
}
