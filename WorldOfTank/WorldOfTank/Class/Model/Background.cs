using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handles the Background of Battlefield
    /// </summary>
    public class Background : StaticObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param>
        public Background(Image image)
            : base(image, TypeObject.Background)
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected Background(Image image, TypeObject type)
            : base(image, type)
        {
        }

        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            return TypeResult.Nothing;
        }
    }
}
