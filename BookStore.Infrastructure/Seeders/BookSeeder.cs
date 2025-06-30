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
                    Price = 5.99m,
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
                    Price = 7.00m,
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
                    Price = 12.99m,
                    Categories = new List<Category> { GetCategory("Dystopian"), GetCategory("Science Fiction") }
                },

                new Book
                {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    ISBN = "9780316769488",
                    Description = "A story about teenage rebellion and identity.",
                    Publisher = "Little, Brown and Company",
                    PublishedDate = new DateTime(1951, 7, 16),
                    IsAvailableForSale = true,
                    Price = 1.99m,
                    Categories = new List<Category> { GetCategory("Classic") }
                },
                new Book
                {
                    Title = "Frankenstein",
                    Author = "Mary Shelley",
                    ISBN = "9780141439471",
                    Description = "A gothic novel about the creation of a monster.",
                    Publisher = "Lackington, Hughes, Harding, Mavor & Jones",
                    PublishedDate = new DateTime(1818, 1, 1),
                    IsAvailableForSale = true,
                    Price = 5.99m,
                    Categories = new List<Category> { GetCategory("Horror"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    ISBN = "9780141040349",
                    Description = "A romantic novel of manners.",
                    Publisher = "T. Egerton",
                    PublishedDate = new DateTime(1813, 1, 28),
                    IsAvailableForSale = true,
                    Price = 8.99m,
                    Categories = new List<Category> { GetCategory("Romance"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "The Little Prince",
                    Author = "Antoine de Saint-Exupéry",
                    ISBN = "9780156012195",
                    Description = "A philosophical tale disguised as a children’s story.",
                    Publisher = "Reynal & Hitchcock",
                    PublishedDate = new DateTime(1943, 4, 6),
                    IsAvailableForSale = true,
                    Price = 11.99m,
                    Categories = new List<Category> { GetCategory("Philosophy"), GetCategory("Children's") }
                },

                new Book
                {
                    Title = "The Da Vinci Code",
                    Author = "Dan Brown",
                    ISBN = "9780307474278",
                    Description = "A mystery thriller novel that follows symbologist Robert Langdon.",
                    Publisher = "Doubleday",
                    PublishedDate = new DateTime(2003, 3, 18),
                    IsAvailableForSale = true,
                    Price = 4.99m,
                    Categories = new List<Category> { GetCategory("Thriller") }
                },
                new Book
                {
                    Title = "Steve Jobs",
                    Author = "Walter Isaacson",
                    ISBN = "9781451648539",
                    Description = "The authorized biography of Steve Jobs.",
                    Publisher = "Simon & Schuster",
                    PublishedDate = new DateTime(2011, 10, 24),
                    IsAvailableForSale = true,
                    Price = 2.50m,
                    Categories = new List<Category> { GetCategory("Biography") }
                },
                new Book
                {
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    ISBN = "9780062316110",
                    Description = "A narrative of humanity’s creation and evolution.",
                    Publisher = "Harvill Secker",
                    PublishedDate = new DateTime(2011, 9, 4),
                    IsAvailableForSale = true,
                    Price = 3.99m,
                    Categories = new List<Category> { GetCategory("Philosophy"), GetCategory("Historical") }
                },
                new Book
                {
                    Title = "The Shining",
                    Author = "Stephen King",
                    ISBN = "9780307743657",
                    Description = "A horror novel about a haunted hotel and a family's descent into madness.",
                    Publisher = "Doubleday",
                    PublishedDate = new DateTime(1977, 1, 28),
                    IsAvailableForSale = true,
                    Price = 10.50m,
                    Categories = new List<Category> { GetCategory("Horror") }
                },
                new Book
                {
                    Title = "Ender's Game",
                    Author = "Orson Scott Card",
                    ISBN = "9780812550702",
                    Description = "A young genius is trained through battle simulations to defend Earth.",
                    Publisher = "Tor Books",
                    PublishedDate = new DateTime(1985, 1, 15),
                    IsAvailableForSale = true,
                    Price = 3.99m,
                    Categories = new List<Category> { GetCategory("Science Fiction") }
                },
                new Book
                {
                    Title = "The Book Thief",
                    Author = "Markus Zusak",
                    ISBN = "9780375842207",
                    Description = "A story about a girl who finds solace in books during Nazi Germany.",
                    Publisher = "Knopf Books for Young Readers",
                    PublishedDate = new DateTime(2005, 3, 14),
                    IsAvailableForSale = true,
                    Price = 14.50m,
                    Categories = new List<Category> { GetCategory("Historical"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "Charlotte's Web",
                    Author = "E.B. White",
                    ISBN = "9780061124952",
                    Description = "A children’s novel about the friendship between a pig and a spider.",
                    Publisher = "Harper & Brothers",
                    PublishedDate = new DateTime(1952, 10, 15),
                    IsAvailableForSale = true,
                    Price = 13.50m,
                    Categories = new List<Category> { GetCategory("Children's"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    ISBN = "9780061122415",
                    Description = "A philosophical novel about pursuing one's destiny.",
                    Publisher = "HarperOne",
                    PublishedDate = new DateTime(1988, 4, 15),
                    IsAvailableForSale = true,
                    Price = 14.99m,
                    Categories = new List<Category> { GetCategory("Philosophy"), GetCategory("Adventure") }
                },

                new Book
                {
                    Title = "Jane Eyre",
                    Author = "Charlotte Brontë",
                    ISBN = "9780142437209",
                    Description = "A coming-of-age story and love story wrapped in gothic elements.",
                    Publisher = "Smith, Elder & Co.",
                    PublishedDate = new DateTime(1847, 10, 16),
                    IsAvailableForSale = true,
                    Price = 8.99m,
                    Categories = new List<Category> { GetCategory("Classic"), GetCategory("Romance") }
                },
                new Book
                {
                    Title = "Moby-Dick",
                    Author = "Herman Melville",
                    ISBN = "9780142437247",
                    Description = "The epic tale of Captain Ahab's obsessive quest for revenge on the white whale.",
                    Publisher = "Harper & Brothers",
                    PublishedDate = new DateTime(1851, 11, 14),
                    IsAvailableForSale = true,
                    Price = 4.99m,
                    Categories = new List<Category> { GetCategory("Classic"), GetCategory("Adventure") }
                },
                new Book
                {
                    Title = "The Girl with the Dragon Tattoo",
                    Author = "Stieg Larsson",
                    ISBN = "9780307949486",
                    Description = "A mystery thriller involving a journalist and a hacker investigating a decades-old disappearance.",
                    Publisher = "Norstedts Förlag",
                    PublishedDate = new DateTime(2005, 8, 27),
                    IsAvailableForSale = true,
                    Price = 13.50m,
                    Categories = new List<Category> { GetCategory("Thriller") }
                },
                new Book
                {
                    Title = "Dracula",
                    Author = "Bram Stoker",
                    ISBN = "9780141439846",
                    Description = "A horror classic that introduced the character Count Dracula.",
                    Publisher = "Archibald Constable and Company",
                    PublishedDate = new DateTime(1897, 5, 26),
                    IsAvailableForSale = true,
                    Price = 5.99m,
                    Categories = new List<Category> { GetCategory("Horror"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "Anne of Green Gables",
                    Author = "L.M. Montgomery",
                    ISBN = "9780141321592",
                    Description = "A children’s classic about an imaginative girl adopted by a brother and sister.",
                    Publisher = "L.C. Page & Co.",
                    PublishedDate = new DateTime(1908, 6, 20),
                    IsAvailableForSale = true,
                    Price = 10.99m,
                    Categories = new List<Category> { GetCategory("Children's"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "The War of the Worlds",
                    Author = "H.G. Wells",
                    ISBN = "9780141441030",
                    Description = "A science fiction novel about an alien invasion from Mars.",
                    Publisher = "William Heinemann",
                    PublishedDate = new DateTime(1898, 4, 1),
                    IsAvailableForSale = true,
                    Price = 13.99m,
                    Categories = new List<Category> { GetCategory("Science Fiction"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "Les Misérables",
                    Author = "Victor Hugo",
                    ISBN = "9780451419439",
                    Description = "A historical novel set in post-revolutionary France, centered on justice and redemption.",
                    Publisher = "A. Lacroix, Verboeckhoven & Cie.",
                    PublishedDate = new DateTime(1862, 4, 3),
                    IsAvailableForSale = true,
                    Price = 8.99m,
                    Categories = new List<Category> { GetCategory("Historical"), GetCategory("Classic") }
                },
                new Book
                {
                    Title = "The Fault in Our Stars",
                    Author = "John Green",
                    ISBN = "9780525478812",
                    Description = "A romantic novel about two teens with cancer who fall in love.",
                    Publisher = "Dutton Books",
                    PublishedDate = new DateTime(2012, 1, 10),
                    IsAvailableForSale = true,
                    Price = 9.99m,
                    Categories = new List<Category> { GetCategory("Romance") }
                }
            };
        }
    }
}
