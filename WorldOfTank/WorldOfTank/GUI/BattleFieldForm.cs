using System;
using System.Drawing;
using System.Windows.Forms;
using WorldOfTank.Class.Model;
using WorldOfTank.Class.Components;

namespace WorldOfTank.GUI
{
    public partial class BattleFieldForm : Form
    {
        private BattleField _battleField;
        private Bitmap _bufferBmpGame;
        private Bitmap _bmpGame;
        private Graphics _gfx;
        private bool _isStarted;
        private bool _isPaused;

        public BattleFieldForm()
        {
            InitializeComponent();
        }

        private void BattleFieldForm_Load(object sender, EventArgs e)
        {
            _isStarted = false;
            _isPaused = false;
            ViewControl();
        }

        private void ViewControl()
        {
            if (!_isStarted)
            {
                buttonStart.Text = "Start";

                buttonPause.Enabled = false;
                buttonPause.Text = "Pause";
            }
            else
            {
                buttonStart.Text = "Stop";

                buttonPause.Enabled = true;
                buttonPause.Text = !_isPaused ? "Pause" : "Continue";
            }
        }

        private new void Paint()
        {
            _bmpGame.Dispose();
            _bmpGame = new Bitmap(_bufferBmpGame);
            _gfx = Graphics.FromImage(_bmpGame);

            foreach (ObjectGame obj in _battleField.Objects)
            {
                if (obj.Type != TypeObject.Wall) obj.Paint(_gfx);
            }

            /*
            Pen pen = new Pen(new SolidBrush(Color.Green));
            foreach (ObjectGame obj in battleField.Objects)
            {
                RectangleF rec = new RectangleF(obj.Position.X - obj.Radius, obj.Position.Y - obj.Radius, obj.Radius * 2, obj.Radius * 2);
                gfx.DrawArc(pen, rec, 0, 360);
            }
            */

            /*
            Tank tank;
            SolidBrush semiTransBrush = new SolidBrush(Color.Transparent);
            Rectangle rec;
            for (int i = 0; i < battleField.Objects.Count; i++)
                if (battleField.Objects[i].Type == TypeObject.Tank)
                {
                    tank = (Tank)battleField.Objects[i];
                    semiTransBrush = new SolidBrush(Color.FromArgb(32, 255, 255, 0));
                    rec = new Rectangle(
                        (int)tank.Position.X - 300, (int)tank.Position.Y - 300,
                        600, 600);
                    gfx.FillPie(semiTransBrush, rec, battleField.Objects[i].Direction - 90 - 10, 20);
                }
            */
            panelView.CreateGraphics().DrawImage(_bmpGame, 0, 0);
        }

        private void timerControl_Tick(object sender, EventArgs e)
        {
            TypeResult result = _battleField.NextFrame();
            Paint();
            if (result == TypeResult.GameOver)
            {
                buttonPause_Click(null, null);
                MessageBox.Show("Game Over");
                buttonStart_Click(null, null);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                timerControl.Enabled = true;
                _isStarted = true;
            }
            else
            {
                timerControl.Enabled = false;
                _isStarted = false;
                panelView.Invalidate();
            }
            ViewControl();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (!_isPaused)
            {
                timerControl.Enabled = false;
                _isPaused = true;
            }
            else
            {
                timerControl.Enabled = true;
                _isPaused = false;
            }
            ViewControl();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            _battleField = new BattleField();
            _battleField.SetupGame();
            _bufferBmpGame = new Bitmap(_battleField.Size.Width, _battleField.Size.Height);
            _gfx = Graphics.FromImage(_bufferBmpGame);

            Image imgBG = _battleField.Background;
            for (int i = 0; i <= (_battleField.Size.Width - 1) / imgBG.Width; i++)
                for (int j = 0; j <= (_battleField.Size.Height - 1) / imgBG.Height; j++)
                    _gfx.DrawImage(imgBG, imgBG.Width * i, imgBG.Height * j);

            foreach (ObjectGame obj in _battleField.Objects)
                if (obj.Type == TypeObject.Wall) obj.Paint(_gfx);
        }
    }
}
