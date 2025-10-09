using Gallery.ViewModels;

namespace Gallery.Views;

public partial class GalleryPage : ContentPage
{
    private readonly GalleryViewModel _viewModel;
    public GalleryPage(GalleryViewModel viewModel)
    {
        InitializeComponent(); 
        _viewModel = viewModel;

        BindingContext = _viewModel;
        
    }
    private void OnPhotoTapped(object sender, TappedEventArgs e)
    {
        var viewModel = BindingContext as GalleryViewModel;
        if (viewModel == null) return; 

        if (sender is BindableObject bindable && bindable.BindingContext is PhotoViewModel photoViewModel)
        {
            if (viewModel.GoToDetailCommand.CanExecute(photoViewModel))
            {
                viewModel.GoToDetailCommand.Execute(photoViewModel);
            }
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel?.GetPhotosCommand.Execute(null);
    }
}