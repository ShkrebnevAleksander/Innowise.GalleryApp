using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gallery.Models;
using Gallery.Services;
using Gallery.ViewModels;
using Gallery.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Gallery.ViewModels;

public partial class FavoritesViewModel : ObservableObject
{
    private readonly IUnsplashService _unsplashService;
    private readonly IFavoritesService _favoritesService;

    public FavoritesViewModel(IUnsplashService unsplashService, IFavoritesService favoritesService)
    {
        _unsplashService = unsplashService;
        _favoritesService = favoritesService;
    }

    public ObservableCollection<PhotoViewModel> FavoritePhotos { get; } = new();

    [ObservableProperty]
    private bool isLoading;

    [RelayCommand]
    private async Task LoadFavoritesAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;
            FavoritePhotos.Clear();

            var favoriteIds = _favoritesService.GetAllFavorites();

            if (favoriteIds is null || favoriteIds.Count == 0)
            {
                return;
            }

            foreach (var photoId in favoriteIds)
            {
                var photo = await _unsplashService.GetPhotoByIdAsync(photoId);
                if (photo != null)
                {
                    FavoritePhotos.Add(new PhotoViewModel(photo, true));
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"--> Ошибка при загрузке избранных фото: {ex.Message}");
            await Shell.Current.DisplayAlert("Ошибка", "Не удалось загрузить избранные фотографии.", "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }
    [RelayCommand]
    private async Task GoToDetailsAsync(PhotoViewModel photoViewModel)
    {
        if (photoViewModel is null) return;

        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            { "Photo", photoViewModel.Photo }
        });
    }
}