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
        private readonly IEnterpriseBO _enterpriseBO;

        public RegisterEnterpriseBO(IEnterpriseBO enterpriseBO)
        {
            _enterpriseBO = enterpriseBO;
        }

        public async Task CheckIfEnterpriseExists(EnterpriseRegisterDTO enterprise)
        {
            bool isEnterpriseRegistered = await _enterpriseBO.ExistsEnterprise(enterprise);

            if (isEnterpriseRegistered)
            {
                throw new Exception("Esta empresa já está registrada. Verifique os dados.");
            }
        }

        public async Task<int> RegisterEnterprise(EnterpriseRegisterDTO enterprise)
        {
            return await _enterpriseBO.AddEnterprise(enterprise);
        }

        private async Task<string> GetFile(string jsonFile)
        {
            string filePath = null;

            filePath = await FileHelper.FindFileInProject(jsonFile);

            if (!File.Exists(filePath))
            {
                throw new Exception("O arquivo não existe ou não pode ser encontrado.");
            }

            return filePath;
        }

        private async Task<string> GetStatesFileByCountry(string country)
        {
            string statesFile = null;

            switch (country)
            {
                case "Brasil":
                    statesFile = await GetFile("br_states.json");
                    break;
            }

            if (string.IsNullOrEmpty(statesFile))
            {
                throw new Exception("Não foi possível verificar os estados disponíveis.");
            }

            return statesFile;
        }

        public async Task<string> GetStatesJsonByCountry(string country)
        {
            string statesFile = await GetStatesFileByCountry(country);

            string jsonStates = File.ReadAllText(statesFile);

            if (string.IsNullOrEmpty(jsonStates))
            {
                throw new Exception("Não há estados para este país.");
            }

            return jsonStates;
        }

        private async Task<string> GetCitiesFileByState(string country)
        {
            string citiesFile = null;

            switch (country)
            {
                case "Brasil":
                    citiesFile = await GetFile("br_cities.json");
                    break;
            }

            if (string.IsNullOrEmpty(citiesFile))
            {
                throw new Exception("Não foi possível verificar as cidades disponíveis.");
            }

            return citiesFile;
        }

        public async Task<string> GetCitiesJsonByCountry(string country)
        {
            string citiesFile = await GetCitiesFileByState(country);

            string jsonCities = File.ReadAllText(citiesFile);

            if (string.IsNullOrEmpty(jsonCities))
            {
                throw new Exception("Não há cidades para este país.");
            }

            return jsonCities;
        }
    }
}
