using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ImpulseLive.WPF
{
    public class BooleanToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool hasInstallment)
            {
                return hasInstallment ? new SolidColorBrush(Color.FromRgb(46, 204, 113)) : new SolidColorBrush(Color.FromRgb(155, 89, 182));
            }
            return new SolidColorBrush(Color.FromRgb(155, 89, 182));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}