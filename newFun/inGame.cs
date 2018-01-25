using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace newFun
{
    
    public partial class inGame : Form
    {
        /// <summary>
        /// matchups
        /// Sniper vs. soldier, bakzooka, sniper = 200%
        /// Sniper vs. Lt. Tank = 10%
        /// Sinper vs. Md. Tank = 5%
        /// Sinper vs. Hvy. Tank = 0%
        /// Sniper vs. anti-Tank = 10%
        /// 
        /// soldier vs Sniper, bazooka, soldier = 75%
        /// soldier vs Lt. Tank = 20%
        /// soldier vs Md. Tank = 10%
        /// soldier vs Hvy. Tank = 5%
        /// soldier vs anti-Tank = 10%
        /// 
        /// Bazooka va Sniper, soldier, bazooka = 20%
        /// bazooka va Lt. Tank = 100%
        /// bazooka vs Md. Tank = 75%
        /// bazooka vs Hvy. Tnk = 50%
        /// bazooka vs anti-Tank = 150%
        /// 
        /// Lt. Tank vs Sniper, soldier, bzooka = 50%
        /// Lt. Tank vs Lt. Tank = 75%
        /// Lt. Tank vs Md.Tank = 40%
        /// Lt. Tank vs Hvy Tank = 10%
        /// Lt. Tank vs anti- tank = 50%
        /// 
        /// Md. Tank vs Sniper, soldier, bazooka = 60%
        /// Md. tank vs Lt. tank = 80%
        /// md. tank vs md. Tank = 50%
        /// md. tank vs Hvy tank = 30%
        /// md tank vs anti tank = 40%
        /// 
        /// hvy tank vs soldier, sniper, bazooka = 70%'
        /// hvy tank vs lt tank = 85%
        /// hvy tank vs md tank = 60%
        /// hvy tank vs hvy tank = 50%
        /// hvy tank vs anti tank = 40%
        /// 
        /// anti tank vs  soldier, sniper, bazooka = 50%
        /// anti tank vs lt tank = 200%
        /// anti tank vs md tank = 100%
        /// anti tank vs hvy tank = 75%
        /// anti tank vs anti tank = 50%
        /// </summary>
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

        //titleScreenUI titleScreen = new titleScreenUI();
        

        public inGame()
        {
            InitializeComponent();

            titleScreen mm = new titleScreen();

            // set the menu to display centre screen based on screen size defaults
            mm.Size = new Size(screenControl.controlWidth, screenControl.controlHeight);
            mm.Location = screenControl.startCentre;

            // add main menu screen to form
            this.Controls.Add(mm);
            if (variables.isStartup)
            {
                //titleScreen.Show();
                //this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Maximized;             
            }

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
        public void Maximize()
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void textSlider()
        {
            slidingTextTimer.Enabled = true;
        }
        int targetInt;
        private void troopSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (troopSelection.SelectedIndex != -1)
            {
                targetInt = troopSelection.SelectedIndex;
            }
            if (targetSelected)
            {
                if ((Convert.ToInt16(matchupData.Tables[targetInt].Columns[cpuUnits.SelectedIndex].DefaultValue) * (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[targetInt].DefaultValue) / 100)) < 100)
                {
                    label2.Text = "Your attack will deal " + (Convert.ToInt16(matchupData.Tables[targetInt].Columns[cpuUnits.SelectedIndex].DefaultValue) * (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[targetInt].DefaultValue) / 100)) + " damage";
                }
                else
                {
                    label2.Text = "Your attack will deal 100 damage";
                }
            }
            hasPlayerSelected = true;
        }
        private void matchUps(int PlayerChoice, int cpuChoice, int health, int enemyHealth)
        {
            if (yourTurn)
            {
                int playerPotentialDamage = Convert.ToInt16(matchupData.Tables[PlayerChoice].Columns["enemy" + cpuCompile].DefaultValue);
                int playerActualDamage = playerPotentialDamage * health / 100;
                enemyHealth -= playerActualDamage;

                if (enemyHealth <= 0)
                {
                    enemyHealth = 0;
                    willDestroy = true;
                    matchupData.Tables[7].Columns[cpuCompile].DefaultValue = 0;
                }
                if (enemyHealth > 0)
                {
                    int cpuPotentialDamage = Convert.ToInt16(matchupData.Tables[cpuChoice].Columns["enemy" + playerCompile].DefaultValue);
                    int cpuActualDamage = cpuPotentialDamage * enemyHealth / 100;
                    health -= cpuActualDamage;

                    if (health <= 0)
                    {
                        health = 0;
                        willCounterDestroy = true;
                        troopSelection.Items.Remove(troopSelection.SelectedItem);
                    }
                }
            }
            else
            {
                int rndPlayerSlection = rndGen.Next(0, 7);

                while (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[rndPlayerSlection].DefaultValue) == 0)
                {
                    rndPlayerSlection = rndGen.Next(0, 7);
                }

                playerCompile = matchupData.Tables[playerIndex].Columns[rndPlayerSlection].ColumnName;

                switch (rndPlayerSlection)
                {
                    case 0:
                        imgPlayerChoice = Soldier;
                        break;
                    case 1:
                        imgPlayerChoice = Sniper;
                        break;
                    case 2:
                        imgPlayerChoice = Bazooka;
                        offsetX = BazookaOffsetX;
                        offsetY = BazookaOffsetY;
                        break;
                    case 3:
                        imgPlayerChoice = Lt;
                        offsetX = LtOffsetX;
                        offsetY = LtOffsetY;
                        break;
                    case 4:
                        imgPlayerChoice = Md;
                        offsetX = MdOffsetX;
                        offsetY = MdOffsetY;
                        break;
                    case 5:
                        imgPlayerChoice = Hvy;
                        offsetX = HvyOffsetX;
                        offsetY = HvyOffsetY;
                        break;
                    case 6:
                        imgPlayerChoice = Properties.Resources.ATIcon;
                        offsetX = ATOffsetX;
                        offsetY = ATOffsetY;
                        break;
                }

                cpuCompile = Ai(rndPlayerSlection, matchupData);

                switch (cpuCompile)
                {
                    case "Soldier":
                        imgCpuChoice = Soldier;
                        break;
                    case "Sniper":
                        imgCpuChoice = Sniper;
                        break;
                    case "Bazooka":
                        imgCpuChoice = Bazooka;
                        offsetX = BazookaOffsetX;
                        offsetY = BazookaOffsetY;
                        break;
                    case "Lt":
                        imgCpuChoice = Lt;
                        offsetX = LtOffsetX;
                        offsetY = LtOffsetY;
                        break;
                    case "Md":
                        imgCpuChoice = Md;
                        offsetX = MdOffsetX;
                        offsetY = MdOffsetY;
                        break;
                    case "Hvy":
                        imgCpuChoice = Hvy;
                        offsetX = HvyOffsetX;
                        offsetY = HvyOffsetY;
                        break;
                    case "AntiTank":
                        imgCpuChoice = Properties.Resources.ATIcon;
                        offsetX = ATOffsetX;
                        offsetY = ATOffsetY;
                        break;
                }

                int cpuPotentialDamage = Convert.ToInt16(matchupData.Tables[cpuCompile + "Matchup"].Columns[rndPlayerSlection].DefaultValue);
                int cpuActualDamage = cpuPotentialDamage * Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue) / 100;
                label1.Text = "CPU: " + cpuPotentialDamage + " " + cpuActualDamage + " " + cpuCompile;
                health -= cpuActualDamage;

                if (health <= 0)
                {
                    health = 0;
                    willDestroy = true;
                }

                if (health > 0)
                {
                    int playerPotentialDamage = Convert.ToInt16(matchupData.Tables[rndPlayerSlection].Columns["enemy" + cpuCompile].DefaultValue);
                    int playerActualDamage = playerPotentialDamage * health / 100;
                    label1.Text += " player:" + playerPotentialDamage + " " + playerActualDamage + " " + PlayerChoice;
                    enemyHealth -= playerActualDamage;

                    if (enemyHealth <= 0)
                    {
                        enemyHealth = 0;
                        willCounterDestroy = true;
                        matchupData.Tables[7].Columns[cpuCompile].DefaultValue = 0;
                    }
                }
            }

            matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue = health;
            matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue = enemyHealth;

        }

        private String Ai(int playerChoice, DataSet dataSet)
        {
            int maxValue = 0;
            string cpuSelection = "";

            for (int cycle = 0; cycle < dataSet.Tables.Count - 2; cycle++)
            {
                if (Convert.ToInt16(dataSet.Tables[cycle].Columns[playerChoice].DefaultValue) * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) / 100 > maxValue && Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) != 0)
                {
                    cpuSelection = dataSet.Tables[cpuIndex].Columns[cycle].ColumnName;
                    maxValue = Convert.ToInt16(dataSet.Tables[cycle].Columns[playerChoice].DefaultValue) * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) / 100; //getMax(dataSet.Tables[cycle].Columns);// * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cpuSelection].DefaultValue) / 100;
                }

            }

            if(cpuSelection == "")
            {
                for (int cycle2 = 0; cycle2 < dataSet.Tables.Count - 2; cycle2++)
                {
                    if (Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle2].DefaultValue) != 0)
                    {
                        cpuSelection = dataSet.Tables[cpuIndex].Columns[cycle2].ColumnName;
                    }
                }
            }

            switch (cpuSelection)
            {
                case "SoldierMatchup":
                    cpuSelection = "Soldier";
                    imgCpuChoice = Soldier;
                    cpuNumberSelection = 0;
                    break;
                case "SniperMatchup":
                    cpuSelection = "Sniper";
                    imgCpuChoice = Sniper;
                    cpuNumberSelection = 1;
                    break;
                case "BazookaMatchup":
                    cpuSelection = "Bazooka";
                    imgCpuChoice = Bazooka;
                    cpuNumberSelection = 2;
                    EoffsetX = BazookaOffsetX;
                    EoffsetY = BazookaOffsetY;
                    break;
                case "LtMatchup":
                    cpuSelection = "Lt";
                    imgCpuChoice = Lt;
                    cpuNumberSelection = 3;
                    EoffsetX = LtOffsetX;
                    EoffsetY = LtOffsetY;
                    break;
                case "MdMatchup":
                    cpuSelection = "Md";
                    imgPlayerChoice = Md;
                    cpuNumberSelection = 4;
                    EoffsetX = MdOffsetX;
                    EoffsetY = MdOffsetY;
                    break;
                case "HvyMatchup":
                    cpuSelection = "Hvy";
                    imgCpuChoice = Hvy;
                    cpuNumberSelection = 5;
                    EoffsetX = HvyOffsetX;
                    EoffsetY = HvyOffsetY;
                    break;
                case "AntiTankMatchup":
                    cpuSelection = "AntiTank";
                    imgCpuChoice = Properties.Resources.ATIcon;
                    cpuNumberSelection = 6;
                    EoffsetX = ATOffsetX;
                    EoffsetY = ATOffsetY;
                    break;
            }

            return cpuSelection;
        }

        private void cpuUnits_SelectedValueChanged(object sender, EventArgs e)
        {
            targetSelected = true;
            if (targetSelected && hasPlayerSelected)
            {
                button1.Visible = true;
                if (troopSelection.SelectedItem != null)
                {
                    if ((Convert.ToInt16(matchupData.Tables[troopSelection.SelectedIndex].Columns[cpuUnits.SelectedIndex].DefaultValue) * (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[troopSelection.SelectedIndex].DefaultValue) / 100)) < 100)
                    {
                        label2.Text = "Your attack will deal " + (Convert.ToInt16(matchupData.Tables[troopSelection.SelectedIndex].Columns[cpuUnits.SelectedIndex].DefaultValue) * (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[troopSelection.SelectedIndex].DefaultValue) / 100)) + " damage";
                    }
                    else
                    {
                        label2.Text = "Your attack will deal 100 damage";
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "";
            animation(imgPlayerChoice, imgCpuChoice, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, offsetX, EoffsetX, offsetY, EoffsetY, isPlayerAnimation, willDestroy, willCounterDestroy);
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

                healthBar.Value = Convert.ToInt16(matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue);
                enemyHealthBar.Value = Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue);

                playerSoldierHealth.Text = "" + matchupData.Tables[playerIndex].Columns[0].DefaultValue;
                cpuSoldierHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[0].DefaultValue;

                playerSniperHealth.Text = "" + matchupData.Tables[playerIndex].Columns[1].DefaultValue;
                cpuSniperHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[1].DefaultValue;

                playerBazookaHealth.Text = "" + matchupData.Tables[playerIndex].Columns[2].DefaultValue;
                cpuBazookaHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[2].DefaultValue;

                playerLtHealth.Text = "" + matchupData.Tables[playerIndex].Columns[3].DefaultValue;
                cpuLtHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[3].DefaultValue;

                playerMdHealth.Text = "" + matchupData.Tables[playerIndex].Columns[4].DefaultValue;
                cpuMdHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[4].DefaultValue;

                playerHvyHealth.Text = "" + matchupData.Tables[playerIndex].Columns[5].DefaultValue;
                cpuHvyHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[5].DefaultValue;

                playerATHealth.Text = "" + matchupData.Tables[playerIndex].Columns[6].DefaultValue;
                cpuATHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[6].DefaultValue;
                textSlider();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            bm = new Bitmap(this.Width, this.Height);
            offScreen = Graphics.FromImage(bm);
            gGraphics = this.CreateGraphics();
            label1.Text = "" + this.Width + " " + this.Height; 
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
            textSlider();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yourTurn = true;

            switch (Convert.ToString(troopSelection.SelectedItem))
            {
                case "Soldier":
                    playerSelection = 0;
                    playerCompile = "Soldier";
                    imgPlayerChoice = Soldier;
                    break;
                case "Sniper":
                    playerSelection = 1;
                    playerCompile = "Sniper";
                    imgPlayerChoice = Sniper;
                    break;
                case "Bazooka":
                    playerSelection = 2;
                    playerCompile = "Bazooka";
                    imgPlayerChoice = Bazooka;
                    offsetX = BazookaOffsetX;
                    offsetY = BazookaOffsetY;
                    break;
                case "Lt":
                    playerSelection = 3;
                    playerCompile = "Lt";
                    imgPlayerChoice = Lt;
                    offsetX = LtOffsetX;
                    offsetY = LtOffsetY;
                    break;
                case "Md":
                    playerSelection = 4;
                    playerCompile = "Md";
                    imgPlayerChoice = Md;
                    offsetX = MdOffsetX;
                    offsetY = MdOffsetY;
                    break;
                case "Hvy":
                    playerSelection = 5;
                    playerCompile = "Hvy";
                    imgPlayerChoice = Hvy;
                    offsetX = HvyOffsetX;
                    offsetY = HvyOffsetY;
                    break;
                case "AntiTank":
                    playerSelection = 6;
                    playerCompile = "AntiTank";
                    imgPlayerChoice = Properties.Resources.ATIcon;
                    offsetX = ATOffsetX;
                    offsetY = ATOffsetY;
                    break;
            }
            isPlayerAnimation = true;

            if (targetSelected)
            {
                clearUi(true);

                cpuCompile = "" + cpuUnits.SelectedItem;
                cpuNumberSelection = matchupData.Tables[cpuIndex].Columns.IndexOf(cpuCompile);

                matchUps(playerSelection, cpuNumberSelection, Convert.ToInt16(matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue), Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue));
                turnCounter++;
                troopSelection.SelectedItem = null;
                targetSelected = false;

                switch (Convert.ToString(cpuUnits.SelectedItem))
                {
                    case "Soldier":
                        imgCpuChoice = Soldier;
                        cpuNumberSelection = 0;
                        break;
                    case "Sniper":
                        imgCpuChoice = Sniper;
                        cpuNumberSelection = 1;
                        break;
                    case "Bazooka":
                        imgCpuChoice = Bazooka;
                        cpuNumberSelection = 2;
                        EoffsetX = BazookaOffsetX;
                        EoffsetY = BazookaOffsetY;
                        break;
                    case "Lt":
                        imgCpuChoice = Lt;
                        cpuNumberSelection = 3;
                        EoffsetX = LtOffsetX;
                        EoffsetY = LtOffsetY;
                        break;
                    case "Md":
                        imgCpuChoice = Md;
                        cpuNumberSelection = 4;
                        EoffsetX = MdOffsetX;
                        EoffsetY = MdOffsetY;
                        break;
                    case "Hvy":
                        imgCpuChoice = Hvy;
                        cpuNumberSelection = 5;
                        EoffsetX = HvyOffsetX;
                        EoffsetY = HvyOffsetY;
                        break;
                    case "AntiTank":
                        imgCpuChoice = Properties.Resources.ATIcon;
                        cpuNumberSelection = 6;
                        EoffsetX = ATOffsetX;
                        EoffsetY = ATOffsetY;
                        break;
                }

                cpuUnits.SelectedItem = null;
                yStart = this.Height - Properties.Resources.ATIcon.Height;
                yStop = this.Height - Properties.Resources.ATIcon.Height;
                //xEStop = this.Width - 230;
                xEStart = this.Width;
                yEStart = yStart;
                yEStop = yStop;
                EanimationDone = false;
                animationDone = false;
                movebackAnim = false;
                EmovebackAnim = false;
                isAnimationComplete = false;
                isTurnDoneDisplaying = false;

                xStart = -100;
                index = 0;
                Eindex = 0;
                flickerIndex = 0;
                waitCount = 0;
                waitECount = 0;

                animationTimer.Enabled = true;
                enemyAninmationSetupTimer.Enabled = true;
                button1.Visible = false;
                targetSelected = false;
                turnSlideLabel.Text = "Enemy's Turn";
                yourTurn = false;
            }
                            
            playerSoldierHealth.Text = "" + matchupData.Tables[playerIndex].Columns[0].DefaultValue;
            cpuSoldierHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[0].DefaultValue;
            playerSniperHealth.Text = "" + matchupData.Tables[playerIndex].Columns[1].DefaultValue;
            cpuSniperHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[1].DefaultValue;
            playerBazookaHealth.Text = "" + matchupData.Tables[playerIndex].Columns[2].DefaultValue;
            cpuBazookaHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[2].DefaultValue;
            playerLtHealth.Text = "" + matchupData.Tables[playerIndex].Columns[3].DefaultValue;
            cpuLtHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[3].DefaultValue;
            playerMdHealth.Text = "" + matchupData.Tables[playerIndex].Columns[4].DefaultValue;
            cpuMdHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[4].DefaultValue;
            playerHvyHealth.Text = "" + matchupData.Tables[playerIndex].Columns[5].DefaultValue;
            cpuHvyHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[5].DefaultValue;
            playerATHealth.Text = "" + matchupData.Tables[playerIndex].Columns[6].DefaultValue;
            cpuATHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[6].DefaultValue;  
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isAnimationComplete)
            {
                turnSlideLabel.Visible = true;
                label1.Text = yourTurn + "";

                if (isTurnDoneDisplaying)
                {
                    yourTurn = false;
                    isPlayerAnimation = false;
                    isAnimationComplete = false;
                    int rndPlayerSlection = rndGen.Next(0, 7);

                    while (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[rndPlayerSlection].DefaultValue) == 0)
                    {
                        rndPlayerSlection = rndGen.Next(0, 7);
                    }

                    playerCompile = matchupData.Tables[playerIndex].Columns[rndPlayerSlection].ColumnName;

                    switch (rndPlayerSlection)
                    {
                        case 0:
                            imgPlayerChoice = Soldier;
                            break;
                        case 1:
                            imgPlayerChoice = Sniper;
                            break;
                        case 2:
                            imgPlayerChoice = Bazooka;
                            offsetX = BazookaOffsetX;
                            offsetY = BazookaOffsetY;
                            break;
                        case 3:
                            imgPlayerChoice = Lt;
                            offsetX = LtOffsetX;
                            offsetY = LtOffsetY;
                            break;
                        case 4:
                            imgPlayerChoice = Md;
                            offsetX = MdOffsetX;
                            offsetY = MdOffsetY;
                            break;
                        case 5:
                            imgPlayerChoice = Hvy;
                            offsetX = HvyOffsetX;
                            offsetY = HvyOffsetY;
                            break;
                        case 6:
                            imgPlayerChoice = Properties.Resources.ATIcon;
                            offsetX = ATOffsetX;
                            offsetY = ATOffsetY;
                            break;
                    }
                    cpuCompile = Ai(rndPlayerSlection, matchupData);
                    switch (cpuCompile)
                    {
                        case "Soldier":
                            imgCpuChoice = Soldier;
                            break;
                        case "Sniper":
                            imgCpuChoice = Sniper;
                            break;
                        case "Bazooka":
                            imgCpuChoice = Bazooka;
                            offsetX = BazookaOffsetX;
                            offsetY = BazookaOffsetY;
                            break;
                        case "Lt":
                            imgCpuChoice = Lt;
                            offsetX = LtOffsetX;
                            offsetY = LtOffsetY;
                            break;
                        case "Md":
                            imgCpuChoice = Md;
                            offsetX = MdOffsetX;
                            offsetY = MdOffsetY;
                            break;
                        case "Hvy":
                            imgCpuChoice = Hvy;
                            offsetX = HvyOffsetX;
                            offsetY = HvyOffsetY;
                            break;
                        case "AntiTank":
                            imgCpuChoice = Properties.Resources.ATIcon;
                            offsetX = ATOffsetX;
                            offsetY = ATOffsetY;
                            break;
                    }

                    matchUps(playerSelection, cpuNumberSelection, Convert.ToInt16(matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue), Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue));

                    yStart = this.Height - Properties.Resources.ATIcon.Height;
                    yStop = this.Height - Properties.Resources.ATIcon.Height;
                    
                    xEStart = this.Width;
                    yEStart = yStart;
                    yEStop = yStop;
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
                    enemyAninmationSetupTimer.Enabled = false;
                    animationTimer.Enabled = true;
                    targetSelected = false;
                    turnSlideLabel.Text = "Your Turn";
                    turnCounter++;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {        
            if (textStartPoint.X < textStopPoint.X)
            {
                textStartPoint.X += 20;
                turnSlideLabel.Location = textStartPoint;
            }
            else
            {
                isTurnDoneDisplaying = true;
                turnSlideLabel.Visible = false;
                clearUi(false);
                textStartPoint = new Point(0 - turnSlideLabel.Width, turnSlideLabel.Location.Y);
                slidingTextTimer.Enabled = false;
            }        
        }

        private void backgroundTimer_Tick(object sender, EventArgs e)
        {           
            if(isAnimationComplete)
            {
                for(int i = 0; i < 7; i++)
                {
                   if(Convert.ToInt16(matchupData.Tables[playerIndex].Columns[i].DefaultValue) == 0)
                    {
                        unitDefeatedCount++;
                    }

                    if (Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[i].DefaultValue) == 0)
                    {
                        EunitDefeatedCount++;
                    }
                }

                if(unitDefeatedCount == 7)
                {
                    gameEnd(false);

                    clearUi(true);
                    healthBar.Visible = false;
                    enemyHealthBar.Visible = false;
                }
                else if(EunitDefeatedCount == 7)
                {
                    gameEnd(true);              

                    clearUi(true);
                    healthBar.Visible = false;
                    enemyHealthBar.Visible = false;
                }

                EunitDefeatedCount = 0;
                unitDefeatedCount = 0;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            gameEnd(true);
            
            //ActiveForm.Opacity = 0;
        }

        private void returnToTitleButton_Click(object sender, EventArgs e)
        {
            titleScreenUI form = new titleScreenUI();
            form.Show();
            form.Maximize();
            Close();
        }
    }
}
