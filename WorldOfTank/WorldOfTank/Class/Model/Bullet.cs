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

        public Bullet Clone()
        {
            Bullet bullet = new Bullet(this.Image);
            bullet.Size = this.Size;
            bullet.Damage = this.Damage;
            bullet.SpeedMove = this.SpeedMove;
            return bullet;
        }

        public override TypeResult NextFrame(List<ObjectGame> Objects)
        {
            this.MoveForward(this.SpeedMove);
            TypeResult result = TypeResult.Nothing;
            for (int i = 0; i < Objects.Count; i++)
                if (Objects[i] != this && this.IsCollided(Objects[i]))
                {
                    if (Objects[i].Type == TypeObject.Tank)
                    {
                        Tank tank = (Tank)Objects[i];
                        tank.Heal -= this.Damage;
                        //tank.NewResult = TypeResult.BeAttacked;
                        if (tank.Heal < 0) tank.NewResult = TypeResult.BeDestroyed;
                        result = TypeResult.BeDestroyed;
                    }
                    else if (Objects[i].Type == TypeObject.Wall) result = TypeResult.BeDestroyed;
                }
            return result;
        }
    }
}
