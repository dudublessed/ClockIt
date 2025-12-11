using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Core.Domain.Entities
{
    public class EmployeeModel
    {
        public int Id { get; }
        public int UserId { get; }
        public string FullName { get; }
        public string CPF { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public int PositionId { get; }

        public EmployeeModel(int id, int userId, string fullname, string cpf, DateTime birthDate, string email, int positionId)
        {
            Id = id;
            UserId = userId;
            FullName = fullname;
            CPF = cpf;
            BirthDate = birthDate;
            Email = email;
            PositionId = positionId;
        }

    }
}
