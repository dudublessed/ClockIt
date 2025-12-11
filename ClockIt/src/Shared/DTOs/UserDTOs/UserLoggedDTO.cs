using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.DTOs.UserDTOs
{
    public class UserLoggedDTO
    {
        public int Id { get; }
        public string UserName { get; }
        public string Login { get; }

        public UserLoggedDTO(int id, string userName, string login)
        {
            Id = id;
            UserName = userName;
            Login = login;
        }
    }
}
