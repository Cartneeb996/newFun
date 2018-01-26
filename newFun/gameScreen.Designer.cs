namespace newFun
{
    partial class gameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.returnToTitleButton = new System.Windows.Forms.Button();
            this.endGameLabel = new System.Windows.Forms.Label();
            this.attackButton = new System.Windows.Forms.Button();
            this.cpuHvyHealth = new System.Windows.Forms.Label();
            this.cpuAntiTankHealth = new System.Windows.Forms.Label();
            this.cpuSniperHealth = new System.Windows.Forms.Label();
            this.cpuBazookaHealth = new System.Windows.Forms.Label();
            this.cpuLtHealth = new System.Windows.Forms.Label();
            this.cpuMdHealth = new System.Windows.Forms.Label();
            this.playerMdHealth = new System.Windows.Forms.Label();
            this.playerLtHealth = new System.Windows.Forms.Label();
            this.playerBazookaHealth = new System.Windows.Forms.Label();
            this.playerHvyHealth = new System.Windows.Forms.Label();
            this.playerSniperHealth = new System.Windows.Forms.Label();
            this.cpuSoldierHealth = new System.Windows.Forms.Label();
            this.playerAntiTankHealth = new System.Windows.Forms.Label();
            this.turnSlideLabel = new System.Windows.Forms.Label();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.matchupData = new System.Data.DataSet();
            this.SoldierMatchup = new System.Data.DataTable();
            this.enemySoldier = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.SniperMatchup = new System.Data.DataTable();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn62 = new System.Data.DataColumn();
            this.dataColumn63 = new System.Data.DataColumn();
            this.dataColumn64 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.BazookaMatchup = new System.Data.DataTable();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.LtMatchup = new System.Data.DataTable();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.MdMatchup = new System.Data.DataTable();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataColumn32 = new System.Data.DataColumn();
            this.HvyMatchup = new System.Data.DataTable();
            this.dataColumn33 = new System.Data.DataColumn();
            this.dataColumn34 = new System.Data.DataColumn();
            this.dataColumn35 = new System.Data.DataColumn();
            this.dataColumn36 = new System.Data.DataColumn();
            this.dataColumn37 = new System.Data.DataColumn();
            this.dataColumn38 = new System.Data.DataColumn();
            this.dataColumn39 = new System.Data.DataColumn();
            this.AntiTankMatchup = new System.Data.DataTable();
            this.dataColumn40 = new System.Data.DataColumn();
            this.dataColumn41 = new System.Data.DataColumn();
            this.dataColumn42 = new System.Data.DataColumn();
            this.dataColumn43 = new System.Data.DataColumn();
            this.dataColumn44 = new System.Data.DataColumn();
            this.dataColumn45 = new System.Data.DataColumn();
            this.dataColumn46 = new System.Data.DataColumn();
            this.CpuHealthValues = new System.Data.DataTable();
            this.dataColumn47 = new System.Data.DataColumn();
            this.dataColumn48 = new System.Data.DataColumn();
            this.dataColumn49 = new System.Data.DataColumn();
            this.dataColumn50 = new System.Data.DataColumn();
            this.dataColumn51 = new System.Data.DataColumn();
            this.dataColumn52 = new System.Data.DataColumn();
            this.dataColumn53 = new System.Data.DataColumn();
            this.PlayerHealthValues = new System.Data.DataTable();
            this.dataColumn54 = new System.Data.DataColumn();
            this.dataColumn55 = new System.Data.DataColumn();
            this.dataColumn56 = new System.Data.DataColumn();
            this.dataColumn57 = new System.Data.DataColumn();
            this.dataColumn58 = new System.Data.DataColumn();
            this.dataColumn59 = new System.Data.DataColumn();
            this.dataColumn60 = new System.Data.DataColumn();
            this.slidingTextTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new System.Windows.Forms.Panel();
            this.cpuUnits = new System.Windows.Forms.Panel();
            this.cpuSoldierButton = new System.Windows.Forms.RadioButton();
            this.cpuSniperButton = new System.Windows.Forms.RadioButton();
            this.cpuAntiTankButton = new System.Windows.Forms.RadioButton();
            this.cpuHvyButton = new System.Windows.Forms.RadioButton();
            this.cpuLtButton = new System.Windows.Forms.RadioButton();
            this.cpuMdButton = new System.Windows.Forms.RadioButton();
            this.cpuBazookaButton = new System.Windows.Forms.RadioButton();
            this.playerSoldierHealth = new System.Windows.Forms.Label();
            this.playerUnits = new System.Windows.Forms.Panel();
            this.SoldierButton = new System.Windows.Forms.RadioButton();
            this.SniperButton = new System.Windows.Forms.RadioButton();
            this.AntiTankButton = new System.Windows.Forms.RadioButton();
            this.HvyButton = new System.Windows.Forms.RadioButton();
            this.LtButton = new System.Windows.Forms.RadioButton();
            this.MdButton = new System.Windows.Forms.RadioButton();
            this.BazookaButton = new System.Windows.Forms.RadioButton();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.choiceFlicker = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.matchupData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoldierMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SniperMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BazookaMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LtMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HvyMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntiTankMatchup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpuHealthValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHealthValues)).BeginInit();
            this.topPanel.SuspendLayout();
            this.cpuUnits.SuspendLayout();
            this.playerUnits.SuspendLayout();
            this.SuspendLayout();
            // 
            // returnToTitleButton
            // 
            this.returnToTitleButton.BackColor = System.Drawing.Color.Red;
            this.returnToTitleButton.FlatAppearance.BorderSize = 0;
            this.returnToTitleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnToTitleButton.Location = new System.Drawing.Point(647, 338);
            this.returnToTitleButton.Name = "returnToTitleButton";
            this.returnToTitleButton.Size = new System.Drawing.Size(84, 38);
            this.returnToTitleButton.TabIndex = 57;
            this.returnToTitleButton.Text = "Return to Title screen";
            this.returnToTitleButton.UseVisualStyleBackColor = false;
            this.returnToTitleButton.Visible = false;
            // 
            // endGameLabel
            // 
            this.endGameLabel.AutoSize = true;
            this.endGameLabel.BackColor = System.Drawing.Color.Transparent;
            this.endGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGameLabel.Location = new System.Drawing.Point(282, 226);
            this.endGameLabel.Name = "endGameLabel";
            this.endGameLabel.Size = new System.Drawing.Size(146, 55);
            this.endGameLabel.TabIndex = 56;
            this.endGameLabel.Text = "TEXT";
            this.endGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.endGameLabel.Visible = false;
            // 
            // attackButton
            // 
            this.attackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.attackButton.FlatAppearance.BorderSize = 0;
            this.attackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.attackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackButton.ForeColor = System.Drawing.Color.White;
            this.attackButton.Location = new System.Drawing.Point(360, 130);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(174, 76);
            this.attackButton.TabIndex = 54;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Visible = false;
            this.attackButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cpuHvyHealth
            // 
            this.cpuHvyHealth.AutoSize = true;
            this.cpuHvyHealth.ForeColor = System.Drawing.Color.White;
            this.cpuHvyHealth.Location = new System.Drawing.Point(596, 209);
            this.cpuHvyHealth.Name = "cpuHvyHealth";
            this.cpuHvyHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuHvyHealth.TabIndex = 52;
            this.cpuHvyHealth.Text = "100";
            // 
            // cpuAntiTankHealth
            // 
            this.cpuAntiTankHealth.AutoSize = true;
            this.cpuAntiTankHealth.ForeColor = System.Drawing.Color.White;
            this.cpuAntiTankHealth.Location = new System.Drawing.Point(596, 226);
            this.cpuAntiTankHealth.Name = "cpuAntiTankHealth";
            this.cpuAntiTankHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuAntiTankHealth.TabIndex = 51;
            this.cpuAntiTankHealth.Text = "100";
            // 
            // cpuSniperHealth
            // 
            this.cpuSniperHealth.AutoSize = true;
            this.cpuSniperHealth.ForeColor = System.Drawing.Color.White;
            this.cpuSniperHealth.Location = new System.Drawing.Point(596, 147);
            this.cpuSniperHealth.Name = "cpuSniperHealth";
            this.cpuSniperHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuSniperHealth.TabIndex = 50;
            this.cpuSniperHealth.Text = "100";
            // 
            // cpuBazookaHealth
            // 
            this.cpuBazookaHealth.AutoSize = true;
            this.cpuBazookaHealth.ForeColor = System.Drawing.Color.White;
            this.cpuBazookaHealth.Location = new System.Drawing.Point(596, 163);
            this.cpuBazookaHealth.Name = "cpuBazookaHealth";
            this.cpuBazookaHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuBazookaHealth.TabIndex = 49;
            this.cpuBazookaHealth.Text = "100";
            // 
            // cpuLtHealth
            // 
            this.cpuLtHealth.AutoSize = true;
            this.cpuLtHealth.ForeColor = System.Drawing.Color.White;
            this.cpuLtHealth.Location = new System.Drawing.Point(596, 178);
            this.cpuLtHealth.Name = "cpuLtHealth";
            this.cpuLtHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuLtHealth.TabIndex = 48;
            this.cpuLtHealth.Text = "100";
            // 
            // cpuMdHealth
            // 
            this.cpuMdHealth.AutoSize = true;
            this.cpuMdHealth.ForeColor = System.Drawing.Color.White;
            this.cpuMdHealth.Location = new System.Drawing.Point(596, 193);
            this.cpuMdHealth.Name = "cpuMdHealth";
            this.cpuMdHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuMdHealth.TabIndex = 47;
            this.cpuMdHealth.Text = "100";
            // 
            // playerMdHealth
            // 
            this.playerMdHealth.AutoSize = true;
            this.playerMdHealth.ForeColor = System.Drawing.Color.White;
            this.playerMdHealth.Location = new System.Drawing.Point(143, 193);
            this.playerMdHealth.Name = "playerMdHealth";
            this.playerMdHealth.Size = new System.Drawing.Size(25, 13);
            this.playerMdHealth.TabIndex = 46;
            this.playerMdHealth.Text = "100";
            // 
            // playerLtHealth
            // 
            this.playerLtHealth.AutoSize = true;
            this.playerLtHealth.ForeColor = System.Drawing.Color.White;
            this.playerLtHealth.Location = new System.Drawing.Point(143, 178);
            this.playerLtHealth.Name = "playerLtHealth";
            this.playerLtHealth.Size = new System.Drawing.Size(25, 13);
            this.playerLtHealth.TabIndex = 45;
            this.playerLtHealth.Text = "100";
            // 
            // playerBazookaHealth
            // 
            this.playerBazookaHealth.AutoSize = true;
            this.playerBazookaHealth.ForeColor = System.Drawing.Color.White;
            this.playerBazookaHealth.Location = new System.Drawing.Point(143, 163);
            this.playerBazookaHealth.Name = "playerBazookaHealth";
            this.playerBazookaHealth.Size = new System.Drawing.Size(25, 13);
            this.playerBazookaHealth.TabIndex = 44;
            this.playerBazookaHealth.Text = "100";
            // 
            // playerHvyHealth
            // 
            this.playerHvyHealth.AutoSize = true;
            this.playerHvyHealth.ForeColor = System.Drawing.Color.White;
            this.playerHvyHealth.Location = new System.Drawing.Point(143, 209);
            this.playerHvyHealth.Name = "playerHvyHealth";
            this.playerHvyHealth.Size = new System.Drawing.Size(25, 13);
            this.playerHvyHealth.TabIndex = 43;
            this.playerHvyHealth.Text = "100";
            // 
            // playerSniperHealth
            // 
            this.playerSniperHealth.AutoSize = true;
            this.playerSniperHealth.ForeColor = System.Drawing.Color.White;
            this.playerSniperHealth.Location = new System.Drawing.Point(143, 147);
            this.playerSniperHealth.Name = "playerSniperHealth";
            this.playerSniperHealth.Size = new System.Drawing.Size(25, 13);
            this.playerSniperHealth.TabIndex = 42;
            this.playerSniperHealth.Text = "100";
            // 
            // cpuSoldierHealth
            // 
            this.cpuSoldierHealth.AutoSize = true;
            this.cpuSoldierHealth.ForeColor = System.Drawing.Color.White;
            this.cpuSoldierHealth.Location = new System.Drawing.Point(596, 130);
            this.cpuSoldierHealth.Name = "cpuSoldierHealth";
            this.cpuSoldierHealth.Size = new System.Drawing.Size(25, 13);
            this.cpuSoldierHealth.TabIndex = 41;
            this.cpuSoldierHealth.Text = "100";
            // 
            // playerAntiTankHealth
            // 
            this.playerAntiTankHealth.AutoSize = true;
            this.playerAntiTankHealth.ForeColor = System.Drawing.Color.White;
            this.playerAntiTankHealth.Location = new System.Drawing.Point(143, 226);
            this.playerAntiTankHealth.Name = "playerAntiTankHealth";
            this.playerAntiTankHealth.Size = new System.Drawing.Size(25, 13);
            this.playerAntiTankHealth.TabIndex = 40;
            this.playerAntiTankHealth.Text = "100";
            // 
            // turnSlideLabel
            // 
            this.turnSlideLabel.AutoSize = true;
            this.turnSlideLabel.BackColor = System.Drawing.Color.Transparent;
            this.turnSlideLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnSlideLabel.Location = new System.Drawing.Point(115, 266);
            this.turnSlideLabel.Name = "turnSlideLabel";
            this.turnSlideLabel.Size = new System.Drawing.Size(238, 55);
            this.turnSlideLabel.TabIndex = 38;
            this.turnSlideLabel.Text = "Your Turn";
            this.turnSlideLabel.Visible = false;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 16;
            this.animationTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // matchupData
            // 
            this.matchupData.DataSetName = "NewDataSet";
            this.matchupData.Tables.AddRange(new System.Data.DataTable[] {
            this.SoldierMatchup,
            this.SniperMatchup,
            this.BazookaMatchup,
            this.LtMatchup,
            this.MdMatchup,
            this.HvyMatchup,
            this.AntiTankMatchup,
            this.CpuHealthValues,
            this.PlayerHealthValues});
            // 
            // SoldierMatchup
            // 
            this.SoldierMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.enemySoldier,
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.SoldierMatchup.TableName = "SoldierMatchup";
            // 
            // enemySoldier
            // 
            this.enemySoldier.ColumnName = "enemySoldier";
            this.enemySoldier.DataType = typeof(short);
            this.enemySoldier.DefaultValue = ((short)(75));
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "enemySniper";
            this.dataColumn1.DataType = typeof(short);
            this.dataColumn1.DefaultValue = ((short)(75));
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "enemyBazooka";
            this.dataColumn2.DataType = typeof(short);
            this.dataColumn2.DefaultValue = ((short)(75));
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "enemyLt";
            this.dataColumn3.DataType = typeof(short);
            this.dataColumn3.DefaultValue = ((short)(20));
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "enemyMd";
            this.dataColumn4.DataType = typeof(short);
            this.dataColumn4.DefaultValue = ((short)(10));
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "enemyHvy";
            this.dataColumn5.DataType = typeof(short);
            this.dataColumn5.DefaultValue = ((short)(5));
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "enemyAntiTank";
            this.dataColumn6.DataType = typeof(short);
            this.dataColumn6.DefaultValue = ((short)(10));
            // 
            // SniperMatchup
            // 
            this.SniperMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn7,
            this.dataColumn11,
            this.dataColumn62,
            this.dataColumn63,
            this.dataColumn64,
            this.dataColumn8,
            this.dataColumn9});
            this.SniperMatchup.TableName = "SniperMatchup";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "enemySoldier";
            this.dataColumn7.DataType = typeof(short);
            this.dataColumn7.DefaultValue = ((short)(200));
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "enemySniper";
            this.dataColumn11.DataType = typeof(short);
            this.dataColumn11.DefaultValue = ((short)(200));
            // 
            // dataColumn62
            // 
            this.dataColumn62.Caption = "enemyBazooka";
            this.dataColumn62.ColumnName = "enemyBazooka";
            this.dataColumn62.DataType = typeof(short);
            this.dataColumn62.DefaultValue = ((short)(200));
            // 
            // dataColumn63
            // 
            this.dataColumn63.ColumnName = "enemyLt";
            this.dataColumn63.DataType = typeof(short);
            this.dataColumn63.DefaultValue = ((short)(10));
            // 
            // dataColumn64
            // 
            this.dataColumn64.ColumnName = "enemyMd";
            this.dataColumn64.DataType = typeof(short);
            this.dataColumn64.DefaultValue = ((short)(5));
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "enemyHvy";
            this.dataColumn8.DataType = typeof(short);
            this.dataColumn8.DefaultValue = ((short)(0));
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "enemyAntiTank";
            this.dataColumn9.DataType = typeof(short);
            this.dataColumn9.DefaultValue = ((short)(10));
            // 
            // BazookaMatchup
            // 
            this.BazookaMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18});
            this.BazookaMatchup.TableName = "BazookaMatchup";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "enemySoldier";
            this.dataColumn12.DataType = typeof(short);
            this.dataColumn12.DefaultValue = ((short)(20));
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "enemySniper";
            this.dataColumn13.DataType = typeof(short);
            this.dataColumn13.DefaultValue = ((short)(20));
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "enemyBazooka";
            this.dataColumn14.DataType = typeof(short);
            this.dataColumn14.DefaultValue = ((short)(20));
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "enemyLt";
            this.dataColumn15.DataType = typeof(short);
            this.dataColumn15.DefaultValue = ((short)(150));
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "enemyMd";
            this.dataColumn16.DataType = typeof(short);
            this.dataColumn16.DefaultValue = ((short)(100));
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "enemyHvy";
            this.dataColumn17.DataType = typeof(short);
            this.dataColumn17.DefaultValue = ((short)(50));
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "enemyAntiTank";
            this.dataColumn18.DataType = typeof(short);
            this.dataColumn18.DefaultValue = ((short)(150));
            // 
            // LtMatchup
            // 
            this.LtMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25});
            this.LtMatchup.TableName = "LtMatchup";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "enemySoldier";
            this.dataColumn19.DataType = typeof(short);
            this.dataColumn19.DefaultValue = ((short)(50));
            // 
            // dataColumn20
            // 
            this.dataColumn20.Caption = "enemySniper";
            this.dataColumn20.ColumnName = "enemySniper";
            this.dataColumn20.DataType = typeof(short);
            this.dataColumn20.DefaultValue = ((short)(50));
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "enemyBazooka";
            this.dataColumn21.DataType = typeof(short);
            this.dataColumn21.DefaultValue = ((short)(50));
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "enemyLt";
            this.dataColumn22.DataType = typeof(short);
            this.dataColumn22.DefaultValue = ((short)(75));
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "enemyMd";
            this.dataColumn23.DataType = typeof(short);
            this.dataColumn23.DefaultValue = ((short)(40));
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "enemyHvy";
            this.dataColumn24.DataType = typeof(short);
            this.dataColumn24.DefaultValue = ((short)(10));
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "enemyAntiTank";
            this.dataColumn25.DataType = typeof(short);
            this.dataColumn25.DefaultValue = ((short)(50));
            // 
            // MdMatchup
            // 
            this.MdMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn26,
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn29,
            this.dataColumn30,
            this.dataColumn31,
            this.dataColumn32});
            this.MdMatchup.TableName = "MdMatchup";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "enemySoldier";
            this.dataColumn26.DataType = typeof(short);
            this.dataColumn26.DefaultValue = ((short)(60));
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "enemySniper";
            this.dataColumn27.DataType = typeof(short);
            this.dataColumn27.DefaultValue = ((short)(60));
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "enemyBazooka";
            this.dataColumn28.DataType = typeof(short);
            this.dataColumn28.DefaultValue = ((short)(60));
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "enemyLt";
            this.dataColumn29.DataType = typeof(short);
            this.dataColumn29.DefaultValue = ((short)(80));
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "enemyMd";
            this.dataColumn30.DefaultValue = "50";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "enemyHvy";
            this.dataColumn31.DataType = typeof(short);
            this.dataColumn31.DefaultValue = ((short)(30));
            // 
            // dataColumn32
            // 
            this.dataColumn32.ColumnName = "enemyAntiTank";
            this.dataColumn32.DataType = typeof(short);
            this.dataColumn32.DefaultValue = ((short)(40));
            // 
            // HvyMatchup
            // 
            this.HvyMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn33,
            this.dataColumn34,
            this.dataColumn35,
            this.dataColumn36,
            this.dataColumn37,
            this.dataColumn38,
            this.dataColumn39});
            this.HvyMatchup.TableName = "HvyMatchup";
            // 
            // dataColumn33
            // 
            this.dataColumn33.ColumnName = "enemySoldier";
            this.dataColumn33.DataType = typeof(short);
            this.dataColumn33.DefaultValue = ((short)(70));
            // 
            // dataColumn34
            // 
            this.dataColumn34.ColumnName = "enemySniper";
            this.dataColumn34.DataType = typeof(short);
            this.dataColumn34.DefaultValue = ((short)(70));
            // 
            // dataColumn35
            // 
            this.dataColumn35.ColumnName = "enemyBazooka";
            this.dataColumn35.DataType = typeof(short);
            this.dataColumn35.DefaultValue = ((short)(70));
            // 
            // dataColumn36
            // 
            this.dataColumn36.ColumnName = "enemyLt";
            this.dataColumn36.DataType = typeof(short);
            this.dataColumn36.DefaultValue = ((short)(85));
            // 
            // dataColumn37
            // 
            this.dataColumn37.ColumnName = "enemyMd";
            this.dataColumn37.DataType = typeof(short);
            this.dataColumn37.DefaultValue = ((short)(60));
            // 
            // dataColumn38
            // 
            this.dataColumn38.ColumnName = "enemyHvy";
            this.dataColumn38.DataType = typeof(short);
            this.dataColumn38.DefaultValue = ((short)(50));
            // 
            // dataColumn39
            // 
            this.dataColumn39.ColumnName = "enemyAntiTank";
            this.dataColumn39.DataType = typeof(short);
            this.dataColumn39.DefaultValue = ((short)(40));
            // 
            // AntiTankMatchup
            // 
            this.AntiTankMatchup.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn40,
            this.dataColumn41,
            this.dataColumn42,
            this.dataColumn43,
            this.dataColumn44,
            this.dataColumn45,
            this.dataColumn46});
            this.AntiTankMatchup.TableName = "AntiTankMatchup";
            // 
            // dataColumn40
            // 
            this.dataColumn40.ColumnName = "enemySoldier";
            this.dataColumn40.DataType = typeof(short);
            this.dataColumn40.DefaultValue = ((short)(50));
            // 
            // dataColumn41
            // 
            this.dataColumn41.ColumnName = "enemySniper";
            this.dataColumn41.DataType = typeof(short);
            this.dataColumn41.DefaultValue = ((short)(50));
            // 
            // dataColumn42
            // 
            this.dataColumn42.ColumnName = "enemyBazooka";
            this.dataColumn42.DataType = typeof(short);
            this.dataColumn42.DefaultValue = ((short)(50));
            // 
            // dataColumn43
            // 
            this.dataColumn43.ColumnName = "enemyLt";
            this.dataColumn43.DataType = typeof(short);
            this.dataColumn43.DefaultValue = ((short)(200));
            // 
            // dataColumn44
            // 
            this.dataColumn44.ColumnName = "enemyMd";
            this.dataColumn44.DataType = typeof(short);
            this.dataColumn44.DefaultValue = ((short)(100));
            // 
            // dataColumn45
            // 
            this.dataColumn45.ColumnName = "enemyHvy";
            this.dataColumn45.DataType = typeof(short);
            this.dataColumn45.DefaultValue = ((short)(75));
            // 
            // dataColumn46
            // 
            this.dataColumn46.ColumnName = "enemyAntiTank";
            this.dataColumn46.DataType = typeof(short);
            this.dataColumn46.DefaultValue = ((short)(50));
            // 
            // CpuHealthValues
            // 
            this.CpuHealthValues.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn47,
            this.dataColumn48,
            this.dataColumn49,
            this.dataColumn50,
            this.dataColumn51,
            this.dataColumn52,
            this.dataColumn53});
            this.CpuHealthValues.TableName = "CpuHealth";
            // 
            // dataColumn47
            // 
            this.dataColumn47.ColumnName = "Soldier";
            this.dataColumn47.DataType = typeof(short);
            this.dataColumn47.DefaultValue = ((short)(100));
            // 
            // dataColumn48
            // 
            this.dataColumn48.ColumnName = "Sniper";
            this.dataColumn48.DataType = typeof(short);
            this.dataColumn48.DefaultValue = ((short)(100));
            // 
            // dataColumn49
            // 
            this.dataColumn49.ColumnName = "Bazooka";
            this.dataColumn49.DataType = typeof(short);
            this.dataColumn49.DefaultValue = ((short)(100));
            // 
            // dataColumn50
            // 
            this.dataColumn50.ColumnName = "Lt";
            this.dataColumn50.DataType = typeof(short);
            this.dataColumn50.DefaultValue = ((short)(100));
            // 
            // dataColumn51
            // 
            this.dataColumn51.ColumnName = "Md";
            this.dataColumn51.DataType = typeof(short);
            this.dataColumn51.DefaultValue = ((short)(100));
            // 
            // dataColumn52
            // 
            this.dataColumn52.ColumnName = "Hvy";
            this.dataColumn52.DataType = typeof(short);
            this.dataColumn52.DefaultValue = ((short)(100));
            // 
            // dataColumn53
            // 
            this.dataColumn53.ColumnName = "AntiTank";
            this.dataColumn53.DataType = typeof(short);
            this.dataColumn53.DefaultValue = ((short)(100));
            // 
            // PlayerHealthValues
            // 
            this.PlayerHealthValues.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn54,
            this.dataColumn55,
            this.dataColumn56,
            this.dataColumn57,
            this.dataColumn58,
            this.dataColumn59,
            this.dataColumn60});
            this.PlayerHealthValues.TableName = "PlayerHealth";
            // 
            // dataColumn54
            // 
            this.dataColumn54.ColumnName = "Soldier";
            this.dataColumn54.DataType = typeof(short);
            this.dataColumn54.DefaultValue = ((short)(100));
            // 
            // dataColumn55
            // 
            this.dataColumn55.ColumnName = "Sniper";
            this.dataColumn55.DataType = typeof(short);
            this.dataColumn55.DefaultValue = ((short)(100));
            // 
            // dataColumn56
            // 
            this.dataColumn56.ColumnName = "Bazooka";
            this.dataColumn56.DataType = typeof(short);
            this.dataColumn56.DefaultValue = ((short)(100));
            // 
            // dataColumn57
            // 
            this.dataColumn57.ColumnName = "Lt";
            this.dataColumn57.DataType = typeof(short);
            this.dataColumn57.DefaultValue = ((short)(100));
            // 
            // dataColumn58
            // 
            this.dataColumn58.ColumnName = "Md";
            this.dataColumn58.DataType = typeof(short);
            this.dataColumn58.DefaultValue = ((short)(100));
            // 
            // dataColumn59
            // 
            this.dataColumn59.ColumnName = "Hvy";
            this.dataColumn59.DataType = typeof(short);
            this.dataColumn59.DefaultValue = ((short)(100));
            // 
            // dataColumn60
            // 
            this.dataColumn60.ColumnName = "AntiTank";
            this.dataColumn60.DataType = typeof(short);
            this.dataColumn60.DefaultValue = ((short)(100));
            // 
            // slidingTextTimer
            // 
            this.slidingTextTimer.Interval = 16;
            this.slidingTextTimer.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Controls.Add(this.cpuUnits);
            this.topPanel.Controls.Add(this.cpuSniperHealth);
            this.topPanel.Controls.Add(this.cpuAntiTankHealth);
            this.topPanel.Controls.Add(this.cpuHvyHealth);
            this.topPanel.Controls.Add(this.cpuMdHealth);
            this.topPanel.Controls.Add(this.cpuLtHealth);
            this.topPanel.Controls.Add(this.cpuBazookaHealth);
            this.topPanel.Controls.Add(this.cpuSoldierHealth);
            this.topPanel.Controls.Add(this.returnToTitleButton);
            this.topPanel.Controls.Add(this.turnSlideLabel);
            this.topPanel.Controls.Add(this.attackButton);
            this.topPanel.Controls.Add(this.endGameLabel);
            this.topPanel.Controls.Add(this.playerMdHealth);
            this.topPanel.Controls.Add(this.playerLtHealth);
            this.topPanel.Controls.Add(this.playerBazookaHealth);
            this.topPanel.Controls.Add(this.playerHvyHealth);
            this.topPanel.Controls.Add(this.playerSniperHealth);
            this.topPanel.Controls.Add(this.playerAntiTankHealth);
            this.topPanel.Controls.Add(this.playerSoldierHealth);
            this.topPanel.Controls.Add(this.playerUnits);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(867, 283);
            this.topPanel.TabIndex = 59;
            // 
            // cpuUnits
            // 
            this.cpuUnits.Controls.Add(this.cpuSoldierButton);
            this.cpuUnits.Controls.Add(this.cpuSniperButton);
            this.cpuUnits.Controls.Add(this.cpuAntiTankButton);
            this.cpuUnits.Controls.Add(this.cpuHvyButton);
            this.cpuUnits.Controls.Add(this.cpuLtButton);
            this.cpuUnits.Controls.Add(this.cpuMdButton);
            this.cpuUnits.Controls.Add(this.cpuBazookaButton);
            this.cpuUnits.ForeColor = System.Drawing.Color.White;
            this.cpuUnits.Location = new System.Drawing.Point(647, 130);
            this.cpuUnits.Name = "cpuUnits";
            this.cpuUnits.Size = new System.Drawing.Size(102, 117);
            this.cpuUnits.TabIndex = 65;
            // 
            // cpuSoldierButton
            // 
            this.cpuSoldierButton.AutoSize = true;
            this.cpuSoldierButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuSoldierButton.ForeColor = System.Drawing.Color.Red;
            this.cpuSoldierButton.Location = new System.Drawing.Point(45, 0);
            this.cpuSoldierButton.Name = "cpuSoldierButton";
            this.cpuSoldierButton.Size = new System.Drawing.Size(57, 17);
            this.cpuSoldierButton.TabIndex = 6;
            this.cpuSoldierButton.TabStop = true;
            this.cpuSoldierButton.Text = "Soldier";
            this.cpuSoldierButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuSoldierButton.UseVisualStyleBackColor = true;
            this.cpuSoldierButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuSniperButton
            // 
            this.cpuSniperButton.AutoSize = true;
            this.cpuSniperButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuSniperButton.ForeColor = System.Drawing.Color.Red;
            this.cpuSniperButton.Location = new System.Drawing.Point(47, 17);
            this.cpuSniperButton.Name = "cpuSniperButton";
            this.cpuSniperButton.Size = new System.Drawing.Size(55, 17);
            this.cpuSniperButton.TabIndex = 5;
            this.cpuSniperButton.TabStop = true;
            this.cpuSniperButton.Text = "Sniper";
            this.cpuSniperButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuSniperButton.UseVisualStyleBackColor = true;
            this.cpuSniperButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuAntiTankButton
            // 
            this.cpuAntiTankButton.AutoSize = true;
            this.cpuAntiTankButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuAntiTankButton.ForeColor = System.Drawing.Color.Red;
            this.cpuAntiTankButton.Location = new System.Drawing.Point(34, 94);
            this.cpuAntiTankButton.Name = "cpuAntiTankButton";
            this.cpuAntiTankButton.Size = new System.Drawing.Size(68, 17);
            this.cpuAntiTankButton.TabIndex = 4;
            this.cpuAntiTankButton.TabStop = true;
            this.cpuAntiTankButton.Text = "AntiTank";
            this.cpuAntiTankButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuAntiTankButton.UseVisualStyleBackColor = true;
            this.cpuAntiTankButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuHvyButton
            // 
            this.cpuHvyButton.AutoSize = true;
            this.cpuHvyButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuHvyButton.ForeColor = System.Drawing.Color.Red;
            this.cpuHvyButton.Location = new System.Drawing.Point(58, 79);
            this.cpuHvyButton.Name = "cpuHvyButton";
            this.cpuHvyButton.Size = new System.Drawing.Size(44, 17);
            this.cpuHvyButton.TabIndex = 3;
            this.cpuHvyButton.TabStop = true;
            this.cpuHvyButton.Text = "Hvy";
            this.cpuHvyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuHvyButton.UseVisualStyleBackColor = true;
            this.cpuHvyButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuLtButton
            // 
            this.cpuLtButton.AutoSize = true;
            this.cpuLtButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuLtButton.ForeColor = System.Drawing.Color.Red;
            this.cpuLtButton.Location = new System.Drawing.Point(68, 48);
            this.cpuLtButton.Name = "cpuLtButton";
            this.cpuLtButton.Size = new System.Drawing.Size(34, 17);
            this.cpuLtButton.TabIndex = 2;
            this.cpuLtButton.TabStop = true;
            this.cpuLtButton.Text = "Lt";
            this.cpuLtButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuLtButton.UseVisualStyleBackColor = true;
            this.cpuLtButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuMdButton
            // 
            this.cpuMdButton.AutoSize = true;
            this.cpuMdButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuMdButton.ForeColor = System.Drawing.Color.Red;
            this.cpuMdButton.Location = new System.Drawing.Point(62, 63);
            this.cpuMdButton.Name = "cpuMdButton";
            this.cpuMdButton.Size = new System.Drawing.Size(40, 17);
            this.cpuMdButton.TabIndex = 1;
            this.cpuMdButton.TabStop = true;
            this.cpuMdButton.Text = "Md";
            this.cpuMdButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuMdButton.UseVisualStyleBackColor = true;
            this.cpuMdButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // cpuBazookaButton
            // 
            this.cpuBazookaButton.AutoSize = true;
            this.cpuBazookaButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuBazookaButton.ForeColor = System.Drawing.Color.Red;
            this.cpuBazookaButton.Location = new System.Drawing.Point(35, 33);
            this.cpuBazookaButton.Name = "cpuBazookaButton";
            this.cpuBazookaButton.Size = new System.Drawing.Size(67, 17);
            this.cpuBazookaButton.TabIndex = 0;
            this.cpuBazookaButton.TabStop = true;
            this.cpuBazookaButton.Text = "Bazooka";
            this.cpuBazookaButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cpuBazookaButton.UseVisualStyleBackColor = true;
            this.cpuBazookaButton.CheckedChanged += new System.EventHandler(this.cpuUnits_SelectedValueChanged);
            // 
            // playerSoldierHealth
            // 
            this.playerSoldierHealth.AutoSize = true;
            this.playerSoldierHealth.ForeColor = System.Drawing.Color.White;
            this.playerSoldierHealth.Location = new System.Drawing.Point(143, 130);
            this.playerSoldierHealth.Name = "playerSoldierHealth";
            this.playerSoldierHealth.Size = new System.Drawing.Size(25, 13);
            this.playerSoldierHealth.TabIndex = 39;
            this.playerSoldierHealth.Text = "100";
            // 
            // playerUnits
            // 
            this.playerUnits.Controls.Add(this.SoldierButton);
            this.playerUnits.Controls.Add(this.SniperButton);
            this.playerUnits.Controls.Add(this.AntiTankButton);
            this.playerUnits.Controls.Add(this.HvyButton);
            this.playerUnits.Controls.Add(this.LtButton);
            this.playerUnits.Controls.Add(this.MdButton);
            this.playerUnits.Controls.Add(this.BazookaButton);
            this.playerUnits.ForeColor = System.Drawing.Color.White;
            this.playerUnits.Location = new System.Drawing.Point(16, 122);
            this.playerUnits.Name = "playerUnits";
            this.playerUnits.Size = new System.Drawing.Size(100, 117);
            this.playerUnits.TabIndex = 64;
            // 
            // SoldierButton
            // 
            this.SoldierButton.AutoSize = true;
            this.SoldierButton.ForeColor = System.Drawing.Color.Lime;
            this.SoldierButton.Location = new System.Drawing.Point(3, 8);
            this.SoldierButton.Name = "SoldierButton";
            this.SoldierButton.Size = new System.Drawing.Size(57, 17);
            this.SoldierButton.TabIndex = 6;
            this.SoldierButton.TabStop = true;
            this.SoldierButton.Text = "Soldier";
            this.SoldierButton.UseVisualStyleBackColor = true;
            this.SoldierButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // SniperButton
            // 
            this.SniperButton.AutoSize = true;
            this.SniperButton.ForeColor = System.Drawing.Color.Lime;
            this.SniperButton.Location = new System.Drawing.Point(3, 23);
            this.SniperButton.Name = "SniperButton";
            this.SniperButton.Size = new System.Drawing.Size(55, 17);
            this.SniperButton.TabIndex = 5;
            this.SniperButton.TabStop = true;
            this.SniperButton.Text = "Sniper";
            this.SniperButton.UseVisualStyleBackColor = true;
            this.SniperButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // AntiTankButton
            // 
            this.AntiTankButton.AutoSize = true;
            this.AntiTankButton.ForeColor = System.Drawing.Color.Lime;
            this.AntiTankButton.Location = new System.Drawing.Point(3, 102);
            this.AntiTankButton.Name = "AntiTankButton";
            this.AntiTankButton.Size = new System.Drawing.Size(68, 17);
            this.AntiTankButton.TabIndex = 4;
            this.AntiTankButton.TabStop = true;
            this.AntiTankButton.Text = "AntiTank";
            this.AntiTankButton.UseVisualStyleBackColor = true;
            this.AntiTankButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // HvyButton
            // 
            this.HvyButton.AutoSize = true;
            this.HvyButton.ForeColor = System.Drawing.Color.Lime;
            this.HvyButton.Location = new System.Drawing.Point(3, 87);
            this.HvyButton.Name = "HvyButton";
            this.HvyButton.Size = new System.Drawing.Size(44, 17);
            this.HvyButton.TabIndex = 3;
            this.HvyButton.TabStop = true;
            this.HvyButton.Text = "Hvy";
            this.HvyButton.UseVisualStyleBackColor = true;
            this.HvyButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // LtButton
            // 
            this.LtButton.AutoSize = true;
            this.LtButton.ForeColor = System.Drawing.Color.Lime;
            this.LtButton.Location = new System.Drawing.Point(3, 54);
            this.LtButton.Name = "LtButton";
            this.LtButton.Size = new System.Drawing.Size(34, 17);
            this.LtButton.TabIndex = 2;
            this.LtButton.TabStop = true;
            this.LtButton.Text = "Lt";
            this.LtButton.UseVisualStyleBackColor = true;
            this.LtButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // MdButton
            // 
            this.MdButton.AutoSize = true;
            this.MdButton.ForeColor = System.Drawing.Color.Lime;
            this.MdButton.Location = new System.Drawing.Point(3, 71);
            this.MdButton.Name = "MdButton";
            this.MdButton.Size = new System.Drawing.Size(40, 17);
            this.MdButton.TabIndex = 1;
            this.MdButton.TabStop = true;
            this.MdButton.Text = "Md";
            this.MdButton.UseVisualStyleBackColor = true;
            this.MdButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // BazookaButton
            // 
            this.BazookaButton.AutoSize = true;
            this.BazookaButton.ForeColor = System.Drawing.Color.Lime;
            this.BazookaButton.Location = new System.Drawing.Point(3, 39);
            this.BazookaButton.Name = "BazookaButton";
            this.BazookaButton.Size = new System.Drawing.Size(67, 17);
            this.BazookaButton.TabIndex = 0;
            this.BazookaButton.TabStop = true;
            this.BazookaButton.Text = "Bazooka";
            this.BazookaButton.UseVisualStyleBackColor = true;
            this.BazookaButton.CheckedChanged += new System.EventHandler(this.troopSelection_SelectedValueChanged);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Green;
            this.bottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bottomPanel.ForeColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Location = new System.Drawing.Point(0, 280);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(867, 188);
            this.bottomPanel.TabIndex = 60;
            // 
            // choiceFlicker
            // 
            this.choiceFlicker.Tick += new System.EventHandler(this.choiceFlicker_Tick);
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::newFun.Properties.Resources.cammo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(867, 468);
            this.Resize += new System.EventHandler(this.gameScreen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.matchupData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoldierMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SniperMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BazookaMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LtMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MdMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HvyMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AntiTankMatchup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CpuHealthValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHealthValues)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.cpuUnits.ResumeLayout(false);
            this.cpuUnits.PerformLayout();
            this.playerUnits.ResumeLayout(false);
            this.playerUnits.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button returnToTitleButton;
        private System.Windows.Forms.Label endGameLabel;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Label cpuHvyHealth;
        private System.Windows.Forms.Label cpuAntiTankHealth;
        private System.Windows.Forms.Label cpuSniperHealth;
        private System.Windows.Forms.Label cpuBazookaHealth;
        private System.Windows.Forms.Label cpuLtHealth;
        private System.Windows.Forms.Label cpuMdHealth;
        private System.Windows.Forms.Label playerMdHealth;
        private System.Windows.Forms.Label playerLtHealth;
        private System.Windows.Forms.Label playerBazookaHealth;
        private System.Windows.Forms.Label playerHvyHealth;
        private System.Windows.Forms.Label playerSniperHealth;
        private System.Windows.Forms.Label cpuSoldierHealth;
        private System.Windows.Forms.Label playerAntiTankHealth;
        private System.Windows.Forms.Label turnSlideLabel;
        private System.Windows.Forms.Timer animationTimer;
        private System.Data.DataSet matchupData;
        private System.Data.DataTable SoldierMatchup;
        private System.Data.DataColumn enemySoldier;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataTable SniperMatchup;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn62;
        private System.Data.DataColumn dataColumn63;
        private System.Data.DataColumn dataColumn64;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataTable BazookaMatchup;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataTable LtMatchup;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn25;
        private System.Data.DataTable MdMatchup;
        private System.Data.DataColumn dataColumn26;
        private System.Data.DataColumn dataColumn27;
        private System.Data.DataColumn dataColumn28;
        private System.Data.DataColumn dataColumn29;
        private System.Data.DataColumn dataColumn30;
        private System.Data.DataColumn dataColumn31;
        private System.Data.DataColumn dataColumn32;
        private System.Data.DataTable HvyMatchup;
        private System.Data.DataColumn dataColumn33;
        private System.Data.DataColumn dataColumn34;
        private System.Data.DataColumn dataColumn35;
        private System.Data.DataColumn dataColumn36;
        private System.Data.DataColumn dataColumn37;
        private System.Data.DataColumn dataColumn38;
        private System.Data.DataColumn dataColumn39;
        private System.Data.DataTable AntiTankMatchup;
        private System.Data.DataColumn dataColumn40;
        private System.Data.DataColumn dataColumn41;
        private System.Data.DataColumn dataColumn42;
        private System.Data.DataColumn dataColumn43;
        private System.Data.DataColumn dataColumn44;
        private System.Data.DataColumn dataColumn45;
        private System.Data.DataColumn dataColumn46;
        private System.Data.DataTable CpuHealthValues;
        private System.Data.DataColumn dataColumn47;
        private System.Data.DataColumn dataColumn48;
        private System.Data.DataColumn dataColumn49;
        private System.Data.DataColumn dataColumn50;
        private System.Data.DataColumn dataColumn51;
        private System.Data.DataColumn dataColumn52;
        private System.Data.DataColumn dataColumn53;
        private System.Data.DataTable PlayerHealthValues;
        private System.Data.DataColumn dataColumn54;
        private System.Data.DataColumn dataColumn55;
        private System.Data.DataColumn dataColumn56;
        private System.Data.DataColumn dataColumn57;
        private System.Data.DataColumn dataColumn58;
        private System.Data.DataColumn dataColumn59;
        private System.Data.DataColumn dataColumn60;
        private System.Windows.Forms.Timer slidingTextTimer;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Label playerSoldierHealth;
        private System.Windows.Forms.Panel playerUnits;
        private System.Windows.Forms.RadioButton SoldierButton;
        private System.Windows.Forms.RadioButton SniperButton;
        private System.Windows.Forms.RadioButton AntiTankButton;
        private System.Windows.Forms.RadioButton HvyButton;
        private System.Windows.Forms.RadioButton LtButton;
        private System.Windows.Forms.RadioButton MdButton;
        private System.Windows.Forms.RadioButton BazookaButton;
        private System.Windows.Forms.Panel cpuUnits;
        private System.Windows.Forms.RadioButton cpuSoldierButton;
        private System.Windows.Forms.RadioButton cpuSniperButton;
        private System.Windows.Forms.RadioButton cpuAntiTankButton;
        private System.Windows.Forms.RadioButton cpuHvyButton;
        private System.Windows.Forms.RadioButton cpuLtButton;
        private System.Windows.Forms.RadioButton cpuMdButton;
        private System.Windows.Forms.RadioButton cpuBazookaButton;
        private System.Windows.Forms.Timer choiceFlicker;
    }
}
