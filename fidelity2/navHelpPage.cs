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
    public partial class navHelpPage : fidelity2.helpWindowBase
    {
       helpMain helpWindow;
       createHelpPage createWindow;
       findHelpPage findWindow;

        public navHelpPage(helpMain helpWindow,
            createHelpPage createWindow, findHelpPage findWindow)
        {
            this.helpWindow = helpWindow;
            this.createWindow = createWindow;
            this.findWindow = findWindow;

            InitializeComponent();

            initLinking();

            //update previously made windows with this windows data
            createWindow.updateNav(this);
            findWindow.updateNav(this);
        }

        public void initLinking()
        {
            link1.Click += new EventHandler(toCreate);
            link2.Click += new EventHandler(toFind);
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

        private void toFind(Object sender, EventArgs e)
        {
            this.Hide();
            findWindow.Show();
        }
    }
}
