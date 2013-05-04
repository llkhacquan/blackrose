using System;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    [Serializable]
    public abstract class DynamicObject : ObjectGame
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected DynamicObject(Image image, TypeObject type)
            : base(image, type)
        {
        }

        /// <summary>
        ///     Rotate left object
        /// </summary>
        /// <param name="value">So goc' se quay</param>
        public void RotateLeft(float value)
        {
            Direction -= value;
        }

        /// <summary>
        ///     Rotate right object
        /// </summary>
        /// <param name="value">So goc' se quay</param>
        public void RotateRight(float value)
        {
            Direction += value;
        }

        /// <summary>
        ///     Move forward object
        /// </summary>
        /// <param name="value">so khoang cach di chuyen</param>
        public void MoveForward(float value)
        {
            double rad = Math.PI * Direction / 180;
            Position.X += (float)Math.Sin(rad) * value;
            Position.Y -= (float)Math.Cos(rad) * value;
        }

        /// <summary>
        ///     Move backward object
        /// </summary>
        /// <param name="value">so khoang cach di chuyen</param>
        public void MoveBackward(float value)
        {
            double rad = Math.PI * Direction / 180;
            Position.X -= (float)Math.Sin(rad) * value;
            Position.Y += (float)Math.Cos(rad) * value;
        }
    }
}
