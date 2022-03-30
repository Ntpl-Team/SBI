using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBI
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            try
            {

                System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //ImageHeaven.Program.IHMain(args);

                Start(args);
            }
            catch (Exception)
            {
            }
        }

        public static void Start(string[] args)   // <-- must be marked public!
        {


            do
            {

                ImageHeaven.Program.IHMain(args);

            }

            while (ImageHeaven.Program.LogOut() == true);

        }
    }
}
