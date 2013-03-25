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
        public Image Image;
        public Size Size;
        public PointF Position;
        public float Direction;
        public TypeObject Type;

        public PointF Anchor
        {
            get { return new PointF(this.Size.Height / 2, this.Size.Width / 2); }
        }

        public virtual float Radius
        {
            get { return this.Size.Height / 2; }
        }

        public ObjectGame(Image Image, TypeObject Type)
        {
            this.Image = Image;
            this.Size = Image.Size;
            this.Position = new PointF(0, 0);
            this.Direction = 0;
            this.Type = Type;
        }

        public bool IsCollided(ObjectGame obj)
        {
            float distance = (this.Position.X - obj.Position.X) * (this.Position.X - obj.Position.X) +
                             (this.Position.Y - obj.Position.Y) * (this.Position.Y - obj.Position.Y);
            if (Math.Sqrt(distance) < this.Radius + obj.Radius) return true;
            return false;
        }

        public void Paint(Graphics gfx)
        {
            Bitmap bmp = new Bitmap(GraphicsProcessor.RotateImage(this.Image, this.Direction), this.Size);
            gfx.DrawImage(bmp, this.Position.X - this.Anchor.X, this.Position.Y - this.Anchor.Y);
        }

        public abstract TypeResult NextFrame(List<ObjectGame> Objects);
    }
}
