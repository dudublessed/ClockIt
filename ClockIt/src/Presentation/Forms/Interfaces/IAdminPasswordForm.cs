using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface IAdminPasswordForm
    {
        string Password { get; }
        string ConfirmPassword { get; }

        void SetPasswordMessageAndShowError(string errorMessage);
        void SetConfirmPasswordMessageAndShowError(string errorMessage);

        void HideFirstPasswordError();
        void HideSecondPasswordError();

        void AdjustFormLayout(bool hasError, int adjustOffset = 26);

        event EventHandler UpdateAdminPasswordRequested;

        event EventHandler<TriggeredByEventArgs> FirstPasswordValidationRequested;
        event EventHandler<TriggeredByEventArgs> SecondPasswordValidationRequested;
    }
}
