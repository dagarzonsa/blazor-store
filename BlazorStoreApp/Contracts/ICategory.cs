using BlazorStoreApp.Models;

namespace BlazorStoreApp.Contracts
{
    public interface ICategory
    {
        Task<List<Category>?> GetAsync();
    }
}
