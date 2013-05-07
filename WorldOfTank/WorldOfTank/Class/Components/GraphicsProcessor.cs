using System.Drawing;
using System.Drawing.Imaging;

namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// This class includes some static method to handle some work with image
    /// </summary>
    public static class GraphicsProcessor
    {
        /// <summary>
        ///     Rotate image (rotative center is the center of the image) (0 degree is North, clockwise is positive)
        ///
        /// </summary>
        /// <param name="img">image need to be rotated</param>
        /// <param name="angle">rotative angle in degree</param>
        /// <returns>result image</returns>
        public static Bitmap RotateImage(Image img, float angle)
        {
            var returnBitmap = new Bitmap(img.Width, img.Height + 1);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)img.Width / 2, (float)img.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)img.Width / 2, -(float)img.Height / 2);
            g.DrawImage(img, img.Width / 2 - img.Height / 2, img.Height / 2 - img.Width / 2, img.Height, img.Width);
            g.Dispose();
            return returnBitmap;
        }

        /// <summary>
        ///     make image blur
        /// </summary>
        /// <param name="value">blur value (0.0 -> 1.0)</param>
        /// <returns>images attributes</returns>
        public static ImageAttributes SemiTransparent(float value)
        {
            var img = new ImageAttributes();
            float[][] matrixItems = { 
                new[] {1f, 0, 0, 0, 0},
                new[] {0, 1f, 0, 0, 0},
                new[] {0, 0, 1f, 0, 0},
                new[] {0, 0, 0, value, 0}, 
                new[] {0, 0, 0, 0, 1f}};
            var colorMatrix = new ColorMatrix(matrixItems);
            img.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            return img;
        }
    }
}
