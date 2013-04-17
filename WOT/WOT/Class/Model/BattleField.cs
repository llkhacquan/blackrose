using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WOT.Resources;
using WOT.Class.Components;
using System.Windows.Media;

namespace WOT.Class.Model {
    class BattleField : PhoneApplicationPage  {
        //public static List<ObjectGame> Objects;
        public static List<Tank> Tanks;
        public static List<Bullet> Bullets;
        public static List<Wall> Walls;
        public static int NumberOfTanks;
        public bool NeedToUpdate;
        //public ProgressBar test;
        public BattleField() {
            //Objects = new List<ObjectGame>(100);
            Tanks = new List<Tank>(10);
            Bullets = new List<Bullet>(10);
            Walls = new List<Wall>(1000);
            NumberOfTanks = 0;
            NeedToUpdate = true;
            
        }

        public void SetupGame() {
            Tank tank = new Tank(TankResources.Tank1);
            //tank.Index = NumberOfTanks;
            tank.SpeedMove = 3;
            tank.setSize( new Size(40, 40));
            tank.setPosition(new Position(100, 200));
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveBackward,100),
                new Instruction(TypeInstruction.RotateLeft, 45),
                new Instruction(TypeInstruction.MoveForward, 50),
                new Instruction(TypeInstruction.RotateRight, 37),
                new Instruction(TypeInstruction.Fire,0),
            };
            Tanks.Add(tank);
            //NumberOfTanks++;

            tank = new Tank(TankResources.Tank2);
            //tank.Index = NumberOfTanks;
            tank.SpeedMove = 3;
            tank.setSize (new Size(40, 40));
            tank.setPosition (new Position(100, 100));
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateLeft, 50),
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.Fire,0),
            };
            Tanks.Add(tank);
            //NumberOfTanks++;

            tank = new Tank(TankResources.Tank3);
            tank.SpeedMove = 3;
            tank.Index = NumberOfTanks;
            tank.setSize (new Size(40, 40));
            tank.setPosition (new Position(300, 300));
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.RotateLeft, 90),
                new Instruction(TypeInstruction.RotateRight,180),
                new Instruction(TypeInstruction.Fire,0),
            };
            Tanks.Add(tank);
            //NumberOfTanks++;

            tank = new Tank(TankResources.Tank4);
            //tank.Index = NumberOfTanks;
            tank.SpeedMove = 4;
            tank.setSize (new Size(40, 40));
            tank.setPosition (new Position(100, 400));
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
                new Instruction(TypeInstruction.Fire,0),
            };
            Tanks.Add(tank);
            //NumberOfTanks++;
            updateObjects();
            //updateBattlefield();
             
      
        }

        public void updateBattlefield() {
            
            MainPage.BattleField.Children.Clear();
            for (int i = 0; i < Tanks.Count; i++) {
                MainPage.BattleField.Children.Add(Tanks[i].Image);
                MainPage.BattleField.Children.Add(Tanks[i].StatsText);
                //MainPage.BattleField.Children.Add(Tanks[i].Stats);
            }
            for (int i = 0; i < Bullets.Count; i++) {
                MainPage.BattleField.Children.Add(Bullets[i].Image);
            }
        }
        public void updateObjects() {
            for (int i = 0; i < Tanks.Count; i++) {
                Tanks[i].Index = i;
                Tanks[i].bullet.TankIndex = i;
            }
        }

        private void ProcessBullet(Bullet bullet) {
            bullet.MoveForward(bullet.Speed);
            
            for (int i = 0; i < Tanks.Count; i++){
                    if (bullet.IsCollided(Tanks[i])) {
                            (Tanks[i]).beAttacked(bullet);
                            Tanks[bullet.TankIndex].FireDone();
                            if (!Tanks[i].Alive) {
                                Bullets.Remove(Tanks[i].bullet);
                                Tanks.RemoveAt(i);
                                updateObjects();
                            }
                        Bullets.Remove(bullet);
                        NeedToUpdate = true;
                    }
                    
                //}
                
            }
            if(bullet.outOfRange()){
                Tanks[bullet.TankIndex].AllowToFire = true;
                Bullets.Remove(bullet);
            }
        }

        private void ProcessTank(Tank tank) {
            tank.Update();
            Position p = new Position(tank.getPosition().X, tank.getPosition().Y);
            for (int i = 0; i < tank.Instructions.Count; i++) {
                if (tank.Instructions[i].Type == TypeInstruction.MoveForward) {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedMove);
                    tank.MoveForward(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Tanks.Count; j++)
                        if (Tanks[j] != tank && tank.IsCollided(Tanks[j])) {
                            tank.setPosition(p);
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                } else if (tank.Instructions[i].Type == TypeInstruction.MoveBackward) {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedMove);
                    tank.MoveBackward(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Tanks.Count; j++)
                        if (Tanks[j] != tank && tank.IsCollided(Tanks[j])) {
                            tank.setPosition(p);
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                } else if (tank.Instructions[i].Type == TypeInstruction.RotateLeft) {
                    float value = Math.Min(tank.Instructions[i].Parameter, 5);
                    tank.RotateLeft(value);
                    tank.Instructions[i].Parameter -= value;
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                } else if (tank.Instructions[i].Type == TypeInstruction.RotateRight) {
                    float value = Math.Min(tank.Instructions[i].Parameter, 5);
                    tank.RotateRight(value);
                    tank.Instructions[i].Parameter -= value;
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                } else if (tank.Instructions[i].Type == TypeInstruction.Fire) {
                    if (tank.AllowToFire) {
                        tank.Fire();
                        Bullets.Add(tank.bullet);
                        tank.Instructions.RemoveAt(i);
                        NeedToUpdate = true;
                        //tank.UpdateStats();
                    }
                }
            }
        }

        public void NextFrame() {
            
            for (int i = 0; i < Bullets.Count; i++) {
                //if (Objects[i].Type == TypeObject.Bullet) {
                    ProcessBullet(Bullets[i]);
            }

            for (int i = 0; i < Tanks.Count; i++) {
                //if (Objects[i].Type == TypeObject.Bullet) {
                ProcessTank(Tanks[i]);
            }
            if (NeedToUpdate == true) {
                updateBattlefield();
                //needUpdate = false;
            }
        }
    }
}
