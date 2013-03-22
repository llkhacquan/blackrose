using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            Image imgBG = WorldOfTank.Properties.Resources.Grass_C;
            for (int i = 0; i <= battleField.Size.Width / imgBG.Width; i++)
                for (int j = 0; j <= battleField.Size.Height / imgBG.Height; j++)
                    gfx.DrawImage(imgBG, imgBG.Width * i, imgBG.Height * j);

            foreach (ObjectGame obj in battleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                Bitmap bmp = new Bitmap(GraphicsProcessor.RotateImage(dobj.Image, dobj.Direction), dobj.Size);
                gfx.DrawImage(
                    bmp,
                    new Rectangle(new Point((int)dobj.Position.X, (int)dobj.Position.Y), dobj.Size),
                    0, 0,
                    dobj.Size.Width, dobj.Size.Height,
                    GraphicsUnit.Pixel,
                    GraphicsProcessor.SemiTransparent(1.0f));
            }

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
