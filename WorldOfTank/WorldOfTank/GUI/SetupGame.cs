using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Properties;

namespace WorldOfTank.GUI
{
    public partial class SetupGame : Form
    {
        private readonly Image[] _listBackground = new Image[]
        {
            Resources.Grass_A, 
            Resources.Grass_B, 
            Resources.Ice_A, 
            Resources.Ocean_A, 
        };

        private int _indexBackground;
        public Size SizeBattlefield = new Size(600, 600);


        private readonly Tank[] _listTanks = new Tank[8];
        private int _tankCount;

        public SetupGame()
        {
            InitializeComponent();
        }

        private void SetupGame_Load(object sender, EventArgs e)
        {
            comboBoxSize.Text = string.Format("{0} x {1}", SizeBattlefield.Width, SizeBattlefield.Height);
            pictureBoxBackground.Image = _listBackground[_indexBackground];
        }

        private void AddTank(int index)
        {
            var opener = new OpenFileDialog
            {
                Title = "Open Tank",
                Filter = "Tank File (*.tank)|*.tank",
                RestoreDirectory = true
            };
            if (opener.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(opener.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                    if (_listTanks[index] == null) _tankCount++;
                    _listTanks[index] = (Tank)formatter.Deserialize(stream);
                    stream.Close();
                    _listTanks[index].Name = opener.FileName.Substring(opener.FileName.LastIndexOf('\\') + 1);
                    var button = (Button)Controls[string.Format("buttonAddTank{0}", index)];
                    button.Text = _listTanks[index].Name;
                    button.Image = _listTanks[index].Image;
                    button.TextAlign = ContentAlignment.BottomCenter;
                }
                catch
                {
                    if (_listTanks[index] == null) _tankCount--;
                    MessageBox.Show("Cannot load this file!");
                }
            }
        }

        public Image GetBackground()
        {
            return _listBackground[_indexBackground];
        }

        public List<Tank> GetListTanks()
        {
            return (from tank in _listTanks where tank != null select tank).ToList();
        }

        public int GetNumberTank()
        {
            return _tankCount;
        }

        public float GetTime()
        {
            return (float)numericUpDownTime.Value;
        }

        private void buttonAddTank0_Click(object sender, EventArgs e)
        {
            AddTank(0);
        }

        private void buttonAddTank1_Click(object sender, EventArgs e)
        {
            AddTank(1);
        }

        private void buttonAddTank2_Click(object sender, EventArgs e)
        {
            AddTank(2);
        }

        private void buttonAddTank3_Click(object sender, EventArgs e)
        {
            AddTank(3);
        }

        private void buttonAddTank4_Click(object sender, EventArgs e)
        {
            AddTank(4);
        }

        private void buttonAddTank5_Click(object sender, EventArgs e)
        {
            AddTank(5);
        }

        private void buttonAddTank6_Click(object sender, EventArgs e)
        {
            AddTank(6);
        }

        private void buttonAddTank7_Click(object sender, EventArgs e)
        {
            AddTank(7);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_tankCount < 2)
            {
                MessageBox.Show("Be must at least 2 tanks. Please add more tank");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _indexBackground = (_indexBackground + 1) % _listBackground.Length;
            pictureBoxBackground.Image = _listBackground[_indexBackground];
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            _indexBackground = (_indexBackground + _listBackground.Length - 1) % _listBackground.Length;
            pictureBoxBackground.Image = _listBackground[_indexBackground];
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSize.Text)
            {
                case "600 x 600":
                    SizeBattlefield = new Size(600, 600);
                    break;
                case "800 x 600":
                    SizeBattlefield = new Size(800, 600);
                    break;
                case "1000 x 600":
                    SizeBattlefield = new Size(1000, 600);
                    break;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _listTanks.Length; i++)
            {
                _listTanks[i] = null;
                var button = (Button)Controls[string.Format("buttonAddTank{0}", i)];
                button.Text = "Add a tank";
                button.Image = null;
                button.TextAlign = ContentAlignment.MiddleCenter;
            }
            _tankCount = 0;
        }
    }
}
