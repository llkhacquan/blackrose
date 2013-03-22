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
        public float[] BorderDegree;
        public TypeObject Type;

        public ObjectGame(Image Image, TypeObject Type)
        {
            this.Image = Image;
            this.Size = Image.Size;
            this.Position = new PointF(0, 0);
            this.Direction = 0;
            BorderDegree = new float[] { -45, 45, 135, 225 };
            this.Type = Type;
        }

        public bool IsCollided(ObjectGame obj)
        {
            PointF[] pthis = this.BorderPoint();
            PointF[] pobj = obj.BorderPoint();
            for (int i = 0; i < pthis.Length - 1; i++)
                for (int j = 0; j < pobj.Length - 1; j++)
                {
                    if (GraphicsProcessor.LineIntersectionCheck(pthis[i], pthis[i + 1], pobj[j], pobj[j + 1]))
                        return true;
                }
            return false;
        }

        public PointF[] BorderPoint()
        {
            PointF[] pf = new PointF[this.BorderDegree.Length + 1];
            for (int i = 0; i < this.BorderDegree.Length; i++)
            {
                double rad = Math.PI * this.BorderDegree[i] / 180;
                float dis = (float)Math.Abs(this.Size.Height / 2 / Math.Cos(rad));

                rad = Math.PI * (this.BorderDegree[i] - this.Direction) / 180;
                pf[i] = new PointF(
                    (float)Math.Sin(rad) * dis + this.Size.Width / 2 + this.Position.X,
                    (float)Math.Cos(rad) * dis + this.Size.Height / 2 + this.Position.Y);
            }
            pf[pf.Length - 1] = pf[0];
            return pf;
        }

        public virtual void Paint(Graphics gfx)
        {
            Bitmap bmp = new Bitmap(GraphicsProcessor.RotateImage(this.Image, this.Direction), this.Size);
            gfx.DrawImage(bmp, this.Position.X, this.Position.Y);
        }
    }
}
