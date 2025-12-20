using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace ImpulseLive.WPF
{
    public class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return Visibility.Collapsed;
            }

            string valueString = value.ToString() ?? string.Empty;
            string parameterString = parameter.ToString() ?? string.Empty;

            return valueString.Equals(parameterString, StringComparison.OrdinalIgnoreCase) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}