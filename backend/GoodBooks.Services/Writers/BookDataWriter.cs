using GoodBooks.Data;
using GoodBooks.Data.Models;

namespace GoodBooks.Services.Writers
{
    public class BookDataWriter : IBookDataWriter
    {
        private GoodBooksDbContext _dbContext { get; set; }

        public BookDataWriter(GoodBooksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBookToDb(Book bookToAdd)
        {
            _dbContext.Add(bookToAdd);
            _dbContext.SaveChanges();
        }

        public void DeleteBookFromDb(Book bookToDelete)
        {
            // the  service has had the reader go and find the book by id, and then checked if result is null. All this does is delete that book
            _dbContext.Remove(bookToDelete);
            _dbContext.SaveChanges();
        }
    }
}
