using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameSettingsUI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTicTacToeMisere());
        }
    }
}
