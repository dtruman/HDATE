using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalGame.Classes.Items;

namespace FinalGame.Classes.Monster
{
    class IntMonster : Monster
    {
        public IntMonster(int level)
        {
            Level = level;
            experience = 20 + (level - 1) * 2;
            type = "intMonster";
            strength = BASE_STRENGTH + level - 1;
            intellect = BASE_INTELLECT * 2 + level - 1;
            dexterity = BASE_DEXTERITY + level - 1;
            damage = intellect / 4 + level - 1;
            damage = (int)Math.Round(damage * 1.1);
            hp = level * 4 - level / 5;
            maxHP = hp;
        }
        public override int getGoldDrop()
        {
            return 1 + (int)(Level * .1);
        }
        public override Items.Item getDrop()
        {
            Classes.Items.Type itemType = (Classes.Items.Type)((Level % 12) / 2 + ((Level % 12) % 2) + ((Level % 12 == 0) ? 6 : 0));
            int grade = 0;
            for (int i = 0; i < Level; i += 12)
                grade = i / 12;

            Item itemToDrop = null;
            switch (rGen.Next(1, 5))
            {
                case 1:
                    itemToDrop = new Consumable(grade, itemType, "A " + itemType + "+" + grade + " health potion! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " health potion");
                    break;
                case 2:
                    itemToDrop = new Armor(itemType, grade, "Some " + itemType + "+" + grade + " armor! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " armor");
                    break;
                case 3:
                    WeaponType wepType = (Classes.Items.WeaponType)rGen.Next(1, 4);
                    itemToDrop = new Weapon(itemType, wepType, grade, "A " + itemType + "+" + grade + " " + wepType + "! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " " + wepType);
                    break;
                case 4:
                    itemToDrop = new Consumable(grade, itemType, "A " + itemType + "+" + grade + " health potion! Enjoy it!", (grade == 0 ? "" : "+" + grade + " ") + itemType + " health potion");
                    break;
            }
            return itemToDrop;
        }
    }
}
