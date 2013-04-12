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
        /// <summary>
        ///     Quay anh (tam o vi tri chinh giua anh) (0 degree is North, clockwise is positive)
        /// </summary>
        /// <param name="img">anh can` quay</param>
        /// <param name="angle">so goc quay</param>
        /// <returns>anh sau khi quay</returns>
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

        /// <summary>
        ///     Tao. do. mo` cho anh? khi ve~
        /// </summary>
        /// <param name="value">gia tri do. mo` (0.0 -> 1.0)</param>
        /// <returns>thuoc tinh' mo` cua anh?</returns>
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
