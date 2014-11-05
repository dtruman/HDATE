using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalGame.MapElements
{
    public class Tile : Label, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TileType _type;
        private bool _open;
        private bool _visible;
        private bool _playerIsHere;
        private bool _monsterIsHere;
        private PlayerDirections _direction;

        public PlayerDirections direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("direction"));
            }
        }


        public bool playerIsHere
        {
            get { return _playerIsHere; }
            set
            {
                _playerIsHere = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("playerIsHere"));
            }
        }

        public bool monsterIsHere
        {
            get { return _monsterIsHere; }
            set
            {
                _monsterIsHere = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("monsterIsHere"));
            }
        }

        public bool open
        {
            get {return _open; }
            set
            {
                _open = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("open"));
            }
        }

        public bool visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("visible"));
            }
        }

        public TileType type
        {
            get { return _type; }
            set
            {
                _type = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("type"));
            }
        }

        public Tile()
        {
            visible = false;
            type = TileType.closed;
            direction = PlayerDirections.South;
            Height = 25;
            Width = 25;
        }
    }
}
