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
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            logger.LogInformation("Getting all restaurants");
            var books = await bookRepository.GetAllAsync();
            return books;
        }
    }
}
