using StyleStore.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

public class CartService : ICartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly StoreContext _context;

    public CartService(IHttpContextAccessor httpContextAccessor, StoreContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }

    public async Task<List<CartItem>> GetCartItems()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartJson = session.GetString("Cart");

        if (string.IsNullOrEmpty(cartJson))
            return new List<CartItem>();

        var cartItems = JsonSerializer.Deserialize<List<CartItem>>(cartJson);

        // Load product details for each cart item
        foreach (var item in cartItems)
        {
            item.Product = await _context.Products.FindAsync(item.ProductId);
        }

        return cartItems;
    }

    public async Task AddToCart(int productId, int quantity)
    {
        var cart = await GetCartItems();
        var existingItem = cart.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var product = await _context.Products.FindAsync(productId);
            cart.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = product.Price,
                Product = product
            });
        }

        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString("Cart", JsonSerializer.Serialize(cart, new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        }));
    }

    public Task RemoveFromCart(int productId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuantity(int productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task ClearCart()
    {
        throw new NotImplementedException();
    }
}