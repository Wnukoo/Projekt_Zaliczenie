using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa Book dziedziczy po LibraryItem - rozszerza bazę o pole ISBN.
    // Wykorzystuje hermetyzację, bo ISBN ma prywatny setter.
    public class Book : LibraryItem
    {
        // Numer ISBN książki
        [JsonInclude]
        public string Isbn { get; private set; }

        // Konstruktor wymagający tytułu, autora i ISBN - przekazuje parametry do klasy bazowej
        public Book(string title, string author, string isbn) : base(title, author)
        {
            Isbn = isbn;
        }

        // Konstruktor bezparametrowy dla deserializacji JSON (Hermetyzacja - ukryty setter i konstruktor)
        [JsonConstructor]
        private Book() : base(string.Empty, string.Empty)
        {
            Isbn = string.Empty;
        }

        // Nadpisanie metody Info (polimorfizm) - dodaje numer ISBN do opisu książki
        public override string Info() => $"{Title} by {Author} (ISBN: {Isbn})";
    }
}
