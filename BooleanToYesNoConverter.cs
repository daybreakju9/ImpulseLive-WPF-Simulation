using System.Globalization;
using System.Windows.Data;

namespace ImpulseLive.WPF
{
    public class BooleanToYesNoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? "是" : "否";
            }
            return "否";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return stringValue.Equals("是", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}