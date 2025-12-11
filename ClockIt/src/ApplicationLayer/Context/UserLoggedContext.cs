using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Context
{
    public class UserLoggedContext : IUserLoggedContext
    {
        public UserLoggedDTO User { get; private set; }

        public void SetUserLoggedContext(UserLoggedDTO user)
        {
            User = user;
        }
    }
}
