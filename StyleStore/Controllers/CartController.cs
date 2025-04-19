using Microsoft.AspNetCore.Mvc;
using StyleStore.Models.ViewModels;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductRepository _productRepository;

    public CartController(ICartService cartService, IProductRepository productRepository)
    {
        _cartService = cartService;
        _productRepository = productRepository;
    }

    public async Task<IActionResult> Index()
    {
        var cartItems = await _cartService.GetCartItems();
        var cartViewModel = new CartViewModel
        {
            Items = new List<CartItemViewModel>()
        };

        foreach (var item in cartItems)
        {
            var product = await _productRepository.GetProductById(item.ProductId);
            cartViewModel.Items.Add(new CartItemViewModel
            {
                ProductId = item.ProductId,
                ProductName = product.Name,
                Quantity = item.Quantity,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            });
        }

        return View(cartViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int productId)
    {
        await _cartService.RemoveFromCart(productId);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
    {
        await _cartService.UpdateQuantity(productId, quantity);
        return RedirectToAction(nameof(Index));
    }
}