using System;
using System.Collections.Generic;
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
        private readonly Tank[] _listTanks = new Tank[4];
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
                    switch (index)
                    {
                        case 0:
                            buttonAddTank1.Text = String.Format("Tank '{0}' is loaded successfully", _listTanks[index].Name);
                            break;
                        case 1:
                            buttonAddTank2.Text = String.Format("Tank '{0}' is loaded successfully", _listTanks[index].Name);
                            break;
                        case 2:
                            buttonAddTank3.Text = String.Format("Tank '{0}' is loaded successfully", _listTanks[index].Name);
                            break;
                        case 3:
                            buttonAddTank4.Text = String.Format("Tank '{0}' is loaded successfully", _listTanks[index].Name);
                            break;
                    }

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
            return (from tank in _listTanks where tank != null select tank.Clone()).ToList();
        }

        public float GetTime()
        {
            return (float)numericUpDownTime.Value;
        }

        private void buttonAddTank1_Click(object sender, EventArgs e)
        {
            AddTank(0);
        }

        private void buttonAddTank2_Click(object sender, EventArgs e)
        {
            AddTank(1);
        }

        private void buttonAddTank3_Click(object sender, EventArgs e)
        {
            AddTank(2);
        }

        private void buttonAddTank4_Click(object sender, EventArgs e)
        {
            AddTank(3);
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
