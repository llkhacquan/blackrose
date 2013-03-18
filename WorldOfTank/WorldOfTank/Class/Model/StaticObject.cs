using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    abstract class StaticObject : ObjectGame
    {
        public StaticObject(Image Image, TypeObject Type)
            : base(Image, Type)
        {
        }
    }
}
