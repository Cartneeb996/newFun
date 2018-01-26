using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace newFun
{
    public partial class gameScreen : UserControl
    {
        #region variables
        const int cpuIndex = 7;
        const int playerIndex = 8;

        Random rndGen = new Random();

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

        RadioButton btn;
        RadioButton Ebtn;

        string cpuCompile;
        string playerCompile;

        int healthFlicker = 0;
        int playerSelection;
        int turnCounter = 1;
        int cpuNumberSelection;
        int EunitDefeatedCount = 0;
        int unitDefeatedCount = 0;
        int waitCount;
        int flickerIndex = 0;
        int waitECount;
        int index = 0;
        int Eindex = 0;
        int xStart = -100;
        int yStart;
        int xStop;
        int yStop;
        int xEStart;
        int yEStart;
        int xEStop;
        int yEStop;
        int targetInt;
        int cpuTarget;
        int previous;

        Point cpuP;
        Point textStartPoint;
        Point textStopPoint;
        Point bottomPanelPoint;

        Graphics offScreen;
        Graphics gGraphics;
        Graphics health;

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

        SoundPlayer attack = new SoundPlayer(Properties.Resources.Tank_Firing);
        #endregion

        #region init
        public gameScreen()
        {
            InitializeComponent();

            //background music \/

            variables.BMPlayer.Open(new Uri(Application.StartupPath + "/Resources/battle_music.mp3"));        
            variables.BMPlayer.Stop();
            variables.BMPlayer.Play();

            // decides what mode the player chose \/

            if (variables.mode == "expert")
            {
                for(int x = 0; x < matchupData.Tables[cpuIndex].Columns.Count; x++)
                {
                    matchupData.Tables[cpuIndex].Columns[x].DefaultValue = 150;
                }
            }
            else if (variables.mode == "easy")
            {
                for (int x = 0; x < matchupData.Tables[cpuIndex].Columns.Count; x++)
                {
                    matchupData.Tables[cpuIndex].Columns[x].DefaultValue = 50;
                }
            }

            // graphics initialization \/
            
            xStart = -100;
            xStop = 50;
            Bazooka = new Bitmap(Properties.Resources.BazookaIcon, Properties.Resources.ATIcon.Width / 2, fire.Height);
            Hvy = new Bitmap(Properties.Resources.HvyIcon, Properties.Resources.ATIcon.Size);
            Lt = new Bitmap(Properties.Resources.LtIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Md = new Bitmap(Properties.Resources.MdIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Soldier = new Bitmap(Properties.Resources.SoldierIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            Sniper = new Bitmap(Properties.Resources.SniperIcon, Properties.Resources.ATIcon.Width / 2, Properties.Resources.ATIcon.Height);
            textStartPoint = new Point(0 - turnSlideLabel.Width, bottomPanel.Location.Y + 1);
            textStopPoint = new Point(this.Width, turnSlideLabel.Location.Y);
            turnSlideLabel.Location = textStartPoint;

            Efire.RotateFlip(RotateFlipType.Rotate180FlipY);
        }

        private void gameScreen_Resize(object sender, EventArgs e) // fits the ui to the screen
        {
            bottomPanelPoint = new Point(0, textStartPoint.Y + turnSlideLabel.Height);
            bottomPanel.Size = new Size(screenControl.screenWidth, screenControl.screenHeight - bottomPanelPoint.Y);
            bottomPanel.Location = bottomPanelPoint;

            organizeControls(playerUnits, true); // organizes the unit selections
            organizeControls(cpuUnits, false);

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
            playerAntiTankHealth.Text = "" + matchupData.Tables[playerIndex].Columns[6].DefaultValue;
            cpuAntiTankHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[6].DefaultValue;
            topPanel.Size = new Size(screenControl.screenWidth, bottomPanelPoint.Y);
            topPanel.Location = new Point(0, 0);

            bm = new Bitmap(Width, Height);
            offScreen = Graphics.FromImage(bm);
            gGraphics = bottomPanel.CreateGraphics();

            xEStop = bottomPanel.Width - 300;
            cpuP = new Point(this.Width - cpuUnits.Width - 20, cpuUnits.Location.Y);
            cpuUnits.Location = cpuP;
            cpuSoldierHealth.Location = new Point(this.Width - cpuSoldierHealth.Width - 145, cpuSoldierHealth.Location.Y);
            cpuSniperHealth.Location = new Point(this.Width - cpuSniperHealth.Width - 145, cpuSniperHealth.Location.Y);
            cpuBazookaHealth.Location = new Point(this.Width - cpuBazookaHealth.Width - 145, cpuBazookaHealth.Location.Y);
            cpuLtHealth.Location = new Point(this.Width - cpuLtHealth.Width - 145, cpuLtHealth.Location.Y);
            cpuMdHealth.Location = new Point(this.Width - cpuMdHealth.Width - 145, cpuMdHealth.Location.Y);
            cpuHvyHealth.Location = new Point(this.Width - cpuHvyHealth.Width - 145, cpuHvyHealth.Location.Y);
            cpuAntiTankHealth.Location = new Point(this.Width - cpuAntiTankHealth.Width - 145, cpuAntiTankHealth.Location.Y);
            textStartPoint = new Point(0 - turnSlideLabel.Width, 1);
            textStopPoint = new Point(this.Width, 1);
            attackButton.Location = new Point(topPanel.Width / 2 - attackButton.Width + 40, topPanel.Height / 2 - 3);
            textSlider();
        }
        #endregion init

        #region logic
        private void matchUps(int PlayerChoice, int cpuChoice, int health, int enemyHealth)
        {
            //this calculates the damages for the units
            if (yourTurn) // if player turn, the player will attack first
            {
                // damage formula \/ ( get player & cpu units, find damage value in the matchup dataset, and do: damage * health % )
                int playerPotentialDamage = Convert.ToInt16(matchupData.Tables[PlayerChoice].Columns["enemy" + cpuCompile].DefaultValue);
                int playerActualDamage = playerPotentialDamage * health / 100;
                enemyHealth -= playerActualDamage;

                if (enemyHealth <= 0) // if the enemy is destroied, they won't attack back
                {
                    enemyHealth = 0;
                    willDestroy = true;
                    matchupData.Tables[7].Columns[cpuCompile].DefaultValue = 0;
                }

                if (enemyHealth > 0) // if not, calc damage after player deals damage
                {
                    int cpuPotentialDamage = Convert.ToInt16(matchupData.Tables[cpuChoice].Columns["enemy" + playerCompile].DefaultValue);
                    int cpuActualDamage = cpuPotentialDamage * enemyHealth / 100;
                    health -= cpuActualDamage;

                    if (health <= 0)
                    {
                        health = 0;
                        willCounterDestroy = true;
                    }
                }
            }
            else // if not player turn, select rnd player unit to attack
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
                        break;
                    case 3:
                        imgPlayerChoice = Lt;
                        break;
                    case 4:
                        imgPlayerChoice = Md;
                        break;
                    case 5:
                        imgPlayerChoice = Hvy;
                        break;
                    case 6:
                        imgPlayerChoice = Properties.Resources.ATIcon;
                        break;
                }

                // then use the Ai func to find the best counter 

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
                        break;
                    case "Lt":
                        imgCpuChoice = Lt;
                        break;
                    case "Md":
                        imgCpuChoice = Md;
                        break;
                    case "Hvy":
                        imgCpuChoice = Hvy;
                        break;
                    case "AntiTank":
                        imgCpuChoice = Properties.Resources.ATIcon;
                        break;
                }

                // this time the ememy will attack first

                int cpuPotentialDamage = Convert.ToInt16(matchupData.Tables[cpuCompile + "Matchup"].Columns[rndPlayerSlection].DefaultValue);
                int cpuActualDamage = cpuPotentialDamage * Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue) / 100;
                health -= cpuActualDamage;

                if (health <= 0) // if the player is destroied, do not counter
                {
                    health = 0;
                    willDestroy = true;
                }

                if (health > 0) // else calc counter damage
                {
                    int playerPotentialDamage = Convert.ToInt16(matchupData.Tables[rndPlayerSlection].Columns["enemy" + cpuCompile].DefaultValue);
                    int playerActualDamage = playerPotentialDamage * health / 100;
                    enemyHealth -= playerActualDamage;

                    if (enemyHealth <= 0)
                    {
                        enemyHealth = 0;
                        willCounterDestroy = true;
                        matchupData.Tables[7].Columns[cpuCompile].DefaultValue = 0;
                    }
                }
            }

            // modifies the health tables for the player and cpu \/

            matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue = health;
            matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue = enemyHealth;
        }

        private String Ai(int playerChoice, DataSet dataSet) // this is the logic to finding the proper counter to the chosen unit
        {
            int maxValue = 0;
            string cpuSelection = "";

            for (int cycle = 0; cycle < dataSet.Tables.Count - 2; cycle++) // cycle thru the matchups for the highest value, (takes into account health) and set the cpu selection to that unit
            {
                if (Convert.ToInt16(dataSet.Tables[cycle].Columns[playerChoice].DefaultValue) * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) / 100 > maxValue && Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) != 0)
                {
                    cpuSelection = dataSet.Tables[cpuIndex].Columns[cycle].ColumnName;
                    maxValue = Convert.ToInt16(dataSet.Tables[cycle].Columns[playerChoice].DefaultValue) * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle].DefaultValue) / 100; //getMax(dataSet.Tables[cycle].Columns);// * Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cpuSelection].DefaultValue) / 100;
                }

            }

            // this is a safety mesure in case the AI selects a troop with no health \/ (this should never be used, but just in case)

            if (cpuSelection == "")
            {
                for (int cycle2 = 0; cycle2 < dataSet.Tables.Count - 2; cycle2++)
                {
                    if (Convert.ToInt16(dataSet.Tables[cpuIndex].Columns[cycle2].DefaultValue) != 0)
                    {
                        cpuSelection = dataSet.Tables[cpuIndex].Columns[cycle2].ColumnName;
                    }
                }
            }

            switch (cpuSelection) // assign the properties according to the chosen unit
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
                    break;
                case "LtMatchup":
                    cpuSelection = "Lt";
                    imgCpuChoice = Lt;
                    cpuNumberSelection = 3;
                    break;
                case "MdMatchup":
                    cpuSelection = "Md";
                    imgPlayerChoice = Md;
                    cpuNumberSelection = 4;
                    break;
                case "HvyMatchup":
                    cpuSelection = "Hvy";
                    imgCpuChoice = Hvy;
                    cpuNumberSelection = 5;
                    break;
                case "AntiTankMatchup":
                    cpuSelection = "AntiTank";
                    imgCpuChoice = Properties.Resources.ATIcon;
                    cpuNumberSelection = 6;
                    break;
            }

            return cpuSelection; // returns the troop name in a string
        }
        #endregion logic

        #region userResponse
        private void troopSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (choiceFlicker.Enabled) // if the damage flicker is on reset it
            {
                healthFlicker = 0;
            }

            int index = getCheckedIndex(playerUnits, sender);

            if (index != -1)
            {
                hasPlayerSelected = true;
            }

            if (cpuTarget != -1)
            {
                targetSelected = true;
            }

            //damage flicker setup ^

            switch (index) // stores the button chosen to btn for later
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
                default:
                    hasPlayerSelected = false;
                    targetSelected = false;
                    break;
            }

            targetInt = index;

            //checks is the target is valid \/

            if (targetSelected && Convert.ToInt16(matchupData.Tables[playerIndex].Columns[targetInt].DefaultValue) != 0 && Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuTarget].DefaultValue) != 0)
            {
                choiceFlicker.Enabled = true;
                attackButton.Visible = true;
            }
            else if (targetSelected) // if not valid, reset
            {
                attackButton.Visible = false;
                choiceFlicker.Enabled = false;
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].Text = "" + matchupData.Tables[cpuIndex].Columns[cpuUnits.Controls[cpuTarget].Text].DefaultValue;
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].ForeColor = Color.White;
                healthFlicker = 0;
            }

        }

        private void cpuUnits_SelectedValueChanged(object sender, EventArgs e) // when the user selects a target
        {
            if (choiceFlicker.Enabled) // if the health label is already flickering...
            {
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].Text = "" + matchupData.Tables[cpuIndex].Columns[cpuUnits.Controls[cpuTarget].Text].DefaultValue;
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].ForeColor = Color.White;
                healthFlicker = 0;
            }
            
            //checks if the player has chosen a) their own unit, and b) a target \/

            cpuTarget = getCheckedIndex(cpuUnits, sender); // this func returns -1 by default (if there is no selected unit)
            int index = cpuTarget;
            int indexP = getCheckedIndex(playerUnits, sender);

            if (index != -1)
            {
                targetSelected = true;
                //hasPlayerSelected = true;
            }

            if(targetInt != -1)
            {
                hasPlayerSelected = true;
            }
            else
            {
                hasPlayerSelected = false;
            }

            switch (index) //asign the btn control associated with the selected enemy unit to Ebtn
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
                default:
                    hasPlayerSelected = false;
                    targetSelected = false; // should never occur, but is a safety
                    break;
            }

            //if the user has picked vaild targets (ones with at least 1 health)
            if (hasPlayerSelected && targetSelected && hasPlayerSelected && Convert.ToInt16(matchupData.Tables[playerIndex].Columns[targetInt].DefaultValue) != 0 && Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuTarget].DefaultValue) != 0)
            {
                attackButton.Visible = true;
                previous = Convert.ToInt16(topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].Text);
                choiceFlicker.Enabled = true;
            }
            else if(targetSelected) // if invalid, turn off flicker and remove attack option
            {
                attackButton.Visible = false;
                choiceFlicker.Enabled = false;
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].Text = "" + matchupData.Tables[cpuIndex].Columns[cpuUnits.Controls[cpuTarget].Text].DefaultValue;
                topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"].ForeColor = Color.White;
                healthFlicker = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e) // when the attack button is pushed
        {
            yourTurn = true;
            Ebtn.Checked = false; // unchecks the unit selections
            btn.Checked = false;
            choiceFlicker.Enabled = false;

            switch (targetInt) // assigns the properties to the unit choice
            {
                case 0:
                    playerSelection = 0;
                    playerCompile = "Soldier";
                    imgPlayerChoice = Soldier;
                    break;
                case 1:
                    playerSelection = 1;
                    playerCompile = "Sniper";
                    imgPlayerChoice = Sniper;
                    break;
                case 2:
                    playerSelection = 2;
                    playerCompile = "Bazooka";
                    imgPlayerChoice = Bazooka;
                    break;
                case 3:
                    playerSelection = 3;
                    playerCompile = "Lt";
                    imgPlayerChoice = Lt;
                    break;
                case 4:
                    playerSelection = 4;
                    playerCompile = "Md";
                    imgPlayerChoice = Md;
                    break;
                case 5:
                    playerSelection = 5;
                    playerCompile = "Hvy";
                    imgPlayerChoice = Hvy;
                    break;
                case 6:
                    playerSelection = 6;
                    playerCompile = "AntiTank";
                    imgPlayerChoice = Properties.Resources.ATIcon;
                    break;
            }

            isPlayerAnimation = true;

            if (targetSelected) // if the user has chosen a target (this is a fail safe, once again it shouldn't need this), it does essentially the same stuff as before
            {
                cpuCompile = "" + matchupData.Tables[cpuIndex].Columns[cpuTarget].ColumnName;
                cpuNumberSelection = cpuTarget;
                matchUps(playerSelection, cpuNumberSelection, Convert.ToInt16(matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue), Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue));
                turnCounter++;
                targetSelected = false;

                switch (cpuTarget)
                {
                    case 0:
                        imgCpuChoice = Soldier;
                        cpuNumberSelection = 0;
                        break;
                    case 1:
                        imgCpuChoice = Sniper;
                        cpuNumberSelection = 1;
                        break;
                    case 2:
                        imgCpuChoice = Bazooka;
                        cpuNumberSelection = 2;
                        break;
                    case 3:
                        imgCpuChoice = Lt;
                        cpuNumberSelection = 3;
                        break;
                    case 4:
                        imgCpuChoice = Md;
                        cpuNumberSelection = 4;
                        break;
                    case 5:
                        imgCpuChoice = Hvy;
                        cpuNumberSelection = 5;
                        break;
                    case 6:
                        imgCpuChoice = Properties.Resources.ATIcon;
                        cpuNumberSelection = 6;
                        break;
                }
                // adjusting the anim values \/
                yStart = bottomPanel.Height - Properties.Resources.ATIcon.Height;
                yStop = bottomPanel.Height - Properties.Resources.ATIcon.Height;
                xEStart = bottomPanel.Width + 100;
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
                attackButton.Visible = false;
                targetSelected = false;
                hasPlayerSelected = false;
                btn.Checked = false;
                hasPlayerSelected = false;
                targetSelected = false;
                btn.Checked = false;
                yourTurn = false;
            }
        }
        #endregion userResponse

        #region animation
        private void textSlider()
        {
            //slides text across screen
            BazookaButton.Checked = false;
            slidingTextTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e) // main timer, the animation timer any errors in animation will likely occur here
        {
            // draw the anim
            animation(imgPlayerChoice, imgCpuChoice, Properties.Resources.ATIcon.Height, Properties.Resources.ATIcon.Height, isPlayerAnimation, willDestroy, willCounterDestroy);
            gGraphics.DrawImage(bm, 0, 0);

            // clear the anti-flicker screen \/

            offScreen.Clear(Color.Green);
        }

        // this the bulk of the code, unfortunately this is very finiky, any changes here could cause major problems (even in the main code)
        private void animation(Bitmap image, Bitmap Eimage, int imgHeight, int imgEHeight, bool isYourTurn, bool isDestruction, bool isCounterDestruction)
        {
            yStart = bottomPanel.Height - imgHeight;
            yEStart = bottomPanel.Height - imgEHeight;
            xStop = 10;
            xEStop = bottomPanel.Width - Eimage.Width - 10;

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
                            attack.Play();
                        }

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
                    gGraphics.Clear(Color.Green);
                    offScreen.Clear(Color.Green);

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
                    gGraphics.Clear(Color.Green);
                    offScreen.Clear(Color.Green);
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
                animationTimer.Enabled = false;
                if (endGameCheck())
                {
                    targetSelected = false;
                    hasPlayerSelected = false;
                    Ebtn.Checked = false;
                    willDestroy = false;
                    willCounterDestroy = false;
                    clearUi(false);

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
                    playerAntiTankHealth.Text = "" + matchupData.Tables[playerIndex].Columns[6].DefaultValue;
                    cpuAntiTankHealth.Text = "" + matchupData.Tables[cpuIndex].Columns[6].DefaultValue;

                    textSlider();
                }
            }
        }

        private void clearUi(bool isClear)
        {
            if (isClear)
            {
                topPanel.Visible = false;
            }
            else
            {
                topPanel.Visible = true;
            }
        }

        private void damageFlicker(Control c, int cpuhealth)
        {
            if (healthFlicker == 0) // if the flicker has been reset,
            {
                health = c.CreateGraphics();
                c.Text = "" + cpuhealth;
                c.ForeColor = Color.Green;
            }
            else // else cnt the flicker as it was
            {
                if (healthFlicker % 7 < 3)
                {
                    c.ForeColor = Color.Green; // half the time, green
                }
                else if (healthFlicker % 7 > 4)
                {
                    c.ForeColor = Color.White; // other half, white
                }

                if (!choiceFlicker.Enabled)
                {
                    c.Text = "" + matchupData.Tables[cpuIndex].Columns[c.Name]; // if the flicker is stopped, (anim, diff target) change back the label
                    healthFlicker = 0;
                }
            }

            healthFlicker++;
        }

        private void choiceFlicker_Tick(object sender, EventArgs e)
        {
            int tv1 = (Convert.ToInt16(matchupData.Tables[targetInt].Columns[cpuTarget].DefaultValue)); //damage
            int tv2 = (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[targetInt].DefaultValue)); // health
            int tv3 = (Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuTarget].DefaultValue)); //e health
            int tv = tv1 * tv2 / 100; // damage calc

            if (tv3 - tv < 0) // if the attack will kill
            {
                damageFlicker(topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"], 0);
            }
            else
            {
                damageFlicker(topPanel.Controls["cpu" + cpuUnits.Controls[cpuTarget].Text + "Health"], tv3 - tv);
            }
        }

        private void timer3_Tick(object sender, EventArgs e) // this is the sliding text timer, for sliding the turn across the screen
        {
            gGraphics.Clear(Color.Green);
            BazookaButton.Checked = false; // i don't know why, but for some reason this one gets checked at the beginning, so this unchecks it
            if (textStartPoint.X < textStopPoint.X) // while the text is sliding, 
            {
                if (yourTurn)
                {
                    gGraphics.DrawString("Your Turn", new System.Drawing.Font(FontFamily.GenericSansSerif, 36), new SolidBrush(Color.Black), textStartPoint);
                }
                else
                {
                    gGraphics.DrawString("Enemy Turn", new System.Drawing.Font(FontFamily.GenericSansSerif, 36), new SolidBrush(Color.Black), textStartPoint);
                }

                textStartPoint.X += 20;
            }
            else // if it is done,
            {
                isTurnDoneDisplaying = true;
                turnSlideLabel.Visible = false;
                clearUi(false);

                if (!yourTurn)
                {
                    turnSwap(); // this is for the cpu attack and anim
                }

                textStartPoint = new Point(0 - turnSlideLabel.Width, textStartPoint.Y);
                slidingTextTimer.Enabled = false;
            }
        }
        #endregion animation

        #region misc 
        private void BMPlayer_MediaEnded(object sender, EventArgs e) 
        {
            variables.BMPlayer.Open(new Uri(Application.StartupPath + "/Resources/battle_music.mp3"));
            variables.BMPlayer.Stop();
            variables.BMPlayer.Play();
            //loops music
        }

        private void turnSwap() // when the player attacks, it will allot the enemy its turn
        {
            if (!yourTurn)
            { // pretty much the same as the code above, decides a rnd target, and finds the best match for it
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
                        break;
                    case 3:
                        imgPlayerChoice = Lt;
                        break;
                    case 4:
                        imgPlayerChoice = Md;
                        break;
                    case 5:
                        imgPlayerChoice = Hvy;
                        break;
                    case 6:
                        imgPlayerChoice = Properties.Resources.ATIcon;
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
                        break;
                    case "Lt":
                        imgCpuChoice = Lt;
                        break;
                    case "Md":
                        imgCpuChoice = Md;
                        break;
                    case "Hvy":
                        imgCpuChoice = Hvy;
                        break;
                    case "AntiTank":
                        imgCpuChoice = Properties.Resources.ATIcon;
                        break;
                }
                // same as the player attack code
                matchUps(playerSelection, cpuNumberSelection, Convert.ToInt16(matchupData.Tables[playerIndex].Columns[playerCompile].DefaultValue), Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[cpuCompile].DefaultValue));

                yStart = bottomPanel.Height - Properties.Resources.ATIcon.Height;
                yStop = bottomPanel.Height - Properties.Resources.ATIcon.Height;
                xEStart = bottomPanel.Width + 100;
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
                targetSelected = false;
                animationTimer.Enabled = true;
                yourTurn = true;
            }
        }

        private int getCheckedIndex(Panel panel, object sender) // finds the btn associated with the sender parma
        {
            int checkedIndex = -1;

            for (int index = 0; index < panel.Controls.Count; index++)
            {
                if (panel.Controls[index].Equals(sender))
                {
                    checkedIndex = index;
                }
            }

            return checkedIndex;
        }
        private void organizeControls(Panel panel, bool player) // removes all cntrls, then adds them back in a managible order
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
        #endregion

        #region postGame
        private bool endGameCheck() // checks the conditions for the game to end
        {
            if (isAnimationComplete)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (Convert.ToInt16(matchupData.Tables[playerIndex].Columns[i].DefaultValue) == 0) // for each defeated unit, add one to var below
                    {
                        unitDefeatedCount++;
                    }

                    if (Convert.ToInt16(matchupData.Tables[cpuIndex].Columns[i].DefaultValue) == 0)
                    {
                        EunitDefeatedCount++;
                    }
                }

                if (unitDefeatedCount == 7) // if all the player's units are dead, or all the cpu's units are dead end the game
                {
                    gameEnd(false);
                    clearUi(true);

                    return false;
                }
                else if (EunitDefeatedCount == 7)
                {
                    gameEnd(true);
                    clearUi(true);

                    return false;
                }

                EunitDefeatedCount = 0;
                unitDefeatedCount = 0;
            }

            return true;
        }

        private void gameEnd(bool didPlayerWin) // ends the game
        {
            clearUi(true);
            variables.BMPlayer.Stop();

            turnSlideLabel.Visible = false;
            endGameLabel.Visible = true;
            slidingTextTimer.Enabled = false;
            animationTimer.Enabled = false;

            if (didPlayerWin) // to display the proper end screen 
            {
                variables.victory = true; 
            }
            else
            {
                variables.victory = false;
            }

            screenControl.changeScreen(this, "EndScreen");
        }
        #endregion             
    }
 }