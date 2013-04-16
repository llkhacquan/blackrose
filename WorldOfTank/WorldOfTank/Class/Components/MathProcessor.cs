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
        ///     Determine the relative direction of vector II to vector I
        ///         vector i: p1-->p2
        ///         vector ii: p2-->p3
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
        ///     Check if 2 segments AB and CD intersect
        /// </summary>
        /// <param name="pA">Point A</param>
        /// <param name="pB">Point B</param>
        /// <param name="pC">Point C</param>
        /// <param name="pD">Point D</param>
        /// <returns></returns>
        public static bool LineIntersectionCheck(PointF pA, PointF pB, PointF pC, PointF pD)
        {
            if (CounterClockWise(pA, pB, pC) * CounterClockWise(pA, pB, pD) != -1) return false;
            if (CounterClockWise(pC, pD, pA) * CounterClockWise(pC, pD, pB) != -1) return false;
            return true;
        }


        /// <summary>
        ///     Calculate the angle between input vector (determined by 2 points) and the j (0,1) vector unit
        ///     Clockwise is positive
        /// </summary>
        /// <param name="root">root of the vector</param>
        /// <param name="head">head of the vector</param>
        /// <returns>angle in degre</returns>
        public static float CalPointAngle(PointF root, PointF head)
        {
            float x = head.X - root.X;
            float y = root.Y - head.Y;
            if (y == 0)
                if (x > 0) return 90;
                else return -90;
            float deg = (float)(Math.Atan(x / y) * 180 / Math.PI);
            if (y < 0) deg += 180;
            return deg;
        }


        /// <summary>
        ///     Given vector's root, magnitude, directions (relative to North (0 degre))
        ///     calculate the head's coordinates of the vector
        /// </summary>
        /// <param name="root">goc' vector</param>
        /// <param name="magnitude">do dai vector</param>
        /// <param name="angle">huong' vector</param>
        /// <returns>head of the vector</returns>
        public static PointF CalPointPosition(PointF root, float magnitude, float angle)
        {
            float rad = (float)Math.PI * angle / 180;
            return new PointF(root.X + (float)Math.Sin(rad) * magnitude, root.Y - (float)Math.Cos(rad) * magnitude);
        }
    }
}
