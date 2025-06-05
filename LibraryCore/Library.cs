using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LibraryCore
{
    /// <summary>
    /// Centralny „magazyn” – przechowuje zarówno kopie książek,
    /// jak i karty biblioteczne (dla studentów).
    /// </summary>
    public class Library
    {
        // ========  KOPIE  ========
        private readonly List<BookCopy> _copies = new();
        public IEnumerable<BookCopy> Copies => _copies;

        public BookCopy AddNewCopy(string title, string author, string isbn)
        {
            var copy = new BookCopy(title, author, isbn);
            _copies.Add(copy);
            return copy;
        }

        public bool RemoveCopy(string copyId) => _copies.RemoveAll(c => c.CopyId == copyId) > 0;
        public BookCopy? FindCopy(string copyId) => _copies.FirstOrDefault(c => c.CopyId == copyId);

        public void Borrow(string copyId, LibraryCard card)
            => (FindCopy(copyId) ?? throw new ArgumentException("Nie znaleziono kopii.")).Borrow(card);

        public void Return(string copyId)
            => (FindCopy(copyId) ?? throw new ArgumentException("Nie znaleziono kopii.")).Return();

        // ========  KARTY  ========
        private readonly List<LibraryCard> _cards = new();
        public IEnumerable<LibraryCard> Cards => _cards;

        public LibraryCard AddNewCard(string studentName)
        {
            if (string.IsNullOrWhiteSpace(studentName))
                throw new ArgumentException("Imię i nazwisko nie mogą być puste.");

            var card = new LibraryCard(studentName.Trim());
            _cards.Add(card);
            return card;
        }

        public bool RemoveCard(Guid id) => _cards.RemoveAll(c => c.CardId == id) > 0;
        public LibraryCard? FindCard(Guid id) => _cards.FirstOrDefault(c => c.CardId == id);

        // ========  SERIALIZACJA  ========
        private record LibraryState(List<BookCopy> Copies, List<LibraryCard> Cards);

        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        public void Save(string path)
        {
            var state = new LibraryState(_copies, _cards);
            File.WriteAllText(path, JsonSerializer.Serialize(state, _jsonOptions));
        }

        public void Load(string path)
        {
            if (!File.Exists(path)) return;

            var state = JsonSerializer.Deserialize<LibraryState>(File.ReadAllText(path), _jsonOptions);
            if (state is null) return;

            _copies.Clear();
            _cards.Clear();
            _copies.AddRange(state.Copies);
            _cards.AddRange(state.Cards);

            // Spięcie referencji: BorrowedBy musi wskazywać na instancję z _cards
            foreach (var copy in _copies.Where(c => c.BorrowedBy is not null))
            {
                var matched = _cards.FirstOrDefault(k => k.CardId == copy.BorrowedBy!.CardId);
                if (matched is not null) copy.BorrowedBy = matched;
                else _cards.Add(copy.BorrowedBy!); // karta istniała tylko w kopii
            }
        }
    }
}
