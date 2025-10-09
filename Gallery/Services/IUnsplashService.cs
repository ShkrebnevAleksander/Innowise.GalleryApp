using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.Services
{
    public interface IUnsplashService
    {
        Task<List<Photo>> GetPhotosAsync(int pageNumber);
        Task<Photo> GetPhotoByIdAsync(string photoId);
    }
}
