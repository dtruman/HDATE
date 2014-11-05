using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Items
{
    public class Armor : Item, IComparable
    {
        public int StrengthModifier { get; private set; }

        public int DexterityModifier { get; private set; }

        public int IntelligenceModifier { get; private set; }

        public Armor()
        {
            
        }

        public Armor(Type armorItemType, int itemGrade, string description, string name)
        {
            ItemType = armorItemType;
            Grade = itemGrade;
            ItemDescription = description;
            ItemName = name;

            setMods();
        }

        public void setMods()
        {
            StrengthModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;
            DexterityModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;
            IntelligenceModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;

        }

        public int CompareTo(Armor item)
        {
            int ret = (Grade - item.Grade) + ((int)ItemType - (int)item.ItemType) + (StrengthModifier - item.StrengthModifier) + (IntelligenceModifier - item.IntelligenceModifier) + (DexterityModifier - item.DexterityModifier);
            return ret;
        }
    }
}