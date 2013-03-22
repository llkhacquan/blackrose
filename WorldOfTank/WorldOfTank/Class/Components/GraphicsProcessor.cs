using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace WorldOfTank.Class.Components
{
    static class GraphicsProcessor
    {
        public static Bitmap RotateImage(Image img, float angle)
        {
            Bitmap returnBitmap = new Bitmap(img.Width, img.Height + 1);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
            g.DrawImage(img, img.Width / 2 - img.Height / 2, img.Height / 2 - img.Width / 2, img.Height, img.Width);

            return returnBitmap;
        }

        public static ImageAttributes SemiTransparent(float value)
        {
            ImageAttributes img = new ImageAttributes();
            float[][] matrixItems = { 
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, value, 0}, 
                new float[] {0, 0, 0, 0, 1}};
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            img.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            return img;
        }

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
    }
}
