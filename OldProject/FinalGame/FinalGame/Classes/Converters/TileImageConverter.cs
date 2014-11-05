using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using FinalGame.MapElements;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace FinalGame.Converters
{
    class TileImageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(values[0] is TileType))
                throw new Exception("First Binding must be of type TileType");
            if (!(values[1] is bool))
                throw new Exception("Second Binding must be of type bool");
            if (!(values[2] is bool))
                throw new Exception("Third Binding must be of type bool");
            if (!(values[3] is PlayerDirections))
                throw new Exception("Fourth Binding must be of type playerDirecion");
            if (values.Length > 4)
                throw new Exception("too many bindings.");

            TileType chosenType = (TileType)values[0];
            bool isPlayerHere = (bool)values[1];
            bool visible = (bool)values[2];
            PlayerDirections playerFacing = (PlayerDirections)values[3];

            BitmapImage ImageSource = new BitmapImage();

            if (!visible)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/FogTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.closed)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/ClosedTile_25x25.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.decoration)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/box.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.counter)
            {
                Random rGen = new Random();

                ImageSource.BeginInit();
                switch (rGen.Next(1, 5))
                {
                    case 1:
                        ImageSource.UriSource = new Uri("Resources/CounterTop.png", UriKind.Relative);
                        break;
                    case 2:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_1.png", UriKind.Relative);
                        break;
                    case 3:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_2.png", UriKind.Relative);
                        break;
                    case 4:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_3.png", UriKind.Relative);
                        break;
                }
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.decoration)
            {
                ImageSource.BeginInit();
                ImageSource.UriSource = new Uri("Resources/box.png", UriKind.Relative);
                ImageSource.EndInit();
            }
            else if (chosenType == TileType.counter)
            {
                Random rGen = new Random();

                ImageSource.BeginInit();
                switch (rGen.Next(1, 5))
                {
                    case 1:
                        ImageSource.UriSource = new Uri("Resources/CounterTop.png", UriKind.Relative);
                        break;
                    case 2:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_1.png", UriKind.Relative);
                        break;
                    case 3:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_2.png", UriKind.Relative);
                        break;
                    case 4:
                        ImageSource.UriSource = new Uri("Resources/CounterTop_3.png", UriKind.Relative);
                        break;
                }
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

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/MonsterTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.trap)
            {
                ImageSource.BeginInit();

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.triggeredTrap)
            {
                ImageSource.BeginInit();

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north_trap.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east_trap.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south_trap.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west_trap.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/TrapTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.open)
            {
                ImageSource.BeginInit();

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.start)
            {
                ImageSource.BeginInit();

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.store)
            {
                ImageSource.BeginInit();

                if (isPlayerHere)
                {
                    if (playerFacing == PlayerDirections.North)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_north.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.East)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_east.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.South)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_south.png", UriKind.Relative);
                    }
                    else if (playerFacing == PlayerDirections.West)
                    {
                        ImageSource.UriSource = new Uri("Resources/Player_west.png", UriKind.Relative);
                    }
                }
                else
                    ImageSource.UriSource = new Uri("Resources/OpenTile_25x25.png", UriKind.Relative);

                ImageSource.EndInit();
            }
            else if (chosenType == TileType.npc)
            {
                ImageSource.BeginInit();

                
                ImageSource.UriSource = new Uri("Resources/Shopkeeper_25x25.png", UriKind.Relative);

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

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
