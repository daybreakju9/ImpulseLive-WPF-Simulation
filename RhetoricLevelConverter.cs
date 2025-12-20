using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ImpulseLive.WPF
{
    public class RhetoricLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int level)
            {
                // 根据话术等级返回不同颜色（1-5颗星）
                // 这里简化处理，实际应该根据当前索引和等级比较
                return Brushes.Gray; // 默认灰色
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}