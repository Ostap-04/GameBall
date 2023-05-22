using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace GameBall
{
    public class Game
    { 
        public List<Gamer> AllGamers = new List<Gamer>();
        public Gamer CurGamer { get; set; }
        public int BestOfAllGamersScores { get; set; }
        public int CreationInterval { get; set; }
        public int PenaltyLimit { get; set; }
        public int AmountOfBalls { get; set; }
        public string FilePath = "..\\..\\gamers.txt";
        public Timer MainTimer = new Timer();

        public Game() 
        {
            AmountOfBalls = 0;
            PenaltyLimit = -50;
            CreationInterval = 2000;
            ReadFromFile(FilePath);
        }
        public Game(int penaltyLimit, string gamerName) 
        {
            AmountOfBalls = 0;
            PenaltyLimit = penaltyLimit;
            CurGamer = new Gamer(gamerName);
            CreationInterval = 2000;
            ReadFromFile(FilePath);
        }

        public Game(string gamerName)
        {
            AmountOfBalls = 0;
            PenaltyLimit = -50;
            CurGamer = new Gamer(gamerName);
            CreationInterval = 2000;
            ReadFromFile(FilePath);
        }

        public void ReadFromFile(string filePath)
        {
            AllGamers.Clear();
            string[] data = File.ReadAllLines(filePath);
            BestOfAllGamersScores = int.MinValue;
            for (int i = 0; i<data.Length; i++)
            {
                string[] gamer = data[i].Split(',');
                AllGamers = AllGamers.Append(new Gamer(gamer[0], int.Parse(gamer[1]), DateTime.Parse(gamer[2]))).ToList();
            }
            
            AllGamers.Sort();
            AllGamers.Reverse();
            if (AllGamers.Count != 0)
                BestOfAllGamersScores = AllGamers[0].BestScore;
            else
                BestOfAllGamersScores = 0;
        }

        public void WriteToFile(string filePath)
        {
            string[] data = { };
            AllGamers.Sort();
            AllGamers.Reverse();
            foreach (Gamer gamer in AllGamers)
            {
                if (gamer.Name == CurGamer.Name && CurGamer.Score > CurGamer.BestScore)
                {
                    gamer.BestScore = CurGamer.Score;
                    gamer.BestTryDateTime = CurGamer.BestTryDateTime;
                }
                if (gamer.Name == CurGamer.Name && gamer.BestTryDateTime == DateTime.MinValue)
                {
                    gamer.BestTryDateTime = CurGamer.BestTryDateTime;
                }
                data = data.Append($"{gamer.Name},{gamer.BestScore},{gamer.BestTryDateTime}").ToArray();
            }
            File.WriteAllLines(filePath, data);
        }
    }
}
