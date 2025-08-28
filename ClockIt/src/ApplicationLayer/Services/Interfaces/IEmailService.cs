using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.EmailDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface IEmailService
    {
        void GenerateAndStoreCode();
        void SendVerificationCode(EmailValidationDTO credentials);
        void ReSendVerificationCode(EmailValidationDTO credentials);
        void ValidateInputCode(string inputCode);
    }
}
