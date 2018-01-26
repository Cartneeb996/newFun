using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Media;

namespace newFun
{
    public partial class tutorialScreen : UserControl
    {
        #region variables
        const int cpuIndex = 7;
        const int playerIndex = 8;

        Random rndGen = new Random();

        bool willDestroy = false;
        bool willCounterDestroy = false;
        bool targetSelected = false;
        bool movebackAnim = false;
        bool animationDone = false;
        bool EmovebackAnim = false;
        bool EanimationDone = false;
        bool isAnimationComplete = false;
        bool hasPlayerSelected;

        RadioButton btn;
        RadioButton Ebtn;

        int tutorialStep = 0;
        int turnCounter = 1;
        int waitCount;
        int flickerIndex = 0;
        int waitECount;
        int index = 0;
        int Eindex = 0;
        int xStart = 0;
        int yStart;
        int xStop;
        int yStop;
        int xEStart;
        int yEStart;
        int xEStop;
        int yEStop;
        int targetInt;
        int cpuTarget;

        Point cpuP;
        Point textStartPoint;
        Point textStopPoint;

        Graphics offScreen;
        Graphics gGraphics;

        Bitmap bm;
        Bitmap Bazooka;
        Bitmap Hvy;
        Bitmap Md;
        Bitmap Lt;
        Bitmap Soldier;
        Bitmap Sniper;
        Bitmap imgPlayerChoice;
        Bitmap imgCpuChoice;
        Bitmap fire = new Bitmap(Properties.Resources.redComet, 50, 50);
        Bitmap Efire = new Bitmap(Properties.Resources.redComet, 50, 50);

        System.Windows.Media.MediaPlayer BMPlayer;
        SoundPlayer attack = new SoundPlayer(Properties.Resources.Tank_Firing);
        #endregion variables

        #region init
        public tutorialScreen()
        {
            InitializeComponent();

            BMPlayer = new System.Windows.Media.MediaPlayer();
            BMPlayer.Open(new Uri(Application.StartupPath + "/Resources/battle_music.mp3"));
            BMPlayer.Stop();
            BMPlayer.Play();

            // set up background music ^
            // inititalize graphics \/

            xStart = -100;
            xStop = 50;
            Efire.RotateFlip(RotateFlipType.Rotate180FlipY);
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm);
            gGraphics = this.CreateGraphics();
            Bazooka = new Bitmap(Properties.Resources.BazookaIcon, Properties.Resources.ATIcon.Width / 2, fire.Height);
            Hvy = new Bitmap(Properties.Resources.HvyIcon, Properties.Resources.ATIcon.Size);
            Lt = new Bitmap(Properties.Resources.LtIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Md = new Bitmap(Properties.Resources.MdIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Soldier = new Bitmap(Properties.Resources.SoldierIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Sniper = new Bitmap(Properties.Resources.SniperIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
        }

        private void tutorial_Resize(object sender, EventArgs e)
        {
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm);
            gGraphics = this.CreateGraphics();

            // set up graphics ^
            // adjust ui to screen \/

            xEStop = this.Width - 300;
            cpuP = new Point(this.Width - cpuUnits.Width - 15, playerUnits.Location.Y);
            cpuUnits.Location = cpuP;
            cpuSoldierHealth.Location = new Point(this.Width - cpuSoldierHealth.Width - 125, cpuSoldierHealth.Location.Y);
            cpuSniperHealth.Location = new Point(this.Width - cpuSniperHealth.Width - 125, cpuSniperHealth.Location.Y);
            cpuBazookaHealth.Location = new Point(this.Width - cpuBazookaHealth.Width - 125, cpuBazookaHealth.Location.Y);
            cpuLtHealth.Location = new Point(this.Width - cpuLtHealth.Width - 125, cpuLtHealth.Location.Y);
            cpuMdHealth.Location = new Point(this.Width - cpuMdHealth.Width - 125, cpuMdHealth.Location.Y);
            cpuHvyHealth.Location = new Point(this.Width - cpuHvyHealth.Width - 125, cpuHvyHealth.Location.Y);
            cpuATHealth.Location = new Point(this.Width - cpuATHealth.Width - 125, cpuATHealth.Location.Y);
            tutorialTextLabel.Location = new Point(Width / 2 - tutorialTextLabel.Width / 2, Height / 2 - tutorialTextLabel.Height / 2);
            continueButton.Location = new Point(tutorialTextLabel.Location.X + tutorialTextLabel.Width / 2 - continueButton.Width / 2, tutorialTextLabel.Location.Y + 200);
            topPanel.Size = new Size(screenControl.screenWidth, tutorialTextLabel.Location.Y + tutorialTextLabel.Height);
            topPanel.Location = new Point(0, 0);
            attackButton.Location = new Point(tutorialTextLabel.Location.X + tutorialTextLabel.Width / 2 - attackButton.Width / 2 - 10, (playerUnits.Location.Y + playerUnits.Height + attackButton.Height) / 2);

            // clear the troop selections and health labels from screen \/

            clearUi(true);
        }
        #endregion init

        #region userResponse
        private void troopSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = getCheckedIndex(playerUnits, sender); // finds the radio button pressed

            //assigns the radio button to btn to be used later \/

            switch (index)
            {
                case 0:
                    btn = SoldierButton;
                    break;
                case 1:
                    btn = SniperButton;
                    break;
                case 2:
                    btn = BazookaButton;
                    break;
                case 3:
                    btn = LtButton;
                    break;
                case 4:
                    btn = MdButton;
                    break;
                case 5:
                    btn = HvyButton;
                    break;
                case 6:
                    btn = AntiTankButton;
                    break;
            }

            targetInt = index;

            // checks what step the tutorial is at \/

            if (tutorialStep == 4)
            {
                if (targetInt == 0)
                {
                    hasPlayerSelected = true;
                    tutorialTimer.Enabled = true;
                    tutorialStep++;
                }
                else
                {
                    tutorialTextLabel.Text = "Thats not a soldier!";
                }
            }
        }

        private void cpuUnits_SelectedValueChanged(object sender, EventArgs e)
        {
            cpuTarget = getCheckedIndex(cpuUnits, sender); // finds the radio button selected
            int index = cpuTarget;

            // assigns the radio button to Ebtn for later use \/

            switch (index)
            {
                case 0:
                    Ebtn = cpuSoldierButton;
                    break;
                case 1:
                    Ebtn = cpuSniperButton;
                    break;
                case 2:
                    Ebtn = cpuBazookaButton;
                    break;
                case 3:
                    Ebtn = cpuLtButton;
                    break;
                case 4:
                    Ebtn = cpuMdButton;
                    break;
                case 5:
                    Ebtn = cpuHvyButton;
                    break;
                case 6:
                    Ebtn = cpuAntiTankButton;
                    break;
            }

            targetSelected = true;

            // if the player has selected the target advance \/

            if (targetSelected && hasPlayerSelected)
            {
                if (cpuTarget == 0)
                {
                    tutorialStep++;
                    attackButton.Visible = true;
                    attackButton.Enabled = false;
                }
                else
                {
                    tutorialTextLabel.Text = "Thats not a soldier!";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // attack button click
        {
            clearUi(true);
            resetAnim();
            playerSoldierHealth.Text = "82";
            cpuSoldierHealth.Text = "25";
            btn.Checked = false;
            Ebtn.Checked = false;
            turnCounter++;
            animationTimer.Enabled = true;
            attackButton.Visible = false;
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            tutorialStep++;
        }
        #endregion userResponse

        #region animation
        private void timer1_Tick(object sender, EventArgs e)
        {
            // animations for player and cpu \/

            if (tutorialStep == 11)
            {
                animation(Hvy, Bazooka, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, false, false, false);
            }
            else
            {
                animation(Soldier, Soldier, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, true, false, false);
            }

            gGraphics.DrawImage(bm, 0, 0);
            offScreen.DrawImage(BackgroundImage, 0, 0, Width, Height);

            //clear graphics ^
        }

        private void animation(Bitmap image, Bitmap Eimage, int imgHeight, int imgEHeight, bool isYourTurn, bool isDestruction, bool isCounterDestruction)
        {
            // this deals with drawing the images and animating them, this is called by a timer to create the animation \/
            // animationDone: player portion of the anim
            // EanimationDone: cpu portion of anim
            // isAnimationComplete: is entire anim done
            // movebackanim: the recoil anim from firing

            yStart = this.Height - imgHeight;
            yEStart = this.Height - imgEHeight;

            if (isYourTurn)
            {
                if (!animationDone)
                {
                    if (!movebackAnim)
                    {
                        if (xStart != xStop)
                        {
                            if (xStart < xStop)
                            {
                                xStart += 5;
                            }

                            if (xStart > xStop)
                            {
                                xStart -= 5;
                            }
                        }

                        if (yStart != yStop)
                        {
                            if (yStart < yStop)
                            {
                                yStart++;
                            }

                            if (yStart > yStop)
                            {
                                yStart--;
                            }
                        }
                    }

                    if (xStart == xStop)
                    {
                        movebackAnim = true;
                        waitCount++;
                    }

                    if (movebackAnim && EmovebackAnim && waitCount > 10)
                    {
                        xStart -= 10;
                        index++;

                        if(index == 1)
                        {
                            attack.Play();
                        }

                        if (index > 3)
                        {
                            movebackAnim = false;
                            animationDone = true;
                        }
                    }
                }

                if (!EanimationDone)
                {
                    if (!EmovebackAnim)
                    {
                        if (xEStart != xEStop)
                        {
                            if (xEStart < xEStop)
                            {
                                xEStart += 5;
                            }

                            if (xEStart > xEStop)
                            {
                                xEStart -= 5;
                            }
                        }

                        if (yEStart != yEStop)
                        {

                            if (yEStart < yEStop)
                            {
                                yEStart++;
                            }

                            if (yEStart > yEStop)
                            {
                                yEStart--;
                            }
                        }
                    }

                    if (xEStart == xEStop)
                    {
                        EmovebackAnim = true;
                    }

                    if (animationDone)
                    {
                        waitECount++;
                    }

                    if (EmovebackAnim && animationDone && waitECount > 10 && !isDestruction)
                    {
                        xEStart += 10;
                        Eindex++;

                        if (Eindex == 1)
                        {
                            attack.Play();
                        }

                        if (Eindex > 3)
                        {
                            EmovebackAnim = false;
                            EanimationDone = true;
                        }
                    }

                }
            }
            else
            {
                if (!EanimationDone)
                {
                    if (!EmovebackAnim)
                    {
                        if (xEStart != xEStop)
                        {
                            if (xEStart < xEStop)
                            {
                                xEStart += 5;
                            }

                            if (xEStart > xEStop)
                            {
                                xEStart -= 5;
                            }
                        }

                        if (yEStart != yEStop)
                        {
                            if (yEStart < yEStop)
                            {
                                yEStart++;
                            }

                            if (yEStart > yEStop)
                            {
                                yEStart--;
                            }
                        }
                    }

                    if (xEStart == xEStop)
                    {
                        EmovebackAnim = true;
                        waitECount++;
                    }

                    if (EmovebackAnim && movebackAnim && waitECount > 10)
                    {
                        xEStart += 10;

                        Eindex++;

                        if (Eindex == 1)
                        {
                            attack.Play();
                        }

                        if (Eindex > 3)
                        {
                            EmovebackAnim = false;
                            EanimationDone = true;
                        }
                    }
                }

                if (!animationDone)
                {
                    if (!movebackAnim)
                    {
                        if (xStart != xStop)
                        {

                            if (xStart < xStop)
                            {
                                xStart += 5;
                            }

                            if (xStart > xStop)
                            {
                                xStart -= 5;
                            }
                        }

                        if (yStart != yStop)
                        {
                            if (yStart < yStop)
                            {
                                yStart++;
                            }

                            if (yStart > yStop)
                            {
                                yStart--;
                            }
                        }
                    }

                    if (xStart == xStop)
                    {
                        movebackAnim = true;
                    }

                    if (EanimationDone)
                    {
                        waitCount++;
                    }

                    if (movebackAnim && EanimationDone && waitCount > 10 && !isDestruction)
                    {
                        xStart -= 10;

                        index++;

                        if (index == 1)
                        {
                            attack.Play();
                        }

                        if (index > 3)
                        {
                            movebackAnim = false;
                            animationDone = true;
                        }
                    }
                }
            }

            //decides who to "flicker" depending on what unit is destroyied \/

            if ((!isDestruction && isYourTurn && animationDone && EanimationDone && isCounterDestruction) || (isDestruction && !isYourTurn && EanimationDone))
            {
                if (flickerIndex % 5 == 0 && flickerIndex < 25)
                {
                    offScreen.DrawImage(image, xStart, yStart);
                }
                else if (flickerIndex > 25)
                {
                    Thread.Sleep(500);
                    gGraphics.Clear(Color.White);
                    offScreen.Clear(Color.White);

                    isAnimationComplete = true;
                    willDestroy = false;
                    willCounterDestroy = false;
                    clearUi(false);
                    animationTimer.Enabled = false;
                }

                flickerIndex++;
            }
            else
            {
                offScreen.DrawImage(image, xStart, yStart);
            }

            Eimage.RotateFlip(RotateFlipType.Rotate180FlipY);

            if (!isDestruction && !isYourTurn && EanimationDone && animationDone && isCounterDestruction || (isDestruction && isYourTurn && animationDone))//deciding if should destroy enemy
            {
                if (flickerIndex % 5 == 0 && flickerIndex < 25)
                {
                    offScreen.DrawImage(Eimage, xEStart, yEStart);
                }
                else if (flickerIndex > 25)
                {
                    Thread.Sleep(500);
                    gGraphics.Clear(Color.White);
                    offScreen.Clear(Color.White);
                    isAnimationComplete = true;
                    willDestroy = false;
                    willCounterDestroy = false;
                    clearUi(false);
                    animationTimer.Enabled = false;
                }

                flickerIndex++;
            }
            else
            {
                offScreen.DrawImage(Eimage, xEStart, yEStart);
            }

            if (animationDone && EanimationDone && !willDestroy && !willCounterDestroy) // finishes the anim
            {
                imgCpuChoice = null;
                imgPlayerChoice = null;
                isAnimationComplete = true;
            }

            Eimage.RotateFlip(RotateFlipType.Rotate180FlipY);

            if (isAnimationComplete) // return to troop selection logic
            {
                offScreen.DrawImage(BackgroundImage, 0, 0, Width, Height);
                willDestroy = false;
                willCounterDestroy = false;
                clearUi(false);
                animationTimer.Enabled = false;
                if(tutorialStep == 8)
                {
                    continueButton.Visible = true;
                }
                tutorialStep++;
            }
        }

        private void clearUi(bool isClear) // clears or draws screen before/after anim
        {
            if (isClear)
            {
                cpuUnits.Visible = false;
                playerUnits.Visible = false;
                cpuSoldierHealth.Visible = false;
                cpuSniperHealth.Visible = false;
                cpuBazookaHealth.Visible = false;
                cpuLtHealth.Visible = false;
                cpuMdHealth.Visible = false;
                cpuHvyHealth.Visible = false;
                cpuATHealth.Visible = false;
                playerSoldierHealth.Visible = false;
                playerSniperHealth.Visible = false;
                playerBazookaHealth.Visible = false;
                playerLtHealth.Visible = false;
                playerMdHealth.Visible = false;
                playerHvyHealth.Visible = false;
                playerATHealth.Visible = false;
            }
            else
            {
                cpuUnits.Visible = true;
                playerUnits.Visible = true;
                cpuSoldierHealth.Visible = true;
                cpuSniperHealth.Visible = true;
                cpuBazookaHealth.Visible = true;
                cpuLtHealth.Visible = true;
                cpuMdHealth.Visible = true;
                cpuHvyHealth.Visible = true;
                cpuATHealth.Visible = true;
                playerSoldierHealth.Visible = true;
                playerSniperHealth.Visible = true;
                playerBazookaHealth.Visible = true;
                playerLtHealth.Visible = true;
                playerMdHealth.Visible = true;
                playerHvyHealth.Visible = true;
                playerATHealth.Visible = true;
            }
        }

        private void resetAnim() // clears vars for next anim
        {
            yStart = this.Height - Properties.Resources.ATIcon.Height;
            yStop = this.Height - Properties.Resources.ATIcon.Height;
            xEStart = this.Width;
            yEStart = yStart;
            yEStop = yStop;
            isAnimationComplete = false;
            EanimationDone = false;
            animationDone = false;
            movebackAnim = false;
            EmovebackAnim = false;
            xStart = -100;
            index = 0;
            Eindex = 0;
            flickerIndex = 0;
            waitCount = 0;
            waitECount = 0;
        }
        #endregion animation

        #region misc
        private void returnToTitle()
        {
            screenControl.changeScreen(this, "TitleScreen"); // does what you think
        }

        private void tutorialTimer_Tick(object sender, EventArgs e)
        {
            // the stages for the tutorial \/
            switch (tutorialStep)
            {
                case 1:
                    tutorialTextLabel.Text = "You are a Commander in the Green Star army, fighting against the Red Comet army";
                    break;
                case 2:
                    tutorialTextLabel.Text = "Look over here, this is your troop list which shows all of your units";
                    playerUnits.Visible = true;
                    playerUnits.Enabled = false;
                    break;
                case 3:
                    tutorialTextLabel.Text = "You can only select one unit to attack with, and each unit has different effectiveness depending on the enemy";
                    break;
                case 4:
                    tutorialTextLabel.Text = "Why don't you choose a soldier?";
                    tutorialTimer.Enabled = false;
                    playerUnits.Enabled = true;
                    continueButton.Visible = false;
                    break;
                case 5:
                    tutorialTextLabel.Text = "Now you can select an enemy unit to attack, for now choose soldier";
                    cpuUnits.Visible = true;
                    break;
                case 6:
                    tutorialTextLabel.Text = "When you select a target, an attack button will pop up, and up here it will display how much damage your attack will deal";
                    continueButton.Visible = true;
                    break;
                case 7:
                    tutorialTextLabel.Text = "When your ready, press the attack button, and an animation will play";
                    attackButton.Enabled = true;
                    continueButton.Visible = false;
                    break;
                case 8:
                    tutorialTextLabel.Text = "When you attack your opponet, the enemy will counter attack, dealing some damage back to you";
                    break;
                case 9:
                    tutorialTextLabel.Text = "However, if you or the enemy defeat the target before they can counter attack, they will not deal any damage";
                    break;
                case 10:
                    tutorialTextLabel.Text = "Now, after you attacked your enemy they will attack back";
                    resetAnim();
                    animationTimer.Enabled = true;
                    attackButton.Visible = false;
                    continueButton.Visible = false;
                    tutorialStep++;
                    break;
                case 12:
                    tutorialTextLabel.Text = "The game will end whenever all your units or your enemy's units are defeated";
                    cpuBazookaHealth.Text = "65";
                    playerHvyHealth.Text = "50";
                    continueButton.Visible = true;
                    break;
                case 13:
                    tutorialTextLabel.Text = "Congratulations you have learned the basics of the game!\nnow returning to the title screen...";
                    tutorialTimer.Enabled = false;
                    continueButton.Visible = false;
                    tutorialTextLabel.Refresh();                  
                    continueButton.Refresh();
                    Thread.Sleep(5000);
                    BMPlayer.Stop();
                    returnToTitle();
                    break;
            }
        }

        
        private int getCheckedIndex(Panel panel, object sender) // finds which r button is clicked
        {
            int checkedIndex = 0;

            for (int index = 0; index < panel.Controls.Count; index++)
            {
                if (panel.Controls[index].Equals(sender))
                {
                    checkedIndex = index;
                }
            }

            return checkedIndex;
        }
        private void organizeControls(Panel panel, bool player) // ensures the r btns are in order
        {
            Control soldier;
            Control sniper;
            Control bazooka;
            Control lt;
            Control md;
            Control hvy;
            Control at;

            if (player)
            {
                soldier = panel.Controls["SoldierButton"];
                sniper = panel.Controls["SniperButton"];
                bazooka = panel.Controls["BazookaButton"];
                lt = panel.Controls["LtButton"];
                md = panel.Controls["MdButton"];
                hvy = panel.Controls["HvyButton"];
                at = panel.Controls["AntiTankButton"];
            }
            else
            {
                soldier = panel.Controls["cpuSoldierButton"];
                sniper = panel.Controls["cpuSniperButton"];
                bazooka = panel.Controls["cpuBazookaButton"];
                lt = panel.Controls["cpuLtButton"];
                md = panel.Controls["cpuMdButton"];
                hvy = panel.Controls["cpuHvyButton"];
                at = panel.Controls["cpuAntiTankButton"];
            }

            for (int x = 0; x < 7; x++)
            {
                panel.Controls.RemoveAt(0);
            }

            panel.Controls.Add(soldier);
            panel.Controls.Add(sniper);
            panel.Controls.Add(bazooka);
            panel.Controls.Add(lt);
            panel.Controls.Add(md);
            panel.Controls.Add(hvy);
            panel.Controls.Add(at);
        }
        #endregion misc
    }
}
