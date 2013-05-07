using System;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Components;
using WorldOfTank.Class.Model;

namespace WorldOfTank.GUI
{
    public partial class BattleFieldForm : Form
    {
        private BattleField _battleField;
        private Bitmap _bufferBmpGame;
        private Bitmap _bmpGame;
        private Graphics _gfx;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private new void Paint()
        {
            if (_bmpGame != null) _bmpGame.Dispose();
            _bmpGame = new Bitmap(_bufferBmpGame);
            if (_gfx != null) _gfx.Dispose();
            _gfx = Graphics.FromImage(_bmpGame);
            foreach (ObjectGame obj in _battleField.Objects)
                if (obj.Type == TypeObject.Tank || obj.Type == TypeObject.Bullet) obj.Paint(_gfx);
            panelView.CreateGraphics().DrawImage(_bmpGame, 0, 0);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            using (var setupGame = new SetupGame())
            {
                if (setupGame.ShowDialog() == DialogResult.OK)
                {
                    _battleField = new BattleField();
                    _battleField.SetupGame(setupGame.ListTanks);
                    _bufferBmpGame = new Bitmap(_battleField.Size.Width, _battleField.Size.Height);
                    _gfx = Graphics.FromImage(_bufferBmpGame);
                    foreach (ObjectGame obj in _battleField.Objects)
                        if (obj.Type == TypeObject.Background || obj.Type == TypeObject.Wall)
                            obj.Paint(_gfx);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            timerControl.Enabled = true;
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            _battleField.NextFrame();
            Paint();
        }
    }
}
