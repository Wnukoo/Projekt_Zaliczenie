namespace LibraryCore
{
    // Kontrakt dla wszystkich przedmiotów, które można wypożyczać.

    public interface ILendable
    {
        void Borrow(LibraryCard card);  
        void Return();                 
        bool IsBorrowed { get; }       
        LibraryCard? BorrowedBy { get; } 
    }
}
