using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Wall : StaticObject
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image wall</param>
        public Wall(Image Image)
            : base(Image, TypeObject.Wall)
        {
        }

        /// <summary>
        ///     Create a copy of this wall
        /// </summary>
        /// <returns>A copy of this wall</returns>
        public override ObjectGame Clone()
        {
            Wall wall = new Wall(this.Image) { Size = this.Size };
            return wall;
        }

        /// <summary>
        ///     Execute some change of this wall in a frame in battefield
        /// </summary>
        /// <param name="Objects">>Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> Objects)
        {
            return TypeResult.Nothing;
        }
    }
}
