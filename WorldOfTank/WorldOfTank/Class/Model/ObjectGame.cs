using System;
using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handle all objects in the game
    /// </summary>
    [Serializable]
    public abstract class ObjectGame : IDisposable
    {
        /// <summary>
        ///     Gets or sets Image
        /// </summary>
        public Image Image;

        /// <summary>
        ///     Gets or sets Position in Battlefield
        /// </summary>
        public PointF Position;

        /// <summary>
        ///     Gets or sets Direction (0 degree is North, clockwise is positive)
        /// </summary>
        public float Direction;

        /// <summary>
        ///     Gets Type
        /// </summary>
        public TypeObject Type;

        /// <summary>
        ///     Gets Radius. Here we consider an object as a circle with center is Image center
        /// </summary>
        public float Radius;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly")]
        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected ObjectGame(Image image, TypeObject type)
        {
            Image = image;
            Position = new PointF(0, 0);
            Direction = 0;
            Type = type;
            Radius = 0.5f * Image.Width;
        }

        /// <summary>
        ///     Check if the object is collided with another object    
        /// </summary>
        /// <param name="obj">another object need to check collision</param>
        /// <returns>True if collided, else False</returns>
        public bool IsCollided(ObjectGame obj)
        {
            float distance = (Position.X - obj.Position.X) * (Position.X - obj.Position.X) +
                             (Position.Y - obj.Position.Y) * (Position.Y - obj.Position.Y);
            if (Math.Sqrt(distance) < Radius + obj.Radius) return true;
            return false;
        }

        /// <summary>
        ///     Paint in graphics
        /// </summary>
        /// <param name="graphics">Where it is painted</param>
        public virtual void Paint(Graphics graphics)
        {
            Bitmap bmp = GraphicsProcessor.RotateImage(Image, Direction);
            graphics.DrawImage(bmp, Position.X - 0.5f * Image.Width, Position.Y - 0.5f * Image.Height);
            bmp.Dispose();

        }

        /// <summary>
        ///     Execute some change of object in a frame in battlefield
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public abstract TypeResult NextFrame(List<ObjectGame> objects);
    }
}
