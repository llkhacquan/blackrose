using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    abstract class DynamicObject : ObjectGame
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image object</param>
        /// <param name="Type">Type object</param>
        public DynamicObject(Image Image, TypeObject Type)
            : base(Image, Type)
        {
        }

        /// <summary>
        ///     Rotate left object
        /// </summary>
        /// <param name="value">So goc' se quay</param>
        public void RotateLeft(float value)
        {
            this.Direction -= value;
        }

        /// <summary>
        ///     Rotate right object
        /// </summary>
        /// <param name="value">So goc' se quay</param>
        public void RotateRight(float value)
        {
            this.Direction += value;
        }

        /// <summary>
        ///     Move forward object
        /// </summary>
        /// <param name="value">so khoang cach di chuyen</param>
        public void MoveForward(float value)
        {
            double rad = Math.PI * this.Direction / 180;
            this.Position.X += (float)Math.Sin(rad) * value;
            this.Position.Y -= (float)Math.Cos(rad) * value;
        }

        /// <summary>
        ///     Move backward object
        /// </summary>
        /// <param name="value">so khoang cach di chuyen</param>
        public void MoveBackward(float value)
        {
            double rad = Math.PI * this.Direction / 180;
            this.Position.X -= (float)Math.Sin(rad) * value;
            this.Position.Y += (float)Math.Cos(rad) * value;
        }
    }
}
