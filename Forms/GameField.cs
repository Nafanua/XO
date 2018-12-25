using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using XO.Core;
using XO.Core.Abstracts;
using XO.Core.Enums;

namespace XO.Forms
{
    public partial class GameField : Form
    {
        public static readonly string X = ConfigurationManager.AppSettings["X"];
        public static readonly string O = ConfigurationManager.AppSettings["O"];
        private readonly IAi _ai;
        private readonly Form _start;
        private readonly string[] _field;
        private bool _isAi;
        private string _turn = X;
        private int _xWins;
        private int _oWins;
        private int _deadHeats;

        private void NextMove() => _turn = _turn == X ? O : X;

        public GameField(Form start, IAi aiMode = null )
        {
            _field = new string[9];
            _ai = aiMode;
            _start = start;
            _oWins = 0;
            _xWins = 0;
            _deadHeats = 0;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!(_ai is Ai)) return;

            _isAi = true;
            AiMove();
        }

        private void BackToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            _start.Show();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            var button = (Button) sender;

            var index = button.TabIndex;

            if (_field[index] != null) return;

            button.Text = _turn;

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

                if (_turn == O)
                {
                    OWin.Text = (++_oWins).ToString();
                }
                else
                {
                    XWins.Text= (++_xWins).ToString();
                }

                Refresh();
            }

            if (_field.All(k => k != null))
            {
                MessageBox.Show(@"Dead heat");
                Deadheats.Text = (++_deadHeats).ToString();
                Refresh();
            }

            NextMove();
        }

        private new void Refresh()
        {
            for (var i = 0; i < _field.Length; i++)
            {
                Controls.Find(i.ToString(), false).First().ResetText();
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

            BtnClick(Controls.Find(move.ToString(), false).First(), new EventArgs());
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _start.Show();
        }
    }
}
