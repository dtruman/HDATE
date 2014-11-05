using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.MapElements
{
    public class Vector2D
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2D(int x =0,int y = 0)
        {
            this.x = x;
            this.y = y;
        }
    }
}
