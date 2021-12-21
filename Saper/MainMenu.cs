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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();          
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Application.OpenForms.Count.ToString());
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 1)
            {
                Game game = new Game();
                game.Show();
            }
            else
            {
                Application.OpenForms[1].Show();
            }
            this.Hide();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 2)
            {
                Application.OpenForms[1].Close();
            }
            Game game = new Game();
            game.Show();
            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            this.Hide();
        }

        //private void continueToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (Application.OpenForms.Count.ToString() != "1")
        //        Application.OpenForms[1].Show();
        //    else MessageBox.Show("Error");
        //}
    }
}
