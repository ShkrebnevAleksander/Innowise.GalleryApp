using System.Globalization;

namespace Gallery.Converters;

public class BoolToFavoriteTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isFavorite)
        {
            return isFavorite ? "icon_heartfilled.png" : "icon_unheartfilled.png";
        }
        return "icon_unheartfilled.png"; 
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}