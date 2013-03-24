using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorldOfTank.Class.Components
{
    static class MathProcessor
    {
        public static int CheckCCW(PointF p1, PointF p2, PointF p3)
        {
            float a1 = p2.X - p1.X;
            float b1 = p2.Y - p1.Y;
            float a2 = p3.X - p2.X;
            float b2 = p3.Y - p2.Y;
            float t = a1 * b2 - a2 * b1;
            if (t > 0) return 1;            // Turn right
            else if (t < 0) return -1;      // Turn left
            return 0;                       // Straight
        }

        public static bool LineIntersectionCheck(PointF a1, PointF a2, PointF b1, PointF b2)
        {
            if (CheckCCW(a1, a2, b1) * CheckCCW(a1, a2, b2) != -1) return false;
            if (CheckCCW(b1, b2, a1) * CheckCCW(b1, b2, a2) != -1) return false;
            return true;
        }

        public static float CalPointAngle(PointF anchor, PointF p)
        {
            float x = p.X - anchor.X;
            float y = anchor.Y - p.Y;
            if (y == 0)
                if (x > 0) return 90;
                else return -90;
            float deg = (float)(Math.Atan(x / y) * 180 / Math.PI);
            if (y < 0) deg += 180;
            return deg;
        }

        public static PointF CalPointPosition(PointF anchor, float distance, float angle)
        {
            float rad = (float)Math.PI * angle / 180;
            return new PointF(anchor.X + (float)Math.Sin(rad) * distance, anchor.Y - (float)Math.Cos(rad) * distance);
        }

        public static PointF CalPointRotatation(PointF anchor, PointF p, float angle)
        {
            float distance = (float)Math.Sqrt((p.X - anchor.X) * (p.X - anchor.X) + (p.Y - anchor.Y) * (p.Y - anchor.Y));
            return CalPointPosition(anchor, distance, CalPointAngle(anchor, p) + angle);
        }
    }
}
