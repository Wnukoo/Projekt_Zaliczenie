namespace LibraryCore
{
    public interface ILendable
    {
        void Borrow(LibraryCard card);
        void Return();
        bool IsBorrowed { get; }
        LibraryCard? BorrowedBy { get; }
    }
}
