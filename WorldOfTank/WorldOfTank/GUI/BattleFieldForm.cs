using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Class.Components;

namespace WorldOfTank.GUI
{
    public partial class BattleFieldForm : Form
    {
        private BattleField battleField;
        private Bitmap bmpGame;
        Graphics gfx;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void Display()
        {
            Image imgBG = battleField.Background;
            for (int i = 0; i <= (battleField.Size.Width - 1) / imgBG.Width; i++)
                for (int j = 0; j <= (battleField.Size.Height - 1) / imgBG.Height; j++)
                    gfx.DrawImage(imgBG, imgBG.Width * i, imgBG.Height * j);

            foreach (ObjectGame obj in battleField.Objects)
            {
                obj.Paint(gfx);
            }

            /*
            Pen pen = new Pen(new SolidBrush(Color.Green));
            foreach (ObjectGame obj in battleField.Objects)
            {
                PointF[] pf = obj.RealEdge;
                for (int i = 0; i < pf.Length - 1; i++)
                {
                    gfx.DrawLine(pen, pf[i], pf[i + 1]);
                }
            }         
            
             
            Tank tank;
            SolidBrush semiTransBrush = new SolidBrush(Color.Transparent);
            Rectangle rec;
            for (int i = 0; i < 4; i++)
            {
                tank = (Tank)battleField.Objects[i];
                switch (i)
                {
                    case 0: semiTransBrush = new SolidBrush(Color.FromArgb(32, 0, 255, 0)); break;
                    case 1: semiTransBrush = new SolidBrush(Color.FromArgb(32, 0, 0, 255)); break;
                    case 2: semiTransBrush = new SolidBrush(Color.FromArgb(32, 255, 255, 0)); break;
                    case 3: semiTransBrush = new SolidBrush(Color.FromArgb(32, 255, 0, 0)); break;
                }

                rec = new Rectangle(
                    (int)tank.Position.X - 300, (int)tank.Position.Y - 300,
                    600, 600);

                gfx.FillPie(semiTransBrush, rec, battleField.Objects[i].Direction - 90 - 10, 20);
            }
            */

            panelView.CreateGraphics().DrawImage(bmpGame, 0, 0);
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            battleField.NextFrame();
            Display();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            battleField = new BattleField();
            battleField.SetupGame();
            bmpGame = new Bitmap(battleField.Size.Width, battleField.Size.Height);
            gfx = Graphics.FromImage(bmpGame);
            timerControl.Enabled = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timerControl.Enabled = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
    }
}
