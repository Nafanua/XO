using System;
using System.Linq;
using System.Windows.Forms;
using XO.Core;
using XO.Core.Abstracts;

namespace XO.Forms
{
    public partial class GameField : Form
    {
        private string _turn = "X";
        private readonly IGame _gameType;
        private readonly string[] _field;
        private bool _isAi;

        public GameField(IGame gameType)
        {
            _field = new string[9];
            _gameType = gameType;
           
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!(_gameType is PvA)) return;

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
            _turn = _turn == "X" ? "O" : "X";
        }

        private void BtnClick(Control b, int ind)
        {
            b.Text = _turn;

            if (_turn == "O" || !_isAi)
            {
                _field[ind] = _turn;
            }

            b.Enabled = false;

            WhoWin();

            if (_turn != "X") return;

            AiMove();
        }

        private void WhoWin()
        {
            if ((_field[0] == "X" & _field[1] == "X" & _field[2] == "X") | 
                (_field[0] == "X" & _field[4] == "X" & _field[8] == "X") | 
                (_field[0] == "X" & _field[3] == "X" & _field[6] == "X") | 
                (_field[1] == "X" & _field[4] == "X" & _field[7] == "X") | 
                (_field[2] == "X" & _field[5] == "X" & _field[8] == "X") | 
                (_field[2] == "X" & _field[4] == "X" & _field[6] == "X") | 
                (_field[3] == "X" & _field[4] == "X" & _field[5] == "X") | 
                (_field[6] == "X" & _field[7] == "X" & _field[8] == "X"))
            {
                MessageBox.Show(@"X WIN!");
                Refresh();
            }

            if ((_field[0] == "O" & _field[1] == "O" & _field[2] == "O") | 
                (_field[0] == "O" & _field[4] == "O" & _field[8] == "O") | 
                (_field[0] == "O" & _field[3] == "O" & _field[6] == "O") | 
                (_field[1] == "O" & _field[4] == "O" & _field[7] == "O") | 
                (_field[2] == "O" & _field[5] == "O" & _field[8] == "O") | 
                (_field[2] == "O" & _field[4] == "O" & _field[6] == "O") | 
                (_field[3] == "O" & _field[4] == "O" & _field[5] == "O") | 
                (_field[6] == "O" & _field[7] == "O" & _field[8] == "O"))
            {
                MessageBox.Show(@"O WIN!");
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

            _gameType?.Clear();

            _turn = "O";
        }

        private void AiMove()
        {
            if (!_isAi || _turn == "O") return;

            switch (_gameType.Game(_field))
            {
                case 0:
                    button0_Click(new object(), new EventArgs());
                    break;
                case 1:
                    button1_Click(new object(), new EventArgs());
                    break;
                case 2:
                    button2_Click(new object(), new EventArgs());
                    break;
                case 3:
                    button3_Click(new object(), new EventArgs());
                    break;
                case 4:
                    button4_Click(new object(), new EventArgs());
                    break;
                case 5:
                    button5_Click(new object(), new EventArgs());
                    break;
                case 6:
                    button6_Click(new object(), new EventArgs());
                    break;
                case 7:
                    button7_Click(new object(), new EventArgs());
                    break;
                case 8:
                    button8_Click(new object(), new EventArgs());
                    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Environment.Exit(0);
        }
    }
}
