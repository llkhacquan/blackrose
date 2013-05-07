using System;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handles the Dynamic object like: tank, bullet, rocket...
    /// </summary>
    [Serializable]
    public abstract class DynamicObject : ObjectGame
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected DynamicObject(Image image, TypeObject type)
            : base(image, type)
        {
        }

        /// <summary>
        /// Rotate left object
        /// </summary>
        /// <param name="value">The angel in degree that the image will be rotated</param>
        public void RotateLeft(float value)
        {
            Direction -= value;
        }

        /// <summary>
        /// Rotate right object
        /// </summary>
        /// <param name="value">The angel in degree that the image will be rotated</param>
        public void RotateRight(float value)
        {
            Direction += value;
        }

        /// <summary>
        /// Move forward object
        /// </summary>
        /// <param name="value">The distance of movement</param>
        public void MoveForward(float value)
        {
            var rad = Math.PI * Direction / 180;
            Position.X += (float)Math.Sin(rad) * value;
            Position.Y -= (float)Math.Cos(rad) * value;
        }

        /// <summary>
        /// Move backward object
        /// </summary>
        /// <param name="value">The distance of movement</param>
        public void MoveBackward(float value)
        {
            var rad = Math.PI * Direction / 180;
            Position.X -= (float)Math.Sin(rad) * value;
            Position.Y += (float)Math.Cos(rad) * value;
        }
    }
}
