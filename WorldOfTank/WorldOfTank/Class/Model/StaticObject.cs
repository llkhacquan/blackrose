using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handles the static objects like: wall, trees...
    /// </summary>
    public abstract class StaticObject : ObjectGame
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected StaticObject(Image image, TypeObject type)
            : base(image, type)
        {
        }
    }
}
