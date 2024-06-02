using System.Globalization;
using System.Windows.Data;

namespace RBACSample.Converters;

public class UserTypeToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int.TryParse(value.ToString(), out int newValue);
        int.TryParse(parameter.ToString(), out int paramValue);

        return newValue >= paramValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}