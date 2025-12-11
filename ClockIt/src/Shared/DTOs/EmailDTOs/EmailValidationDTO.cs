using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Shared.DTOs.EmailDTOs
{
    public class EmailValidationDTO
    {
        public Email Email { get; }
        public string Name { get; }

        public EmailValidationDTO(string email, string name) {
            Email = new Email(email);
            Name = name;
        }
    }
}
