﻿using System;
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

        public BattleField()
        {
            Objects = new List<ObjectGame>();
        }

        public void SetupGame()
        {
            Tank tank = new Tank(Resources.tank_up);
            tank.Speed = 3;
            tank.Size = new Size(60, 60);
            tank.Position = new Position(100, 200);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateLeft, 60),
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.MoveBackward, 150),
            };
            Objects.Add(tank);

            tank = new Tank(Resources.tank_up);
            tank.Speed = 5;
            tank.Size = new Size(60, 60);
            tank.Position = new Position(180, 100);
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateRight, 5),
                new Instruction(TypeInstruction.MoveForward, 5),
            };
            Objects.Add(tank);
        }

        private void ProcessBullet(Bullet bullet)
        {
            bullet.MoveForward(bullet.Speed);
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
            Position p = new Position(tank.Position.X, tank.Position.Y);
            for (int i = 0; i < tank.Instructions.Count; i++)
            {
                if (tank.Instructions[i].Type == TypeInstruction.MoveForward)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.Speed);
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
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.Speed);
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
                    float value = Math.Min(tank.Instructions[i].Parameter, 5);
                    tank.RotateLeft(value);
                    tank.Instructions[i].Parameter -= value;
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                }
                else if (tank.Instructions[i].Type == TypeInstruction.RotateRight)
                {
                    float value = Math.Min(tank.Instructions[i].Parameter, 5);
                    tank.RotateRight(value);
                    tank.Instructions[i].Parameter -= value;
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
