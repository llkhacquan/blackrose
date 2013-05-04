using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    public class Wall : StaticObject
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="image">Image wall</param>
        public Wall(Image image)
            : base(image, TypeObject.Wall)
        {
        }

        /// <summary>
        ///     Execute some change of this wall in a frame in battefield
        /// </summary>
        /// <param name="objects">>Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            return TypeResult.Nothing;
        }
    }
}
