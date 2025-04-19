using StyleStore.Models;

public interface ICartService
{
    Task<List<CartItem>> GetCartItems();
    Task AddToCart(int productId, int quantity);
    Task RemoveFromCart(int productId);
    Task UpdateQuantity(int productId, int quantity);
    Task ClearCart();
}