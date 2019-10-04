using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Ch06.MultiBindings
{
    class RGBConverter : IMultiValueConverter
    {
        SolidColorBrush _brush = new SolidColorBrush();
        public object Convert(object[] values, Type targetType,object parameter, CultureInfo culture)
        {
            _brush.Color = Color.FromRgb(System.Convert.ToByte(
            values[0]), System.Convert.ToByte(values[1]),
            System.Convert.ToByte(values[2]));
            return _brush;
        }
        public object[] ConvertBack(object value, Type[] tTypes,object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
