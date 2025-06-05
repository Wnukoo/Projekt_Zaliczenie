namespace LibraryCore
{
    // Interfejs ILendable definiuje kontrakt dla obiektów, które można wypożyczać.
    // Każda klasa implementująca ILendable musi mieć metody do wypożyczenia i zwrotu,
    // oraz właściwości informujące o stanie wypożyczenia.
    public interface ILendable
    {
        void Borrow(LibraryCard card);  // Metoda wypożyczająca przedmiot danemu posiadaczowi karty
        void Return();                  // Metoda zwracająca przedmiot do biblioteki
        bool IsBorrowed { get; }        // Czy przedmiot jest aktualnie wypożyczony
        LibraryCard? BorrowedBy { get; } // Kto wypożyczył (jeśli jest wypożyczony)
    }
}
