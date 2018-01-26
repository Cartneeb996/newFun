using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace newFun
{
    public partial class titleScreen : UserControl
    {
        //modes
        //easy: cpu health = 50
        //normal: cpu health = 100
        //expert: cpu health = 150

        public titleScreen()
        {
            InitializeComponent();
            // init sound and images
            variables.TMPlayer.Open(new Uri(Application.StartupPath + "/Resources/title_background_music.mp3"));
            variables.TMPlayer.Stop();
            variables.TMPlayer.Play();
            defaultOverride();

            rightSideTank.Size = new Size(rightSideTank.Width * 2, rightSideTank.Height * 2);
            leftSideTank.Size = new Size(leftSideTank.Width * 2, leftSideTank.Height * 2);
        }
        private void TMPlayer_MediaEnded(object sender, EventArgs e)
        {
            variables.TMPlayer.Open(new Uri(Application.StartupPath + "/Resources/title_background_music.mp3"));
            variables.TMPlayer.Stop();
            variables.TMPlayer.Play();
            //loops music
        }

        private void startButton_Click(object sender, EventArgs e) // displays the mode btns
        {
            startButton.Visible = false;
            tutorialButton.Visible = false;
            easyButton.Location = tutorialButton.Location;
            easyButton.Visible = true;
            normalButton.Location = new Point(startButton.Location.X, (startButton.Location.Y + tutorialButton.Location.Y + startButton.Height - 60)/2);
            normalButton.Visible = true;
            expertButton.Location = startButton.Location;
            expertButton.Visible = true;
        }

        private void tutorialButton_Click(object sender, EventArgs e)
        {
            screenControl.changeScreen(this, "TutorialScreen");
            variables.TMPlayer.Stop();
        }
        public void defaultOverride()
        {
            foreach (Control c in this.Controls)
            {
                c.Location = new Point(c.Location.X, c.Location.Y + 75);
            }
        }

        private void titleScreen_Resize(object sender, EventArgs e) // fit ui to screen
        {
            gameTitleLabel.Size = new Size(Width, gameTitleLabel.Height);
            gameTitleLabel.Location = new Point(gameTitleLabel.Location.X - 30, gameTitleLabel.Location.Y + 50);
            rightSideTank.Location = new Point(this.Width * 2 / 3, this.Height - rightSideTank.Height - 38);
            leftSideTank.Location = new Point(this.Width / 3 - leftSideTank.Width, this.Height - rightSideTank.Height - 38);
            startButton.Location = new Point(this.Width / 2 - startButton.Width / 2, rightSideTank.Location.Y);
            tutorialButton.Location = new Point(startButton.Location.X, startButton.Location.Y - 150);
        }

        private void normalButton_Click(object sender, EventArgs e)
        {
            variables.mode = "normal";
            screenControl.changeScreen(this, "GameScreen");
            variables.TMPlayer.Stop();
        }

        private void expertButton_Click(object sender, EventArgs e)
        {
            variables.mode = "expert";
            screenControl.changeScreen(this, "GameScreen");
            variables.TMPlayer.Stop();
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            variables.mode = "easy";
            screenControl.changeScreen(this, "GameScreen");
            variables.TMPlayer.Stop();
        }
    }
}
