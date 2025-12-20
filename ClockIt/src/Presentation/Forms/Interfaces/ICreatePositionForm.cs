using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Forms.Interfaces
{
    public interface ICreatePositionForm
    {
        string PositionName { get; }
        string Description { get; }

        event Func<object, EventArgs, Task> CreatePositionRequested;

        void CleanUserInputFields();
    }
}
