using BlazorStoreApp.Contracts;
using BlazorStoreApp.Models;
using System.Text.Json;

namespace BlazorStoreApp.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public CategoryService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClient = httpClient;
            _serializerOptions = jsonSerializerOptions;
        }

        public async Task<List<Product>?> GetAsync()
        {
            var response = await _httpClient.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), _serializerOptions);
        }
    }
}
