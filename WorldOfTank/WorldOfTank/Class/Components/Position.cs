using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorldOfTank.Class.Components
{
    class Position
    {
        public float X;
        public float Y;

        public Position(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point GetPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
