using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    class Tank : DynamicObject
    {
        public float Damage;
        public float SpeedMove;
        public float SpeedRotate;
        public float SpeedFire;
        public float Heal;
        public List<Instruction> Instructions;

        public override PointF Anchor
        {
            get { return new PointF(this.Size.Width / 2, this.Size.Height / 2); }
        }

        public override PointF[] Edge
        {
            get
            {
                PointF[] edge = new PointF[] {
                    new PointF(-this.Size.Width*30/100, -this.Size.Height*30/100),
                    new PointF(this.Size.Width*30/100, -this.Size.Height*30/100),
                    new PointF(this.Size.Width*30/100, this.Size.Height*45/100),
                    new PointF(-this.Size.Width*30/100, this.Size.Height*45/100),
                };
                return edge;
            }
        }

        public Tank(Image Image)
            : base(Image, TypeObject.Tank)
        {
            this.Damage = -1;
            this.SpeedMove = 1;
            this.SpeedRotate = 1;
            this.SpeedFire = 1;
            this.Heal = 1;
            Instructions = new List<Instruction>();
        }

        public Func<List<Instruction>> ActionNormal = () => new List<Instruction>();
        public Func<List<Instruction>> ActionCannotMove = () => new List<Instruction>();
        public Func<List<Instruction>> ActionDetected = () => new List<Instruction>();

        public void Update()
        {
            if (Instructions.Count == 0) Instructions = ActionNormal();
        }
    }
}
