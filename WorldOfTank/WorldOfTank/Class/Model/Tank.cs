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
        /// <summary>
        ///     Gets or sets bullet of this tank
        /// </summary>
        public Bullet Bullet;

        /// <summary>
        ///     Gets or sets move speed of this tank
        /// </summary>
        public float SpeedMove;

        /// <summary>
        ///     Gets or sets rotate speed of this tank
        /// </summary>
        public float SpeedRotate;

        /// <summary>
        ///     Gets or sets fire speed of this tank
        /// </summary>
        public float SpeedFire;

        /// <summary>
        ///     Gets or sets heal of this tank
        /// </summary>
        public float Heal;

        /// <summary>
        ///     Gets or sets instructions of this tank
        /// </summary>
        public List<Instruction> Instructions;

        /// <summary>
        ///     Gets result of last frame
        /// </summary>
        public TypeResult LastResult;

        /// <summary>
        ///     Gets result of new frame
        /// </summary>
        public TypeResult NewResult;

        /// <summary>
        ///     Gets Radius (la do. lon' cua object tinh' tu diem anchor)
        /// </summary>
        public override float Radius
        {
            get
            {
                return this.Size.Height * 35 / 100;
            }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="Image">Image tank</param>
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

        /// <summary>
        ///     List instructions of normal action
        /// </summary>
        public Func<List<Instruction>> ActionNormal = () => new List<Instruction>();

        /// <summary>
        ///     List instructions of "cannot move forward" action
        /// </summary>
        public Func<List<Instruction>> ActionCannotMoveForward = () => new List<Instruction>();

        /// <summary>
        ///     List instructions of "cannot move backward" action
        /// </summary>
        public Func<List<Instruction>> ActionCannotMoveBackward = () => new List<Instruction>();

        /// <summary>
        ///     List instructions of "detected enemy" action
        /// </summary>
        public Func<List<Instruction>> ActionDetected = () => new List<Instruction>();

        /// <summary>
        ///     List instructions of "be attacked" action
        /// </summary>
        public Func<List<Instruction>> ActionBeAttacked = () => new List<Instruction>();

        /// <summary>
        ///     Set instructions in each frame (according to LastResult and NewResult)
        /// </summary>
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

        /// <summary>
        ///     Check if this tank is invalid position
        /// </summary>
        /// <param name="Objects">Objects are battlefield</param>
        /// <returns>True if this tank is invalid position</returns>
        public bool IsInvalidPosition(List<ObjectGame> Objects)
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

        /// <summary>
        ///     Create a copy of this tank
        /// </summary>
        /// <returns>A copy of this tank</returns>
        public override ObjectGame Clone()
        {
            Tank tank = new Tank(this.Image);
            tank.Size = this.Size;
            tank.Bullet = (Bullet)this.Bullet.Clone();
            tank.SpeedMove = this.SpeedMove;
            tank.SpeedRotate = this.SpeedRotate;
            tank.SpeedFire = this.SpeedFire;
            tank.Heal = this.Heal;
            return tank;
        }

        /// <summary>
        ///     Execute some change of object in a frame in battefield
        /// </summary>
        /// <param name="Objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
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
                    if (!this.IsInvalidPosition(Objects))
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
                    if (!this.IsInvalidPosition(Objects))
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
                        Bullet bullet = (Bullet)this.Bullet.Clone();
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
