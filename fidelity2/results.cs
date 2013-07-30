using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fidelity2
{
    public partial class results : fidelity2.Form1
    {
        Form mainForm;

        public results(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void homeText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
