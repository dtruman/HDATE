using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Monster
{
    class Goblin : Monster
    {
        public Goblin(int level)
        {
            experience = 20 + (level - 1) * 2;
            type = "Goblin";
            strength = BASE_STRENGTH + level - 1;
            intellect = BASE_INTELLECT + level - 1;
            dexterity = BASE_DEXTERITY * 2 + level - 1;
            damage = dexterity / 4 + level - 1;
            hp = level * 4;
        }
    }
}
