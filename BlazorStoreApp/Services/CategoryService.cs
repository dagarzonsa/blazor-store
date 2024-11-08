using BlazorStoreApp.Contracts;
using BlazorStoreApp.Models;
using System.Text.Json;

namespace BlazorStoreApp.Services
{
    public class CategoryService:ICategory
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true};
        }

        public async Task<List<Category>?> GetAsync()
        {
            var response = await _httpClient.GetAsync("categories");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return await JsonSerializer.DeserializeAsync<List<Category>>(await response.Content.ReadAsStreamAsync(), _serializerOptions);
        }
    }
}
