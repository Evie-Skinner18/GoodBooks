using GoodBooks.Data;
using GoodBooks.Data.Models;
using System.Collections.Generic;

namespace GoodBooks.Services.Readers
{
    public class BookDataReader : IBookDataReader
    {
        private GoodBooksDbContext _dbContext { get; set; }

        public BookDataReader(GoodBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAllBooksFromDb()
        {
            var allBooks = _dbContext.Books;
            return allBooks;
        }

        public Book GetBookFromDbById(int bookId)
        {
            var bookWithGivenId = _dbContext.Books
                .Find(bookId);

            return bookWithGivenId;
        }
    }
}
