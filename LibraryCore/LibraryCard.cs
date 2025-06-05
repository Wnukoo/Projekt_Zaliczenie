using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa reprezentująca kartę biblioteczną przypisaną do studenta/użytkownika.
    public class LibraryCard
    {
        // Publiczne właściwości tylko do odczytu (private set).
        // Dzięki temu imię studenta i ID karty mogą być odczytane z zewnątrz,
        // ale zmieniane tylko wewnątrz klasy - hermetyzacja.
        [JsonInclude] public string StudentName { get; private set; }
        [JsonInclude] public string CardId { get; private set; }

        // Statyczna tablica znaków zawierająca możliwe znaki do wygenerowania ID karty.
        // Używamy wielkich liter i cyfr.
        private static readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        // Prywatna metoda do generowania unikalnego 4-znakowego ID karty.
        // Używa bezpiecznego generatora liczb losowych (cryptographic RNG),
        // aby zwiększyć losowość i uniknąć powtarzalnych ID.
        private static string GenerateCardId()
        {
            // Bufor na 4 bajty (32 bity) do wypełnienia losowymi danymi.
            Span<byte> buf = stackalloc byte[4];
            RandomNumberGenerator.Fill(buf);  // Wypełniamy buforem bezpiecznymi losowymi bajtami.

            var chars = new char[4]; // Tablica na 4 znaki ID.
            for (int i = 0; i < 4; i++)
                // Dla każdego bajtu wybieramy znak z alfabetu, korzystając z modulo,
                // aby indeks nie wychodził poza zakres tablicy znaków.
                chars[i] = _alphabet[buf[i] % _alphabet.Length];

            // Tworzymy i zwracamy nowy string z tych 4 znaków.
            return new string(chars);
        }

        // Konstruktor używany przez deserializację JSON.
        // Pozwala na ustawienie konkretnych wartości CardId i StudentName
        // podczas odczytu danych z pliku JSON.
        [JsonConstructor]
        public LibraryCard(string cardId, string studentName)
        {
            CardId = cardId;
            StudentName = studentName;
        }

        // Konstruktor publiczny do tworzenia nowej karty.
        // Generuje automatycznie unikalne 4-znakowe CardId i przypisuje nazwisko studenta.
        public LibraryCard(string studentName)
        {
            CardId = GenerateCardId(); // Generujemy losowy identyfikator karty.
            StudentName = studentName;
        }

        // Nadpisujemy metodę ToString, aby ładnie wyświetlać kartę
        // jako tekst np. w listach, comboBoxach itp.
        public override string ToString() => $"{StudentName} (Card: {CardId})";
    }
}
