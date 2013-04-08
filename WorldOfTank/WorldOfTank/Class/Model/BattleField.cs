using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using WorldOfTank.Class.Components;
using WorldOfTank.Properties;
using System.Windows.Forms;

namespace WorldOfTank.Class.Model
{
    class BattleField
    {
        public List<ObjectGame> Objects;
        public Size Size;
        public Image Background;

        public BattleField()
        {
            Objects = new List<ObjectGame>();
            Size = new Size(600, 600);
            Background = Resources.Grass_A;
        }

        public void SetupGame()
        {
            Wall wall;

            for (int i = 0; i <= (this.Size.Width - 1) / (Resources.Wall_A.Width - 1); i++)
            {
                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Size.Width - 1) * i + wall.Anchor.X;
                wall.Position.Y = wall.Anchor.Y;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_A);
                wall.Position.X = (wall.Size.Width - 1) * i + wall.Anchor.X;
                wall.Position.Y = this.Size.Height - wall.Size.Height + wall.Anchor.Y;
                Objects.Add(wall);
            }

            for (int i = 0; i <= (this.Size.Height - 1) / (Resources.Wall_B.Height - 1); i++)
            {
                wall = new Wall(Resources.Wall_B);
                wall.Position.X = wall.Anchor.X;
                wall.Position.Y = (wall.Size.Height - 1) * i + wall.Anchor.Y;
                Objects.Add(wall);

                wall = new Wall(Resources.Wall_B);
                wall.Position.X = this.Size.Width - wall.Size.Width + wall.Anchor.X;
                wall.Position.Y = (wall.Size.Height - 1) * i + wall.Anchor.Y;
                Objects.Add(wall);
            }


            Tank tank = new Tank(Resources.Tank_A);
            tank.Heal = 50;
            tank.SpeedMove = 3;
            tank.SpeedRotate = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(100, 100);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateLeft, 60),
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            tank.ActionCannotMoveForward = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateRight, 135),
                new Instruction(TypeInstruction.MoveForward, 200),
            };
            tank.ActionBeAttacked = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            Objects.Add(tank);

            tank = new Tank(Resources.Tank_B);
            tank.Heal = 50;
            tank.SpeedMove = 5;
            tank.SpeedRotate = 3;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(250, 200);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateRight, 50),
                new Instruction(TypeInstruction.MoveForward, 200),
                new Instruction(TypeInstruction.RotateLeft, 20),
                new Instruction(TypeInstruction.MoveBackward, 50),
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            tank.ActionCannotMoveForward = () => new List<Instruction>();
            tank.ActionCannotMoveBackward = () => new List<Instruction>();
            tank.ActionBeAttacked = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            Objects.Add(tank);

            /*
            tank = new Tank(Resources.Tank_C);
            tank.SpeedMove = 3;
            tank.SpeedRotate = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(300, 300);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveForward, 200),
                new Instruction(TypeInstruction.RotateLeft, 90),
                new Instruction(TypeInstruction.MoveBackward, 100),
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            Objects.Add(tank);

            tank = new Tank(Resources.Tank_D);
            tank.SpeedMove = 4;
            tank.SpeedRotate = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(100, 400);
            tank.Direction = 45;
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveForward, 300),
                new Instruction(TypeInstruction.RotateLeft, 135),
                new Instruction(TypeInstruction.MoveForward, 210),
                new Instruction(TypeInstruction.RotateRight, 45),
                new Instruction(TypeInstruction.MoveBackward, 300),
                new Instruction(TypeInstruction.RotateLeft, 45),
                new Instruction(TypeInstruction.Fire, tank.Bullet.Damage),
            };
            Objects.Add(tank);
            */
        }

        public TypeResult NextFrame()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].NextFrame(Objects) == TypeResult.BeDestroyed)
                    Objects.RemoveAt(i--);
            }

            int tankCount = 0;
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Type == TypeObject.Tank) tankCount++;
            }
            if (tankCount <= 1) return TypeResult.GameOver;
            return TypeResult.Nothing;
        }
    }
}
