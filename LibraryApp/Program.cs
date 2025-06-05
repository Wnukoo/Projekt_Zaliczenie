using System;
using System.Windows.Forms;

namespace LibraryApp
{
    // Klasa startowa aplikacji WinForms.
    static class Program
    {
        // Metoda Main - punkt wejœcia do programu.
        [STAThread] // Atrybut ustawiaj¹cy model w¹tku na jednow¹tkowy (Single Thread Apartment).
                    // Wymagane przez Windows Forms i COM do poprawnej obs³ugi interfejsu GUI.
        static void Main()
        {
            // Inicjalizacja konfiguracji aplikacji (np. ustawienia stylów i DPI).
            ApplicationConfiguration.Initialize();

            // Uruchomienie pêtli zdarzeñ aplikacji i pokazanie g³ównego okna.
            // MainForm to klasa formularza g³ównego (okna).
            Application.Run(new MainForm());
        }
    }
}
