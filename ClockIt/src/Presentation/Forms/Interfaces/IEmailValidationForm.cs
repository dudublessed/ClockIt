using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface IEmailValidationForm
    {
        string Email { get; }
        string Name { get; }
        string CodeInput { get; }

        event EventHandler FormLoaded;
        event EventHandler CodeSubmited;
        event EventHandler NewCodeRequested;

        void SetEmail(string email);
        void SetName(string name);

        void AdjustFieldsOnVisual();

        void StartCodeExpirationTimer(Action onFinished = null);
        void ReSendValidationEmailCode(object sender, EventArgs e);
        void TimeOutLink();


    }
}
