using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface IAdminMainForm
    {
        event EventHandler FormShown;

        event EventHandler ShowCreateUserForm;
        event EventHandler ShowViewUsersForm;
        event EventHandler ShowUpdateUserForm;
        event EventHandler ShowDeleteUserForm;

        event EventHandler ShowCreatePositionForm;

        event EventHandler ShowCreateEmployeeForm;
    }
}
