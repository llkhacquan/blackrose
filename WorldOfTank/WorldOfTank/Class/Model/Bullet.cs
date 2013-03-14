using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Bullet : ObjectGame
    {
        public Direction direction { set; get; }
        public int speed { set; get; }
        public int damage { set; get; }
    }
}
