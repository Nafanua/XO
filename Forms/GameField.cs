using System;
using System.Linq;
using System.Windows.Forms;
using XO.Core;
using XO.Core.Abstracts;

namespace XO.Forms
{
    public partial class GameField : Form
    {
        private readonly IGame _ai;
        private readonly string[] _field;
        private bool _isAi;
        private readonly Form _start;
        public const string X = "X";
        public const string O = "O";
        private string _turn = X;

        public GameField(IGame aiMode, Form start)
        {
            _field = new string[9];
            _ai = aiMode;
            _start = start;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!(_ai is PvA)) return;

            _isAi = true;
            AiMove();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            BtnClick(button0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClick(button1, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnClick(button2, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnClick(button3, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BtnClick(button4, 4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BtnClick(button5, 5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BtnClick(button6, 6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BtnClick(button7, 7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BtnClick(button8, 8);
        }

        private void NextMove()
        {
            _turn = _turn == X ? O : X;
        }

        private void BtnClick(Control button, int index)
        {
            button.Text = _turn;

            _field[index] = _turn;

            button.Enabled = false;

            WhoWin();

            if (_turn != X) return;

            AiMove();
        }

        private void WhoWin()
        {
            if ((_field[0] == _field[1] & _field[0] == _field[2] & _field[0] != null) | 
                (_field[0] == _field[4] & _field[8] == _field[0] & _field[0] != null) | 
                (_field[0] == _field[3] & _field[6] == _field[0] & _field[0] != null) | 
                (_field[1] == _field[4] & _field[7] == _field[1] & _field[1] != null) | 
                (_field[2] == _field[5] & _field[8] == _field[2] & _field[2] != null) | 
                (_field[2] == _field[4] & _field[6] == _field[2] & _field[2] != null) | 
                (_field[3] == _field[4] & _field[5] == _field[3] & _field[3] != null) | 
                (_field[6] == _field[7] & _field[8] == _field[6] & _field[6] != null))
            {
                MessageBox.Show($@"{_turn} WIN!");
                Refresh();
            }

            if (_field.All(k => k != null))
            {
                MessageBox.Show(@"Dead heat");
                Refresh();
            }

            NextMove();
        }

        private new void Refresh()
        {
            for (var i = 0; i < 9; i++)
            {
                Controls[i].ResetText();
                Controls[i].Enabled = true;
                _field[i] = null;
            }

            _ai?.Clear();

            _turn = O;
        }

        private void AiMove()
        {
            if (!_isAi || _turn == O) return;

            var move = _ai.Move(_field);

            switch (move)
            {
                case 0:
                    BtnClick(button0, move);
                    break;
                case 1:
                    BtnClick(button1, move);
                    break;
                case 2:
                    BtnClick(button2, move);
                    break;
                case 3:
                    BtnClick(button3, move);
                    break;
                case 4:
                    BtnClick(button4, move);
                    break;
                case 5:
                    BtnClick(button5, move);
                    break;
                case 6:
                    BtnClick(button6, move);
                    break;
                case 7:
                    BtnClick(button7, move);
                    break;
                case 8:
                    BtnClick(button8, move);
                    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _start.Show();
        }
    }
}
