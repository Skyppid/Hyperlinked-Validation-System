using System;
using System.Windows.Forms;

namespace HVS_Sample
{
    static class Program
    {
        /// <summary> Main entry-point for this application. </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
