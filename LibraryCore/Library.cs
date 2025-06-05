using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LibraryCore
{
    // Główna klasa reprezentująca bibliotekę.
    // Zarządza kolekcją książek (kopii) i kart bibliotecznych.
    public class Library
    {
        // Prywatna lista przechowująca kopie książek.
        // Hermetyzacja: dostęp z zewnątrz tylko do kolekcji jako IEnumerable (tylko do odczytu).
        private readonly List<BookCopy> _copies = new();

        // Publiczne, tylko do odczytu, kolekcja kopii książek.
        public IEnumerable<BookCopy> Copies => _copies;

        // Metoda dodająca nową kopię książki do biblioteki.
        // Tworzy nowy obiekt BookCopy i dodaje go do listy.
        public BookCopy AddNewCopy(string title, string author, string isbn)
        {
            var copy = new BookCopy(title, author, isbn);
            _copies.Add(copy);
            return copy;
        }

        // Metoda usuwająca kopię książki po jej unikalnym ID (CopyId).
        // Zwraca true, jeśli usunięto przynajmniej jeden element.
        public bool RemoveCopy(string copyId) => _copies.RemoveAll(c => c.CopyId == copyId) > 0;

        // Metoda wyszukująca kopię książki po ID.
        // Zwraca obiekt BookCopy lub null, jeśli nie znaleziono.
        public BookCopy? FindCopy(string copyId) => _copies.FirstOrDefault(c => c.CopyId == copyId);

        // Metoda wypożyczająca książkę.
        // Najpierw znajduje kopię po ID, jeśli nie ma, rzuca wyjątek.
        // Następnie wywołuje metodę Borrow na kopii, przekazując kartę.
        public void Borrow(string copyId, LibraryCard card)
            => (FindCopy(copyId) ?? throw new ArgumentException("Nie znaleziono kopii.")).Borrow(card);

        // Metoda zwracająca książkę.
        // Znajduje kopię i wywołuje metodę Return.
        public void Return(string copyId)
            => (FindCopy(copyId) ?? throw new ArgumentException("Nie znaleziono kopii.")).Return();

        // Prywatna lista kart bibliotecznych (użytkowników).
        private readonly List<LibraryCard> _cards = new();

        // Publiczny dostęp do kart jako tylko do odczytu.
        public IEnumerable<LibraryCard> Cards => _cards;

        // Metoda dodająca nową kartę biblioteczną.
        // Sprawdza poprawność (nie może być puste imię),
        // tworzy nowy obiekt LibraryCard i dodaje do listy.
        public LibraryCard AddNewCard(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
                throw new ArgumentException("Imię i nazwisko nie mogą być puste.");

            var card = new LibraryCard(studentName.Trim());
            _cards.Add(card);
            return card;
        }

        // Prywatny rekord do serializacji całego stanu biblioteki:
        // kolekcja kopii i kart.
        private record LibraryState(List<BookCopy> Copies, List<LibraryCard> Cards);

        // Opcje serializacji JSON - ustawienie na ładny, czytelny format.
        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        // Metoda do zapisu stanu biblioteki do pliku JSON.
        // Serializuje obiekt LibraryState zawierający kopie i karty.
        public void Save(string path)
        {
            var state = new LibraryState(_copies, _cards);
            File.WriteAllText(path, JsonSerializer.Serialize(state, _jsonOptions));
        }

        // Metoda do wczytania stanu biblioteki z pliku JSON.
        // Jeśli plik nie istnieje lub nie da się wczytać, kończy działanie.
        // Po wczytaniu czyści bieżące listy i dodaje nowe dane.
        public void Load(string path)
        {
            if (!File.Exists(path)) return;

            var state = JsonSerializer.Deserialize<LibraryState>(File.ReadAllText(path), _jsonOptions);
            if (state is null) return;

            _copies.Clear();
            _cards.Clear();
            _copies.AddRange(state.Copies);
            _cards.AddRange(state.Cards);

            // Dodatkowa synchronizacja:
            // Dla każdej wypożyczonej kopii próbujemy znaleźć kartę,
            // która ją wypożyczyła po ID karty.
            // Jeśli karta istnieje, aktualizujemy referencję.
            // Jeśli karta nie istnieje, dodajemy ją do kolekcji.
            foreach (var copy in _copies.Where(c => c.BorrowedBy is not null))
            {
                var matched = _cards.FirstOrDefault(k => k.CardId == copy.BorrowedBy!.CardId);
                if (matched is not null)
                    copy.BorrowedBy = matched; // aktualizujemy referencję na już istniejącą kartę
                else
                    _cards.Add(copy.BorrowedBy!); // dodajemy nową kartę
            }
        }
    }
}
