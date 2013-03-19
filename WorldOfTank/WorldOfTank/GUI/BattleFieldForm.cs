using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void Display()
        {
            foreach (ObjectGame obj in battleField.Objects)
            {
                DynamicObject dobj = (DynamicObject)obj;
                dobj.Picture.Image = GraphicsProcessor.rotateCenter(dobj.Image, dobj.Direction);
                dobj.Picture.Size = dobj.Size;
                dobj.Picture.Location = dobj.Position.GetPoint();
                if (!panelView.Controls.Contains(obj.Picture))
                    panelView.Controls.Add(obj.Picture);
            }
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            battleField.NextFrame();
            Display();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            panelView.Controls.Clear();
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
