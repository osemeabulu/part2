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
    public partial class helpWindowBase : Form
    {
        public helpWindowBase()
        {
            InitializeComponent();

            closeButton.Click += new EventHandler(closeClicked);
        }

        private void closeClicked(Object sender, EventArgs e)
        {
            this.Hide();
        }

        protected void formClosing()
        {
        }

        protected void hideOnClosing(Object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            ((Form)sender).Hide();
        }
    }
}
