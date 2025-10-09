using CommunityToolkit.Mvvm.ComponentModel;
using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery.ViewModels
{
    public partial  class PhotoViewModel : ObservableObject
    {
        public Photo Photo { get; }

        [ObservableProperty]
        private bool isFavorite;

        public PhotoViewModel(Photo photo, bool isFavorite)
        {
            Photo = photo;
            IsFavorite = isFavorite;
        }
    }
}
