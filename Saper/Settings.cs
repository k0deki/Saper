using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.ActiveControl = lbl;
            string[] str = { "Easy", "Normal", "Hard", "Сustomizable" };
            string[] str2 = { "1", "2" };
            Difficulty.Items.AddRange(str);
            Difficulty.Text = Info.Diff.ToString();
            SPSet.Items.AddRange(str2);
            SPSet.Text = Info.SPset.ToString();
            UserName.Text = Info.UserName.ToString();
            BombSize.Text = Info.ButtonSize.ToString();
        }

        bool Saving()
        {
            if (UserName.Text != "" && Convert.ToInt32(BombSize.Text) >= 10)
            {
                Info.UserName = UserName.Text;
                Info.ButtonSize = Convert.ToInt32(BombSize.Text);
                Info.Diff = Difficulty.Text;
            }
            else
            {
                MessageBox.Show("Вы оставили пустые поля или размер кнопок меньше 10");
                return false;
            }
            if (Custom.Visible == true)
            {
                try
                {
                    if (MapSize.Text != "" && BombCount.Text != "" && Convert.ToInt32(MapSize.Text) >=5 && Convert.ToInt32(BombCount.Text)< Math.Pow(Convert.ToInt32(MapSize.Text),2)*3/4)
                    {
                        Info.Size = Convert.ToInt32(MapSize.Text);
                        Info.WidhtMap = Info.HeightMap = Info.Size;
                        Info.Bomb = Convert.ToInt32(BombCount.Text);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Вы оставили пустые поля или количество полей меньше 5, количество бомб должно быть меньше трети поля");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
            return true;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {          
            Application.OpenForms[0].Show();
        }

        private void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Info.Diff = Difficulty.Text;
            switch (Difficulty.Text.ToString())
            {
                case "Сustomizable":
                    MapSize.Text = Info.Size.ToString();
                    BombCount.Text = Info.Bomb.ToString();
                    Custom.Visible = true;
                    break;
                case "Easy":
                    Info.Bomb = 35;
                    Custom.Visible = false;
                    break;
                case "Normal":
                    Custom.Visible = false;
                    Info.Bomb = 60;
                    break;
                case "Hard":
                    Info.Bomb = 120;
                    Custom.Visible = false;
                    break;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Saving())
            {
                this.Close();
            }          
        }

        private void MapSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void BombCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void SPSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SPSet.Text == "2")
            {
                Info.SpriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\5.png"));
                Info.SPset = 2;
            }
            else
            {
                Info.SpriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\1.png"));
                Info.SPset = 1; 
            }
        }
    }
}
