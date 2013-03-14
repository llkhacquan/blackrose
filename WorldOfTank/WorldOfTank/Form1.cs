using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Class.Components;

namespace WorldOfTank
{
    public partial class Form1 : Form
    {
        private Tank tankDemo;
        private int count = 10;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Display()
        {
            if (tankDemo.direction == Direction.North)
                imageTankDemo.Image = WorldOfTank.Properties.Resources.tank_up;
            else if (tankDemo.direction == Direction.East)
                imageTankDemo.Image = WorldOfTank.Properties.Resources.tank_right;
            else if (tankDemo.direction == Direction.South)
                imageTankDemo.Image = WorldOfTank.Properties.Resources.tank_down;
            else imageTankDemo.Image = WorldOfTank.Properties.Resources.tank_left;
            imageTankDemo.Location = new Point(tankDemo.position.x, tankDemo.position.y);
            imageTankDemo.Size = tankDemo.size;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            tankDemo = new Tank();
            tankDemo.image = WorldOfTank.Properties.Resources.tank;
            tankDemo.speed = 3;
            tankDemo.direction = Direction.North;
            tankDemo.position = new Position(500, 300);
            tankDemo.size = new Size(60, 60);
            timerControl.Enabled = true;
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            if (count > 0)
            {
                tankDemo.moveUp();
                count--;
            }
            else
            {
                if (random.Next(100) < 10)
                {
                    if (random.Next(100) < 50) tankDemo.turnRight();
                    else tankDemo.turnLeft();
                    count = 10;
                }
                else tankDemo.moveUp();
            }
            Display();
        }

    }
}
