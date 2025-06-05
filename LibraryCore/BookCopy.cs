using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    public class BookCopy : Book, ILendable
    {
        private static readonly char[] _alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789".ToCharArray();
        private static string GenerateId()
        {
            Span<byte> buf = stackalloc byte[8];
            RandomNumberGenerator.Fill(buf);
            var chars = new char[8];
            for (int i = 0; i < 8; i++)
                chars[i] = _alphabet[buf[i] % _alphabet.Length];
            return new string(chars);
        }

        [JsonInclude] public string CopyId { get; set; } = GenerateId();
        [JsonInclude] public bool IsBorrowed { get; set; }
        [JsonInclude] public LibraryCard? BorrowedBy { get; set; }

        // Wygodna właściwość do wyświetlania w GUI (nie serializujemy, to pochodna).
        [JsonIgnore] public string BorrowerName => BorrowedBy?.StudentName ?? string.Empty;

        public BookCopy(string title, string author, string isbn) : base(title, author, isbn) { }

        // Konstruktor używany przez System.Text.Json
        [JsonConstructor]
        public BookCopy(string title, string author, string isbn, string copyId, bool isBorrowed, LibraryCard? borrowedBy)
            : base(title, author, isbn)
        {
            CopyId = string.IsNullOrWhiteSpace(copyId) ? GenerateId() : copyId.ToUpper();
            IsBorrowed = isBorrowed;
            BorrowedBy = borrowedBy;
        }

        #region ILendable
        public void Borrow(LibraryCard card)
        {
            if (IsBorrowed)
                throw new InvalidOperationException("Ta kopia jest już wypożyczona.");
            IsBorrowed = true;
            BorrowedBy = card;
        }

        public void Return()
        {
            if (!IsBorrowed)
                throw new InvalidOperationException("Ta kopia nie jest wypożyczona.");
            IsBorrowed = false;
            BorrowedBy = null;
        }
        #endregion

        public override string Info() => base.Info() + $" | CopyID: {CopyId} | Borrowed: {IsBorrowed}";
    }
}
