using BlazorStoreApp.Contracts;
using BlazorStoreApp.Models;
using System.Collections.Generic;
using System;

namespace BlazorStoreApp.Services
{
    public class CartService: ICart
    {
        private readonly List<Product>? _cart = new();
        public event Action? OnCartChanged;

        public List<Product>? GetAsync()
        {
            return _cart;
        }

        public void AddAsync(Product product)
        {
            _cart.Add(product);
            OnCartChanged?.Invoke();
        }

        public void DeleteAsync(int productId)
        {
            _cart.RemoveAll(p => p.Id == productId);
            OnCartChanged?.Invoke();
        }

        public void ClearAsync()
        {
            _cart.Clear();
            OnCartChanged?.Invoke();
        }

        
    }
} 