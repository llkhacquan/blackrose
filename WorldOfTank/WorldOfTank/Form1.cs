using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldOfTank.Class.Model;

namespace WorldOfTank
{
    public partial class Form1 : Form
    {
        private Tank tankDemo;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            tankDemo = new Tank();
            tankDemo.image = 
        }
    }
}
