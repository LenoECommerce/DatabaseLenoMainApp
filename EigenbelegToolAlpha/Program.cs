using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CRUDQueries window = new CRUDQueries();
            window.Backup();
            StartMenu window2 = new StartMenu();
            if (window2.CheckUser() == false)
            {
                Application.Run(new StartMenu());
            }
            else
            {
                Application.Run(new Protokollierung());
            }

        }
    }
}
