using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gallery.Models;
using Gallery.Services;

namespace Gallery.ViewModels;

[QueryProperty(nameof(Photo), "Photo")]
public partial class DetailViewModel : ObservableObject
{
    private readonly IFavoritesService _favoritesService;

    public DetailViewModel(IFavoritesService favoritesService)
    {
        _favoritesService = favoritesService;
    }

    [ObservableProperty]
    private Photo photo;

    [ObservableProperty]
    private bool isFavorite;

    partial void OnPhotoChanged(Photo value)
    {
        if (value != null)
        {
            IsFavorite = _favoritesService.IsFavorite(value.Id);
        }
    }

    [RelayCommand]
    private void ToggleFavorite()
    {
        if (Photo is null) return;

        if (IsFavorite)
        {
            _favoritesService.RemoveFromFavorites(Photo.Id);
        }
        else
        {
            _favoritesService.AddToFavorites(Photo.Id);
        }

        IsFavorite = !IsFavorite;
    }
}