using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Items
{
    public class Armor : Item, IComparable
    {
        public int HealthModifier { get; set; }

        public Armor()
        {
            
        }

        public Armor(Type armorItemType, int itemGrade, string description)
        {
            ItemType = armorItemType;
            Grade = itemGrade;
            ItemDescription = description;

            setMods();
        }

        public void setMods()
        {
            HealthModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;

        }

        public int CompareTo(Armor item)
        {
            int ret = (Grade - item.Grade) + ((int)ItemType - (int)item.ItemType) + (HealthModifier - item.HealthModifier);
            return ret;
        }
    }
}