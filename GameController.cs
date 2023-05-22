using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameBall
{
    public partial class GameController : Form
    {
        private Game game;

        public GameController()
        {
            InitializeComponent();
            ScoreStatusStrip.Visible = false;
            RulesButton.Visible = false;
            GamersListButton.Visible = true;
            ReturnButton.Visible = false;
            GameTextBox.Visible = true;
            GameTextBox.Font = new Font("TimesNewRoman", 12, FontStyle.Regular);
            GameTextBox.Text = " У випадкових місцях у межах вікна з'являються різноколірні кружечки на нетривалий період. " +
                "За цей час потрібно клацнути на них мишкою. За кожне попадання нараховують очки, за кожен пропущений кружечок нараховують штраф: -10. " +
                "\r\nГра завершується, коли штраф досягає певного значення: -50. \r\nРізна ціна кульок: червона - 10, жовта - 5, синя - 0, зелена - (-20), її збивати заборонено.\r\n" +
                "Поступово збільшується складність гри кожні 5 кульок, інтервал появи зменшується\r\n Удачі!!!!";
            game = new Game();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GenerateBall();
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            Ball ball = (Ball)sender;
            game.CurGamer.Score += ball.ColorPrices[ball.BackColor];
            Controls.Remove(ball);
            CurScoreLabel.Text = $"Поточні очки: {game.CurGamer.Score}";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            InputBox();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            game.MainTimer.Stop();
            foreach (var control in Controls)
            {
                if (control is Ball)
                    Controls.Remove(control as Ball);
            }
            if (game.CurGamer.Score < 0)
                MessageBox.Show($"Гра закінчена!\nОтримано очків: 0");
            else
                MessageBox.Show($"Гра закінчена!\nОтримано очків: {game.CurGamer.Score}");
            ScoreStatusStrip.Visible = false;
            RulesButton.Visible = false;
            GamersListButton.Visible = true;
            ReturnButton.Visible = false;
            GameTextBox.Visible = true;
            StartButton.Visible = true;
            game.CurGamer.Verified = true;
            game.WriteToFile(game.FilePath);
            game.ReadFromFile(game.FilePath);
            GameTextBox.Text = "";
            foreach (Gamer gamer in game.AllGamers)
            {
                GameTextBox.AppendText($"Ім'я: {gamer.Name}, Найкращий результат: {gamer.BestScore}, Дата і час найкращого результату: {gamer.BestTryDateTime}\r\n\r\n");
            }
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            GameTextBox.Text = " У випадкових місцях у межах вікна з'являються різноколірні кружечки на нетривалий період. " +
                "За цей час потрібно клацнути на них мишкою. За кожне попадання нараховують очки, за кожен пропущений кружечок нараховують штраф: -10. " +
                "\r\nГра завершується, коли штраф досягає певного значення: -50. \r\nРізна ціна кульок: червона - 10, жовта - 5, синя - 0, зелена - (-20), її збивати заборонено.\r\n" +
                "Поступово збільшується складність гри кожні 5 кульок, інтервал появи зменшується\r\n Удачі!!!!";
            GameTextBox.Select(0, 0);
            RulesButton.Visible = false;
            GamersListButton.Visible = true;
        }

        private void GamersListButton_Click(object sender, EventArgs e)
        {
            game.ReadFromFile(game.FilePath);
            GameTextBox.Text = "";
            foreach (Gamer gamer in game.AllGamers)
            {
                GameTextBox.AppendText($"Ім'я: {gamer.Name}, Найкращий результат: {gamer.BestScore}, Дата і час найкращого результату: {gamer.BestTryDateTime}\r\n\r\n");
            }
            GameTextBox.Select(0, 0);
            GamersListButton.Visible = false;
            RulesButton.Visible = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (game.CurGamer != null)
                game.WriteToFile(game.FilePath);
            base.OnFormClosing(e);
        }

        private void GenerateBall()
        {
            if (game.CurGamer.Score <= game.PenaltyLimit)
                GameOver();
            if (game.AmountOfBalls % 5 == 0)
            {
                if (game.MainTimer.Interval != 500)
                    game.MainTimer.Interval -= 100;
            }
            Ball ball = new Ball(ClientSize.Width, ClientSize.Height);
            game.AmountOfBalls += 1;
            ball.Click += Ball_Click;

            Controls.Add(ball);
            game.MainTimer.Tick += (sender, e) =>
            {
                if (Controls.Contains(ball))
                {
                    Controls.Remove(ball);
                    if (ball.BColor != Color.Green)
                        game.CurGamer.Score -= 10;
                }
                CurScoreLabel.Text = $"Поточні очки: {game.CurGamer.Score}";
            };
        }

        private void InputBox()
        {
            Form myInpytBox = new Form();
            myInpytBox.Width = 250;
            myInpytBox.Height = 200;
            myInpytBox.Text = "Увійти";
            Label InputBoxTextLabel = new Label() { Left = 50, Top = 20, Text = "Введіть ім'я:" };
            TextBox InputBoxTextBox = new TextBox() { Left = 50, Top = 50, Width = 100 };
            Button ConfirmButton = new Button() { Text = "Підтвердити", Left = 50, Width = 100, Top = 100 };
            ConfirmButton.Click += (sender, e) => {
                game = new Game(InputBoxTextBox.Text);
                ScoreStatusStrip.Visible = true;
                RulesButton.Visible = false;
                GamersListButton.Visible = false;
                ReturnButton.Visible = true;
                GameTextBox.Visible = false;
                StartButton.Visible = false;
                CurScoreLabel.Text = $"Поточні очки: {game.CurGamer.Score}";
                GamerBestScoreLabel.Text = $"Ваш найкращий результат: {game.CurGamer.BestScore}";
                BestOfAllScoresLabel.Text = $"Найкращий з усіх гравців результат: {game.BestOfAllGamersScores}";
                game.MainTimer.Tick += Timer_Tick;
                game.MainTimer.Interval = game.CreationInterval;
                myInpytBox.Close();
                game.MainTimer.Start();
            };
            myInpytBox.Controls.Add(ConfirmButton);
            myInpytBox.Controls.Add(InputBoxTextLabel);
            myInpytBox.Controls.Add(InputBoxTextBox);
            myInpytBox.ShowDialog();
        }

        private void GameOver()
        {
            game.MainTimer.Stop();
            foreach (var control in Controls)
            {
                if (control is Ball)
                    Controls.Remove(control as Ball);
            }
            game.WriteToFile(game.FilePath);
            MessageBox.Show($"Гра закінчена!\nОтримано очків: 0");
            Close();
        }
    }
}
