using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Items
{
    public class Weapon : Item
    {
        public int StrengthModifier { get; private set; }

        public int DexterityModifier { get; private set; }

        public int IntelligenceModifier { get; private set; }

        public WeaponType type { get; private set; }

        public Weapon()
        {

        }
        
        //incomplete
        public Weapon(int level)
        {
            Random rGen = new Random();
            int typeNum = rGen.Next(0, 3);
            switch (typeNum)
            {
                case 0:
                    type = WeaponType.Sword;
                    StrengthModifier = 2 + level / 2;
                    break;
                case 1:
                    type = WeaponType.Bow;

                    break;
                case 2:
                    type = WeaponType.Staff;

                    break;
            }
        }

        public Weapon(Type weaponItemType, WeaponType weapon, int itemGrade)
        {
            type = weapon;
            itemType = weaponItemType;
            Grade = itemGrade;

            setMods();
        }

        public void setMods()
        {
            int baseMod = 0;
            switch (itemType)
            {
                case Type.Bronze:
                    baseMod = 2;
                    break;

                case Type.Iron:
                    baseMod = 4;
                    break;

                case Type.Steel:
                    baseMod = 6;
                    break;

                case Type.Platinum:
                    baseMod = 8;
                    break;

                case Type.Mithril:
                    baseMod = 10;
                    break;

                case Type.Dragon:
                    baseMod = 12;
                    break;
            }

            switch (type)
            {
                case WeaponType.Sword:
                    StrengthModifier = baseMod;
                    break;

                case WeaponType.Bow:
                    DexterityModifier = baseMod;
                    break;

                case WeaponType.Staff:
                    IntelligenceModifier = baseMod;
                    break;

            }
        }
    }
}
