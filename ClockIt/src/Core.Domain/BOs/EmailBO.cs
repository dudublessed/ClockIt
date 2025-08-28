using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.DTOs.EmailDTOs;

namespace ClockIt.src.Core.Domain.BOs
{
    public class EmailBO : IEmailBO
    {
        public void ValidateInputCode(CodeValidationDTO codeValidation)
        {
            if (string.IsNullOrEmpty(codeValidation.ExpectedCode))
            {
                throw new Exception ("Nenhum código de verificação foi gerado.");
            }

            var elapsedTime = DateTime.UtcNow - codeValidation.GenerationTimeUtc;
            if (elapsedTime.TotalMinutes > CodeValidationDTO.ExpirationMinutes)
            {
                throw new Exception("Código expirado. Por favor, solicite um novo.");
            }

            if (codeValidation.ExpectedCode != codeValidation.InputCode)
            {
                throw new Exception("Código inválido.");
            }
        }
    }
}
