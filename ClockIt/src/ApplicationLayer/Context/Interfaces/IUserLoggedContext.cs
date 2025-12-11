using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Context.Interfaces
{
    public interface IUserLoggedContext
    {
        UserLoggedDTO User { get; } 

        void SetUserLoggedContext(UserLoggedDTO user);
    }
}
