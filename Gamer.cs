using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GameBall
{
    public class Gamer: IComparable
    {
        public string Name { get; set; }
        public int Score {get; set;}
        public int BestScore { get; set; }
        public bool IsNew { get; set; }
        public bool Verified { get; set; } = false;
        public DateTime BestTryDateTime { get; set; }

        public Gamer()
        {
            Name= string.Empty;
            Score= 0;
            BestScore= 0;
            IsNew= true;
            BestTryDateTime = DateTime.Now;
        }

        public Gamer(string name)
        {
            Name = name;
            Score = 0;
            IsNew = true;
            string[] data = File.ReadAllLines("..\\..\\gamers.txt");
            foreach (string line in data)
            {
                string[] temp = line.Split(',');
                if (temp[0] == name)
                {
                    BestScore = int.Parse(temp[1]);
                    BestTryDateTime = DateTime.Now;
                    IsNew = false;
                }
            }
            if (IsNew == true)
            {
                BestScore = 0;
                data = data.Append($"{name},{BestScore},{BestTryDateTime}").ToArray();
                File.WriteAllLines("..\\..\\gamers.txt", data);
                BestTryDateTime = DateTime.Now;
            }
        }

        public Gamer(string name, int bestScore, DateTime bestTry)
        {
            Name = name;
            BestScore = bestScore;
            BestTryDateTime = bestTry;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Cur score: {Score}, Best Score: {BestScore}, {IsNew}, Best Date Time Try: {BestTryDateTime}";
        }

        public static bool operator <(Gamer left, Gamer right)
        {
            return left.BestScore < right.BestScore;
        }

        public static bool operator >(Gamer left, Gamer right)
        {
            return left.BestScore > right.BestScore;
        }

        public int CompareTo(object obj)
        {
            Gamer g = obj as Gamer;
            if (g != null)
            {
                if (this.BestScore < g.BestScore) return -1;
                else if (this.BestScore > g.BestScore) return 1;
                else return 0;
            }
            throw new ArgumentException("Not gamer");
        }
    }
}
