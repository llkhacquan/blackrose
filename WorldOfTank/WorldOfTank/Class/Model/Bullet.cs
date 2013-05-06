using System;
using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    [Serializable]
    public class Bullet : DynamicObject
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
        ///     Constructor
        /// </summary>
        /// <param name="image">Image bullet</param>
        public Bullet(Image image)
            : base(image, TypeObject.Bullet)
        {
            Radius = 0.3f * Image.Width;
            SpeedMove = 8;
        }

        /// <summary>
        ///     Execute some change of this bullet in a frame in battefield
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            MoveForward(SpeedMove);
            var result = TypeResult.Nothing;
            foreach (ObjectGame obj in objects)
                if (obj != this && IsCollided(obj))
                {
                    if (obj.Type == TypeObject.Tank)
                    {
                        var tank = (Tank)obj;
                        tank.HealCur -= Damage;
                        tank.NewResult = TypeResult.BeAttacked;
                        tank.EnemyBullet = this;
                        if (tank.HealCur < 0) tank.NewResult = TypeResult.BeDestroyed;
                        result = TypeResult.BeDestroyed;
                    }
                    else if (obj.Type == TypeObject.Wall) result = TypeResult.BeDestroyed;
                }
            return result;
        }
    }
}
