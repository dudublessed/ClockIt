using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Core.Domain.BOs.Interfaces
{
    public interface IUserBO
    {
        bool ValidatePasswordInput(string password, out string errorMessage);
    }
}
