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
            Tank tank = new Tank(Resources.Tank_A);
            tank.SpeedMove = 3;
            tank.SpeedRotate = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(150, 100);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateLeft, 60),
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.MoveBackward, 100),
            };
            Objects.Add(tank);

            tank = new Tank(Resources.Tank_B);
            tank.SpeedMove = 5;
            tank.SpeedRotate = 3;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(250, 200);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateRight, 3),
                new Instruction(TypeInstruction.MoveForward, 5),
            };
            Objects.Add(tank);

            tank = new Tank(Resources.Tank_C);
            tank.SpeedMove = 3;
            tank.SpeedRotate = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new PointF(300, 300);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.RotateLeft, 90),
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
                new Instruction(TypeInstruction.MoveForward, 210),
                new Instruction(TypeInstruction.RotateRight, 135),
            };
            Objects.Add(tank);
        }

        private void ProcessBullet(Bullet bullet)
        {
            bullet.MoveForward(bullet.SpeedMove);
            for (int i = 0; i < Objects.Count; i++)
                if (bullet.IsCollided(Objects[i]))
                {
                    Objects.Remove(bullet);
                    break;
                }
        }

        private void ProcessTank(Tank tank)
        {
            tank.Update();
            PointF p = tank.Position;
            float d = tank.Direction;
            for (int i = 0; i < tank.Instructions.Count; i++)
            {
                if (tank.Instructions[i].Type == TypeInstruction.MoveForward)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedMove);
                    tank.MoveForward(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j]))
                        {
                            tank.Position = p;
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                }
                else if (tank.Instructions[i].Type == TypeInstruction.MoveBackward)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedMove);
                    tank.MoveBackward(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j]))
                        {
                            tank.Position = p;
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                }
                else if (tank.Instructions[i].Type == TypeInstruction.RotateLeft)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedRotate);
                    tank.RotateLeft(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j]))
                        {
                            tank.Direction = d;
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                }
                else if (tank.Instructions[i].Type == TypeInstruction.RotateRight)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedRotate);
                    tank.RotateRight(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j]))
                        {
                            tank.Direction = d;
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                }
                else if (tank.Instructions[i].Type == TypeInstruction.Fire)
                {

                }
            }
        }

        public void NextFrame()
        {
            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i].Type == TypeObject.Bullet) ProcessBullet((Bullet)Objects[i]);
                else if (Objects[i].Type == TypeObject.Tank) ProcessTank((Tank)Objects[i]);
            }
        }
    }
}
