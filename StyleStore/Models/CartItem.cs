﻿using System.ComponentModel.DataAnnotations;

namespace StyleStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}