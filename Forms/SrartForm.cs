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
            var gf = new GameField(null);
            gf.Show();
            this.Hide();
        }

        private void PvA_Click(object sender, EventArgs e)
        {
            var gameType = new PvA(0);
            var gf = new GameField(gameType);
            gf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var gameType = new PvA(2);
            var gf = new GameField(gameType);
            gf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var gameType = new PvA(1);
            var gf = new GameField(gameType);
            gf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
