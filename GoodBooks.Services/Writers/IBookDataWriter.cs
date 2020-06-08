using GoodBooks.Data.Models;

namespace GoodBooks.Services.Writers
{
    public interface IBookDataWriter
    {
        public void AddBookToDb(Book bookToAdd);

        public void UpdateBookInDb(int bookId);

        public void DeleteBookFromDb(int bookId);
    }
}
