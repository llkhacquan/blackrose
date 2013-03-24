using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Bullet : DynamicObject
    {
        public float Damage;
        public float SpeedMove;

        public override PointF[] Edge
        {
            get
            {
                PointF[] edge = new PointF[] {
                    new PointF(-this.Size.Width*30/100, -this.Size.Height*50/100),
                    new PointF(this.Size.Width*30/100, -this.Size.Height*50/100),
                    new PointF(this.Size.Width*15/100, this.Size.Height*50/100),
                    new PointF(-this.Size.Width*15/100, this.Size.Height*50/100),
                };
                return edge;
            }
        }

        public Bullet(Image Image)
            : base(Image, TypeObject.Bullet)
        {
            this.Damage = 1;
            this.SpeedMove = 1;
        }

        public bool IsValidPosition(List<ObjectGame> Objects)
        {
            for (int i = 0; i < Objects.Count; i++)
                if ((Objects[i] != this) &&
                    (Objects[i].Type == TypeObject.Tank || Objects[i].Type == TypeObject.Wall) &&
                    (this.IsCollided(Objects[i])))
                {
                    return false;
                }
            return true;
        }

        public override TypeResult NextFrame(List<ObjectGame> Objects)
        {
            this.MoveForward(this.SpeedMove);
            if (!this.IsValidPosition(Objects))
            {
                Objects.Remove(this);
                return TypeResult.BeDestroyed;
            }
            return TypeResult.Nothing;
        }
    }
}
