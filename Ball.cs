using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBall
{
    public class Ball : PictureBox
    {
        public Color BColor;
        public int Size { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Dictionary<Color, int> ColorPrices = new Dictionary<Color, int>(){
            {Color.Red, 10 },
            {Color.Yellow, 5 },
            {Color.Blue, 0 },
            {Color.Green, -20 },
        };
        readonly Random random = new Random();

        public Ball(int ClientSizeWidth, int ClientSizeHeight)
        {
            int Size = random.Next(30, 80);
            int X = random.Next(0, ClientSizeWidth - Size);
            int Y = random.Next(0, ClientSizeHeight - Size - 26);
            Width = Size;
            Height = Size;
            BColor = GetRandomColor(ColorPrices);
            BackColor = BColor;
            Location = new Point(X, Y);
            Cursor = Cursors.Hand;

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, Size, Size);
            Region = new Region(path);
        }

        private Color GetRandomColor(Dictionary<Color, int> myDict)
        {
            Color[] mycolors= myDict.Keys.ToArray();
            return mycolors[random.Next(myDict.Count)];
        }
    }
}
