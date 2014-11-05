using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeDiesAtTheEnd.Classes.Items;
using HeDiesAtTheEnd.Classes.Monster;

namespace HeDiesAtTheEnd.Classes.Monster
{
    class Monster
    {
        //static int NUM_OF_TYPES = 3;
        public static int BASE_DEXTERITY = 3;
        public static int BASE_INTELLECT = 3;
        public static int BASE_STRENGTH = 3;
        Random rGen = new Random();
        
        bool isAlive = true;
        public int hp { get; set; }
        public string type;
        public int damage;
        //public Item drop;
        public int experience;
        public int strength;
        public int intellect;
        public int dexterity;
        public int Level;

        public Monster() { }

        private Item getDrop(int num)
        {
            Item itemToDrop = null;
            switch (num)
            {
                case 1:
                    itemToDrop = null;
                    break;
                case 2:
                    itemToDrop = null;
                    break;
                case 3:
                    itemToDrop = null;
                    break;
                case 4:
                    itemToDrop = null;
                    break;
            }
            return itemToDrop;
        }

        //method to make monster take damage. if it takes lethal damage, it returns true. else it returns false.
        public bool takeDamage(int dmg)
        {
            hp -= dmg;
            if (hp <= 0) isAlive = false;
            return !isAlive;
        }
    }
}
