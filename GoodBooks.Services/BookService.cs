using GoodBooks.Data.Models;
using System;
using System.Collections.Generic;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private IBookDataReader _bookDataReader { get; set; }

        private IBookDataWriter _bookDataWriter {get; set;}


        public BookService()
        {

        }
        public void AddBook(Book bookToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
