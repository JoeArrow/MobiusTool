
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
            var app = new MobiusApp(args);
            app.Run(args);
        }
    }
}
