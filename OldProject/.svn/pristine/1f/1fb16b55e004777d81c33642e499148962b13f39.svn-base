using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FinalGame.MapElements;

namespace FinalGame.Converters 
{
    class EnumToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (!(value is TileType))
            //    throw new Exception("You done messed up! Target must be of type TileType");

            BitmapImage ImageSource = new BitmapImage();

            TileType chosenType = (TileType)value;

            if (chosenType == TileType.closed)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/ClosedTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.end)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/EndTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.monster)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/MonsterTile.jpg", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.trap)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.open)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.start)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/ErrorTile.jpg", UriKind.Relative);
                ImageSource.EndInit();
            }

            ImageBrush boolImageBrush = new ImageBrush(ImageSource);

            return boolImageBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
