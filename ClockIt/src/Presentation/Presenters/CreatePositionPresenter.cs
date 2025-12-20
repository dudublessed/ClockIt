using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.PositionDTOs;
using ClockIt.src.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Presenters
{
    public class CreatePositionPresenter : ICreatePositionPresenter
    {
        private readonly ICreatePositionNavigator _navigator;

        private ICreatePositionForm _view;
        private readonly IPositionService _service;
        private readonly IMainContext _context;

        public CreatePositionPresenter(ICreatePositionNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.PositionService;

            _context = navigator.MainContext;
        }

        private void PrepareEventHandlers()
        {
            _view.CreatePositionRequested -= CreatePosition;

            _view.CreatePositionRequested += CreatePosition;
        }

        public void ShowDialog()
        {
            _view = _navigator.CreatePositionForm;

            PrepareEventHandlers();

            var createPositionForm = (Form)_view;
            FormHelper.OpenFormAsDialog(createPositionForm);
        }

        private async Task CreatePosition(object? sender, EventArgs e)
        {
            try
            {
                var position = new PositionDTO(
                    _view.PositionName,
                    _view.Description,
                    _context.Enterprise.Id
                );

                await _service.RegisterPosition(position);

                MessageBoxHelper.ShowSucess("Cargo cadastrado com sucesso!");

                _view.CleanUserInputFields();
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
