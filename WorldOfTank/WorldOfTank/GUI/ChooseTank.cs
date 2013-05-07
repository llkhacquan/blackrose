using System;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Properties;

namespace WorldOfTank.GUI
{
    public partial class ChooseTank : Form
    {
        public Tank Tank;
        private int _typeTank = -1;

        public ChooseTank()
        {
            InitializeComponent();
        }

        private void pictureBoxGreenTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 0)
            {
                pictureBoxGreenTank.BackColor = Color.LimeGreen;
            }
        }

        private void pictureBoxGreenTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 0)
            {
                pictureBoxGreenTank.BackColor = Color.Transparent;
            }
        }

        private void pictureBoxBlueTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 1)
            {
                pictureBoxBlueTank.BackColor = Color.LightSeaGreen;
            }
        }

        private void pictureBoxBlueTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 1)
            {
                pictureBoxBlueTank.BackColor = Color.Transparent;
            }
        }

        private void pictureBoxYellowTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 2)
            {
                pictureBoxYellowTank.BackColor = Color.Gold;
            }
        }

        private void pictureBoxYellowTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 2)
            {
                pictureBoxYellowTank.BackColor = Color.Transparent;
            }
        }

        private void pictureBoxRedTank_MouseEnter(object sender, EventArgs e)
        {
            if (_typeTank != 3)
            {
                pictureBoxRedTank.BackColor = Color.LightCoral;
            }
        }

        private void pictureBoxRedTank_MouseLeave(object sender, EventArgs e)
        {
            if (_typeTank != 3)
            {
                pictureBoxRedTank.BackColor = Color.Transparent;
            }
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
                    richTextBoxInfor.Text = "You chose the green tank\n   Damage: 10 - 20\n   Heal: 100\n   Movement speed: 3\n   Rotation speed: 5\n   Attack speed: 1\n   Rada range: 300\n   Rada angle: 20";
                    pictureBoxGreenTank.BackColor = Color.LimeGreen;
                    break;
                case 1:
                    richTextBoxInfor.Text = "You chose the blue tank\n   Damage: 10 - 20\n   Heal: 100\n   Movement speed: 3\n   Rotation speed: 5\n   Attack speed: 1\n   Rada range: 300\n   Rada angle: 20";
                    pictureBoxBlueTank.BackColor = Color.LightSeaGreen;
                    break;
                case 2:
                    richTextBoxInfor.Text = "You chose the yellow tank\n   Damage: 10 - 20\n   Heal: 100\n   Movement speed: 3\n   Rotation speed: 5\n   Attack speed: 1\n   Rada range: 300\n   Rada angle: 20";
                    pictureBoxYellowTank.BackColor = Color.Gold;
                    break;
                case 3:
                    richTextBoxInfor.Text = "You chose the red tank\n   Damage: 10 - 20\n   Heal: 100\n   Movement speed: 3\n   Rotation speed: 5\n   Attack speed: 1\n   Rada range: 300\n   Rada angle: 20";
                    pictureBoxRedTank.BackColor = Color.LightCoral;
                    break;
                default:
                    break;
            }
        }

        private void pictureBoxGreenTank_Click(object sender, EventArgs e)
        {
            _typeTank = 0;
            ShowInformation();
        }

        private void pictureBoxBlueTank_Click(object sender, EventArgs e)
        {
            _typeTank = 1;
            ShowInformation();
        }

        private void pictureBoxYellowTank_Click(object sender, EventArgs e)
        {
            _typeTank = 2;
            ShowInformation();
        }

        private void pictureBoxRedTank_Click(object sender, EventArgs e)
        {
            _typeTank = 3;
            ShowInformation();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_typeTank == -1)
            {
                MessageBox.Show("Please choose a tank");
                return;
            }

            switch (_typeTank)
            {
                case 0:
                    Tank = new Tank(Resources.Tank_A);
                    break;
                case 1:
                    Tank = new Tank(Resources.Tank_B);
                    break;
                case 2:
                    Tank = new Tank(Resources.Tank_C);
                    break;
                case 3:
                    Tank = new Tank(Resources.Tank_D);
                    break;
                default:
                    break;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
