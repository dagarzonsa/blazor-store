using BlazorStoreApp.Models;

namespace BlazorStoreApp.Contracts
{
    public interface ICart
    {
        public List<Product>? GetAsync();
        public void AddAsync(Product product);
        public void DeleteAsync(int productId);
        void ClearAsync();
    }
}
