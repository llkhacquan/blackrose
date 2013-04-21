using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Bullet : DynamicObject
    {
        /// <summary>
        ///     Damage of this bullet
        /// </summary>
        public float Damage;

        /// <summary>
        ///     Move speed of this bullet
        /// </summary>
        public float SpeedMove;

        /// <summary>
        ///     Gets Radius (la do. lon' cua object tinh' tu diem anchor)
        /// </summary>
        public override float Radius
        {
            get
            {
                return this.Size.Height * 30 / 100;
            }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image bullet</param>
        public Bullet(Image Image)
            : base(Image, TypeObject.Bullet)
        {
            this.Damage = 1;
            this.SpeedMove = 1;
        }

        /// <summary>
        ///     Create a copy of this bullet
        /// </summary>
        /// <returns>A copy of this bullet</returns>
        public override ObjectGame Clone()
        {
            Bullet bullet = new Bullet(this.Image) { Size = this.Size, Damage = this.Damage, SpeedMove = this.SpeedMove };
            return bullet;
        }

        /// <summary>
        ///     Execute some change of this bullet in a frame in battefield
        /// </summary>
        /// <param name="Objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
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
                        tank.NewResult = TypeResult.BeAttacked;
                        if (tank.Heal < 0) tank.NewResult = TypeResult.BeDestroyed;
                        result = TypeResult.BeDestroyed;
                    }
                    else if (Objects[i].Type == TypeObject.Wall) result = TypeResult.BeDestroyed;
                }
            return result;
        }
    }
}
