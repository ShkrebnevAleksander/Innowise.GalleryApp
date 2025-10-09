using Gallery.ViewModels;

namespace Gallery.Views;

public partial class FavoritesPage : ContentPage
{
    public FavoritesPage(FavoritesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as FavoritesViewModel)?.LoadFavoritesCommand.Execute(null);
    }
    private void OnPhotoTapped(object sender, TappedEventArgs e)
    {
        var viewModel = BindingContext as FavoritesViewModel;
        if (viewModel == null) return;

        if (sender is BindableObject bindable && bindable.BindingContext is PhotoViewModel photoViewModel)
        {
            if (viewModel.GoToDetailsCommand.CanExecute(photoViewModel))
            {
                viewModel.GoToDetailsCommand.Execute(photoViewModel);
            }
        }
    }
}