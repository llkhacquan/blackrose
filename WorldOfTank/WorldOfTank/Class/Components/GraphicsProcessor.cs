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
        public static Bitmap RotateImage(Image b, float angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height + 1);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, b.Width / 2 - b.Height / 2, b.Height / 2 - b.Width / 2, b.Height, b.Width);

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
    }
}
