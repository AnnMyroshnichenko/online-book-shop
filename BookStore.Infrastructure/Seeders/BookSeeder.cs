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

                if (!dbContext.Categories.Any())
                {
                    var categories = GetCategories();
                    dbContext.Categories.AddRange(categories);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Books.Any())
                {
                    var categories = GetCategories();
                    var books = GetBooks(categories);
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

        private IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Fantasy" },
                new Category { Name = "Science Fiction" },
                new Category { Name = "Thriller" },
                new Category { Name = "Romance" },
                new Category { Name = "Horror" },
                new Category { Name = "Historical" },
                new Category { Name = "Biography" },
                new Category { Name = "Philosophy" },
                new Category { Name = "Classic" },
                new Category { Name = "Dystopian" },
                new Category { Name = "Adventure" },
                new Category { Name = "Children's" }
            };
        }


        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User)
                    {
                        NormalizedName = UserRoles.User.ToUpper()
                    },
                    new (UserRoles.Admin)
                    {
                        NormalizedName = UserRoles.Admin.ToUpper()
                    }
                ];
            return roles;
        }

        private IEnumerable<Book> GetBooks(IEnumerable<Category> categories)
        {
            Category GetCategory(string name)
            {
                var category = categories.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (category == null)
                {
                    throw new InvalidOperationException($"Category '{name}' not found.");
                }
                return category;
            }

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
                    IsAvailableForSale = true,
                    Categories = new List<Category> { GetCategory("Fantasy"), GetCategory("Adventure") }
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "9780061120084",
                    Description = "A novel about racial injustice in the Deep South.",
                    Publisher = "J.B. Lippincott & Co.",
                    PublishedDate = new DateTime(1960, 7, 11),
                    IsAvailableForSale = true,
                    Categories = new List<Category> { GetCategory("Classic") }
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "9780451524935",
                    Description = "A dystopian novel about surveillance and totalitarianism.",
                    Publisher = "Secker & Warburg",
                    PublishedDate = new DateTime(1949, 6, 8),
                    IsAvailableForSale = true,
                    Categories = new List<Category> { GetCategory("Dystopian"), GetCategory("Science Fiction") }
                }
            };
        }
    }
}
