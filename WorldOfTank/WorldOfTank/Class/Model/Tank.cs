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
        public Bullet Bullet;
        public float SpeedMove;
        public float SpeedRotate;
        public float SpeedFire;
        public float Heal;
        public List<Instruction> Instructions;
        public TypeResult LastResult;
        public TypeResult NewResult;

        public override float Radius
        {
            get
            {
                return this.Size.Height * 35 / 100;
            }
        }

        public Tank(Image Image)
            : base(Image, TypeObject.Tank)
        {
            this.Bullet = new Bullet(WorldOfTank.Properties.Resources.Bullet_D);
            this.Bullet.Size = new Size(20, 20);
            this.Bullet.Damage = 10;
            this.Bullet.SpeedMove = 8;

            this.SpeedMove = 1;
            this.SpeedRotate = 1;
            this.SpeedFire = 1;
            this.Heal = 1;
            Instructions = new List<Instruction>();
            LastResult = TypeResult.Normal;
            NewResult = TypeResult.Normal;
        }

        public Func<List<Instruction>> ActionNormal = () => new List<Instruction>();
        public Func<List<Instruction>> ActionCannotMoveForward = () => new List<Instruction>();
        public Func<List<Instruction>> ActionCannotMoveBackward = () => new List<Instruction>();
        public Func<List<Instruction>> ActionDetected = () => new List<Instruction>();
        public Func<List<Instruction>> ActionBeAttacked = () => new List<Instruction>();

        public void SetInstructions()
        {
            if (Instructions.Count == 0 || LastResult != NewResult)
            {
                if (NewResult == TypeResult.Normal) Instructions = ActionNormal();
                else if (NewResult == TypeResult.CannotMoveForward) Instructions = ActionCannotMoveForward();
                else if (NewResult == TypeResult.CannotMoveBackward) Instructions = ActionCannotMoveBackward();
                else if (NewResult == TypeResult.Detected) Instructions = ActionDetected();
                else if (NewResult == TypeResult.BeAttacked) Instructions = ActionBeAttacked();
                LastResult = NewResult;
            }
        }

        public bool IsCollidedPosition(List<ObjectGame> Objects)
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
            if (NewResult == TypeResult.BeDestroyed) return TypeResult.BeDestroyed;
            this.SetInstructions();
            PointF p = this.Position;
            if (this.Instructions.Count > 0)
            {
                if (this.Instructions[0].Type == TypeInstruction.MoveForward)
                {
                    float value = Math.Min(this.Instructions[0].Parameter, this.SpeedMove);
                    this.Instructions[0].Parameter -= value;
                    this.MoveForward(value);
                    if (!this.IsCollidedPosition(Objects))
                    {
                        this.Position = p;
                        NewResult = TypeResult.CannotMoveForward;
                    }
                }
                else if (this.Instructions[0].Type == TypeInstruction.MoveBackward)
                {
                    float value = Math.Min(this.Instructions[0].Parameter, this.SpeedMove);
                    this.Instructions[0].Parameter -= value;
                    this.MoveBackward(value);
                    if (!this.IsCollidedPosition(Objects))
                    {
                        this.Position = p;
                        NewResult = TypeResult.CannotMoveBackward;
                    }
                }
                else if (this.Instructions[0].Type == TypeInstruction.RotateRight)
                {
                    float value = Math.Min(this.Instructions[0].Parameter, this.SpeedRotate);
                    this.Instructions[0].Parameter -= value;
                    this.RotateRight(value);
                }
                else if (this.Instructions[0].Type == TypeInstruction.RotateLeft)
                {
                    float value = Math.Min(this.Instructions[0].Parameter, this.SpeedRotate);
                    this.Instructions[0].Parameter -= value;
                    this.RotateLeft(value);
                }
                else if (this.Instructions[0].Type == TypeInstruction.Fire)
                {
                    float value = Math.Min(this.Instructions[0].Parameter, this.SpeedFire);
                    this.Instructions[0].Parameter -= value;
                    if (Instructions[0].Parameter == 0)
                    {
                        Bullet bullet = this.Bullet.Clone();
                        bullet.Position = MathProcessor.CalPointPosition(this.Position, this.Size.Height / 2, this.Direction);
                        bullet.Direction = this.Direction;
                        Objects.Add(bullet);
                    }
                }

                if (Instructions[0].Parameter == 0) this.Instructions.RemoveAt(0);
            }
            if (Instructions.Count == 0) NewResult = TypeResult.Normal;
            return TypeResult.Nothing;
        }
    }
}
