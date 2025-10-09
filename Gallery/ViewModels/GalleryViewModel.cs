using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Gallery.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Gallery.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Gallery.Views;

namespace Gallery.ViewModels
{
    public partial class GalleryViewModel : ObservableObject
    {
        private int _currentPage = 1;
        private readonly IUnsplashService _unsplashService;
        private readonly IFavoritesService _favoritesService;
        public GalleryViewModel(IUnsplashService unsplashService, IFavoritesService favoritesService)
        {
            _unsplashService = unsplashService;
            _favoritesService = favoritesService;
        }
        public ObservableCollection<PhotoViewModel> Photos { get; } = new();


        [ObservableProperty]
        private bool isLoading;
        [RelayCommand]
        private async Task GetPhotosAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                Photos.Clear();
                _currentPage = 1;

                var photos = await _unsplashService.GetPhotosAsync(_currentPage);

                foreach (var photo in photos)
                {
                    bool isFavorite = _favoritesService.IsFavorite(photo.Id);
                    Photos.Add(new PhotoViewModel(photo, isFavorite));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"--> Ошибка при загрузке фото: {ex.Message}");
                await Shell.Current.DisplayAlert("Ошибка", "Не удалось загрузить фотографии.", "OK");
            }
            finally
            {
                IsLoading = false;
            }

        }

        [RelayCommand]
        private async Task LoadMorePhotosAsync()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                _currentPage++;
                var photos = await _unsplashService.GetPhotosAsync(_currentPage);

                foreach (var photo in photos)
                {
                    bool isFavorite = _favoritesService.IsFavorite(photo.Id);
                    Photos.Add(new PhotoViewModel(photo, isFavorite));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"--> Ошибка при подгрузке фото: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetailAsync(PhotoViewModel photoViewModel)
        {
            if (photoViewModel == null) return;
            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Photo", photoViewModel.Photo }
        });
        }
    }
}
