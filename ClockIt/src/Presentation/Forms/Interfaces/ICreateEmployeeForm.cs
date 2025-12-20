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

        event EventHandler EnterpriseUsersRequested;
        event EventHandler EnterprisePositionsRequested;

        event EventHandler EmployeeNameInputValidationRequested;
        event EventHandler CpfInputValidationRequested;
        event EventHandler BirthDateInputValidationRequested;
        event EventHandler EmailInputValidationRequested;
        event EventHandler PositionInputValidationRequested;
        event EventHandler EntryTimeInputValidationRequested;
        event EventHandler LunchEntryTimeInputValidationRequested;
        event EventHandler LunchExitTimeInputValidationRequested;
        event EventHandler ExitTimeInputValidationRequested;

        event EventHandler CreateEmployeeRequested;

        List<ShowUsersDTO> EnterpriseUsers { get; set; }
        List<PositionModel> EnterprisePositions { get; set; }

        void ShowEnterpriseUsers();
        void ShowEnterprisePositions();
        void CleanScreenInputs();
    }
}
