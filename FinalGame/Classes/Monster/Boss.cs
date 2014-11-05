using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalGame.Classes.Items;


namespace FinalGame.Classes.Monster
{
    class Boss : Monster
    {
        Random rGen = new Random();

        public Boss(int level)
        {
            Level = level;
            experience = 20 + ((level + 2) * 3);
            type = RandomizeType();
            if (type == "strMonster")
            {
                strength = (5 * 2) + level;
                intellect = 3 + level + 2;
                dexterity = 3 + level + 2;
                damage = strength / 3 + level;
            }
            if (type == "intMonster")
            {
                strength = 3 + level + 2;
                intellect = (5 * 2) + level;
                dexterity = 3 + level + 2;
                damage = intellect / 3 + level;
            }
            if (type == "dexMonster")
            {
                strength = 3 + level + 2;
                intellect = 3 + level + 2;
                dexterity = (5 * 2) + level;
                damage = dexterity / 3 + level;
            }
            damage = (int)Math.Round(damage * 0.9);
            hp = level * 6 + 10;
            maxHP = hp;
            
        }
        public string RandomizeType()
        {
            string ret;
            Random rand = new Random();
            int choice = rand.Next(1, 4);
            if (choice == 1)
            {
                ret = "strMonster";
            }
            if (choice == 2)
            {
                ret = "intMonster";
            }
            else
            {
                ret = "dexMonster";
            }
            return ret;
        }

        public override Items.Item getDrop()
        {
            Classes.Items.Type itemType = (Classes.Items.Type)(((Level + 5) % 12) / 2 + (((Level + 5) % 12) % 2) + (((Level + 5) % 12 == 0) ? 6 : 0));
            UniqueWeaponNames uniqueName = (UniqueWeaponNames)rGen.Next(1, 30);

            int grade = 0;
            for (int i = 0; i < Level + 5; i += 12)
                grade = i / 12;

            WeaponType wepType = (Classes.Items.WeaponType)rGen.Next(1, 4);
            Item itemToDrop = new Weapon(itemType, wepType, grade, uniqueName.GetDescription() + " " + wepType + "! Enjoy it!", uniqueName.GetDescription() + " " + wepType);

            return itemToDrop;
        }
        public override int getGoldDrop()
        {
            return Level+5;
        }


    }
}
