using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handle the wall object
    /// </summary>
    public class Wall : StaticObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image wall</param>
        public Wall(Image image)
            : base(image, TypeObject.Wall)
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected Wall(Image image, TypeObject type)
            : base(image, type)
        {
        }

        /// <summary>
        /// Execute some change of this wall in a frame in battlefield
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            return TypeResult.Nothing;
        }
    }
}
