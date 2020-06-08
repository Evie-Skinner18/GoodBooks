using GoodBooks.Data.Models;
using System.Collections.Generic;

namespace GoodBooks.Services.Readers
{
    public interface IBookDataReader
    {
        IEnumerable<Book> GetAllBooksFromDb();

        public Book GetBookFromDbById(int id);
    }
}
