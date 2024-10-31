using BlazorStoreApp.Contracts;
using BlazorStoreApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorStoreApp.Services
{
    public class ProductService:IProduct
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public ProductService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _serializerOptions = jsonSerializerOptions;
        }

        public async Task<List<Product>?> GetAsync()
        {
            var response = await _httpClient.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), _serializerOptions);
        }

        public async Task AddAsync(Product product)
        {
            var response = await _httpClient.PostAsync("products", JsonContent.Create(product));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task DeleteAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"products/{productId}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
    }
}
