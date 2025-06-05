using System.Text.Json.Serialization;

namespace LibraryCore
{
    public class Book : LibraryItem
    {
        [JsonInclude] public string Isbn { get; private set; }

        public Book(string title, string author, string isbn) : base(title, author) => Isbn = isbn;

        [JsonConstructor]
        private Book() : base(string.Empty, string.Empty) { Isbn = string.Empty; }

        public override string Info() => $"{Title} by {Author} (ISBN: {Isbn})";
    }
}