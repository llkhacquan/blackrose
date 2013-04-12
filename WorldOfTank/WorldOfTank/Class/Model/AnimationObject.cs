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
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image object</param>
        /// <param name="Type">Type object</param>
        public AnimationObject(Image Image, TypeObject Type)
            : base(Image, Type)
        {
        }
    }
}
