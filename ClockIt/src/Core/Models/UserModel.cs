using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.Model
{
    public class UserModel
    {
        public enum UserType
        {
            Admin,
            User
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Login { get; set; }
        public string UserPassword { get; set; }
        public UserType Type { get; set; }
    }
}