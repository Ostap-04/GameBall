namespace GameBall
{
    partial class GameController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.ScoreStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CurScoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GamerBestScoreLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.BestOfAllScoresLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RulesButton = new System.Windows.Forms.Button();
            this.GamersListButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.GameTextBox = new System.Windows.Forms.TextBox();
            this.ScoreStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(552, 132);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(151, 47);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Увійти";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ScoreStatusStrip
            // 
            this.ScoreStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ScoreStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurScoreLabel,
            this.GamerBestScoreLabel,
            this.BestOfAllScoresLabel});
            this.ScoreStatusStrip.Location = new System.Drawing.Point(0, 424);
            this.ScoreStatusStrip.Name = "ScoreStatusStrip";
            this.ScoreStatusStrip.Size = new System.Drawing.Size(800, 26);
            this.ScoreStatusStrip.TabIndex = 2;
            this.ScoreStatusStrip.Visible = false;
            // 
            // CurScoreLabel
            // 
            this.CurScoreLabel.Name = "CurScoreLabel";
            this.CurScoreLabel.Size = new System.Drawing.Size(109, 20);
            this.CurScoreLabel.Text = "Поточні очки: ";
            // 
            // GamerBestScoreLabel
            // 
            this.GamerBestScoreLabel.Name = "GamerBestScoreLabel";
            this.GamerBestScoreLabel.Size = new System.Drawing.Size(200, 20);
            this.GamerBestScoreLabel.Text = "Ваш найкращий результат: ";
            // 
            // BestOfAllScoresLabel
            // 
            this.BestOfAllScoresLabel.Name = "BestOfAllScoresLabel";
            this.BestOfAllScoresLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BestOfAllScoresLabel.Size = new System.Drawing.Size(265, 20);
            this.BestOfAllScoresLabel.Text = "Найкращий з усіх гравців результат: ";
            // 
            // RulesButton
            // 
            this.RulesButton.Location = new System.Drawing.Point(552, 234);
            this.RulesButton.Name = "RulesButton";
            this.RulesButton.Size = new System.Drawing.Size(151, 46);
            this.RulesButton.TabIndex = 3;
            this.RulesButton.Text = "Правила гри";
            this.RulesButton.UseVisualStyleBackColor = true;
            this.RulesButton.Click += new System.EventHandler(this.RulesButton_Click);
            // 
            // GamersListButton
            // 
            this.GamersListButton.Location = new System.Drawing.Point(552, 234);
            this.GamersListButton.Name = "GamersListButton";
            this.GamersListButton.Size = new System.Drawing.Size(151, 46);
            this.GamersListButton.TabIndex = 4;
            this.GamersListButton.Text = "Список гравців";
            this.GamersListButton.UseVisualStyleBackColor = true;
            this.GamersListButton.Click += new System.EventHandler(this.GamersListButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(0, 0);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(115, 28);
            this.ReturnButton.TabIndex = 5;
            this.ReturnButton.Text = "Повернутись";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // GameTextBox
            // 
            this.GameTextBox.Location = new System.Drawing.Point(0, 0);
            this.GameTextBox.Multiline = true;
            this.GameTextBox.Name = "GameTextBox";
            this.GameTextBox.ReadOnly = true;
            this.GameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.GameTextBox.Size = new System.Drawing.Size(457, 421);
            this.GameTextBox.TabIndex = 6;
            // 
            // GameController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameTextBox);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.GamersListButton);
            this.Controls.Add(this.RulesButton);
            this.Controls.Add(this.ScoreStatusStrip);
            this.Controls.Add(this.StartButton);
            this.Name = "GameController";
            this.Text = "Гра";
            this.ScoreStatusStrip.ResumeLayout(false);
            this.ScoreStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.StatusStrip ScoreStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel CurScoreLabel;
        private System.Windows.Forms.ToolStripStatusLabel GamerBestScoreLabel;
        private System.Windows.Forms.ToolStripStatusLabel BestOfAllScoresLabel;
        private System.Windows.Forms.Button RulesButton;
        private System.Windows.Forms.Button GamersListButton;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.TextBox GameTextBox;
    }
}

