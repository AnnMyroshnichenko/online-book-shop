using BookStore.Domain.Constants;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Persistance;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Seeders
{
    internal class BookSeeder(BookStoreDbContext dbContext) : IBookSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if(!dbContext.Books.Any())
                {
                    var books = GetBooks();
                    dbContext.Books.AddRange(books);
                    await dbContext.SaveChangesAsync();
                }

                if(!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User),
                    new (UserRoles.Admin)
                ];
            return roles;
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780547928227",
                    Description = "A fantasy novel and prelude to The Lord of the Rings.",
                    Publisher = "Houghton Mifflin Harcourt",
                    PublishedDate = new DateTime(1937, 9, 21),
                    IsAvailableForSale = true
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "9780061120084",
                    Description = "A novel about racial injustice in the Deep South.",
                    Publisher = "J.B. Lippincott & Co.",
                    PublishedDate = new DateTime(1960, 7, 11),
                    IsAvailableForSale = true
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "9780451524935",
                    Description = "A dystopian novel about surveillance and totalitarianism.",
                    Publisher = "Secker & Warburg",
                    PublishedDate = new DateTime(1949, 6, 8),
                    IsAvailableForSale = true
                }
            };
        }
    }
}
