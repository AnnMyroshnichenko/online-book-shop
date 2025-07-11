﻿using BookStore.Application.Categories.Dtos;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Dtos
{
    public class BookDto
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
        public decimal Price { get; set; }

        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
