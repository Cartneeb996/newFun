namespace newFun
{
    partial class titleScreen
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
            this.tutorialButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.gameTitleLabel = new System.Windows.Forms.Label();
            this.rightSideTank = new System.Windows.Forms.PictureBox();
            this.leftSideTank = new System.Windows.Forms.PictureBox();
            this.expertButton = new System.Windows.Forms.Button();
            this.normalButton = new System.Windows.Forms.Button();
            this.easyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rightSideTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSideTank)).BeginInit();
            this.SuspendLayout();
            // 
            // tutorialButton
            // 
            this.tutorialButton.BackColor = System.Drawing.Color.Red;
            this.tutorialButton.FlatAppearance.BorderSize = 0;
            this.tutorialButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.tutorialButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tutorialButton.Location = new System.Drawing.Point(399, 233);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(202, 56);
            this.tutorialButton.TabIndex = 10;
            this.tutorialButton.Text = "Tutorial";
            this.tutorialButton.UseVisualStyleBackColor = false;
            this.tutorialButton.Click += new System.EventHandler(this.tutorialButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Red;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(399, 167);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(202, 56);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // gameTitleLabel
            // 
            this.gameTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameTitleLabel.Font = new System.Drawing.Font("Courier New", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitleLabel.Location = new System.Drawing.Point(40, 65);
            this.gameTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.gameTitleLabel.Name = "gameTitleLabel";
            this.gameTitleLabel.Size = new System.Drawing.Size(889, 99);
            this.gameTitleLabel.TabIndex = 8;
            this.gameTitleLabel.Text = "Commander Wars";
            this.gameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightSideTank
            // 
            this.rightSideTank.BackColor = System.Drawing.Color.Transparent;
            this.rightSideTank.BackgroundImage = global::newFun.Properties.Resources.HvyReversedIcon;
            this.rightSideTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightSideTank.Location = new System.Drawing.Point(752, 167);
            this.rightSideTank.Name = "rightSideTank";
            this.rightSideTank.Size = new System.Drawing.Size(177, 122);
            this.rightSideTank.TabIndex = 7;
            this.rightSideTank.TabStop = false;
            // 
            // leftSideTank
            // 
            this.leftSideTank.BackColor = System.Drawing.Color.Transparent;
            this.leftSideTank.BackgroundImage = global::newFun.Properties.Resources.HvyIcon;
            this.leftSideTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftSideTank.Location = new System.Drawing.Point(79, 167);
            this.leftSideTank.Name = "leftSideTank";
            this.leftSideTank.Size = new System.Drawing.Size(177, 122);
            this.leftSideTank.TabIndex = 6;
            this.leftSideTank.TabStop = false;
            // 
            // expertButton
            // 
            this.expertButton.BackColor = System.Drawing.Color.Red;
            this.expertButton.FlatAppearance.BorderSize = 0;
            this.expertButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.expertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.expertButton.Location = new System.Drawing.Point(399, 65);
            this.expertButton.Name = "expertButton";
            this.expertButton.Size = new System.Drawing.Size(202, 56);
            this.expertButton.TabIndex = 11;
            this.expertButton.Text = "Expert";
            this.expertButton.UseVisualStyleBackColor = false;
            this.expertButton.Visible = false;
            this.expertButton.Click += new System.EventHandler(this.expertButton_Click);
            // 
            // normalButton
            // 
            this.normalButton.BackColor = System.Drawing.Color.Red;
            this.normalButton.FlatAppearance.BorderSize = 0;
            this.normalButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.normalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalButton.Location = new System.Drawing.Point(399, 6);
            this.normalButton.Name = "normalButton";
            this.normalButton.Size = new System.Drawing.Size(202, 56);
            this.normalButton.TabIndex = 12;
            this.normalButton.Text = "Normal";
            this.normalButton.UseVisualStyleBackColor = false;
            this.normalButton.Visible = false;
            this.normalButton.Click += new System.EventHandler(this.normalButton_Click);
            // 
            // easyButton
            // 
            this.easyButton.BackColor = System.Drawing.Color.Red;
            this.easyButton.FlatAppearance.BorderSize = 0;
            this.easyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.easyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.easyButton.Location = new System.Drawing.Point(647, 19);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(202, 56);
            this.easyButton.TabIndex = 13;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = false;
            this.easyButton.Visible = false;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // titleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::newFun.Properties.Resources.Background_battle;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.normalButton);
            this.Controls.Add(this.expertButton);
            this.Controls.Add(this.tutorialButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameTitleLabel);
            this.Controls.Add(this.rightSideTank);
            this.Controls.Add(this.leftSideTank);
            this.Name = "titleScreen";
            this.Size = new System.Drawing.Size(968, 354);
            this.Resize += new System.EventHandler(this.titleScreen_Resize);
            variables.TMPlayer.MediaEnded += new System.EventHandler(this.TMPlayer_MediaEnded);
            ((System.ComponentModel.ISupportInitialize)(this.rightSideTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSideTank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tutorialButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label gameTitleLabel;
        private System.Windows.Forms.PictureBox rightSideTank;
        private System.Windows.Forms.PictureBox leftSideTank;
        private System.Windows.Forms.Button expertButton;
        private System.Windows.Forms.Button normalButton;
        private System.Windows.Forms.Button easyButton;
    }
}
