using BlazorStoreApp.Models;

namespace BlazorStoreApp.Contracts
{
    public interface IProduct
    {
        Task<List<Product>?> GetAsync();
        Task AddAsync(Product product);
        Task DeleteAsync(int productId);
    }
}
