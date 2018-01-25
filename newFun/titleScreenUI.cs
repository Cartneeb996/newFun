using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newFun
{
    public partial class titleScreenUI : Form
    {
        
        //inGame inGameForm = new inGame();
        public titleScreenUI()
        {
            InitializeComponent();
            rightSideTank.Size = new Size(rightSideTank.Width * 2, rightSideTank.Height * 2);
            leftSideTank.Size = new Size(leftSideTank.Width * 2, leftSideTank.Height * 2);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            gameTitleLabel.Size = new Size(Width, gameTitleLabel.Height);
            gameTitleLabel.Location = new Point(gameTitleLabel.Location.X, gameTitleLabel.Location.Y + 50);
            rightSideTank.Location = new Point(this.Width * 2 / 3, this.Height - rightSideTank.Height - 38);
            leftSideTank.Location = new Point(this.Width / 3 - leftSideTank.Width, this.Height - rightSideTank.Height - 38);
            startButton.Location = new Point(this.Width / 2 - startButton.Width / 2, rightSideTank.Location.Y);
            tutorialButton.Location = new Point(startButton.Location.X, startButton.Location.Y - 150);
        }

        public void Maximize()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            variables.isStartup = false;
            inGame form = new inGame();
            form.Show();
            form.Maximize();            
            Close();      
        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            tutorial form = new tutorial();
            form.Show();
            form.Maximize();
            Close();
        }
    }
}
