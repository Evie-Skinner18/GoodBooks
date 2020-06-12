using GoodBooks.Data.Models;
using GoodBooks.Services.Readers;
using GoodBooks.Services.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private IBookDataReader _bookDataReader { get; set; }

        private IBookDataWriter _bookDataWriter {get; set;}


        public BookService(IBookDataReader bookDataReader, IBookDataWriter bookDataWriter)
        {
            _bookDataReader = bookDataReader;
            _bookDataWriter = bookDataWriter;
        }

        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd != null)
            {
                _bookDataWriter.AddBookToDb(bookToAdd);
            }
            else
            {
                throw new InvalidOperationException("Can't add a book that doesn't exist!");
            }
        }

        public void DeleteBook(int bookId)
        {
            var bookToDelete = _bookDataReader.GetBookFromDbById(bookId);

            if (bookToDelete != null)
            {
                _bookDataWriter.DeleteBookFromDb(bookToDelete);
            }
            else
            {
                throw new InvalidOperationException("Can't delete a book that doesn't exist!");
            }
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _bookDataReader.GetAllBooksFromDb().ToList();
            return allBooks;
        }

        public Book GetBookById(int bookId)
        {
            var bookWithGivenId = _bookDataReader.GetBookFromDbById(bookId);
            return bookWithGivenId;
        }
    }
}
