using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalGame.Classes.Items;
using FinalGame.Classes.Monster;
using System.ComponentModel;

namespace FinalGame.Classes.Monster
{
    public class Monster : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _HP;
        private int _maxHP;
        //static int NUM_OF_TYPES = 3;
        public static int BASE_DEXTERITY = 3;
        public static int BASE_INTELLECT = 3;
        public static int BASE_STRENGTH = 3;
        public Random rGen = new Random();
        
        bool isAlive = true;
        public int maxHP
        {
            get { return _maxHP; }
            set
            {
                _maxHP = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("maxHP"));
            }
        }
        public int hp
        {
            get { return _HP; }
            set
            {
                _HP = value;

                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("hp"));
            } 
        }

        public string type;
        public int damage;
        public int experience;
        public int strength;
        public int intellect;
        public int dexterity;
        public int Level;

        public Monster() { }

        virtual public Item getDrop()
        {
            return new Item();
        }
        virtual public int getGoldDrop()
        {
            return 10;
        }

        //method to make monster take damage. if it takes lethal damage, it returns true. else it returns false.
        public bool takeDamage(int dmg)
        {
            hp -= dmg;
            if (hp <= 0) 
                isAlive = false;

            return !isAlive;
        }

    }
}
