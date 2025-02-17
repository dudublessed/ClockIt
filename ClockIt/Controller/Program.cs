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
                MessageBox.Show("Uma nova versão está disponível! Atualize o aplicativo.");
            }

            Application.Run(new Login());
        }

        static async Task<bool> CheckForUpdates()
        {
            string localVersion = ConfigurationManager.AppSettings["AppVersion"];

            string versionUrl = "https://raw.githubusercontent.com/dudublessed/ClockIt/Producao/.version";

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
                    MessageBox.Show("Erro ao verificar atualizações.");
                    return false;
                }
            }
        }
    }
}
