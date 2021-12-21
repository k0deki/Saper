using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Game : Form
    {

        public Game()
        {
            InitializeComponent();
            MapController.Init(this);
        }

        
        private void Game_Load(object sender, EventArgs e)
        {
            
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[0].Show();
        }

        private void hideToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Hide();
            Game gm = new Game();
            gm.Show();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapController.ShowAll();
        }
    }
}
