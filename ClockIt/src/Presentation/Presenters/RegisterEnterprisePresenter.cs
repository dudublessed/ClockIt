using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.Core.Domain.ValueObjects;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Shared.DTOs.EmailDTOs;
using ClockIt.src.Shared.Utils;

namespace ClockIt.src.Presentation.Presenters
{
    public class RegisterEnterprisePresenter : IRegisterEnterprisePresenter
    {
        private readonly IRegisterEnterpriseNavigator _navigator;

        private IRegisterEnterpriseForm _view;
        private readonly IRegisterEnterpriseService _service;

        public RegisterEnterprisePresenter(IRegisterEnterpriseNavigator navigator)
        {
            _navigator = navigator;

            _service = navigator.RegisterEnterpriseService;
        }

        private void PrepareEventHandlers()
        {
            _view.FormLoaded -= OnFormLoaded;
            _view.RegistrationRequested -= HandleRegistrationRequest;

            _view.LoadStatesByCountry -= LoadStates;
            _view.LoadCitiesByState -= LoadCities;

            _view.FormLoaded += OnFormLoaded;
            _view.RegistrationRequested += HandleRegistrationRequest;

            _view.LoadStatesByCountry += LoadStates;
            _view.LoadCitiesByState += LoadCities;
        }

        public void ShowForm()
        {
            _view = _navigator.RegisterEnterpriseForm;

            PrepareEventHandlers();
            FormHelper.OpenFormAndExit((Form)_view);
        }

        private void OnFormLoaded(object? sender, EventArgs e)
        {
            try
            {
                _view.ShowCountries();
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void LoadStates(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.SelectedCountry))
                {
                    MessageBoxHelper.ShowWarning("Por favor, selecione um país.");
                }

                var states = _service.GetStatesByCountry(_view.SelectedCountry);
                _view.States = states;
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void LoadCities(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_view.SelectedState))
                {
                    MessageBoxHelper.ShowWarning("Por favor, selecione um estado.");
                }

                var selectedState = _view.States.FirstOrDefault(x => x.Name == _view.SelectedState);

                string stateId = selectedState!.ID;

                var cities = _service.GetCitiesByCountryAndState(_view.SelectedCountry, _view.SelectedState);
                var citiesInState = cities
                    .Where(c => c.State == stateId)
                    .ToList();

                _view.Cities = citiesInState;
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }

        private void HandleRegistrationRequest(object? sender, EventArgs e)
        {
            try
            {
                var enterpriseEmail = new Email(_view.Email);
                var enterpriseLocation = new Location(_view.SelectedCountry, _view.SelectedState, _view.SelectedCity);
                var enterpriseToRegister = new EnterpriseRegisterDTO(_view.EnterpriseName, enterpriseEmail, enterpriseLocation);

                _service.CheckEnterpriseExistance(enterpriseToRegister);
                _service.CheckMachineExistance();

                var emailValidationCredentials = new EmailValidationDTO(_view.Email, _view.EnterpriseName);
                var result = _navigator.EmailValidationPresenter.ShowDialog(emailValidationCredentials);

                if (result != DialogResult.OK)
                {
                    return;
                }

                _service.Register(enterpriseToRegister);

                MessageBoxHelper.ShowSucess("Perfeito! Sua empresa foi cadastrada!");

                _view.RestartApplication();
            } catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
            }
        }
    }
}
