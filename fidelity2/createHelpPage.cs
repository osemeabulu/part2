using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fidelity2
{
    public partial class createHelpPage : fidelity2.helpWindowBase
    {
        helpMain helpWindow;
        findHelpPage findWindow;
        navHelpPage navWindow;

        public createHelpPage(helpMain helpWindow,
            findHelpPage findWindow, navHelpPage navWindow)
        {
            this.helpWindow = helpWindow;
            this.findWindow = findWindow;
            this.navWindow = navWindow;

            InitializeComponent();

            initLinking();
        }

        public void initLinking()
        {
            link1.Click += new EventHandler(toFind);
            link2.Click += new EventHandler(toNav);
            link4.Click += new EventHandler(toHome);
        }

        private void toHome(Object sender, EventArgs e)
        {
            this.Hide();
            helpWindow.Show();
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

        public void updateNav(navHelpPage navWindow)
        {
            this.navWindow = navWindow;
        }

        public void updateFind(findHelpPage findWindow)
        {
            this.findWindow = findWindow;
        }
    }
}
