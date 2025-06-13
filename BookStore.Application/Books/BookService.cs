using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books
{
    internal class BookService(IBookRepository bookRepository,
        ILogger<BookService> logger) : IBookService
    {
        public async Task<int> Create(Book book)
        {
            logger.LogInformation("Creating a new book");
            int id = await bookRepository.Create(book);
            return id;   
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            logger.LogInformation("Getting all books");
            var books = await bookRepository.GetAllAsync();
            return books;
        }

        public async Task<Book?> GetById(int id)
        {
            logger.LogInformation($"Getting books {id}");
            var book = await bookRepository.GetByIdAsync(id);

            return book;
        }
    }
}
