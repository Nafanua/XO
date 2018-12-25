using System;
using System.Windows.Forms;
using XO.Core;
using XO.Core.Enums;

namespace XO.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void PvP_Click(object sender, EventArgs e)
        {
            var gf = new GameField(this);
            gf.Show();
            this.Hide();
        }

        private void PvA_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(Complexity.Easy);
            var gf = new GameField(this, aiMode);
            gf.Show();
            this.Hide();
        }

        private void Unreal_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(Complexity.Unreal);
            var gf = new GameField(this, aiMode);
            gf.Show();
            this.Hide();
        }

        private void MiddleAi_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(Complexity.Normal);
            var gf = new GameField(this, aiMode);
            gf.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
