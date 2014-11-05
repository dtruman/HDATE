using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Monster
{
    class Orc : Monster
    {
        public Orc(int level)
        {
            Level = level;
            experience = 20 + (level - 1) * 2;
            type = "Orc";
            strength = BASE_STRENGTH * 2 + level - 1;
            intellect = BASE_INTELLECT + level - 1;
            dexterity = BASE_DEXTERITY + level - 1;
            damage = strength / 4 + level - 1;
            damage = (int)Math.Round(damage * 0.9);
            hp = level * 4 + level / 5;
        }
    }
}
