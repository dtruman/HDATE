using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.MapElements
{
    public enum TileType
    {
        open,
        monster,
        start,
        closed,
        trap,
        triggeredTrap,
        decoration,
        counter,
        end,
        store,
        npc,
    }
}
