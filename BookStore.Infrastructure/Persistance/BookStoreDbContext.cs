using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistance
{
    internal class BookStoreDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Rental> Rentals => Set<Rental>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Wishlist> Wishlists => Set<Wishlist>();

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Categories)
                .WithMany(c => c.Books);

            modelBuilder.Entity<Wishlist>()
                .HasKey(w => new { w.UserId, w.BookId });

            base.OnModelCreating(modelBuilder);
        }
    }

}
