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
    public partial class startupForm : Form
    {
        public startupForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            titleScreen mm = new titleScreen();

            // set the menu to display centre screen based on screen size defaults
            mm.Size = new Size(screenControl.controlWidth, screenControl.controlHeight);
            mm.Location = screenControl.startCentre;

            // add main menu screen to form
            this.Controls.Add(mm);
        }

        private void startupForm_Resize(object sender, EventArgs e)
        {

        }
    }
}
