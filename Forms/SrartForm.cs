using System;
using System.Windows.Forms;
using XO.Core;

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
            var gf = new GameField(null, this);
            gf.Show();
            this.Hide();
        }

        private void PvA_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(0);
            var gf = new GameField(aiMode, this);
            gf.Show();
            this.Hide();
        }

        private void Unreal_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(2);
            var gf = new GameField(aiMode, this);
            gf.Show();
            this.Hide();
        }

        private void MiddleAi_Click(object sender, EventArgs e)
        {
            var aiMode = new Ai(1);
            var gf = new GameField(aiMode, this);
            gf.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
