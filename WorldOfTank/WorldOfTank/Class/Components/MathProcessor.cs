using System;
using System.Drawing;

namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// This class is used to calculate some geometric issue
    /// </summary>
    public static class MathProcessor
    {
        /// <summary>
        /// Determine the relative direction of vector II to vector I
        ///     vector I: p1-->p2
        ///     vector II: p2-->p3

        /// </summary>
        /// <param name="p1">1st point</param>
        /// <param name="p2">2nd point</param>
        /// <param name="p3">3rd point</param>
        /// <returns>1 if turn right, -1 if turn left, 0 if straight</returns>
        public static int CounterClockWise(PointF p1, PointF p2, PointF p3)
        {
            float a1 = p2.X - p1.X;
            float b1 = p2.Y - p1.Y;
            float a2 = p3.X - p2.X;
            float b2 = p3.Y - p2.Y;
            float t = a1 * b2 - a2 * b1;
            if (t > 0) return 1;            // Turn right
            if (t < 0) return -1;           // Turn left
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
        ///     Calculate the angle between input vector (determined by 2 points) and the vector unit (North direction)
        ///     Clockwise is positive
        /// </summary>
        /// <param name="root">root of the vector</param>
        /// <param name="head">head of the vector</param>
        /// <returns>angle in degree</returns>
        public static float CalPointAngle(PointF root, PointF head)
        {
            const float epsilon = 1e-6f;
            float x = head.X - root.X;
            float y = root.Y - head.Y;
            if (Math.Abs(y) < epsilon)
                if (x > 0) return 90;
                else return -90;
            var deg = (float)(Math.Atan(x / y) * 180 / Math.PI);
            if (y < 0) deg += 180;
            return deg;
        }


        /// <summary>
        ///     Given vector's root, magnitude, directions (relative to North (0 degree))
        ///     calculate the head's coordinates of the vector
        /// </summary>
        /// <param name="root">root of vector</param>
        /// <param name="magnitude">magnitude of vector</param>
        /// <param name="angle">vector's direction, determined by the angle between vector and North direction</param>
        /// <returns>head of the vector</returns>
        public static PointF CalPointPosition(PointF root, float magnitude, float angle)
        {
            float rad = (float)Math.PI * angle / 180;
            return new PointF(root.X + (float)Math.Sin(rad) * magnitude, root.Y - (float)Math.Cos(rad) * magnitude);
        }

        /// <summary>
        /// Calculate distance between point 1 and point 2
        /// </summary>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns></returns>
        public static float CalDistance(PointF p1, PointF p2)
        {
            float d = (p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y);
            return (float)Math.Sqrt(d);
        }

        /// <summary>
        /// Calculate different angle of anotherAngle with rootAngle
        /// </summary>
        /// <param name="referenceAngle">Reference angle</param>
        /// <param name="calculatedAngle">The angle need calculated</param>
        /// <returns>The difference degree (smaller than 180 and greater than -180)</returns>
        public static float CalDifferentAngle(float referenceAngle, float calculatedAngle)
        {
            float difference = calculatedAngle - referenceAngle;
            difference -= 360 * (int)(difference / 360);
            // -180 < difference < 180
            if (difference > 180) difference -= 360;
            else if (difference < -180) difference += 360;
            return difference;
        }

    }
}
