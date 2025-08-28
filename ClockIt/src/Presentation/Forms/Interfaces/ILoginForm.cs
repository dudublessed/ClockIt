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

        void ShowUsers(IEnumerable<ShowUsersDTO> users);
        void OpenUserMainForm(IUserMainForm form);

        event EventHandler FormShown;
        event EventHandler LoginRequested;
    }
}
