using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper
{
    static class Info
    {
        static internal Image SpriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\1.png"));
        static internal string UserName = "User";
        static internal string Diff = "Easy";
        static internal int Size = 20;
        static internal int Bomb = 35;
        static internal int ButtonSize = 38;
        static internal int SPset = 1;
        static internal int Menustrip = 24;
        static internal int WidhtMap = 20;
        static internal int HeightMap = 20;
        static internal bool win = false;
    }
}
