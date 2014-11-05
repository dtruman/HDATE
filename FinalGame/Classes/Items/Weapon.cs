using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.Classes.Items
{
    [Serializable]
    public class Weapon : Item, IComparable
    {
        public int StrengthModifier { get; private set; }

        public int DexterityModifier { get; private set; }

        public int IntelligenceModifier { get; private set; }

        public WeaponType type { get; private set; }

        public Weapon()
        {
            
        }

        public Weapon(Type weaponItemType, WeaponType weapon, int itemGrade, string description, string name)
        {
            type = weapon;
            ItemType = weaponItemType;
            Grade = itemGrade;
            ItemDescription = description;
            ItemName = name;

            setMods();
        }

        public void setMods()
        {
            switch (type)
            {
                case WeaponType.Sword:
                    StrengthModifier = ((int)Type.Dragon *2 * Grade) + (int)ItemType*2;
                    break;

                case WeaponType.Bow:
                    DexterityModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;
                    break;

                case WeaponType.Staff:
                    IntelligenceModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;
                    break;

            }
        }

        public int CompareTo(Weapon item)
        {
            int ret = (Grade - item.Grade) + ((int)ItemType - (int)item.ItemType) + (StrengthModifier - item.StrengthModifier) + (IntelligenceModifier - item.IntelligenceModifier) + (DexterityModifier - item.DexterityModifier);
            return ret;
        }
    }
}