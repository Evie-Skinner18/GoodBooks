using GoodBooks.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace GoodBooks.Services.Readers
{
    public interface IBookDataReader
    {
        IEnumerable<Book> GetAllBooksFromDb();

        public Book GetBookFromDbById(int bookId);
    }
}
