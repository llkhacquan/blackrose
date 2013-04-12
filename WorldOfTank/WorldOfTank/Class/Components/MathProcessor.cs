using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WorldOfTank.Class.Components
{
    static class MathProcessor
    {
        /// <summary>
        ///     Kiem tra vector p2->p3 nam ben trai hay phai so voi vector p1->p2
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second point</param>
        /// <param name="p3">Third point</param>
        /// <returns>1 if turn right, -1 if turn left, 0 if straight</returns>
        public static int CounterClockWise(PointF p1, PointF p2, PointF p3)
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

        /// <summary>
        ///     Kiem tra xem 2 doan. thang co cat nhau hay khong
        /// </summary>
        /// <param name="a1">First point of first line</param>
        /// <param name="a2">Second point of first line</param>
        /// <param name="b1">First point of second line</param>
        /// <param name="b2">Second point of second line</param>
        /// <returns></returns>
        public static bool LineIntersectionCheck(PointF a1, PointF a2, PointF b1, PointF b2)
        {
            if (CounterClockWise(a1, a2, b1) * CounterClockWise(a1, a2, b2) != -1) return false;
            if (CounterClockWise(b1, b2, a1) * CounterClockWise(b1, b2, a2) != -1) return false;
            return true;
        }


        /// <summary>
        ///     Tinh huong' vector anchor->p (0 degree is North, clockwise is positive)
        /// </summary>
        /// <param name="anchor">goc' vector</param>
        /// <param name="p">ngon. vector</param>
        /// <returns>so' goc'</returns>
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


        /// <summary>
        ///     Tinh diem ngon. vector biet goc' vector, do dai vector va huong vector (0 degree is North, clockwise is positive) 
        /// </summary>
        /// <param name="anchor">goc' vector</param>
        /// <param name="distance">do dai vector</param>
        /// <param name="angle">huong' vector</param>
        /// <returns>diem ngon. vector</returns>
        public static PointF CalPointPosition(PointF anchor, float distance, float angle)
        {
            float rad = (float)Math.PI * angle / 180;
            return new PointF(anchor.X + (float)Math.Sin(rad) * distance, anchor.Y - (float)Math.Cos(rad) * distance);
        }
    }
}
