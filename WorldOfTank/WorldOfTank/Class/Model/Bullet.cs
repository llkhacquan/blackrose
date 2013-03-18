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
        public float Speed;

        public Bullet(Image Image)
            : base(Image, TypeObject.Bullet)
        {
            this.Damage = 1;
            this.Speed = 1;
        }
    }
}
