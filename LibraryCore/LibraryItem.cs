using System;
using System.Text.Json.Serialization;

namespace LibraryCore
{
    // Klasa abstrakcyjna LibraryItem reprezentuje ogólny przedmiot w bibliotece.
    // Abstrakcyjna oznacza, że nie można stworzyć bezpośrednio obiektu tej klasy,
    // tylko należy dziedziczyć i implementować abstrakcyjne metody.
    public abstract class LibraryItem
    {
        // Właściwości Title i Author są publiczne do odczytu, ale mają prywatne settery,
        // co oznacza, że można je ustawić tylko w klasie (hermetyzacja danych).
        // Atrybut [JsonInclude] pozwala na serializację tych pól podczas zapisu do JSON.
        [JsonInclude] public string Title { get; private set; }
        [JsonInclude] public string Author { get; private set; }

        // Konstruktor chroniony (protected) - mogą go wywołać tylko klasy dziedziczące.
        // Ustawia tytuł i autora książki/przedmiotu.
        protected LibraryItem(string title, string author)
        {
            Title = title;
            Author = author;
        }

        // Konstruktor bezparametrowy prywatny (private), potrzebny do deserializacji JSON.
        // Inicjalizuje pola pustymi stringami - chroni przed błędami podczas odczytu z pliku.
        [JsonConstructor]
        private LibraryItem() { Title = Author = string.Empty; }

        // Abstrakcyjna metoda Info wymusza, aby każda klasa dziedzicząca
        // zaimplementowała swoją wersję tej metody, która zwraca opis obiektu.
        public abstract string Info();
    }
}
