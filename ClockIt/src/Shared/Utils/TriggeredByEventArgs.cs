using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Shared.Utils
{
    public enum ValidationTrigger
    {
        Leave,
        TextChanged
    }

    public class TriggeredByEventArgs : EventArgs
    {
        public ValidationTrigger TriggeredBy { get; }

        public TriggeredByEventArgs(ValidationTrigger triggeredBy)
        {
            TriggeredBy = triggeredBy;
        }
    }
}
