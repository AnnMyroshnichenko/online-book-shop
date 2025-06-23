using BookStore.Application.Books;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Books.Commands.DeleteBook;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Books.Querries.GetBookById;
using BookStore.Application.Books.Querries.GetRestaurants;
using BookStore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await mediator.Send(new GetBookByIdQuery(id));

            if(book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public  async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id}, null);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var isDeleted = await mediator.Send(new DeleteBookCommand(id));

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, UpdateBookCommand command)
        {
            command.Id = id;
            var isUpdated = await mediator.Send(command);

            if (isUpdated)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
