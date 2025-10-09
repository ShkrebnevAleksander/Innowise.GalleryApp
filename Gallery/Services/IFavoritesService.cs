using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Services
{
    public interface IFavoritesService
    {
        bool IsFavorite(string photoId);
        void AddToFavorites(string photoId);
        void RemoveFromFavorites(string photoId);
        List<string> GetAllFavorites();
    }
}
