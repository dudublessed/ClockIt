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
using ClockIt.src.Presentation.Forms.Main.Admin.User;
using ClockIt.src.Presentation.Forms.Main.Admin.Employee;
using ClockIt.src.ApplicationLayer.Context.Interfaces;
using ClockIt.src.ApplicationLayer.Context;

using AutoUpdaterDotNET;


namespace ClockIt
{
    internal static class Program
    {

        [STAThread]
        static async Task Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TestDatabaseConnection();
            CheckForUpdates();

            var services = ConfigureServices();

            using var provider = services.BuildServiceProvider();

            var mainPresenter = provider.GetRequiredService<IMainPresenter>();
            mainPresenter.Start();

            Application.Run();
        }

        static void CheckForUpdates()
        {
            AutoUpdater.Mandatory = false; 
            AutoUpdater.ShowRemindLaterButton = true; 
            AutoUpdater.ReportErrors = true; 

            AutoUpdater.Start("https://raw.githubusercontent.com/dudublessed/ClockIt/release/update.xml");
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
            AddSingletonContexts(services);
            addSingletonBOs(services);
            addTransientRepositories(services);

            return services;
        }

        private static void addTransientNavigators(IServiceCollection services)
        {
            services.AddTransient<ILoginNavigator, LoginNavigator>();
            services.AddTransient<IRegisterEnterpriseNavigator, RegisterEnterpriseNavigator>();
            services.AddTransient<IEmailValidationNavigator, EmailValidationNavigator>();
            services.AddTransient<IAdminPasswordNavigator, AdminPasswordNavigator>();
            services.AddTransient<IAdminMainNavigator, AdminMainNavigator>();
            services.AddTransient<ICreateUserNavigator, CreateUserNavigator>();
            services.AddTransient<ICreateEmployeeNavigator, CreateEmployeeNavigator>();
            services.AddTransient<IEmployeeMainNavigator, EmployeeMainNavigator>();
        }

        private static void addTransientPresenters(IServiceCollection services)
        {
            services.AddTransient<IMainPresenter, MainPresenter>();

            services.AddTransient<ILoginPresenter, LoginPresenter>();
            services.AddTransient<IRegisterEnterprisePresenter, RegisterEnterprisePresenter>();

            services.AddTransient<IEmailValidationPresenter, EmailValidationPresenter>();

            services.AddTransient<IAdminPasswordPresenter, AdminPasswordPresenter>();

            services.AddTransient<IAdminMainPresenter, AdminMainPresenter>();
            services.AddTransient<ICreateUserPresenter, CreateUserPresenter>();
            services.AddTransient<ICreateEmployeePresenter, CreateEmployeePresenter>();

            services.AddTransient<IEmployeeMainPresenter, EmployeeMainPresenter>();
        }

        private static void addTransientForms(IServiceCollection services)
        {
            // Start
            services.AddTransient<ILoginForm, LoginForm>();
            services.AddTransient<IRegisterEnterpriseForm, RegisterEnterpriseForm>();
            services.AddTransient<IAdminPasswordForm, AdminPasswordForm>();

            // Main
            services.AddTransient<IAdminMainForm, AdminMainForm>();
            services.AddTransient<ICreateUserForm, CreateUserForm>();
            services.AddTransient<ICreateEmployeeForm, CreateEmployeeForm>();
            services.AddTransient<IEmployeeMainForm, EmployeeMainForm>();

            // Validation
            services.AddTransient<IEmailValidationForm, EmailValidationForm>();

            // Debugging
            //services.AddTransient<IDebugForm, DebugForm>();
        }

        private static void addSingletonServices(IServiceCollection services)
        {
            services.AddSingleton<IMainService, MainService>();
            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<IRegisterEnterpriseService, RegisterEnterpriseService>();
            services.AddSingleton<IAdminService, AdminService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IEnterpriseService, EnterpriseService>();
            services.AddSingleton<IMachineService, MachineService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IPositionsService, PositionsService>();
            services.AddSingleton<IScheduleService, ScheduleService>();
            services.AddSingleton<IAttendanceService, AttendanceService>();
            services.AddSingleton<IRecordService, RecordService>();
        }

        private static void AddSingletonContexts(IServiceCollection services)
        {
            services.AddSingleton<IMainContext, MainContext>();
            services.AddSingleton<IEmployeeLoggedContext, EmployeeLoggedContext>();
            services.AddSingleton<IUserLoggedContext, UserLoggedContext>();
        }

        private static void addSingletonBOs(IServiceCollection services)
        {
            // Forms
            services.AddSingleton<ILoginBO, LoginBO>();
            services.AddSingleton<IRegisterEnterpriseBO, RegisterEnterpriseBO>();

            // Validation
            services.AddSingleton<IEmailBO, EmailBO>();

            // Models
            services.AddSingleton<IMachineBO, MachineBO>();
            services.AddSingleton<IEnterpriseBO, EnterpriseBO>();
            services.AddSingleton<IUserBO, UserBO>();
            // services.AddSingleton<IEmployeeBO, EmployeeBO>();
        }

        private static void addTransientRepositories(IServiceCollection services)
        {
            string connectionString = DatabaseConfigReader.GetConnectionString();

            services.AddSingleton(_ => connectionString);

            services.AddTransient<IEnterpriseRepository, EnterpriseRepository>();
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IPositionsRepository, PositionsRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<IRecordRepository, RecordRepository>();
        }


    }
}