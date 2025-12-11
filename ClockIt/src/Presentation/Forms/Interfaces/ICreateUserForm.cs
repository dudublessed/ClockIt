using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Core.Domain.ValueObjects;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface ICreateUserForm
    {
        string UserName { get; }
        string Login { get; }
        string UserPassword { get; }

        event EventHandler UserNameInputValidationRequested;
        event EventHandler UserPasswordInputValidationRequested;

        event EventHandler CreateUserRequested;

    }
}
