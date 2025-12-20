using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;

namespace ClockIt.src.ApplicationLayer.Navigation.Interfaces
{
    public interface IAdminMainNavigator
    {
        // Forms
        IAdminMainForm AdminMainForm { get; }
        ICreateUserPresenter CreateUserPresenter { get; }
        ICreatePositionPresenter CreatePositionPresenter { get; }
        ICreateEmployeePresenter CreateEmployeePresenter { get; }

    }
}
