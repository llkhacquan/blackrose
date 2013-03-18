using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    abstract class AnimationObject : ObjectGame
    {
        public AnimationObject(Image Image, TypeObject Type)
            : base(Image, Type)
        {
        }
    }
}
