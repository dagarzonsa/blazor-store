using BlazorStoreApp.Contracts;
using BlazorStoreApp.Models;
using System.Collections.Generic;

namespace BlazorStoreApp.Services
{
    public class CartService: ICart
    {
        private readonly List<Product>? _cart = new();

        public List<Product>? GetAsync()
        {
            return _cart;
        }

        public void AddAsync(Product product)
        {
            _cart.Add(product);
        }

        public void DeleteAsync(int productId)
        {
            _cart.RemoveAll(p => p.Id == productId);
        }

        public void ClearAsync()
        {
            _cart.Clear();
        }

        
    }
} 