using System;
using System.Windows.Forms;

namespace LibraryApp
{
    // Klasa startowa aplikacji WinForms.
    static class Program
    {
        [STAThread] 
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
