using BookStore.Application.Books;
using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(IBookService bookService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await bookService.GetById(id);

            if(book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public  async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await bookService.Create(book);
            return CreatedAtAction(nameof(GetById), new {id}, null);
        }
    }
}
