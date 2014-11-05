using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FinalGame.Converters
{
    class BoolToPlayer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
                throw new Exception("Converter must target a bool");

            Color trueColor = Color.FromArgb(255,255,255,255);
            Color falseColor = Color.FromArgb(255,0,0,0);


            return new SolidColorBrush(((bool)value ? trueColor : falseColor));

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
