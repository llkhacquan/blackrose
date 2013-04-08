using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorldOfTank.GUI
{
    public partial class WorldOfTank : Form
    {
        public WorldOfTank()
        {
            InitializeComponent();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxBattlefield_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new BattleFieldForm().ShowDialog();
            this.Visible = true;
        }

        private void pictureBoxTankCreator_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new TankCreator().ShowDialog();
            this.Visible = true;
        }
    }
}
