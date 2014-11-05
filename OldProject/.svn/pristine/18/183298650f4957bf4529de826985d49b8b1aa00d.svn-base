using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FinalGame.Converters
{
    class BoolToImageConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is bool))
                throw new Exception("You done messed up! Target must be of type bool");
            
            //Image trueImage = new Image();
            //Image falseImage = new Image();
            BitmapImage trueImageSource = new BitmapImage();
            BitmapImage falseImageSource = new BitmapImage();

            
            trueImageSource.BeginInit();
            trueImageSource.UriSource = new Uri("Resources/OpenTile.jpg", UriKind.Relative); //breaking things
            trueImageSource.EndInit();

            falseImageSource.BeginInit();
            falseImageSource.UriSource = new Uri("Resources/ClosedTile.jpg", UriKind.Relative);
            falseImageSource.EndInit();

            //trueImage.Source = trueImageSource;
            //falseImage.Source = falseImageSource;
            bool b = (bool) value;

            ImageBrush boolImageBrush = new ImageBrush((b ? trueImageSource : falseImageSource));
            
            return boolImageBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
