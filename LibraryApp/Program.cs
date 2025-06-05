using System;
using System.Windows.Forms;

namespace LibraryApp
{
    // Klasa startowa aplikacji WinForms.
    static class Program
    {
        // Metoda Main - punkt wej�cia do programu.
        [STAThread] // Atrybut ustawiaj�cy model w�tku na jednow�tkowy (Single Thread Apartment).
                    // Wymagane przez Windows Forms i COM do poprawnej obs�ugi interfejsu GUI.
        static void Main()
        {
            // Inicjalizacja konfiguracji aplikacji (np. ustawienia styl�w i DPI).
            ApplicationConfiguration.Initialize();

            // Uruchomienie p�tli zdarze� aplikacji i pokazanie g��wnego okna.
            // MainForm to klasa formularza g��wnego (okna).
            Application.Run(new MainForm());
        }
    }
}
