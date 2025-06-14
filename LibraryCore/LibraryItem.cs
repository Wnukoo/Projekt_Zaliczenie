using System;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa abstrakcyjna LibraryItem reprezentuje ogólny przedmiot w bibliotece.

    public abstract class LibraryItem
    {
        [JsonInclude] public string Title { get; private set; }
        [JsonInclude] public string Author { get; private set; }

        protected LibraryItem(string title, string author)
        {
            Title = title;
            Author = author;
        }

        [JsonConstructor]
        private LibraryItem() { Title = Author = string.Empty; }

        public abstract string Info();
    }
}
