using GoodBooks.Api.RequestModels;
using GoodBooks.Data.Models;
using GoodBooks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GoodBooks.Api.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            // no need to new up a book service here as the IOC container takes care of doing it for us
            _bookService = bookService;
        }

        [HttpGet("/api/books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("/api/books/{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookWithGivenId = _bookService.GetBookById(id);
            return Ok(bookWithGivenId);
        }

        [HttpPost("/api/books")]
        public IActionResult CreateBook([FromBody] CreateBookRequest bookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid book requst!");
            }

            // turn book that's come through into an entity Book
            var newBook = new Book() 
            { 
                Author = bookRequest.Author, 
                Title = bookRequest.Title, 
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            _bookService.AddBook(newBook);

            return Ok($"New book '{newBook.Title}' successfully added");
        }

        [HttpDelete("/api/books/{id}")]
        public IActionResult DeleteBook(int id)
        {           
            _bookService.DeleteBook(id);

            return Ok($"Book '{id}' successfully deleted");
        }

        
    }
}
