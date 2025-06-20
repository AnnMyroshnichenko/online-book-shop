using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = "Customer";
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Cart> Cart { get; set; } = new List<Cart>();
    }

}
