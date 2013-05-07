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
        private float _time;


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
            richTextBoxInformation.Text = String.Format(" Time remaining: {0:0.0}s", _time);
        }

        private new void Paint()
        {
            if (_bmpGame != null)
            {
                _bmpGame.Dispose();
            }
            _bmpGame = new Bitmap(_bufferBmpGame);
            if (_gfx != null)
            {
                _gfx.Dispose();
            }
            _gfx = Graphics.FromImage(_bmpGame);
            foreach (ObjectGame obj in _battleField.Objects)
            {
                if (obj.Type == TypeObject.Tank || obj.Type == TypeObject.Bullet)
                {
                    obj.Paint(_gfx);
                }
            }
            panelView.CreateGraphics().DrawImage(_bmpGame, 0, 0);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            if (_setupGame.ShowDialog() == DialogResult.OK)
            {
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
                    _time = _setupGame.GetTime();
                    _battleField = new BattleField();
                    _battleField.SetupGame(new List<Tank>(_setupGame.GetListTanks()));
                    _bufferBmpGame = new Bitmap(_battleField.Size.Width, _battleField.Size.Height);
                    _gfx = Graphics.FromImage(_bufferBmpGame);
                    foreach (ObjectGame obj in _battleField.Objects)
                    {
                        if (obj.Type == TypeObject.Background || obj.Type == TypeObject.Wall)
                        {
                            obj.Paint(_gfx);
                        }
                    }
                    timerControl.Enabled = true;
                    _stateGame = TypeStateGame.Started;
                    break;
                case TypeStateGame.Started:
                case TypeStateGame.Paused:
                    timerControl.Enabled = false;
                    _stateGame = TypeStateGame.Restart;
                    break;
                default:
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
                default:
                    break;
            }
            ShowButtonControl();
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            var result = _battleField.NextFrame();
            Paint();
            _time -= 1f / timerControl.Interval;
            ShowInformation();
            if (_time <= 0 || result == TypeResult.GameOver)
            {
                timerControl.Enabled = false;
                _stateGame = TypeStateGame.Restart;
                ShowButtonControl();
                MessageBox.Show("Game Over");
            }
        }
    }
}
