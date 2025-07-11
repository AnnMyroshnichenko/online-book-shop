﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int BookId { get; set; }
        public Book Book { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
    }

}
