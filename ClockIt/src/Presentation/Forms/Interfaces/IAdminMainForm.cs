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
        event EventHandler UserSectionRequested;
        event EventHandler EmployeeSectionRequested;
        event EventHandler SettingsSectionRequested;

        void ShowUserTopSection();
        void ShowEmployeeTopSection();
        void ShowSettingsTopSection();
    }
}
