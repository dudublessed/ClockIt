using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface ICreateEmployeeForm
    {
        string UserName { get; }
        string FullName { get; }
        string CPF { get; }
        DateTime BirthDate { get; }
        string Email { get; }
        string Position { get; }
        DateTime EntryTime { get; }
        DateTime LunchEntryTime { get; }
        DateTime LunchExitTime { get; }
        DateTime ExitTime { get; }

        event Func<object, EventArgs, Task> EnterpriseUsersRequested;
        event Func<object, EventArgs, Task> EnterprisePositionsRequested;

        event Func<object, EventArgs, Task> EmployeeNameInputValidationRequested;
        event Func<object, EventArgs, Task> CpfInputValidationRequested;
        event Func<object, EventArgs, Task> BirthDateInputValidationRequested;
        event Func<object, EventArgs, Task> EmailInputValidationRequested;
        event Func<object, EventArgs, Task> PositionInputValidationRequested;
        event Func<object, EventArgs, Task> EntryTimeInputValidationRequested;
        event Func<object, EventArgs, Task> LunchEntryTimeInputValidationRequested;
        event Func<object, EventArgs, Task> LunchExitTimeInputValidationRequested;
        event Func<object, EventArgs, Task> ExitTimeInputValidationRequested;

        event Func<object, EventArgs, Task> CreateEmployeeRequested;

        List<ShowUsersDTO> EnterpriseUsers { get; set; }
        List<PositionModel> EnterprisePositions { get; set; }

        void ShowEnterpriseUsers();
        void ShowEnterprisePositions();
        void CleanScreenInputs();
    }
}
