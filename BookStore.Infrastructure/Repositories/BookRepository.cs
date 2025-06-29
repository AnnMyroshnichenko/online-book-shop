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

        public async Task<IEnumerable<Book>> GetAllByNameAsync(string? searchPhrase)
        {
            var searchPhraseToLower = searchPhrase?.ToLower();
            var books = await dbContext.Books
                .Include(b => b.Categories)
                .Where(x => searchPhraseToLower == null || (x.Title.ToLower().Contains(searchPhraseToLower)))
                .ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
           var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
           return book;
        }

        public async Task<int> Create(Book book)
        {
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task Delete(Book book)
        {
            dbContext.Remove(book);
            await dbContext.SaveChangesAsync();
        }

        public Task SaveChanges() 
            => dbContext.SaveChangesAsync();
    }
}
