using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;

using ClockIt.src.ApplicationLayer.Services;

using ClockIt.src.Core.Domain.BOs;

using ClockIt.src.Infrastructure.Data.Repositories;
using ClockIt.src.Infrastructure.Data.Interfaces;

using ClockIt.src.Presentation.Forms.Debugging;
using ClockIt.src.Presentation.Forms.Main;
using ClockIt.src.Presentation.Forms.Start;
using ClockIt.src.Presentation.Forms.Validation;

using ClockIt.src.Presentation.Presenters;
using ClockIt.src.Presentation.Presenters.Interfaces;
using ClockIt.src.Presentation.Forms.Interfaces;
using ClockIt.src.ApplicationLayer.Services.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation.Interfaces;
using ClockIt.src.ApplicationLayer.Navigation;
using ClockIt.src.Core.Domain.BOs.Interfaces;
using ClockIt.src.Shared.Utils;


namespace ClockIt
{
    internal static class Program
    {

        [STAThread]
        static async Task Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isThereUpdates = await CheckForUpdates();
            if (isThereUpdates)
            {
                MessageBoxHelper.ShowInfo("Há atualizações disponíveis!");
            }

            TestDatabaseConnection();

            var services = ConfigureServices();

            using var provider = services.BuildServiceProvider();

            var mainPresenter = provider.GetRequiredService<IMainPresenter>();
            mainPresenter.Start();

            Application.Run();
        }

        static async Task<bool> CheckForUpdates()
        {
            string localVersion = ConfigurationManager.AppSettings["AppVersion"];

            string versionUrl = "https://raw.githubusercontent.com/dudublessed/ClockIt/release/.version";

            if (!await IsInternetAvailable())
            {
                MessageBoxHelper.ShowError("Could not connect to the internet. The application will be closed.");
                Environment.Exit(0);
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string remoteVersion = await client.GetStringAsync(versionUrl);
                    remoteVersion = remoteVersion.Trim();

                    return localVersion != remoteVersion;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError("Não foi possível verificar se existem atualizações disponíveis.");
                    return false;
                }
            }
        }

        static async Task<bool> IsInternetAvailable()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await Task.Run(() => ping.Send("8.8.8.8"));
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false;
            }
        }

        private static void TestDatabaseConnection()
        {
            string connectionString = DatabaseConfigReader.GetConnectionString();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Could not connect to the database. The application will be closed");
                Environment.Exit(0);
            }
        }

        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            addTransientNavigators(services);
            addTransientPresenters(services);
            addTransientForms(services);
            addSingletonServices(services);
            addSingletonBOs(services);
            addTransientRepositories(services);

            return services;
        }

        private static void addTransientPresenters(IServiceCollection services)
        {
            services.AddTransient<IMainPresenter, MainPresenter>();

            services.AddTransient<ILoginPresenter, LoginPresenter>();
            services.AddTransient<IRegisterEnterprisePresenter, RegisterEnterprisePresenter>();

            services.AddTransient<IEmailValidationPresenter, EmailValidationPresenter>();

            services.AddTransient<IAdminPasswordPresenter, AdminPasswordPresenter>();

            services.AddTransient<IAdminMainPresenter, AdminMainPresenter>();
            services.AddTransient<IUserMainPresenter, UserMainPresenter>();
        }

        private static void addTransientForms(IServiceCollection services)
        {
            // Start
            services.AddTransient<ILoginForm, LoginForm>();
            services.AddTransient<IRegisterEnterpriseForm, RegisterEnterpriseForm>();
            services.AddTransient<IAdminPasswordForm, AdminPasswordForm>();

            // Main
            services.AddTransient<IAdminMainForm, AdminMainForm>();
            services.AddTransient<IUserMainForm, UserMainForm>();

            // Validation
            services.AddTransient<IEmailValidationForm, EmailValidationForm>();

            // Debugging
            //services.AddTransient<IDebugForm, DebugForm>();
        }

        private static void addTransientNavigators(IServiceCollection services)
        {
            services.AddTransient<ILoginNavigator, LoginNavigator>();
            services.AddTransient<IRegisterEnterpriseNavigator, RegisterEnterpriseNavigator>();
            services.AddTransient<IEmailValidationNavigator, EmailValidationNavigator>();
            services.AddTransient<IAdminPasswordNavigator, AdminPasswordNavigator>();
            services.AddTransient<IAdminMainNavigator, AdminMainNavigator>();
            services.AddTransient<IUserMainNavigator, UserMainNavigator>();
        }

        private static void addSingletonServices(IServiceCollection services)
        {
            // Main
            services.AddSingleton<IMainService, MainService>();

            // Forms
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IRegisterEnterpriseService, RegisterEnterpriseService>();
            services.AddSingleton<IAdminPasswordService, AdminPasswordService>();
            services.AddSingleton<IAdminMainService, AdminMainService>();
            services.AddSingleton<IUserMainService, UserMainService>();

            // Validation
            services.AddSingleton<IEmailService, EmailService>();

            // Models
            services.AddSingleton<IEnterpriseService, EnterpriseService>();
            services.AddSingleton<IMachineService, MachineService>();
        }

        private static void addSingletonBOs(IServiceCollection services)
        {
            // Main
            services.AddSingleton<IMainBO, MainBO>();

            // Forms
            services.AddSingleton<ILoginBO, LoginBO>();
            services.AddSingleton<IRegisterEnterpriseBO, RegisterEnterpriseBO>();
            services.AddSingleton<IAdminPasswordBO, AdminPasswordBO>();
            services.AddSingleton<IAdminMainBO, AdminMainBO>();
            services.AddSingleton<IUserMainBO, UserMainBO>();

            // Validation
            services.AddSingleton<IEmailBO, EmailBO>();

            // Models
            services.AddSingleton<IMachineBO, MachineBO>();
            services.AddSingleton<IEnterpriseBO, EnterpriseBO>();
            services.AddSingleton<IUserBO, UserBO>();
        }

        private static void addTransientRepositories(IServiceCollection services)
        {
            string connectionString = DatabaseConfigReader.GetConnectionString();

            services.AddSingleton(_ => connectionString);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEnterpriseRepository, EnterpriseRepository>();
            services.AddTransient<IMachineRepository, MachineRepository>();
        }


    }
}