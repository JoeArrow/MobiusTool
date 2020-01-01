
using System;
using System.Windows.Forms;

namespace JSON_Formatter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(args.Length > 0 ? new MobiusForm(args[0]) : new MobiusForm());
        }
    }
}
