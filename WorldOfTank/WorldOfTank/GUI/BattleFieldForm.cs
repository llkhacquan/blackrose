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
        private Bitmap bmpGame = new Bitmap(600, 600);
        Graphics gfx;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void Display()
        {
            /*
            foreach (ObjectGame obj in battleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                dobj.Picture.Image = GraphicsProcessor.rotateCenter(dobj.Image, dobj.Direction);
                dobj.Picture.Size = dobj.Size;
                dobj.Picture.Location = dobj.Position.GetPoint();
                if (!panelView.Controls.Contains(obj.Picture))
                    panelView.Controls.Add(obj.Picture);
            }
            */

            gfx.Clear(Color.Gray);
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
                    GraphicsProcessor.SemiTransparent(0.8f));
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
            gfx = Graphics.FromImage(bmpGame);

            battleField = new BattleField();
            battleField.SetupGame();
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
