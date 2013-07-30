using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fidelity2
{
    public partial class helpMain : fidelity2.helpWindowBase
    {
        createHelpPage createWindow;
        findHelpPage findWindow;
        navHelpPage navWindow;

        public helpMain()
        {
            InitializeComponent();

            createWindow = new createHelpPage(this, findWindow, navWindow);
            findWindow = new findHelpPage(this, createWindow, navWindow);
            navWindow = new navHelpPage(this, createWindow, findWindow);

            formClosing();

            initLinking();
        }

        protected void formClosing()
        {
            this.FormClosing += new FormClosingEventHandler(hideOnClosing);
        }

        public void initLinking()
        {
            link1.Click += new EventHandler(toCreate);
            link2.Click += new EventHandler(toFind);
            link4.Click += new EventHandler(toNav);
        }

        private void toFind(Object sender, EventArgs e)
        {
            this.Hide();
            findWindow.Show();
        }

        private void toNav(Object sender, EventArgs e)
        {
            this.Hide();
            navWindow.Show();
        }

        private void toCreate(Object sender, EventArgs e)
        {
            this.Hide();
            createWindow.Show();
        }
    }
}
