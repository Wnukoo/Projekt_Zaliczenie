using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa BookCopy dziedziczy po Book i implementuje interfejs ILendable.
    // To przykład wielodziedziczenia (klasa + interfejs) oraz polimorfizmu.
    public class BookCopy : Book, ILendable
    {
        // Statyczna tablica znaków do generowania unikalnego ID kopii książki
        private static readonly char[] _alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();

        // Metoda generująca unikalny 4-znakowy ID kopii książki
        private static string GenerateId()
        {
            Span<byte> buf = stackalloc byte[4];  // Bufor 4 bajtów na losowe wartości
            RandomNumberGenerator.Fill(buf);      // Bezpieczne losowanie
            var chars = new char[4];
            for (int i = 0; i < 4; i++)
                chars[i] = _alphabet[buf[i] % _alphabet.Length];
            return new string(chars);
        }

        // Właściwość CopyId - identyfikator kopii, domyślnie generowany
        [JsonInclude] public string CopyId { get; } = GenerateId();

        // Stan wypożyczenia - czy jest wypożyczona
        [JsonInclude] public bool IsBorrowed { get; set; }

        // Kto wypożyczył - karta biblioteczna (może być null)
        [JsonInclude] public LibraryCard? BorrowedBy { get; set; }

        // Właściwość pomocnicza - nazwa wypożyczającego (dla wyświetlania)
        [JsonIgnore]
        public string BorrowerName => BorrowedBy?.StudentName ?? string.Empty;

        // Konstruktor podstawowy przekazujący parametry do klasy bazowej
        public BookCopy(string title, string author, string isbn) : base(title, author, isbn) { }

        // Konstruktor do deserializacji JSON (wraz z dodatkowym stanem wypożyczenia)
        [JsonConstructor]
        public BookCopy(string title, string author, string isbn, string copyId, bool isBorrowed, LibraryCard? borrowedBy)
            : base(title, author, isbn)
        {
            CopyId = string.IsNullOrWhiteSpace(copyId) ? GenerateId() : copyId.ToUpper();
            IsBorrowed = isBorrowed;
            BorrowedBy = borrowedBy;
        }

        // Implementacja metody Borrow z interfejsu ILendable
        public void Borrow(LibraryCard card)
        {
            if (IsBorrowed)
                throw new InvalidOperationException("Ta kopia jest już wypożyczona.");
            IsBorrowed = true;
            BorrowedBy = card;
        }

        // Implementacja metody Return z interfejsu ILendable
        public void Return()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("Ta kopia nie jest wypożyczona.");
            IsBorrowed = false;
            BorrowedBy = null;
        }

        // Nadpisanie metody Info z klasy Book (polimorfizm) - dodaje info o kopii i wypożyczeniu
        public override string Info() => base.Info() + $" | CopyID: {CopyId} | Borrowed: {IsBorrowed}";
    }
}
