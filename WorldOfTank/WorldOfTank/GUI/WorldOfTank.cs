using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorldOfTank.Properties;

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

        private void pictureBoxBattlefield_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxBattlefield.Image = Resources.Font_Battlefield_Glow;
        }

        private void pictureBoxBattlefield_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBattlefield.Image = Resources.Font_Battlefield;
        }

        private void pictureBoxTankCreator_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxTankCreator.Image = Resources.Font_TankCreator_Glow;
        }

        private void pictureBoxTankCreator_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxTankCreator.Image = Resources.Font_TankCreator;
        }

        private void pictureBoxIntroduction_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxIntroduction.Image = Resources.Font_Introduction_Glow;
        }

        private void pictureBoxIntroduction_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxIntroduction.Image = Resources.Font_Introduction;
        }

        private void pictureBoxExit_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxExit.Image = Resources.Font_Exit_Glow;
        }

        private void pictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExit.Image = Resources.Font_Exit;
        }
    }
}
