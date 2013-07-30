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
    public partial class findHelpPage : fidelity2.helpWindowBase
    {
       helpMain helpWindow;
       createHelpPage createWindow;
       navHelpPage navWindow;

        public findHelpPage(helpMain helpWindow,
            createHelpPage createWindow, navHelpPage navWindow)
        {
            this.helpWindow = helpWindow;
            this.createWindow = createWindow;
            this.navWindow = navWindow;

            InitializeComponent();

            initLinking();

            //update previously made windows with this windows data
            createWindow.updateFind(this);
        }

        public void initLinking()
        {
            link1.Click += new EventHandler(toCreate);
            link2.Click += new EventHandler(toNav);
            link4.Click += new EventHandler(toHome);
        }

        private void toHome(Object sender, EventArgs e)
        {
            this.Hide();
            helpWindow.Show();
        }

        private void toCreate(Object sender, EventArgs e)
        {
            this.Hide();
            createWindow.Show();
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

        public void updateCreate(createHelpPage createWindow)
        {
            this.createWindow = createWindow;
        }
    }
}
