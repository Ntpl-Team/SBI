using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageHeaven
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool Logout = false;

        public static bool LogOut()
        {
            return Logout;
        }
        [STAThread]
        public static void IHMain(string[] args)
        {
            string yr;
            string mn;
            string dd;
            string qry = string.Empty;
            //NovaNet.Utils.dbCon dbcon;

            //txtLogger txLog = new txtLogger(Path.GetDirectoryName(Application.ExecutablePath), LogLevel.Beta);
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                ///For changing regional settings

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy");
                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sLongDate", "dd/MM/yyyy");
                ///

                string path = Path.GetDirectoryName(Application.ExecutablePath);
                if ((File.Exists(path + "/prKey.snk")))
                {
                    Application.Run(new frmMain());
                }
                else
                {
                    MessageBox.Show("Invalid license. Contact with nevaeh Technology");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while doing the operation...." + ex.Message);
            }
        }
    }
}
