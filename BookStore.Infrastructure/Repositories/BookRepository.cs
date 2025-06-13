using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using BookStore.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    internal class BookRepository(BookStoreDbContext dbContext) 
        : IBookRepository
    {
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await dbContext.Books.ToListAsync();
            return books;
        }
    }
}
