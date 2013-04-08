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
        private Graphics gfx;
        private bool IsStarted;
        private bool IsPaused;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void BattleFieldForm_Load(object sender, EventArgs e)
        {
            IsStarted = false;
            IsPaused = false;
            ViewControl();
        }

        private void ViewControl()
        {
            if (!IsStarted)
            {
                buttonStart.Text = "Start";

                buttonPause.Enabled = false;
                buttonPause.Text = "Pause";
            }
            else
            {
                buttonStart.Text = "Stop";

                buttonPause.Enabled = true;
                if (!IsPaused) buttonPause.Text = "Pause";
                else buttonPause.Text = "Continue";
            }
        }

        private new void Paint()
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
                RectangleF rec = new RectangleF(obj.Position.X - obj.Radius, obj.Position.Y - obj.Radius, obj.Radius * 2, obj.Radius * 2);
                gfx.DrawArc(pen, rec, 0, 360);
            }
            */

            /*
            Tank tank;
            SolidBrush semiTransBrush = new SolidBrush(Color.Transparent);
            Rectangle rec;
            for (int i = 0; i < battleField.Objects.Count; i++)
                if (battleField.Objects[i].Type == TypeObject.Tank)
                {
                    tank = (Tank)battleField.Objects[i];
                    semiTransBrush = new SolidBrush(Color.FromArgb(32, 255, 255, 0));
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
            TypeResult result = battleField.NextFrame();
            Paint();
            if (result == TypeResult.GameOver)
            {
                buttonStart_Click(null, null);
                MessageBox.Show("Game Over");
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!IsStarted)
            {
                battleField = new BattleField();
                battleField.SetupGame();
                bmpGame = new Bitmap(battleField.Size.Width, battleField.Size.Height);
                gfx = Graphics.FromImage(bmpGame);
                timerControl.Enabled = true;
                IsStarted = true;
            }
            else
            {
                timerControl.Enabled = false;
                IsStarted = false;
            }
            ViewControl();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (!IsPaused)
            {
                timerControl.Enabled = false;
                IsPaused = true;
            }
            else
            {
                timerControl.Enabled = true;
                IsPaused = false;
            }
            ViewControl();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
