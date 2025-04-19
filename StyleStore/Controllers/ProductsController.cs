using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public ProductsController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productRepository.GetProductById(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity)
    {
        await _cartService.AddToCart(productId, quantity);
        return RedirectToAction("Index", "Cart");
    }
}