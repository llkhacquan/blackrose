using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WorldOfTank.Class.Model;

namespace WorldOfTank.GUI
{
    public partial class SetupGame : Form
    {
        private readonly Tank[] _listTanks = new Tank[8];
        private int _tankCount;

        public SetupGame()
        {
            InitializeComponent();
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
    }
}
