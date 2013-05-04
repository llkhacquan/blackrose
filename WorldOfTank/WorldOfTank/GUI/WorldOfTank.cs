using System;
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
            Close();
        }

        private void pictureBoxBattlefield_Click(object sender, EventArgs e)
        {
            Visible = false;
            new BattleFieldForm().ShowDialog();
            Visible = true;
        }

        private void pictureBoxTankCreator_Click(object sender, EventArgs e)
        {
            Visible = false;
            new TankCreatorForm().ShowDialog();
            Visible = true;
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
