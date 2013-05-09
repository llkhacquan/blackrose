using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WorldOfTank.Class.Components;
using WorldOfTank.Class.Model;

namespace WorldOfTank.GUI
{
    public partial class BattleFieldForm : Form
    {
        private SetupGame _setupGame;
        private BattleField _battleField;
        private Bitmap _bufferBmpGame;
        private Bitmap _bmpGame;
        private Graphics _gfx;
        private TypeStateGame _stateGame;
        private List<Tank> _listTanks;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void BattleFieldForm_Load(object sender, EventArgs e)
        {
            _setupGame = new SetupGame();
            _stateGame = TypeStateGame.UnCreate;
            ShowButtonControl();
        }

        private void ShowButtonControl()
        {
            switch (_stateGame)
            {
                case TypeStateGame.UnCreate:
                    buttonSetup.Enabled = true;
                    buttonStart.Enabled = false;
                    buttonStart.Text = "Start";
                    buttonPause.Enabled = false;
                    buttonPause.Text = "Pause";
                    break;
                case TypeStateGame.Created:
                    buttonSetup.Enabled = true;
                    buttonStart.Enabled = true;
                    buttonStart.Text = "Start";
                    buttonPause.Enabled = false;
                    buttonPause.Text = "Pause";
                    break;
                case TypeStateGame.Started:
                    buttonSetup.Enabled = false;
                    buttonStart.Enabled = true;
                    buttonStart.Text = "Stop";
                    buttonPause.Enabled = true;
                    buttonPause.Text = "Pause";
                    break;
                case TypeStateGame.Paused:
                    buttonSetup.Enabled = false;
                    buttonStart.Enabled = true;
                    buttonStart.Text = "Stop";
                    buttonPause.Enabled = true;
                    buttonPause.Text = "Continue";
                    break;
                case TypeStateGame.Restart:
                    buttonSetup.Enabled = true;
                    buttonStart.Enabled = true;
                    buttonStart.Text = "Restart";
                    buttonPause.Enabled = false;
                    buttonPause.Text = "Pause";
                    break;
            }
        }

        private void ShowInformation()
        {
            String str = String.Format(" Time remaining: {0:0.0}s\n\n", GlobalVariableGame.TimeRemaining);
            str = _listTanks.Aggregate(str, (current, tank) =>
                current + String.Format(" Tank: {0}\n Heal: {1}/{2}\tScore: {3:0.0}\n\n", tank.Name, tank.HealCur, tank.HealMax, tank.Score));
            richTextBoxInformation.Text = str;
        }

        private new void Paint()
        {
            if (_bmpGame != null) _bmpGame.Dispose();
            _bmpGame = new Bitmap(_bufferBmpGame);
            if (_gfx != null) _gfx.Dispose();
            _gfx = Graphics.FromImage(_bmpGame);
            foreach (ObjectGame obj in _battleField.Objects)
                if (obj.Type != TypeObject.Background && obj.Type != TypeObject.Wall) obj.Paint(_gfx);

            /*Pen pen = new Pen(new SolidBrush(Color.Green));
            foreach (ObjectGame obj in _battleField.Objects)
            {
                RectangleF rec = new RectangleF(obj.Position.X - obj.Radius, obj.Position.Y - obj.Radius, obj.Radius * 2, obj.Radius * 2);
                _gfx.DrawArc(pen, rec, 0, 360);
            }*/

            panelView.CreateGraphics().DrawImage(_bmpGame, 0, 0);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            timerControl.Enabled = false;
            Close();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            if (_setupGame.ShowDialog() == DialogResult.OK)
            {
                timerControl.Interval = (int)(1000 / GlobalVariableGame.FramePerSecond);
                _stateGame = TypeStateGame.Created;
                ShowButtonControl();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            switch (_stateGame)
            {
                case TypeStateGame.Created:
                case TypeStateGame.Restart:
                    _battleField = new BattleField(_setupGame.SizeBattlefield);
                    _battleField.SetupGame(_setupGame.GetListTanks());
                    _listTanks = (from obj in _battleField.Objects where obj.Type == TypeObject.Tank select (Tank)obj).ToList();
                    _bufferBmpGame = new Bitmap(_setupGame.GetBackground(), _setupGame.SizeBattlefield);
                    _gfx = Graphics.FromImage(_bufferBmpGame);
                    foreach (ObjectGame obj in _battleField.Objects)
                        if (obj.Type == TypeObject.Background || obj.Type == TypeObject.Wall) obj.Paint(_gfx);
                    GlobalVariableGame.TimeRemaining = _setupGame.GetTime();
                    GlobalVariableGame.NumberTank = _setupGame.GetNumberTank();
                    timerControl.Enabled = true;
                    _stateGame = TypeStateGame.Started;
                    Size = new Size(_battleField.Size.Width + 206, _battleField.Size.Height + 28);
                    break;
                case TypeStateGame.Started:
                case TypeStateGame.Paused:
                    timerControl.Enabled = false;
                    _stateGame = TypeStateGame.Restart;
                    break;
            }
            ShowButtonControl();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            switch (_stateGame)
            {
                case TypeStateGame.Started:
                    timerControl.Enabled = false;
                    _stateGame = TypeStateGame.Paused;
                    break;
                case TypeStateGame.Paused:
                    timerControl.Enabled = true;
                    _stateGame = TypeStateGame.Started;
                    break;
            }
            ShowButtonControl();
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            _battleField.NextFrame();
            Paint();
            GlobalVariableGame.TimeRemaining -= 1f / GlobalVariableGame.FramePerSecond;
            ShowInformation();
            if (GlobalVariableGame.TimeRemaining <= 0 || GlobalVariableGame.NumberTank < 2)
            {
                timerControl.Enabled = false;
                _stateGame = TypeStateGame.Restart;
                ShowButtonControl();
                foreach (Tank tank in _listTanks)
                    if (tank.HealCur > 0) tank.Score += tank.HealCur + GlobalVariableGame.BonusScoreKiller;

                for (int i = 0; i < _listTanks.Count - 1; i++)
                    for (int j = i + 1; j < _listTanks.Count; j++)
                        if (_listTanks[i].Score < _listTanks[j].Score)
                        {
                            Tank temp = _listTanks[i];
                            _listTanks[i] = _listTanks[j];
                            _listTanks[j] = temp;
                        }

                int rank = 0;
                string rankStr = "Summary\n\n";
                for (int i = 0; i < _listTanks.Count; i++)
                {
                    if (i == 0 || _listTanks[i - 1].Score > _listTanks[i].Score) rank++;
                    rankStr += string.Format("Rank {0}:   {1:0.00}\t{2}\n", rank, _listTanks[i].Score, _listTanks[i].Name);
                }

                MessageBox.Show(rankStr, "GameOver");
            }
        }
    }
}
