using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = "Customer";
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    }

}
