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
    public partial class Win : Form
    {
        public Win()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Win_Load(object sender, EventArgs e)
        {
            if (Info.win) label1.Text = "You win!";
            else label1.Text = "You lose(";
        }

        private void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            Info.win = false;
            if(Application.OpenForms.Count==2)
                Application.OpenForms[1].Close();
            Application.OpenForms[0].Show();            
        }
    }
}
