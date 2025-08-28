using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.EmailDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IEmailBO
    {
        void ValidateInputCode(CodeValidationDTO codeValidation);
    }
}
