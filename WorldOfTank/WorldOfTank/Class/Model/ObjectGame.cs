using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    abstract class ObjectGame
    {
        /// <summary>
        ///     Gets or sets Image
        /// </summary>
        public Image Image;

        /// <summary>
        ///     Gets or sets Size
        /// </summary>
        public Size Size;

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
        ///     Gets Anchor
        ///     Anchor is a point in object's image, associate to object's position in the battlefield
        ///     Anchor point here is the center point of the image
        /// </summary>
        public PointF Anchor
        {
            get { return new PointF(this.Size.Height / 2, this.Size.Width / 2); }
        }

        /// <summary>
        ///     Gets Radius. Here we consider an object as a circle with center is the Anchor point
        /// </summary>
        public virtual float Radius
        {
            get { return this.Size.Height / 2; }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image object</param>
        /// <param name="Type">Type object</param>
        public ObjectGame(Image Image, TypeObject Type)
        {
            this.Image = Image;
            this.Size = Image.Size;
            this.Position = new PointF(0, 0);
            this.Direction = 0;
            this.Type = Type;
        }

        /// <summary>
        ///     Check if the object is collided with another object    
        /// </summary>
        /// <param name="obj">another object need to check collision</param>
        /// <returns>True if collided, else False</returns>
        public bool IsCollided(ObjectGame obj)
        {
            float distance = (this.Position.X - obj.Position.X) * (this.Position.X - obj.Position.X) +
                             (this.Position.Y - obj.Position.Y) * (this.Position.Y - obj.Position.Y);
            if (Math.Sqrt(distance) < this.Radius + obj.Radius) return true;
            return false;
        }

        /// <summary>
        ///     Paint in gfx
        /// </summary>
        /// <param name="gfx">Where it is painted</param>
        public void Paint(Graphics gfx)
        {
            Bitmap bmp = new Bitmap(GraphicsProcessor.RotateImage(this.Image, this.Direction), this.Size);
            gfx.DrawImage(bmp, this.Position.X - this.Anchor.X, this.Position.Y - this.Anchor.Y);
        }

        /// <summary>
        ///     Create a copy of this    
        /// </summary>
        /// <returns>A copy of this</returns>
        public abstract ObjectGame Clone();

        /// <summary>
        ///     Execute some change of object in a frame in battefield
        /// </summary>
        /// <param name="Objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public abstract TypeResult NextFrame(List<ObjectGame> Objects);
    }
}
