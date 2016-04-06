using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ArduinoControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //

            float R1 = 20400;    // !! resistance of R1 !!
            float R2 = 9230;     // !! resistance of R2 !!
            //float vout = (1024 * 5.0) / 1024.0;
            //11.1 = vout / (R2 / (R1 + R2));
            float vout1 = 12 * (R2 / (R1 + R2));
            float vout2 = 6 * (R2 / (R1 + R2));
            //
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }
    }
}
