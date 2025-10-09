using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gallery.Services
{
    public class FavoritesService : IFavoritesService
    {
        private const string FavoritesKey = "favorite_photos";

        private List<string> GetFavoriteIds()
        {
            string favoritesJson = Preferences.Get(FavoritesKey, "[]");

            return JsonSerializer.Deserialize<List<string>>(favoritesJson);
        }

        private void SaveFavoriteIds(List<string> favoriteIds)
        {
            string favoritesJson = JsonSerializer.Serialize(favoriteIds);
            Preferences.Set(FavoritesKey, favoritesJson);
        }

        public void AddToFavorites(string photoId)
        {
            var favoriteIds = GetFavoriteIds();
            if (!favoriteIds.Contains(photoId))
            {
                favoriteIds.Add(photoId);
                SaveFavoriteIds(favoriteIds);
            }
        }

        public void RemoveFromFavorites(string photoId)
        {
            var favoriteIds = GetFavoriteIds();
            favoriteIds.Remove(photoId);
            SaveFavoriteIds(favoriteIds);
        }

        public bool IsFavorite(string photoId)
        {
            var favoriteIds = GetFavoriteIds();

            return favoriteIds.Contains(photoId);
        }
        public List<string> GetAllFavorites()
        {
            return GetFavoriteIds(); 
        }
    }
}
