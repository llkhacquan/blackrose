using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Wall : StaticObject
    {
        public Wall(Image Image)
            : base(Image, TypeObject.Wall)
        {
        }

        public override TypeResult NextFrame(List<ObjectGame> Objects)
        {
            return TypeResult.Nothing;
        }
    }
}
