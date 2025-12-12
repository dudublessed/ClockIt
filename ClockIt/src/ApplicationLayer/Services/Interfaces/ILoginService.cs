using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.ApplicationLayer.Services.Interfaces
{
    public interface ILoginService
    {
        EmployeeModel GetEmployeeByUserContext();
        List<ShowUsersDTO> GetEnterpriseEmployeeUsers();
        bool IsAdminPasswordDefault();
        void VerifyPassword(UserLoginDTO input);

    }
}
