using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.Classes.Items
{
    [Serializable]
    public class Armor : Item, IComparable
    {
        public int HealthModifier { get; set; }

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
            HealthModifier = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;

        }

        public int CompareTo(Armor item)
        {
            int ret = (Grade - item.Grade) + ((int)ItemType - (int)item.ItemType) + (HealthModifier - item.HealthModifier);
            return ret;
        }
    }
}