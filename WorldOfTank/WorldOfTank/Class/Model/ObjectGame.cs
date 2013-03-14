using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class ObjectGame
    {
        public Image image { set; get; }
        public Size size { set; get; }
        public Position position { set; get; }
        public TypeObject type { set; get; }

        public ObjectGame()
        {
        }

        public bool isCollide(ObjectGame obj)
        {
            return false;
        }
    }
}
