using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WorldOfTank.Class.Components;

namespace WorldOfTank.Class.Model
{
    /// <summary>
    /// This class handles the tank object
    /// </summary>
    [Serializable]
    public class Tank : DynamicObject
    {
        public float RadaRange;
        public float RadaAngle;
        public Color RadaColor;

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
        public Tank EnemyTank;
        public Bullet EnemyBullet;

        public Instruction Instruction;

        /// <summary>
        ///     Gets or sets instructions of this tank
        /// </summary>
        public List<Instruction> ListInstructions;

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
        ///     Constructor with Image of the tank
        /// </summary>
        /// <param name="image">Image tank</param>
        public Tank(Image image)
            : base(image, TypeObject.Tank)
        {
            Radius = 0.4f * Image.Width;

            RadaRange = 300;
            RadaAngle = 20;
            RadaColor = Color.FromArgb(31, 255, 255, 255);

            DamageMin = 10;
            DamageMax = 20;
            _damageCur = 0;

            SpeedMove = 3;
            SpeedRotate = 5;
            SpeedFire = 1;
            HealMax = 100;
            HealCur = 100;

            Name = "NewTank";

            ListInstructions = new List<Instruction>();
            LastResult = TypeResult.Normal;
            NewResult = TypeResult.Normal;

            ActionNormal = new List<Instruction>();
            ActionCannotMoveForward = new List<Instruction>();
            ActionCannotMoveBackward = new List<Instruction>();
            ActionDetected = new List<Instruction>();
            ActionBeAttacked = new List<Instruction>();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image">Image object</param>
        /// <param name="type">Type object</param>
        protected Tank(Image image, TypeObject type)
            : base(image, type)
        {
            
        }

        /// <summary>
        ///     Set instructions in each frame (according to LastResult and NewResult)
        /// </summary>
        public void SetListInstructions()
        {
            if (ActionCannotMoveForward.Count == 0) ActionCannotMoveForward = ActionNormal;
            if (ActionCannotMoveBackward.Count == 0) ActionCannotMoveBackward = ActionNormal;
            if (ActionDetected.Count == 0) ActionDetected = ActionNormal;
            if (ActionBeAttacked.Count == 0) ActionBeAttacked = ActionNormal;

            if (ListInstructions.Count == 0 || LastResult != NewResult)
            {
                Instruction = null;
                _damageCur = 0;
                switch (NewResult)
                {
                    case TypeResult.Normal:
                        ListInstructions = new List<Instruction>(ActionNormal);
                        break;
                    case TypeResult.CannotMoveForward:
                        ListInstructions = new List<Instruction>(ActionCannotMoveForward);
                        break;
                    case TypeResult.CannotMoveBackward:
                        ListInstructions = new List<Instruction>(ActionCannotMoveBackward);
                        break;
                    case TypeResult.Detected:
                        ListInstructions = new List<Instruction>(ActionDetected);
                        break;
                    case TypeResult.BeAttacked:
                        ListInstructions = new List<Instruction>(ActionBeAttacked);
                        break;
                    default:
                        break;
                }
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
            return objects.Any(obj => obj != this && (obj.Type == TypeObject.Tank || obj.Type == TypeObject.Wall) && IsCollided(obj));
        }

        public void DetectedEnemy(List<ObjectGame> objects)
        {
            foreach (ObjectGame obj in objects)
                if (obj != this && obj.Type == TypeObject.Tank)
                {
                    float distance = MathProcessor.CalDistance(Position, obj.Position);
                    float direction = MathProcessor.CalPointAngle(Position, obj.Position);
                    float differentAngle = MathProcessor.CalDifferentAngle(Direction, direction);
                    if (distance < RadaRange && Math.Abs(differentAngle) < RadaAngle / 2)
                    {
                        EnemyTank = (Tank)obj;
                        break;
                    }
                }
        }

        public void ExecuteInstruction(List<ObjectGame> objects)
        {
            if (Instruction == null) return;
            const float epsilon = 1e-6f;
            float value;
            PointF oldPosition = Position;

            switch (Instruction.Type)
            {
                case TypeInstruction.MoveForward:
                    value = Math.Min(Instruction.Value, SpeedMove);
                    Instruction.Value -= value;
                    MoveForward(value);
                    if (IsInvalidPosition(objects))
                    {
                        Position = oldPosition;
                        NewResult = TypeResult.CannotMoveForward;
                    }
                    break;
                case TypeInstruction.MoveBackward:
                    value = Math.Min(Instruction.Value, SpeedMove);
                    Instruction.Value -= value;
                    MoveBackward(value);
                    if (IsInvalidPosition(objects))
                    {
                        Position = oldPosition;
                        NewResult = TypeResult.CannotMoveBackward;
                    }
                    break;
                case TypeInstruction.RotateRight:
                    value = Math.Min(Instruction.Value, SpeedRotate);
                    Instruction.Value -= value;
                    RotateRight(value);
                    break;
                case TypeInstruction.RotateLeft:
                    value = Math.Min(Instruction.Value, SpeedRotate);
                    Instruction.Value -= value;
                    RotateLeft(value);
                    break;
                case TypeInstruction.Fire:
                    value = Math.Min(Instruction.Value, SpeedFire);
                    Instruction.Value -= value;
                    _damageCur += value;
                    if (Math.Abs(Instruction.Value) < epsilon)
                    {
                        var bullet = new Bullet(Properties.Resources.Bullet_A)
                            {
                                Position = MathProcessor.CalPointPosition(Position, 0.5f * Image.Width, Direction),
                                Direction = Direction,
                                Damage = _damageCur
                            };
                        _damageCur = 0;
                        objects.Add(bullet);
                    }
                    break;
            }
            if (Math.Abs(Instruction.Value) < epsilon)
            {
                Instruction = null;
                ListInstructions.RemoveAt(0);
            }
        }

        /// <summary>
        ///     Execute some change of object in a frame in battlefield
        /// </summary>
        /// <param name="objects">Objects are battlefield</param>
        /// <returns>Result of that frame</returns>
        public override TypeResult NextFrame(List<ObjectGame> objects)
        {
            if (NewResult == TypeResult.BeDestroyed) return TypeResult.BeDestroyed;
            DetectedEnemy(objects);
            if (EnemyTank != null) NewResult = TypeResult.Detected;
            SetListInstructions();
            while (Instruction == null)
                if (ListInstructions.Count == 0) break;
                else
                {
                    if (ListInstructions[0].Condition == null || ListInstructions[0].Condition.GetResult(this, EnemyTank, EnemyBullet))
                        Instruction = ListInstructions[0].Clone();
                    else
                        ListInstructions.RemoveAt(0);
                }
            NewResult = TypeResult.Normal;
            ExecuteInstruction(objects);
            EnemyTank = null;
            EnemyBullet = null;
            return TypeResult.Nothing;
        }

        public override void Paint(Graphics gfx)
        {
            base.Paint(gfx);
            gfx.FillPie(
                new SolidBrush(RadaColor),
                Position.X - RadaRange, Position.Y - RadaRange,
                RadaRange * 2, RadaRange * 2,
                Direction - 90 - RadaAngle / 2, RadaAngle);
        }
    }
}
