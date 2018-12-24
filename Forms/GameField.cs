using System;
using System.Linq;
using System.Windows.Forms;
using XO.Core;
using XO.Core.Abstracts;
using XO.Core.Enums;

namespace XO.Forms
{
    public partial class GameField : Form
    {
        public const string X = "X";
        public const string O = "O";
        private readonly IAi _ai;
        private readonly Form _start;
        private readonly string[] _field;
        private bool _isAi;
        private string _turn = X;

        public GameField(IAi aiMode, Form start)
        {
            _field = new string[9];
            _ai = aiMode;
            _start = start;
            InitializeComponent();
        }

        public GameField(Form start)
        {
            _field = new string[9];
            _start = start;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!(_ai is Ai)) return;

            _isAi = true;
            AiMove();
        }

        private void button0_Click(object sender, EventArgs e) => BtnClick(button0, 0);

        private void button1_Click(object sender, EventArgs e) => BtnClick(button1, 1);

        private void button2_Click(object sender, EventArgs e) => BtnClick(button2, 2);

        private void button3_Click(object sender, EventArgs e) => BtnClick(button3, 3);

        private void button4_Click(object sender, EventArgs e) => BtnClick(button4, 4);

        private void button5_Click(object sender, EventArgs e) => BtnClick(button5, 5);

        private void button6_Click(object sender, EventArgs e) => BtnClick(button6, 6);

        private void button7_Click(object sender, EventArgs e) => BtnClick(button7, 7);

        private void button8_Click(object sender, EventArgs e) => BtnClick(button8, 8);

        private void NextMove() => _turn = _turn == X ? O : X;

        private void BtnClick(Control button, int index)
        {
            button.Text = _turn;

            button.Enabled = false;

            _field[index] = _turn;

            WhoWin();

            if (_isAi && _turn == X)
            {
                AiMove();
            }
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

            if (_ai != null && _ai.Complexity == Complexity.Unreal)
            {
                _turn = O;
            }
        }

        private void AiMove()
        {
            var move = _ai.Move(_field);

            BtnClick(Controls.Find("button" + move, false).First(), move);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _start.Show();
        }
    }
}
