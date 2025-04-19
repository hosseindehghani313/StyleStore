using System.Collections.Generic;

namespace StyleStore.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal SubTotal => Items.Sum(item => item.Price * item.Quantity);
        public decimal ShippingCost { get; set; } = 10.00m;
        public decimal Total => SubTotal + ShippingCost;
    }

    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}