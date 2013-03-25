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

        public override float Radius
        {
            get
            {
                return this.Size.Height * 30 / 100;
            }
        }

        public Bullet(Image Image)
            : base(Image, TypeObject.Bullet)
        {
            this.Damage = 1;
            this.SpeedMove = 1;
        }

        public override TypeResult NextFrame(List<ObjectGame> Objects)
        {
            this.MoveForward(this.SpeedMove);
            TypeResult result = TypeResult.Nothing;
            for (int i = 0; i < Objects.Count; i++)
                if ((Objects[i] != this) &&
                    (Objects[i].Type == TypeObject.Tank || Objects[i].Type == TypeObject.Wall) &&
                    (this.IsCollided(Objects[i])))
                {
                    result = TypeResult.BeDestroyed;
                }
            if (result == TypeResult.BeDestroyed) Objects.Remove(this);
            return result;
        }
    }
}
