using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Monster
{
    class Witch : Monster
    {
        public Witch(int level)
        {
            Level = level;
            experience = 20 + (level - 1) * 2;
            type = "Witch";
            strength = BASE_STRENGTH + level - 1;
            intellect = BASE_INTELLECT * 2 + level - 1;
            dexterity = BASE_DEXTERITY + level - 1;
            damage = intellect / 4 + level - 1;
            damage = (int)Math.Round(damage * 1.1);
            hp = level * 4 - level / 5;
        }
    }
}
