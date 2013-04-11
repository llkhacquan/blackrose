using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp1.Resources;
using PhoneApp1.Class.Components;

namespace PhoneApp1.Class.Model {
    class BattleField : PhoneApplicationPage  {
        public static List<ObjectGame> Objects;
        public static int NumberOfTanks;
        public BattleField() {
            Objects = new List<ObjectGame>(1000);
            NumberOfTanks = 0;
        }

        public void SetupGame() {
            Tank tank = new Tank(TankResources.FirstTank);
            tank.SpeedMove = 3;
            tank.setSize( new Size(40, 40));
            tank.setPosition(new Position(100, 200));
            //tank.setDirection(30);

            //Add Instructions
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveBackward,100),
                new Instruction(TypeInstruction.RotateLeft, 45),
                new Instruction(TypeInstruction.MoveForward, 50),
                new Instruction(TypeInstruction.RotateRight, 37),
                new Instruction(TypeInstruction.Fire,0),
            };
            Objects.Add(tank);

            //Bullet bullet = new Bullet(TankResources.Bullet1);
            //bullet.setPosition(new Position(20, 20));
            tank = new Tank(TankResources.SecondTank);
            tank.SpeedMove = 3;
            tank.setSize (new Size(40, 40));
            tank.setPosition (new Position(100, 100));
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.RotateLeft, 50),
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.Fire,0),
            };
            Objects.Add(tank);

            tank = new Tank(TankResources.ThirdTank);
            tank.SpeedMove = 3;
            tank.setSize (new Size(40, 40));
            tank.setPosition (new Position(300, 300));
            tank.ActionNormal = () => new List<Instruction>()
            {
                new Instruction(TypeInstruction.MoveForward, 100),
                new Instruction(TypeInstruction.RotateLeft, 90),
                new Instruction(TypeInstruction.RotateRight,180),
                new Instruction(TypeInstruction.Fire,0),
            };
            Objects.Add(tank);
            
            tank = new Tank(TankResources.FourthTank);
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
            Objects.Add(tank);
             
            //updateBattlefield();
             
      
        }

        public void updateBattlefield() {
            MainPage.BattleField.Children.Clear();
            for (int i = 0; i < Objects.Count; i++) {
                MainPage.BattleField.Children.Add(Objects[i].Image);
            }
        }

        private void ProcessBullet(Bullet bullet) {
            bullet.MoveForward(bullet.Speed);
            //float value = Math.Min(bullet.Instructions.Parameter, bullet.Speed);
            
            for (int i = 0; i < Objects.Count; i++){
                if (Objects[i].Type != TypeObject.Bullet) {
                    if (bullet.IsCollided(Objects[i])) {
                        if (Objects[i].Type == TypeObject.Tank) {
                            //((Tank)Objects[i]).Die();
                            ((Tank)Objects[i]).beAttacked(bullet);
                            if(!((Tank)Objects[i]).Alive) Objects.RemoveAt(i);
                        }
                    }
                }
                
            }
                if(bullet.outOfRange()){
                    
                    for(int j=0;j<Objects.Count;j++){
                        if(Objects[j].Type == TypeObject.Tank){
                            if(((Tank)Objects[j]).Index == bullet.TankIndex){
                                ((Tank)Objects[j]).bullet.RemoveAt((bullet.index));
                                Objects.Remove(bullet);
                                ((Tank)Objects[j]).NumberOfBulltets--;
                            }
                        }
                    }
                    
                    //break;
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
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j])) {
                            tank.setPosition(p);
                            break;
                        }
                    if (tank.Instructions[i].Parameter == 0) tank.Instructions.RemoveAt(i--);
                    else break;
                } else if (tank.Instructions[i].Type == TypeInstruction.MoveBackward) {
                    float value = Math.Min(tank.Instructions[i].Parameter, tank.SpeedMove);
                    tank.MoveBackward(value);
                    tank.Instructions[i].Parameter -= value;
                    for (int j = 0; j < Objects.Count; j++)
                        if (Objects[j] != tank && tank.IsCollided(Objects[j])) {
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
                    if (tank.FireDelay > 1000) {
                        tank.Fire();
                        Objects.Add(tank.bullet[tank.bullet.Count - 1]);
                        tank.Instructions.RemoveAt(i);
                    }
                }
            }
        }

        public void NextFrame() {
            
            for (int i = 0; i < Objects.Count; i++) {
                if (Objects[i].Type == TypeObject.Bullet) {
                    ProcessBullet((Bullet)Objects[i]);
                    
                } else if (Objects[i].Type == TypeObject.Tank) {
                    ProcessTank((Tank)Objects[i]);
                    ((Tank)Objects[i]).FireDelay += MainPage.timerControl.Interval.Milliseconds;
                }
            }
            updateBattlefield();
        }
    }
}
