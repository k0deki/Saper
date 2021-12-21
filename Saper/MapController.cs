using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    static class MapController
    {
        static public int[,] map = new int[Info.Size, Info.Size];
        static public ButtonExtended[,] buttons = new ButtonExtended[Info.Size, Info.Size];
        static public bool FirstStep;
        static Point FirstCoord;
        public static Form form;
        static internal bool end = false;


        internal static void Init(Form current)
        {
            end = false;
            form = current;
            FirstStep = true;
            ConfigureMapSize(current);
            InitButtons(current);           
        }

        static void ConfigureMapSize(Form current)
        {
            current.Width = Info.WidhtMap * Info.ButtonSize + 20;
            current.Height = (Info.HeightMap + 1) * Info.ButtonSize;
        }

        static void InitButtons(Form current)
        {
            for (int i = 0; i < Info.WidhtMap; i++)
            {
                for (int j = 0; j < Info.HeightMap; j++)
                {
                    ButtonExtended button = new ButtonExtended();
                    button.Location = new Point(j * Info.ButtonSize, i * Info.ButtonSize+Info.Menustrip);
                    button.Size = new Size(Info.ButtonSize, Info.ButtonSize);
                    if(Info.SPset == 2)
                        button.Image = FindImage(0, 0);
                    button.MouseUp += new MouseEventHandler(ButtonPressedMouse);
                    current.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private static void ButtonPressedMouse(object sender, MouseEventArgs e)
        {
            ButtonExtended pressedBtn = sender as ButtonExtended;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    RightButtonPressed(pressedBtn);
                    break;
                case MouseButtons.Left:
                    LeftButtonPressed(pressedBtn);
                    break;
                //case MouseButtons.Middle:
                //    MidButtonPressed(pressedBtn);
                //    break;
            } 
        }
        //private static void MidButtonPressed(ButtonExtended pressedBtn)
        //{
        //    int iButton = pressedBtn.Location.Y / Info.ButtonSize;
        //    int jButton = pressedBtn.Location.X / Info.ButtonSize;
        //    if (buttons[iButton, jButton].IsPressed && buttons[iButton, jButton].Status > 0)
        //    {
        //        if (CountFlags(iButton, jButton) == buttons[iButton, jButton].Status)
        //        {

        //        }
        //        else MessageBox.Show("Count flags = "+CountFlags(iButton, jButton));
        //    }
        //}

        private static void RightButtonPressed(ButtonExtended pressedBtn)
        {
            if (pressedBtn.IsPressed == false)
            {
                int posX = 0;
                int posY = 0;
                if (Info.SPset == 1)
                {
                    pressedBtn.CurrentPictureToSet++;
                    pressedBtn.CurrentPictureToSet %= 3;
                    switch (pressedBtn.CurrentPictureToSet)
                    {
                        case 0:
                            posX = 0;
                            posY = 0;
                            break;
                        case 1:
                            posX = 0;
                            posY = 2;
                            break;
                        case 2:
                            posX = 2;
                            posY = 2;
                            break;
                    }
                }
                else if (Info.SPset == 2)
                {
                    pressedBtn.CurrentPictureToSet++;
                    pressedBtn.CurrentPictureToSet %= 2;
                    switch (pressedBtn.CurrentPictureToSet)
                    {
                        case 0:
                            posX = 0;
                            posY = 0;
                            break;
                        case 1:
                            posX = 1;
                            posY = 0;
                            break;
                    }
                }
                pressedBtn.Image = FindImage(posX, posY);
            }
        }

        private static void LeftButtonPressed(ButtonExtended pressedBtn)
        {
            int iButton = pressedBtn.Location.Y / Info.ButtonSize;
            int jButton = pressedBtn.Location.X / Info.ButtonSize;
            if (!pressedBtn.IsPressed && buttons[iButton, jButton].CurrentPictureToSet == 0)
            {
                pressedBtn.IsPressed = true;
                //int iButton = pressedBtn.Location.Y / Info.ButtonSize;
                //int jButton = pressedBtn.Location.X / Info.ButtonSize;
                if (FirstStep)
                {
                    FirstCoord = new Point(iButton, jButton);
                    SeedMap();
                    CounCellBomb();
                    FirstStep = false;
                }
                OpenCel(iButton, jButton);
                if (buttons[iButton, jButton].Status == -1 && !end)
                {
                    end = true;
                    ShowAllBombs();
                    Info.win = false;
                    Win win = new Win();
                    win.Show();
                }
                    
            }
            if (CountPressed() == (Info.HeightMap * Info.WidhtMap - Info.Bomb) && !end)
            {
                end = true;
                ShowAllBombs();
                Info.win = true;
                Win win = new Win();
                win.Show();
            } 
            //dop
        }

        static int CountPressed()
        {
            int count = 0;
            for (int i = 0; i < Info.WidhtMap; i++)
            {
                for (int j = 0; j < Info.HeightMap; j++)
                {
                    if (buttons[i, j].IsPressed) count++;
                }
            }
            return count;
        }

        public static Image FindImage(int xPos, int yPos)
        {
            Image image = new Bitmap(Info.ButtonSize, Info.ButtonSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Info.SpriteSet, new Rectangle(new Point(0,0),new Size(Info.ButtonSize, Info.ButtonSize)), 0 + 32* xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);
            return image;
        }

        static void SeedMap()
        {
            Random r = new Random();
            Clean();
                for (int i = 0; i < Info.Bomb; i++)
                {
                    int posI = r.Next(0, Info.Size - 1);
                    int posJ = r.Next(0, Info.Size - 1);

                    while (buttons[posI, posJ].Status == -1 || (Math.Abs(posI - FirstCoord.X) <= 1 && Math.Abs(posJ - FirstCoord.Y) <= 1))
                    //while (map[posI, posJ] == -1 || (Math.Abs(posI - FirstCoord.Y) <= 1 && Math.Abs(posJ - FirstCoord.X) <= 1)) 
                    {
                        posI = r.Next(0, Info.Size - 1);
                        posJ = r.Next(0, Info.Size - 1);
                    }
                    buttons[posI, posJ].Status = -1;
                    map[posI, posJ] = -1;
                }
        }

        static void Clean()
        {
            for (int i = 0; i < Info.WidhtMap; i++)
            {
                for (int j = 0; j < Info.HeightMap; j++)
                {
                    buttons[i, j].Status = 0;
                }
            }
        }

        static void CounCellBomb()
        {
            for (int i = 0; i < Info.Size; i++)
            {
                for (int j = 0; j < Info.Size; j++)
                {
                    if(buttons[i, j].Status != -1)
                    //if (map[i, j] == -1)
                    //{
                    //    for (int k = i-1; k < i+2; k++)
                    //    {
                    //        for (int l = j-1; l < j+2; l++)
                    //        {
                    //            if (!IsInBorder(k, l) || buttons[k, l].Status == -1) continue;
                    //            //if (!IsInBorder(k, l) || map[k, l] == -1) continue;
                    //            buttons[k, l].Status += 1;
                    //            //map[k, l] = map[k, l]+1;
                    //        }
                    //    }
                    //}
                    {
                        buttons[i, j].Status = CountBomb(i, j);
                    }
                }
            }
        }
        //static void FlagRev(int x, int y)
        //{
        //    if (!IsInBorder(x, y)) return;
        //    if (buttons[x, y].IsPressed) return;
        //    buttons[x, y].IsPressed = true;
        //    FlagCel(x, y);
        //}
        //static void FlagCel(int x, int y)
        //{
        //    OpenCell(x, y);
        //    if (buttons[x, y].Status == 0)
        //    {
        //        FlagRev(x - 1, y - 1);
        //        FlagRev(x - 1, y + 1);
        //        FlagRev(x + 1, y - 1);
        //        FlagRev(x + 1, y + 1);
        //        FlagRev(x - 1, y);
        //        FlagRev(x + 1, y);
        //        FlagRev(x, y - 1);
        //        FlagRev(x, y + 1);
        //    }
        //}

        static void Reveal(int x, int y)
        {
            if (!IsInBorder(x,y)) return;
            if (buttons[x, y].IsPressed) return;
            buttons[x, y].IsPressed = true;
            OpenCel(x, y);
        }

        static void OpenCel(int x, int y)
        {
            OpenCell(x, y);
            if(buttons[x,y].Status == 0)
            {                
                Reveal(x - 1, y - 1);
                Reveal(x - 1, y + 1);
                Reveal(x + 1, y - 1);
                Reveal(x + 1, y + 1);
                Reveal(x - 1, y);
                Reveal(x + 1, y);
                Reveal(x, y - 1);
                Reveal(x, y + 1);
            }
        }

        static int CountBomb(int iB, int jB)
        {
            int count = 0;
            for (int i = iB-1; i <= iB+1; i++)
            {
                for (int j = jB-1; j <= jB+1; j++)
                {
                    if(i>=0 && j>=0 && i<Info.Size && j<Info.Size)
                        if(buttons[i,j].Status==-1)
                            count++;
                }
            }
            return count;
        }

        //static int CountFlags(int iB, int jB)
        //{
        //    int count = 0;
        //    for (int i = iB - 1; i <= iB + 1; i++)
        //    {
        //        for (int j = jB - 1; j <= jB + 1; j++)
        //        {
        //            if (i >= 0 && j >= 0 && i < Info.Size && j < Info.Size)
        //                if (buttons[i, j].CurrentPictureToSet == 1)
        //                    count++;
        //        }
        //    }
        //    return count;
        //}

        static void OpenCell(int i, int j)
        {
            try { buttons[i, j].IsPressed = true; } catch { MessageBox.Show("i " + i + " j " + j); }
            if(Info.SPset == 1) {
                switch (buttons[i, j].Status)
                //switch (map[i, j])
                {
                    case 1:
                        buttons[i, j].Image = FindImage(1, 0);
                        break;
                    case 2: 
                        buttons[i, j].Image = FindImage(2, 0);
                        break;
                    case 3:
                        buttons[i, j].Image = FindImage(3, 0);
                        break;
                    case 4:
                        buttons[i, j].Image = FindImage(4, 0);
                        break;
                    case 5:
                        buttons[i, j].Image = FindImage(0, 1);
                        break;
                    case 6:
                        buttons[i, j].Image = FindImage(1, 1);
                        break;
                    case 7:
                        buttons[i, j].Image = FindImage(2, 1);
                        break;
                    case 8:
                        buttons[i, j].Image = FindImage(3, 1);
                        break;
                    case -1:
                        buttons[i, j].Image = FindImage(1, 2);
                        break;
                    case 0:
                        buttons[i, j].Image = FindImage(0, 0);
                        break;
                    case -2:
                        buttons[i, j].Image = FindImage(3, 2);
                        break;
                }
            }
            else if(Info.SPset == 2)
            {
                switch (buttons[i, j].Status)
                {
                    case 1:
                        buttons[i, j].Image = FindImage(0, 1);
                        break;
                    case 2:
                        buttons[i, j].Image = FindImage(1, 1);
                        break;
                    case 3:
                        buttons[i, j].Image = FindImage(2, 1);
                        break;
                    case 4:
                        buttons[i, j].Image = FindImage(3, 1);
                        break;
                    case 5:
                        buttons[i, j].Image = FindImage(0, 2);
                        break;
                    case 6:
                        buttons[i, j].Image = FindImage(1, 2);
                        break;
                    case 7:
                        buttons[i, j].Image = FindImage(2, 2);
                        break;
                    case 8:
                        buttons[i, j].Image = FindImage(3, 2);
                        break;
                    case -1:
                        buttons[i, j].Image = FindImage(2, 0);
                        break;
                    case 0:
                        buttons[i, j].Image = FindImage(3, 0);
                        break;
                    case -2:
                        buttons[i, j].Image = FindImage(2, 0);
                        break;
                }
            }
        }

        static void OpenCells(int i, int j)
        {
            OpenCell(i, j);
            if (buttons[i, j].Status > 0) return;
            //if (map[i, j] > 0) return;
            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l)) continue;
                    if (buttons[k, l].IsPressed) continue;
                    if (buttons[k, l].Status == 0) OpenCells(k, l);
                    //if (map[k, l] == 0) OpenCells(k, l);
                    else if (buttons[k, l].Status > 0) OpenCell(k, l);
                    //else if (map[k, l] > 0) OpenCell(k, l);
                }
            }
        }

        static bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > Info.Size - 1 || i > Info.Size - 1)
            {
                return false;
            }
            else return true;
        }

        internal static void ShowAll()
        {
            for (int i = 0; i < Info.WidhtMap; i++)
            {
                for (int j = 0; j < Info.HeightMap; j++)
                {
                    OpenCell(i, j);
                }
            }
        }

        static void ShowAllBombs()
        {
            for (int i = 0; i < Info.WidhtMap; i++)
            {
                for (int j = 0; j < Info.HeightMap; j++)
                {
                    if (buttons[i, j].Status == -1 && buttons[i, j].CurrentPictureToSet == 1)
                    {
                        OpenCell(i, j);
                    }
                    else if(buttons[i, j].Status == -1)
                    {
                        buttons[i, j].Status = -2;
                        OpenCell(i, j);
                    }
                }
            }
        }
    }

    class ButtonExtended: Button
    {
        internal int CurrentPictureToSet=0;
        internal int Status = 0;//kolvo min, -1 = mina
        internal bool IsPressed = false;
    }
}
