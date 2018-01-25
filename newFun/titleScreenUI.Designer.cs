namespace newFun
{
    partial class titleScreenUI
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
            this.rightSideTank = new System.Windows.Forms.PictureBox();
            this.leftSideTank = new System.Windows.Forms.PictureBox();
            this.gameTitleLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.tutorialButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rightSideTank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSideTank)).BeginInit();
            this.SuspendLayout();
            // 
            // rightSideTank
            // 
            this.rightSideTank.BackColor = System.Drawing.Color.Transparent;
            this.rightSideTank.BackgroundImage = global::newFun.Properties.Resources.HvyReversedIcon;
            this.rightSideTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightSideTank.Location = new System.Drawing.Point(712, 127);
            this.rightSideTank.Name = "rightSideTank";
            this.rightSideTank.Size = new System.Drawing.Size(177, 122);
            this.rightSideTank.TabIndex = 2;
            this.rightSideTank.TabStop = false;
            // 
            // leftSideTank
            // 
            this.leftSideTank.BackColor = System.Drawing.Color.Transparent;
            this.leftSideTank.BackgroundImage = global::newFun.Properties.Resources.HvyIcon;
            this.leftSideTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftSideTank.Location = new System.Drawing.Point(39, 127);
            this.leftSideTank.Name = "leftSideTank";
            this.leftSideTank.Size = new System.Drawing.Size(177, 122);
            this.leftSideTank.TabIndex = 0;
            this.leftSideTank.TabStop = false;
            // 
            // gameTitleLabel
            // 
            this.gameTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameTitleLabel.Font = new System.Drawing.Font("Courier New", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitleLabel.Location = new System.Drawing.Point(0, 25);
            this.gameTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.gameTitleLabel.Name = "gameTitleLabel";
            this.gameTitleLabel.Size = new System.Drawing.Size(889, 99);
            this.gameTitleLabel.TabIndex = 3;
            this.gameTitleLabel.Text = "Commander Wars";
            this.gameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Red;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Location = new System.Drawing.Point(359, 127);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(202, 56);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tutorialButton
            // 
            this.tutorialButton.BackColor = System.Drawing.Color.Red;
            this.tutorialButton.FlatAppearance.BorderSize = 0;
            this.tutorialButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.tutorialButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tutorialButton.Location = new System.Drawing.Point(359, 193);
            this.tutorialButton.Name = "tutorialButton";
            this.tutorialButton.Size = new System.Drawing.Size(202, 56);
            this.tutorialButton.TabIndex = 5;
            this.tutorialButton.Text = "Tutorial";
            this.tutorialButton.UseVisualStyleBackColor = false;
            this.tutorialButton.Click += new System.EventHandler(this.tutorialButton_Click);
            // 
            // titleScreenUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::newFun.Properties.Resources.Background_battle;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(919, 261);
            this.Controls.Add(this.tutorialButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.gameTitleLabel);
            this.Controls.Add(this.rightSideTank);
            this.Controls.Add(this.leftSideTank);
            this.Name = "titleScreenUI";
            this.Text = "Commander Wars";
            this.Resize += new System.EventHandler(this.Form2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.rightSideTank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSideTank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox leftSideTank;
        private System.Windows.Forms.PictureBox rightSideTank;
        private System.Windows.Forms.Label gameTitleLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button tutorialButton;
    }
}