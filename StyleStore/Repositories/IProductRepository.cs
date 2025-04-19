public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<IEnumerable<Product>> GetFeaturedProducts();
    Task<IEnumerable<Product>> GetProductsByCategory(int categoryId);
}