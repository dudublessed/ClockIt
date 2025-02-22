using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockIt
{
    internal static class Program
    {

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isUpdated = await CheckForUpdates();

            if (isUpdated)
            {
                MessageBox.Show("A new version is available. Update the app!");
            }

            Application.Run(new LoginForm());
        }

        static async Task<bool> CheckForUpdates()
        {
            string localVersion = ConfigurationManager.AppSettings["AppVersion"];

            string versionUrl = "https://raw.githubusercontent.com/dudublessed/ClockIt/release/.version";

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
                    MessageBox.Show(ExceptionHandler.GetErrorMessages(3161)); 
                    return false;
                }
            }
        }
    }
}