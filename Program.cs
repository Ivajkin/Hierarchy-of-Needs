using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hierarchy_of_Needs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var debug = false;
            if (debug)
            {
                var needs = new Needs();
                needs.material = 1;
                needs.safety = 2;
                needs.connections = 3;
                needs.respect = 4;
                needs.realisation = 5;
                Application.Run(new ResultForm(new MainForm(), needs));
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
