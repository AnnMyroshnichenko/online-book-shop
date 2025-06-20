using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? CoverImageUrl { get; set; }
        public bool IsAvailableForSale { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }

}
