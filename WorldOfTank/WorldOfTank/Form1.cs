using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Properties;
using WorldOfTank.Class.Components;

namespace WorldOfTank
{
    public partial class Form1 : Form
    {
        private BattleField battleField;

        public Form1()
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
                if (!panel2.Controls.Contains(obj.Picture))
                    panel2.Controls.Add(obj.Picture);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            battleField = new BattleField();
            battleField.SetupGame();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            battleField.NextFrame();
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            battleField.NextFrame();
            Display();
        }
    }
}
