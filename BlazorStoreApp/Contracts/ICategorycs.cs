using BlazorStoreApp.Models;

namespace BlazorStoreApp.Contracts
{
    public interface ICategoryService
    {
        Task<List<Product>?> GetAsync();
    }
}
