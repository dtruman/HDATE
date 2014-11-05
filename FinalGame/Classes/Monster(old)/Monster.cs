//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HeDiesAtTheEnd.Classes.Items;

//namespace HeDiesAtTheEnd.Classes.Monster(Old)
//{
//    class Monster
//    {
//        int NUM_OF_TYPES = 3;
//        int BASE_DEXTERITY = 3;
//        int BASE_INTELLECT = 3;
//        int BASE_STRENGTH = 3;
//        Random rGen = new Random();
//        bool isAlive = true;

//        public string type;
//        public int damage;
//        public Item drop;
//        public int experience;
//        public int strength;
//        public int intellect;
//        public int dexterity;
//        public int Level { get; set; }
//        public int hp { get; private set; }

//        public Monster(int level)
//        {
//            experience = 20 + (level - 1) * 2;
//            Level = level;
//            switch (rGen.Next(1, NUM_OF_TYPES + 1))
//            {
//                case 1:
//                    makeGoblin(level);
//                    break;
//                case 2:
//                    makeWitch(level);
//                    break;
//                case 3:
//                    makeOrc(level);
//                    break;
//            }
//            drop = getDrop(rGen.Next(1, 5));
//        }

//        private void makeOrc(int level)
//        {
//            type = "Orc";
//            strength = BASE_STRENGTH * 2 + level - 1;
//            intellect = BASE_INTELLECT + level - 1;
//            dexterity = BASE_DEXTERITY + level - 1;
//            damage = strength / 4 + level - 1;
//            damage = (int)Math.Round(damage * 0.9);
//            hp = level * 4 + level / 5;
//        }

//        private void makeWitch(int level)
//        {
//            type = "Witch";
//            strength = BASE_STRENGTH + level - 1;
//            intellect = BASE_INTELLECT * 2 + level - 1;
//            dexterity = BASE_DEXTERITY + level - 1;
//            damage = intellect / 4 + level - 1;
//            damage = (int)Math.Round(damage * 1.1);
//            hp = level * 4 - level / 5;
//        }

//        private void makeGoblin(int level)
//        {
//            type = "Goblin";
//            strength = BASE_STRENGTH + level - 1;
//            intellect = BASE_INTELLECT + level - 1;
//            dexterity = BASE_DEXTERITY * 2 + level - 1;
//            damage = dexterity / 4 + level - 1;
//            hp = level * 4;
//        }

//        private Item getDrop(int num)
//        {
//            Item itemToDrop = null;
//            switch (num)
//            {
//                case 1:
//                    itemToDrop = null;
//                    break;
//                case 2:
//                    itemToDrop = null;
//                    break;
//                case 3:
//                    itemToDrop = null;
//                    break;
//                case 4:
//                    itemToDrop = null;
//                    break;
//            }
//            return itemToDrop;
//        }

//        //method to make monster take damage. if it takes lethal damage, it returns true. else it returns false.
//        public bool takeDamage(int dmg)
//        {
//            hp -= dmg;
//            if (hp <= 0) isAlive = false;
//            return !isAlive;
//        }
//    }
//}
