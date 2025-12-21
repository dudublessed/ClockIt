using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Shared.DTOs.UserDTOs;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface ILoginForm
    {
        string Login { get; }
        string InputPassword { get; }
        string EnterpriseName { get; set; }

        Task ShowUsers(List<ShowUsersDTO> users);
        void ClearInputFields();

        event Func<object, EventArgs, Task> FormShown;
        event Func<object, EventArgs, Task> FormActivated;
        event Func<object, EventArgs, Task> LoginRequested;
    }
}
