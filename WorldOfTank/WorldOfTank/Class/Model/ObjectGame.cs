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

        public virtual PointF Anchor
        {
            get { return new PointF(0, 0); }
        }

        public virtual PointF[] Edge
        {
            get
            {
                PointF[] edge = new PointF[] {
                    new PointF(0, 0),
                    new PointF(this.Size.Width, 0),
                    new PointF(this.Size.Width, this.Size.Height),
                    new PointF(0, this.Size.Height),
                };
                return edge;
            }
        }

        public float Direction;
        public TypeObject Type;

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
            PointF[] pthis = this.RealEdge();
            PointF[] pobj = obj.RealEdge();
            for (int i = 0; i < pthis.Length - 1; i++)
                for (int j = 0; j < pobj.Length - 1; j++)
                {
                    if (MathProcessor.LineIntersectionCheck(pthis[i], pthis[i + 1], pobj[j], pobj[j + 1]))
                        return true;
                }
            return false;
        }

        public PointF[] RealEdge()
        {
            PointF[] p = new PointF[this.Edge.Length + 1];
            for (int i = 0; i < this.Edge.Length; i++)
            {
                p[i] = MathProcessor.CalPointRotatation(new PointF(0, 0), this.Edge[i], this.Direction);
                p[i].X += this.Position.X;
                p[i].Y += this.Position.Y;
            }
            p[p.Length - 1] = p[0];
            return p;
        }

        public void Paint(Graphics gfx)
        {
            Bitmap bmp = new Bitmap(GraphicsProcessor.RotateImage(this.Image, this.Direction), this.Size);
            gfx.DrawImage(bmp, this.Position.X - this.Anchor.X, this.Position.Y - this.Anchor.Y);
        }
    }
}
