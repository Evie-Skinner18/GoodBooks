using GoodBooks.Data.Models;
using GoodBooks.Services;
using GoodBooks.Services.Readers;
using GoodBooks.Services.Writers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GoodBooks.Tests
{
    public class BookServiceTests
    {
        private List<Book> _books;

        // equivalent to Setup method in NUnit
        public BookServiceTests()
        {
            _books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "Sapiens",
                    Author = "Yuval Noah Harari",
                    CreatedOn = new DateTime(2020, 4, 12),
                    UpdatedOn = new DateTime(2020, 4, 12)
                },
                new Book
                {
                    Id = 2,
                    Title = "Sane New World",
                    Author = "Ruby Wax",
                    CreatedOn = new DateTime(2020, 6, 12),
                    UpdatedOn = new DateTime(2020, 7, 12)
                },
                new Book
                {
                    Id = 3,
                    Title = "Scrum Mastery",
                    Author = "Geoff Watts",
                    CreatedOn = new DateTime(2020, 1, 12),
                    UpdatedOn = new DateTime(2020, 5, 12)
                }
            };
        }



        [Fact]
        public void CanGetAllBooks_ShouldReturnAListOfAllBooks()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();

            mockBookDataReader.Setup(r => r.GetAllBooksFromDb()).Returns(_books);

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);
            var allBooks = bookService.GetAllBooks();

            mockBookDataReader.Verify(r => r.GetAllBooksFromDb(), Times.Once);
            Assert.Equal(_books, allBooks);
        }

        [Fact]
        public void CanGetBookById_ShouldReturnSaneNewWorld()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();
            
            var saneNewWorld = _books[1];
            mockBookDataReader.Setup(r => r.GetBookFromDbById(2)).Returns(saneNewWorld);

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);
            var bookWithGivenId = bookService.GetBookById(2);

            mockBookDataReader.Verify(r => r.GetBookFromDbById(2), Times.Once);
            Assert.Equal(saneNewWorld, bookWithGivenId);
        }

        [Fact]
        public void CanAddBook_ShouldInvokeTheWriterToAddTheGivenBook()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();
            var bookToAdd = new Book()
            {
                Id = 10,
                Title = "Happy",
                Author = "Fearne Cotton",
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };           

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);
            bookService.AddBook(bookToAdd);

            mockBookDataWriter.Verify(w => w.AddBookToDb(It.IsAny<Book>()), Times.Once);
        }

        [Fact]
        public void CanAddBook_ShouldThrowAnExceptionWhenTheGivenBookIsNull()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();
            Book bookToAdd = null;

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);

            mockBookDataWriter.Verify(w => w.AddBookToDb(It.IsAny<Book>()), Times.Never);
            var result = Assert.Throws<InvalidOperationException>(() => bookService.AddBook(bookToAdd));
            Assert.Equal("Can't add a book that doesn't exist!", result.Message);
        }

        [Fact]
        public void CanDeleteBook_ShouldInvoketheReaderToFindTheBookWithTheGivenId()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();
            var sapiens = _books[0];

            mockBookDataReader.Setup(r => r.GetBookFromDbById(1)).Returns(sapiens);

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);
            bookService.DeleteBook(sapiens.Id);

            mockBookDataReader.Verify(r => r.GetBookFromDbById(1), Times.Once);
        }

        [Fact]
        public void CanDeleteBook_ShouldInvoketheWriterToDeleteTheBookRetrievedByTheReader()
        {
            var mockBookDataReader = new Mock<IBookDataReader>();
            var mockBookDataWriter = new Mock<IBookDataWriter>();
            var sapiens = _books[0];

            mockBookDataReader.Setup(r => r.GetBookFromDbById(1)).Returns(sapiens);

            var bookService = new BookService(mockBookDataReader.Object, mockBookDataWriter.Object);
            bookService.DeleteBook(sapiens.Id);

            mockBookDataWriter.Verify(w => w.DeleteBookFromDb(sapiens), Times.Once);
        }        
    }
}
