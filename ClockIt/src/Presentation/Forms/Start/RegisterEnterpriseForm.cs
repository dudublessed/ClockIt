using Newtonsoft.Json;
using System.Transactions;
using ClockIt.src.Core.Domain.Entities;
using ClockIt.src.Shared.DTOs.MachineDTOs;
using ClockIt.src.Shared.DTOs.EnterpriseDTOs;
using ClockIt.src.Shared.Utils;
using ClockIt.src.Presentation.Forms.Validation;
using ClockIt.src.Presentation.Forms.Interfaces;

namespace ClockIt.src.Presentation.Forms.Start
{
    public partial class RegisterEnterpriseForm : Form, IRegisterEnterpriseForm
    {
        public string EnterpriseName => enterpriseNameText.Text.ToUpper().Trim();
        public string Email => enterpriseEmailText.Text.Trim();
        public string SelectedCountry => enterpriseCountryCombo.SelectedItem?.ToString() ?? string.Empty;
        public string SelectedState => enterpriseStateCombo.SelectedItem?.ToString() ?? string.Empty;
        public string SelectedCity => enterpriseCityCombo.SelectedItem?.ToString() ?? string.Empty;

        public string[] Countries { get; } = ["Brasil"];
        public List<StateModel> States { get; set; }
        public List<CityModel> Cities { get; set; }

        public event EventHandler FormLoaded;
        public event EventHandler RegistrationRequested;

        public event EventHandler LoadStatesByCountry;
        public event EventHandler LoadCitiesByState;

        public RegisterEnterpriseForm()
        {
            InitializeComponent();
        }

        private void RegisterEnterpriseForm_Load(object sender, EventArgs e)
        {
            this.Load += (s, e) => FormLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void ShowCountries()
        {
            enterpriseCountryCombo.Items.Clear();
            enterpriseCountryCombo.Items.AddRange(Countries);
            enterpriseCountryCombo.SelectedIndex = -1;
        }

        public void ShowStatesByCountry(object sender, EventArgs e)
        {
            LoadStatesByCountry?.Invoke(this, EventArgs.Empty);

            enterpriseStateCombo.Items.Clear();
            enterpriseStateCombo.Items.AddRange(States.Select(s => s.Name).ToArray());
            enterpriseStateCombo.SelectedIndex = -1;
        }

        public void ShowCitiesByState(object sender, EventArgs e)
        {
            LoadCitiesByState?.Invoke(this, EventArgs.Empty);

            enterpriseCityCombo.Items.Clear();
            enterpriseCityCombo.Items.AddRange(Cities.Select(s => s.Name).ToArray());
            enterpriseCityCombo.SelectedIndex = -1;
        }

        public void RestartApplication()
        {
            Application.Restart();
        }

        private void SubmitRegistration(object sender, EventArgs e)
        {
            RegistrationRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
