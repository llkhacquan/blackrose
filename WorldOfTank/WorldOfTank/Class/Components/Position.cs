using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfTank.Class.Components
{
    class Position
    {
        public int x { set; get; }
        public int y { set; get; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
