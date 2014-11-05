using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Items
{
    public class Consumable : Item, IComparable
    {
        public int HealthRegen { get; private set; }

        public Consumable(int itemGrade, Type consumableType, string description)
        {
            Grade = itemGrade;
            ItemType = consumableType;
            ItemDescription = description;

            HealthRegen = ((int)Type.Dragon * 2 * Grade) + (int)ItemType * 2;
        }

        public int CompareTo(Consumable item)
        {
            int ret = (Grade - item.Grade) + ((int)ItemType - (int)item.ItemType) + (HealthRegen - item.HealthRegen);
            return ret;
        }
    }
}
