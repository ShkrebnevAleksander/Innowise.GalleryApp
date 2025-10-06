using Gallery.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace Gallery.Services
{
    internal class UnsplashService : IUnsplashService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "yUuje4BD_ocPlme150LHenjGYjzTVisxohs9AYROQRI";
        public UnsplashService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Client-ID {ApiKey}");
        }


        public async Task<List<Photo>> GetPhotosAsync(int pageNumber)
        {
            if (string.IsNullOrEmpty(ApiKey) || ApiKey == "ТВОЙ_КЛЮЧ_ДОСТУПА")
            {
                Debug.WriteLine("ОШИБКА: API ключ для Unsplash не указан в UnsplashService.cs!");
                return new List<Photo>();
            }

            var url = $"https://api.unsplash.com/photos?page={pageNumber}&per_page=30";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Photo>>(url);

                return response ?? new List<Photo>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"--> Ошибка при получении фото из Unsplash: {ex.Message}");

                return new List<Photo>();
            }
        }
    }
}
