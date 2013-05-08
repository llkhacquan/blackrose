using System;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;
using WorldOfTank.Class.Model;
using WorldOfTank.Properties;

namespace WorldOfTank.GUI
{
    public partial class ChooseTank : Form
    {
        public Tank Tank;
        private int _typeTank = -1;

        // Standard Tank
        public static Tank GreenTank = new Tank(Resources.Tank_A)
            {
                RadaColor = Color.FromArgb(31, 0, 255, 0),
            };

        // Speed Tank
        public static Tank BlueTank = new Tank(Resources.Tank_B)
            {
                RadaColor = Color.FromArgb(31, 0, 0, 255),
                // Buff
                SpeedMove = 3.5f,
                SpeedRotate = 6f,
                SpeedFire = 1.2f,
                DamageMin = 5f,
                // Nerf
                Armor = 0f,
                RadaRange = 250f,
                HealMax = 160f,
                HealCur = 160f,
            };

        // Defense Tank
        public static Tank YellowTank = new Tank(Resources.Tank_C)
            {
                RadaColor = Color.FromArgb(31, 255, 255, 0),
                // Buff
                HealMax = 220f,
                HealCur = 220f,
                Armor = 1.5f,
                RadaAngle = 30f,
                // Nerf
                RadaRange = 200f,
                SpeedMove = 2.5f,
                SpeedRotate = 4f,
                SpeedFire = 0.9f,
            };

        // Attack Tank
        public static Tank RedTank = new Tank(Resources.Tank_D)
            {
                RadaColor = Color.FromArgb(31, 255, 0, 0),
                // Buff
                DamageMax = 20f,
                RadaRange = 350f,
                SpeedFire = 1.1f,
                // Nerf
                HealMax = 180f,
                HealCur = 180f,
                Armor = 0.5f,
                RadaAngle = 15,
            };

        public ChooseTank()
        {
            InitializeComponent();
        }

        private void pictureBoxGreenTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 0) pictureBoxGreenTank.BackColor = Color.LimeGreen;
        }

        private void pictureBoxGreenTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 0) pictureBoxGreenTank.BackColor = Color.Transparent;
        }

        private void pictureBoxBlueTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 1) pictureBoxBlueTank.BackColor = Color.LightSeaGreen;
        }

        private void pictureBoxBlueTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 1) pictureBoxBlueTank.BackColor = Color.Transparent;
        }

        private void pictureBoxYellowTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 2) pictureBoxYellowTank.BackColor = Color.Gold;
        }

        private void pictureBoxYellowTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 2) pictureBoxYellowTank.BackColor = Color.Transparent;
        }

        private void pictureBoxRedTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 3) pictureBoxRedTank.BackColor = Color.LightCoral;
        }

        private void pictureBoxRedTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 3) pictureBoxRedTank.BackColor = Color.Transparent;
        }

        private void ShowInformation()
        {
            pictureBoxGreenTank.BackColor = Color.Transparent;
            pictureBoxBlueTank.BackColor = Color.Transparent;
            pictureBoxYellowTank.BackColor = Color.Transparent;
            pictureBoxRedTank.BackColor = Color.Transparent;
            switch (_typeTank)
            {
                case 0:
                    richTextBoxInfor.Text = string.Format("You chose the green tank\n{0}", GlobalVariableGame.PrintTankInformation(Tank));
                    pictureBoxGreenTank.BackColor = Color.LimeGreen;
                    break;
                case 1:
                    richTextBoxInfor.Text = string.Format("You chose the blue tank\n{0}", GlobalVariableGame.PrintTankInformation(Tank));
                    pictureBoxBlueTank.BackColor = Color.LightSeaGreen;
                    break;
                case 2:
                    richTextBoxInfor.Text = string.Format("You chose the yellow tank\n{0}", GlobalVariableGame.PrintTankInformation(Tank));
                    pictureBoxYellowTank.BackColor = Color.Gold;
                    break;
                case 3:
                    richTextBoxInfor.Text = string.Format("You chose the red tank\n{0}", GlobalVariableGame.PrintTankInformation(Tank));
                    pictureBoxRedTank.BackColor = Color.LightCoral;
                    break;
            }
        }

        private void pictureBoxGreenTank_Click(object sender, EventArgs e)
        {
            _typeTank = 0;
            Tank = GreenTank.Clone();
            ShowInformation();
        }

        private void pictureBoxBlueTank_Click(object sender, EventArgs e)
        {
            _typeTank = 1;
            Tank = BlueTank.Clone();
            ShowInformation();
        }

        private void pictureBoxYellowTank_Click(object sender, EventArgs e)
        {
            _typeTank = 2;
            Tank = YellowTank.Clone();
            ShowInformation();
        }

        private void pictureBoxRedTank_Click(object sender, EventArgs e)
        {
            _typeTank = 3;
            Tank = RedTank.Clone();
            ShowInformation();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_typeTank == -1)
            {
                MessageBox.Show("Please choose a tank");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
