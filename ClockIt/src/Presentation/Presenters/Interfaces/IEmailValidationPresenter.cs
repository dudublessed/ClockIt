using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.EmailDTOs;

namespace ClockIt.src.Presentation.Presenters.Interfaces
{
    public interface IEmailValidationPresenter
    {
        DialogResult ShowDialog(EmailValidationDTO emailValidationCredentials);
    }
}
