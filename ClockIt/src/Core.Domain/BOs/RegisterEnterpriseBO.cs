using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Shared.DTOs.UserDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        public string GetStatesJsonByCountry(string country)
        {
            string jsonStatesContent = GetStatesFileByCountry(country);

            if (string.IsNullOrEmpty(jsonStatesContent))
            {
                throw new Exception("Não há estados para este país.");
            }

            return jsonStatesContent;
        }

        private string GetStatesFileByCountry(string country)
        {
            string? jsonStatesContent = null;

            switch (country)
            {
                case "Brasil":
                    jsonStatesContent = GetFileContent("ClockIt.config.resources.brazil.br_states.json");
                    break;
            }

            if (string.IsNullOrEmpty(jsonStatesContent))
            {
                throw new Exception("Não foi possível verificar os estados disponíveis.");
            }

            return jsonStatesContent;
        }

        public string GetCitiesJsonByCountry(string country)
        {
            string jsonCitiesContent = GetCitiesFileByState(country);

            if (string.IsNullOrEmpty(jsonCitiesContent))
            {
                throw new Exception("Não há cidades para este país.");
            }

            return jsonCitiesContent;
        }


        private string GetCitiesFileByState(string country)
        {
            string? jsonCitiesContent = null;

            switch (country)
            {
                case "Brasil":
                    jsonCitiesContent = GetFileContent("ClockIt.config.resources.brazil.br_cities.json");
                    break;
            }

            if (string.IsNullOrEmpty(jsonCitiesContent))
            {
                throw new Exception("Não foi possível verificar as cidades disponíveis.");
            }

            return jsonCitiesContent;
        }

        private static string GetFileContent(string jsonFile)
        {
            using var stream =
                Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(jsonFile)
                ?? throw new InvalidOperationException("Recurso não encontrado.");

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
