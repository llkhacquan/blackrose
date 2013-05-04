using System;
using System.Collections.Generic;
using System.Drawing;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    [Serializable]
    public class Tank : DynamicObject
    {

        public float RadaRange;

        public float RadaAngle;

        public float DamageMin;

        public float DamageMax;

        private float _damageCur;

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
        ///     Gets or sets maximum heal of this tank
        /// </summary>
        public float HealMax;

        /// <summary>
        ///     Gets or sets current heal of this tank
        /// </summary>
        public float HealCur;

        public string Name;

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
        ///     List instructions of normal action
        /// </summary>
        public List<Instruction> ActionNormal;

        /// <summary>
        ///     List instructions of "cannot move forward" action
        /// </summary>
        public List<Instruction> ActionCannotMoveForward;

        /// <summary>
        ///     List instructions of "cannot move backward" action
        /// </summary>
        public List<Instruction> ActionCannotMoveBackward;

        /// <summary>
        ///     List instructions of "detected enemy" action
        /// </summary>
        public List<Instruction> ActionDetected;

        /// <summary>
        ///     List instructions of "be attacked" action
        /// </summary>
        public List<Instruction> ActionBeAttacked;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="image">Image tank</param>
        public Tank(Image image)
            : base(image, TypeObject.Tank)
        {
            Radius = Image.Width * 40 / 100;

            RadaRange = 300;
            RadaAngle = 20;

            DamageMin = 10;
            DamageMax = 20;
            _damageCur = 0;

            SpeedMove = 3;
            SpeedRotate = 5;
            SpeedFire = 1;
            HealMax = 100;
            HealCur = 100;

            Name = "NewTank";

            Instructions = new List<Instruction>();
            LastResult = TypeResult.Normal;
            NewResult = TypeResult.Normal;

            ActionNormal = new List<Instruction>();
            ActionCannotMoveForward = new List<Instruction>();
            ActionCannotMoveBackward = new List<Instruction>();
            ActionDetected = new List<Instruction>();
            ActionBeAttacked = new List<Instruction>();
        }

        /// <summary>
        ///     Set instructions in each frame (according to LastResult and NewResult)
        /// </summary>
        public void SetInstructions()
        {
            if (Instructions.Count == 0 || LastResult != NewResult)
            {
                if (NewResult == TypeResult.Normal) Instructions = new List<Instruction>(ActionNormal);
                else if (NewResult == TypeResult.CannotMoveForward) Instructions = new List<Instruction>(ActionCannotMoveForward);
                else if (NewResult == TypeResult.CannotMoveBackward) Instructions = new List<Instruction>(ActionCannotMoveBackward);
                else if (NewResult == TypeResult.Detected) Instructions = new List<Instruction>(ActionDetected);
                else if (NewResult == TypeResult.BeAttacked) Instructions = new List<Instruction>(ActionBeAttacked);
                LastResult = NewResult;
            }
        }

        /// <summary>
        ///     Check if this tank is invalid position
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>True if this tank is invalid position</returns>
        public bool IsInvalidPosition(List<ObjectGame> objects)
        {
            foreach (ObjectGame obj in objects)
            {
                if (obj != this && (obj.Type == TypeObject.Tank || obj.Type == TypeObject.Wall) && IsCollided(obj))
                    return false;
            }
            return true;
        }

        public Tank DetectedEnemy(List<ObjectGame> objects)
        {
            foreach (ObjectGame obj in objects)
                if (obj != this && obj.Type == TypeObject.Tank)
                {
                    float distance = MathProcessor.CalDistance(Position, obj.Position);
                    float direction = MathProcessor.CalPointAngle(Position, obj.Position);
                    float differentAngle = MathProcessor.CalDifferentAngle(Direction, direction);
                    if (distance < RadaRange && Math.Abs(differentAngle) < RadaAngle / 2) return (Tank)obj;
                }
            return null;
        }

        /// <summary>
        ///     Execute some change of object in a frame in battefield
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            const float epsilon = 1e-6f;
            if (NewResult == TypeResult.BeDestroyed) return TypeResult.BeDestroyed;
            if (DetectedEnemy(objects) != null) NewResult = TypeResult.Detected;
            SetInstructions();
            PointF p = Position;
            if (Instructions.Count > 0)
            {
                if (Instructions[0].Type == TypeInstruction.MoveForward)
                {
                    float value = Math.Min(Instructions[0].Value, SpeedMove);
                    Instructions[0].Value -= value;
                    MoveForward(value);
                    if (!IsInvalidPosition(objects))
                    {
                        Position = p;
                        NewResult = TypeResult.CannotMoveForward;
                    }
                }
                else if (Instructions[0].Type == TypeInstruction.MoveBackward)
                {
                    float value = Math.Min(Instructions[0].Value, SpeedMove);
                    Instructions[0].Value -= value;
                    MoveBackward(value);
                    if (!IsInvalidPosition(objects))
                    {
                        Position = p;
                        NewResult = TypeResult.CannotMoveBackward;
                    }
                }
                else if (Instructions[0].Type == TypeInstruction.RotateRight)
                {
                    float value = Math.Min(Instructions[0].Value, SpeedRotate);
                    Instructions[0].Value -= value;
                    RotateRight(value);
                }
                else if (Instructions[0].Type == TypeInstruction.RotateLeft)
                {
                    float value = Math.Min(Instructions[0].Value, SpeedRotate);
                    Instructions[0].Value -= value;
                    RotateLeft(value);
                }
                else if (Instructions[0].Type == TypeInstruction.Fire)
                {
                    float value = Math.Min(Instructions[0].Value, SpeedFire);
                    Instructions[0].Value -= value;
                    _damageCur += value;
                    if (Math.Abs(Instructions[0].Value) < epsilon)
                    {
                        Bullet bullet = new Bullet(Properties.Resources.Bullet_A)
                                            {
                                                Position = MathProcessor.CalPointPosition(Position, Image.Width / 2, Direction),
                                                Direction = Direction,
                                                Damage = _damageCur
                                            };
                        _damageCur = 0;
                        objects.Add(bullet);
                    }
                }

                if (Math.Abs(Instructions[0].Value) < epsilon) Instructions.RemoveAt(0);
            }
            if (Instructions.Count == 0) NewResult = TypeResult.Normal;
            return TypeResult.Nothing;
        }

        public override void Paint(Graphics gfx)
        {
            base.Paint(gfx);
            gfx.FillPie(
                new SolidBrush(Color.FromArgb(32, 255, 255, 0)),
                Position.X - RadaRange, Position.Y - RadaRange,
                RadaRange * 2, RadaRange * 2,
                Direction - 90 - RadaAngle / 2, RadaAngle);
        }
    }
}
