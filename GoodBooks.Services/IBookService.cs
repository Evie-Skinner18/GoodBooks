using System.Collections.Generic;
using GoodBooks.Data.Models;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        public void AddBook(Book bookToAdd);

        public void DeleteBook(int bookId);

        public List<Book> GetAllBooks();

        public Book GetBookById(int id);
    }
}
