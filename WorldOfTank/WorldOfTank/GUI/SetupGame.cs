using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WorldOfTank.Class.Model;

namespace WorldOfTank.GUI
{
    public partial class SetupGame : Form
    {
        private readonly Tank[] _listTank = new Tank[4];
        public List<Tank> ListTanks;

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
                    _listTank[index] = (Tank)formatter.Deserialize(stream);
                    stream.Close();
                    switch (index)
                    {
                        case 0:
                            buttonAddTank1.Text = String.Format("Tank '{0}' is loaded successfully", _listTank[index].Name);
                            break;
                        case 1:
                            buttonAddTank2.Text = String.Format("Tank '{0}' is loaded successfully", _listTank[index].Name);
                            break;
                        case 2:
                            buttonAddTank3.Text = String.Format("Tank '{0}' is loaded successfully", _listTank[index].Name);
                            break;
                        case 3:
                            buttonAddTank4.Text = String.Format("Tank '{0}' is loaded successfully", _listTank[index].Name);
                            break;
                        default:
                            break;
                    }

                }
                catch
                {
                    MessageBox.Show("Cannot load this file!");
                }
            }
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
            ListTanks = new List<Tank>();
            foreach (Tank tank in _listTank)
                if (tank != null) ListTanks.Add(tank);
            if (ListTanks.Count < 2)
            {
                MessageBox.Show("Be must at least 2 tanks. Please add more tank");
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
