using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace newFun
{
    public partial class endScreen : UserControl
    {
        SoundPlayer defeat = new SoundPlayer(Properties.Resources.defeat_wav);
        SoundPlayer victory = new SoundPlayer(Properties.Resources.victory_wav);
        public endScreen()
        {
            InitializeComponent();
            if(variables.victory)
            {
                BackgroundImage = Properties.Resources.victory;
                endGameLabel.Text = "Congratz!\nYou Win";
                victory.Play();
            }
            else
            {
                BackgroundImage = Properties.Resources.defeat;
                endGameLabel.Text = "Defeat\nYou Lose";
                defeat.Play();
            }
        }

        private void endScreen_Resize(object sender, EventArgs e)
        {
            endGameLabel.Location = new Point(Width / 2 - endGameLabel.Width /2, Height / 2 - endGameLabel.Height/2);
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            screenControl.changeScreen(this, "TitleScreen");
        }
    }
}
