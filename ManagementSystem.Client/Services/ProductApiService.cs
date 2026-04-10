using System.Net.Http.Json;
using ManagementSystem.Client.Models;


namespace ManagementSystem.Client.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _http;

        public ProductApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProductDto>> Get()
            => await _http.GetFromJsonAsync<List<ProductDto>>("api/products");
        public async Task Update(ProductDto dto)
            => await _http.PutAsJsonAsync($"api/products/{dto.Id}", dto);

        public async Task Create(ProductDto dto)
            => await _http.PostAsJsonAsync("api/products", dto);

        public async Task Delete(Guid id)
            => await _http.DeleteAsync($"api/products/{id}");
    }
}