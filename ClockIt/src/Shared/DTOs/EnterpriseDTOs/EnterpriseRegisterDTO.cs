using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.EnterpriseDTOs
{
    public class EnterpriseRegisterDTO
    {
        public string Name { get; }
        public Email Email { get; }
        public Location Location { get; }

        public EnterpriseRegisterDTO(string name, Email email, Location location)
        {
            ValidateInputData(name, email, location);

            Name = name;
            Email = email;
            Location = location;
        }

        private void ValidateInputData(string name, Email email, Location location)
        {
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                errorMessage = "Por favor, preencha o nome da empresa.";
            }

            if (string.IsNullOrEmpty(email.Value))
            {
                errorMessage = "Por favor, preencha o campo de email.";
            }

            if (string.IsNullOrEmpty(location.Country))
            {
                errorMessage = "Por favor, selecione um país.";
            }

            if (string.IsNullOrEmpty(location.State))
            {
                errorMessage = "Por favor, selecione um estado.";
            }

            if (string.IsNullOrEmpty(location.City))
            {
                errorMessage = "Por favor, selecione uma cidade.";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
