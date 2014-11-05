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

        private Item getDrop()
        {
            Classes.Items.Type itemType = (Classes.Items.Type)((Level % 12) / 2 + (Level % 12) % 2);
            int grade = Level / 12;
            Item itemToDrop = null;
            switch (rGen.Next(1,5))
            {
                case 1:
                    itemToDrop = new Consumable(grade, itemType, "A "+itemType+"+"+grade+" health potion! Enjoy it!");;
                    break;
                case 2:
                    itemToDrop = new Armor(itemType, grade, "Some "+itemType+"+"+grade+" armor! Enjoy it!");;
                    break;
                case 3:
                    WeaponType wepType = (Classes.Items.WeaponType)rGen.Next(1,4);
                    itemToDrop = new Weapon(itemType, wepType, grade, "A "+itemType+"+"+grade+" " +wepType+"! Enjoy it!");;
                    break;
                case 4:
                    itemToDrop = new Consumable(grade, itemType, "A "+itemType+"+"+grade+" health potion! Enjoy it!");;
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
