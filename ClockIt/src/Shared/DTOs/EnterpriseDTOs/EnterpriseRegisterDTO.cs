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
            ValidateNameInput(name);
            ValidateEmailInput(email);
            ValidateLocationInput(location);

            Name = name;
            Email = email;
            Location = location;
        }

        private void ValidateNameInput(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Por favor, preencha o nome da empresa.");
            }
        }

        private void ValidateEmailInput(Email email)
        {
            if (string.IsNullOrEmpty(email.Value))
            {
                throw new ArgumentException("Por favor, preencha o campo de email.");
            }
        }

        private void ValidateLocationInput(Location location)
        {
            if (string.IsNullOrEmpty(location.Country))
            {
                throw new ArgumentException("Por favor, selecione um país.");
            }

            if (string.IsNullOrEmpty(location.State))
            {
                throw new ArgumentException("Por favor, selecione um estado.");
            }

            if (string.IsNullOrEmpty(location.City))
            {
                throw new ArgumentException("Por favor, selecione uma cidade.");
            }
        }
    }
}
