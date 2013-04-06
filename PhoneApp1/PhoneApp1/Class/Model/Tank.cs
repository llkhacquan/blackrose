﻿using System;
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
    class Tank : DynamicObject {
        public List<Bullet> bullet;
        //public float Damage;
        public float SpeedMove;
        public int Index;
        public int Amo;
        public int NumberOfBulltets;
        public int FireDelay;
        //public float SpeedRotation;
        //public float SpeedFire;
        public float Heal;
        public int timePlayed;
        public List<Instruction> Instructions;

        public Tank(string url) :base(url, TypeObject.Tank) {
            Amo = 10;
            NumberOfBulltets = 0;
            BattleField.NumberOfTanks++;
            this.FireDelay = 1000;
            this.Index = BattleField.NumberOfTanks;
            this.bullet = new List<Bullet>(Amo);
            //this.bullet.setSize(new Size(20, 20));
            //this.bullet.Direction = this.Direction;
            //this.bullet.Damage = 10;
            //this.bullet.Speed = 10;
            this.SpeedMove = 1;
            this.Heal = 1;
            this.timePlayed = 0;
            //this.Direction = 90;
            Instructions = new List<Instruction>();
        }

        public Func<List<Instruction>> ActionNormal = () => new List<Instruction>();
        public Func<List<Instruction>> ActionCannotMove = () => new List<Instruction>();
        public Func<List<Instruction>> ActionDetected = () => new List<Instruction>();

        public void Update() {
            if (Instructions.Count == 0) Instructions = ActionNormal();
            //this.timePlayed++;
            for (int i = 0; i < bullet.Count; i++) {
                bullet[i].index = i;
            }
        }

        public override void MoveBackward(float value) {
            float tempx = this.getPosition().X;
            float tempy = this.getPosition().Y;
            base.MoveBackward(value);
            if (this.outOfRange()) this.setPosition(new Position(tempx, tempy));
        }

        public override void RotateLeft(float value) {
            float tempDir = Direction;
            base.RotateLeft(value);
            if (this.outOfRange()) Direction = tempDir;
        }

        public override void RotateRight(float value) {
            float tempDir = Direction;
            base.RotateRight(value);
            if (this.outOfRange()) Direction = tempDir;
        }

        public override void MoveForward(float value) {
            float tempx = this.getPosition().X;
            float tempy = this.getPosition().Y;
            base.MoveForward(value);
            if (this.outOfRange()) this.setPosition(new Position(tempx, tempy));

        }

        public void Die() {

        }

        public void Fire() {
            
            Bullet b = new Bullet(TankResources.Bullet1,this.Index,NumberOfBulltets);
            this.NumberOfBulltets++;
            b.setSize(new Size(5, 5));
            b.Direction = this.Direction;
            b.Damage = 10;
            b.Speed = 10;
            //calculate the position of bullet
            double angle = Math.PI * this.Direction / 180;
                
            float x = this.getPosition().X;
            float y = this.getPosition().Y;

            x+=(float)this.getSize().Width/2;
            y+=(float)this.getSize().Height/2;

            x += (float)Math.Sin(angle) * (((float)this.getSize().Width+(float)b.getSize().Width)/2);
            y -= (float)Math.Cos(angle) * (((float)this.getSize().Height+(float)b.getSize().Height)/2);

            x-= ((float)b.getSize().Width)/2;
            y-= ((float)b.getSize().Width)/2;

            //end bullet-position calculation
            b.setPosition(new Position(x, y));
            bullet.Add(b);
            //Amo--;
            this.FireDelay = 0;
            //if (outOfRange(this)) this.bullet.setPosition(new Position(tempx, tempy));
            //this.setPosition(new Position(x, y));
            
            //this.bullet.Direction = this.Direction;
            //this.setSize(new Size(20, 20));
            //BattleField.Objects.Add(b);
            
            //MainPage.BattleField.Children.Add(b);
            //BattleField.Objects.Add(b);
            return;
        }
    }
}
