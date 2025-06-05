using System;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    /// <summary>
    /// Abstrakcyjny element biblioteczny.
    /// </summary>
    public abstract class LibraryItem
    {
        [JsonInclude] public string Title { get; private set; }
        [JsonInclude] public string Author { get; private set; }

        protected LibraryItem(string title, string author)
        {
            Title = title;
            Author = author;
        }

        // Konstruktor dla serializatora
        [JsonConstructor]
        private LibraryItem() { Title = Author = string.Empty; }

        public abstract string Info();
    }
}
