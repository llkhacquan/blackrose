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
using System.Windows.Media;

namespace PhoneApp1.Class.Model {
    class Tank : DynamicObject {
        public Bullet bullet;
        public bool AllowToFire;
        //public float Damage;
        public int HP;
        public TextBlock StatsText;
        public ProgressBar Stats;
        public int Defense;
        public float SpeedMove;
        public int Index; //In order to know what tank is
        public bool Alive;
        public List<Instruction> Instructions;
        
        public Tank(string url) :base(url, TypeObject.Tank) {
            Defense = 40;
            HP = 100;
            BattleField.NumberOfTanks++;
            this.Index = BattleField.NumberOfTanks;
            
            this.SpeedMove = 1;
            
            AllowToFire = true;
            Instructions = new List<Instruction>();
            Alive = true;
            bullet = new Bullet(TankResources.Bullet1, this.Index);
            //StatsText default
            StatsText = new TextBlock();
            StatsText.FontSize = 12;
            StatsText.Foreground = new SolidColorBrush(Colors.Black);
            StatsText.Text = HP.ToString();
            StatsText.FontWeight = FontWeights.Bold;
            StatsText.Visibility = System.Windows.Visibility.Visible;
            StatsText.Text = HP.ToString() + "/" + Defense.ToString();
            //Stats default
            Stats = new ProgressBar();
            Stats.Background = new SolidColorBrush(Colors.Transparent);
            //Stats.Width = this.getSize().Width;
            //Stats.Height = this.getSize().Height;
            //Stats.MaxHeight = this.getSize().Height;
            //Stats.MaxWidth = this.getSize().Width;
            //Stats.
            Stats.Padding = new Thickness(0, 0, 0, 0);
            Stats.Visibility = System.Windows.Visibility.Visible;
            Stats.Minimum = 0;
            Stats.Maximum = 100;
            Stats.Value = HP;
            //Stats.
            Stats.Foreground = new SolidColorBrush(Colors.Cyan);
            Stats.Margin = new Thickness(this.getPosition().X, this.getPosition().Y + this.getSize().Height, 0, 0);
            //Stat

        }
        public void FireDone() {
            AllowToFire = true;
        }

        public void beAttacked(Bullet bullet) {
            Defense -= bullet.Damage;
            if (Defense < 0) {
                HP -= Math.Abs(Defense);
                Defense = 0;
            }
            if (HP <= 0) {
                Alive = false;
            }
            StatsText.Text = HP.ToString() + "/" + Defense.ToString();
        }
        public Func<List<Instruction>> ActionNormal = () => new List<Instruction>();
        public Func<List<Instruction>> ActionCannotMove = () => new List<Instruction>();
        public Func<List<Instruction>> ActionDetected = () => new List<Instruction>();

        public void Update() {
            if (Instructions.Count == 0) Instructions = ActionNormal();
            StatsText.Margin = new Thickness(this.getPosition().X, this.getPosition().Y + this.getSize().Height, 0, 0);
            //Stats.Margin = new Thickness(this.getPosition().X, this.getPosition().Y + this.getSize().Height, 0, 0);
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

        public void Fire() {
            
            bullet = new Bullet(TankResources.Bullet1,this.Index);
            bullet.setSize(new Size(5, 5));
            bullet.Direction = this.Direction;
            bullet.Damage = 20;
            bullet.Speed = 10;
            //calculate the position of bullet
            double angle = Math.PI * this.Direction / 180;
                
            float x = this.getPosition().X;
            float y = this.getPosition().Y;

            x+=(float)this.getSize().Width/2;
            y+=(float)this.getSize().Height/2;

            x += (float)Math.Sin(angle) * (((float)this.getSize().Width+(float)bullet.getSize().Width)/2);
            y -= (float)Math.Cos(angle) * (((float)this.getSize().Height+(float)bullet.getSize().Height)/2);

            x-= ((float)bullet.getSize().Width)/2;
            y-= ((float)bullet.getSize().Width)/2;

            //end bullet-position calculation
            bullet.setPosition(new Position(x, y));
            AllowToFire = false;
            return;
        }
    }
}
