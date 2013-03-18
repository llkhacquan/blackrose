using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class DynamicObject : ObjectGame
    {
        public float Direction;

        public DynamicObject(Image Image, TypeObject Type)
            : base(Image, Type)
        {
            this.Direction = 0;
        }

        public void RotateLeft(float value)
        {
            Direction -= value;
        }

        public void RotateRight(float value)
        {
            Direction += value;
        }

        public void MoveForward(float value)
        {
            double radian = Math.PI * this.Direction / 180;
            this.Position.X += (float)Math.Sin(radian) * value;
            this.Position.Y -= (float)Math.Cos(radian) * value;
        }

        public void MoveBackward(float value)
        {
            double radian = Math.PI * this.Direction / 180;
            this.Position.X -= (float)Math.Sin(radian) * value;
            this.Position.Y += (float)Math.Cos(radian) * value;
        }
    }
}
