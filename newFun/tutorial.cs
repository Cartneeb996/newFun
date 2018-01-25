using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace newFun
{
    public partial class tutorial : Form
    {
        const int cpuIndex = 7;
        const int playerIndex = 8;

        Random rndGen = new Random();

        //bool isStartup = true;
        bool willDestroy = false;
        bool willCounterDestroy = false;
        bool targetSelected = false;
        bool isPlayerAnimation = true;
        bool isTurnDoneDisplaying = false;
        bool isGameDone = false;
        bool isPlayerWinner = true;
        bool yourTurn = true;
        bool movebackAnim = false;
        bool animationDone = false;
        bool EmovebackAnim = false;
        bool EanimationDone = false;
        bool isAnimationComplete = false;
        bool hasPlayerSelected;

        string cpuCompile;
        string playerCompile;

        int playerSelection;
        int tutorialStep = 0;
        int turnCounter = 1;
        int cpuNumberSelection;
        int EunitDefeatedCount = 0;
        int unitDefeatedCount = 0;
        int EoffsetX;
        int EoffsetY;
        int offsetX;
        int offsetY;
        int waitCount;
        int flickerIndex = 0;
        int waitECount;
        int index = 0;
        int Eindex = 0;
        int ATOffsetX = 410;
        int ATOffsetY = 25;
        int HvyOffsetX = 380;
        int HvyOffsetY = 4;
        int BazookaOffsetX = 205;
        int BazookaOffsetY = 4;
        int LtOffsetX = 175;
        int LtOffsetY = 16;
        int MdOffsetX = 196;
        int MdOffsetY = 40;
        int xStart = 0;
        int yStart;
        int xStop;
        int yStop;
        int xEStart;
        int yEStart;
        int xEStop;
        int yEStop;

        Point cpuP;

        Graphics offScreen;
        Graphics gGraphics;

        Bitmap bm;
        Bitmap Bazooka;
        Bitmap Hvy;
        Bitmap Md;
        Bitmap Lt;
        Bitmap Soldier;
        Bitmap Sniper;
        Point textStartPoint;
        Point textStopPoint;
        Bitmap imgPlayerChoice;
        Bitmap imgCpuChoice;
        Bitmap fire = new Bitmap(Properties.Resources.redComet, 50, 50);
        Bitmap Efire = new Bitmap(Properties.Resources.redComet, 50, 50);

        public tutorial()
        {
            InitializeComponent();

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
            textStartPoint = new Point(0 - turnSlideLabel.Width, turnSlideLabel.Location.Y);
            textStopPoint = new Point(this.Width, turnSlideLabel.Location.Y);
            turnSlideLabel.Location = textStartPoint;
        }

        private void tutorial_Resize(object sender, EventArgs e)
        {
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm);
            gGraphics = this.CreateGraphics();
            label1.Text = "" + this.Width + " " + this.Height;
            turnSlideLabel.Visible = false;
            healthBar.Visible = false;
            enemyHealthBar.Visible = false;
            xEStop = this.Width - 300;
            cpuP = new Point(this.Width - cpuUnits.Width - 20, cpuUnits.Location.Y);
            cpuUnits.Location = cpuP;
            enemyHealthBar.Location = new Point(this.Width - enemyHealthBar.Width - 20, enemyHealthBar.Location.Y);
            cpuSoldierHealth.Location = new Point(this.Width - cpuSoldierHealth.Width - 145, cpuSoldierHealth.Location.Y);
            cpuSniperHealth.Location = new Point(this.Width - cpuSniperHealth.Width - 145, cpuSniperHealth.Location.Y);
            cpuBazookaHealth.Location = new Point(this.Width - cpuBazookaHealth.Width - 145, cpuBazookaHealth.Location.Y);
            cpuLtHealth.Location = new Point(this.Width - cpuLtHealth.Width - 145, cpuLtHealth.Location.Y);
            cpuMdHealth.Location = new Point(this.Width - cpuMdHealth.Width - 145, cpuMdHealth.Location.Y);
            cpuHvyHealth.Location = new Point(this.Width - cpuHvyHealth.Width - 145, cpuHvyHealth.Location.Y);
            cpuATHealth.Location = new Point(this.Width - cpuATHealth.Width - 145, cpuATHealth.Location.Y);
            textStopPoint = new Point(this.Width, turnSlideLabel.Location.Y);
            tutorialTextLabel.Location = new Point(Width / 2 - tutorialTextLabel.Width / 2, Height / 2 - tutorialTextLabel.Height / 2);
            continueButton.Location = new Point(tutorialTextLabel.Location.X + tutorialTextLabel.Width / 2 - continueButton.Width / 2, tutorialTextLabel.Location.Y + 200);
            //textSlider();
            clearUi(true);
        }

        public void Maximize()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void returnToTitle()
        {
            titleScreenUI form = new titleScreenUI();
            form.Show();
            form.Maximize();
            Close();
        }

        private void textSlider()
        {
            slidingTextTimer.Enabled = true;
        }

        private void troopSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tutorialStep == 4)
            {
                if (Convert.ToString(troopSelection.SelectedItem) == "Soldier")
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
            targetSelected = true;
            if (targetSelected && hasPlayerSelected)
            {
                if (Convert.ToString(cpuUnits.SelectedItem) == "Soldier")
                {
                    tutorialStep++;
                    button1.Visible = true;
                    button1.Enabled = false;
                    label1.Text = "Your attack will deal 75 damage";
                }
                else
                {
                    tutorialTextLabel.Text = "Thats not a soldier!";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "";
            if (tutorialStep == 11)
            {
                animation(Hvy, Bazooka, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, BazookaOffsetX, HvyOffsetX, BazookaOffsetY, HvyOffsetY, false, false, false);
            }
            else
            {
                animation(Soldier, Soldier, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, 0, 0, 0, 0, true, false, false);
            }
            gGraphics.DrawImage(bm, 0, 0);
            offScreen.Clear(Color.White);
        }

        private void animation(Bitmap image, Bitmap Eimage, int imgHeight, int imgEHeight, int imgXOffset, int imgEXOffset, int imgYOffset, int imgEYOffset, bool isYourTurn, bool isDestruction, bool isCounterDestruction)
        {
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

                        if (image != Soldier && image != Sniper)
                        {
                            offScreen.DrawImage(fire, xStart + imgXOffset, yStart + imgYOffset);
                        }

                        index++;

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

                        if (Eimage != Soldier && Eimage != Sniper)
                        {
                            if (Eimage == Bazooka)
                            {
                                offScreen.DrawImage(Efire, xEStart - imgEXOffset / 4, yEStart + imgEYOffset);
                            }
                            else
                            {
                                offScreen.DrawImage(Efire, xEStart, yEStart + imgEYOffset);
                            }
                        }

                        Eindex++;

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
                        if (Eimage != Soldier && Eimage != Sniper)
                        {
                            if (Eimage == Bazooka)
                            {
                                offScreen.DrawImage(Efire, xEStart - imgEXOffset / 4, yEStart + imgEYOffset);
                            }
                            else
                            {
                                offScreen.DrawImage(Efire, xEStart, yEStart + imgEYOffset);
                            }
                        }

                        Eindex++;

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
                        if (image != Soldier && image != Sniper)
                        {
                            offScreen.DrawImage(fire, xStart + imgXOffset, yStart + imgYOffset);
                        }

                        index++;

                        if (index > 3)
                        {
                            movebackAnim = false;
                            animationDone = true;
                        }
                    }
                }
            }

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
            
            if (animationDone && EanimationDone && !willDestroy && !willCounterDestroy)
            {
                imgCpuChoice = null;
                imgPlayerChoice = null;
                isAnimationComplete = true;
            }

            Eimage.RotateFlip(RotateFlipType.Rotate180FlipY);

            if (isAnimationComplete)
            {
                gGraphics.Clear(Color.White);
                offScreen.Clear(Color.White);
                troopSelection.Visible = true;
                willDestroy = false;
                willCounterDestroy = false;
                clearUi(false);
                animationTimer.Enabled = false;
                enemyAninmationSetupTimer.Enabled = false;
                tutorialStep++;
                textSlider();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearUi(true);
            resetAnim();
            playerSoldierHealth.Text = "82";
            cpuSoldierHealth.Text = "25";
            turnCounter++;
            troopSelection.SelectedItem = null;
            cpuUnits.SelectedItem = null;        
            animationTimer.Enabled = true;
            button1.Visible = false;
            turnSlideLabel.Text = "Enemy's Turn";
        }
    
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            animation(Bazooka, Hvy, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, BazookaOffsetX, HvyOffsetX, BazookaOffsetY, HvyOffsetY, false, false, false);
            gGraphics.DrawImage(bm, 0, 0);
            offScreen.Clear(Color.White);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void backgroundTimer_Tick(object sender, EventArgs e)
        {

        }
        private void clearUi(bool isClear)
        {
            if (isClear)
            {
                troopSelection.Visible = false;
                cpuUnits.Visible = false;
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
                troopSelection.Visible = true;
                cpuUnits.Visible = true;
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
        private void gameEnd(bool didPlayerWin)
        {
            clearUi(true);
            healthBar.Visible = false;
            enemyHealthBar.Visible = false;
            turnSlideLabel.Visible = false;
            endGameLabel.Visible = true;
            slidingTextTimer.Enabled = false;
            enemyAninmationSetupTimer.Enabled = false;
            animationTimer.Enabled = false;
            backgroundTimer.Enabled = false;

            if (didPlayerWin)
            {
                endGameLabel.Text = "You defeated all the enemy's units, and you win!\nClick This button to return to title screen";
                returnToTitleButton.Visible = true;
            }
            else
            {
                endGameLabel.Text = "You were defeated by the enemy, You Lose\nClick This button to return to title screen";
                returnToTitleButton.Visible = true;
            }
        }

        private void tutorialTimer_Tick(object sender, EventArgs e)
        {
            switch(tutorialStep)
            {
                case 1:
                    tutorialTextLabel.Text = "You are a Commander in the Green Star army, fighting against the Red Comet army";
                    break;
                case 2:
                    tutorialTextLabel.Text = "Look over here, this is your troop list which shows all of your units";
                    troopSelection.Visible = true;
                    troopSelection.Enabled = false;
                    break;
                case 3:
                    tutorialTextLabel.Text = "You can only select one unit to attack with, and each unit has different effectiveness depending on the enemy";
                    break;
                case 4:
                    tutorialTextLabel.Text = "Why don't you choose a soldier?";
                    tutorialTimer.Enabled = false;
                    troopSelection.Enabled = true;
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
                    turnSlideLabel.Text = "Enemy's Turn";
                    //label1.BackColor = Color.White;
                    //tutorialTextLabel.BackColor = Color.White;
                    button1.Enabled = true;
                    continueButton.Visible = false;
                    break;
                case 8:
                    tutorialTextLabel.Text = "When you attack your opponet, the enemy will counter attack, dealing some damage back to you";
                    continueButton.Visible = true;
                    break;
                case 9:
                    tutorialTextLabel.Text = "However, if you or the enemy defeat the target before they can counter attack, they will not deal any damage";
                    break;
                case 10:
                    tutorialTextLabel.Text = "Now, after you attacked your enemy they will attack back";
                    resetAnim();
                    animationTimer.Enabled = true;
                    button1.Visible = false;
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
                    continueButton.Visible = false;
                    tutorialTextLabel.Refresh();
                    continueButton.Refresh();
                    Thread.Sleep(5000);
                    returnToTitle();
                    break;
            }
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            tutorialStep++;
        }

        private void resetAnim()
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
    }
}
