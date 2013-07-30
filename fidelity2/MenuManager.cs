using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//for any type of collection
using System.Drawing;//for any type of color info

/*sets and manages what happens to each menuStrip item*/

namespace fidelity2
{
    class MenuManager
    {
        Form current;

        public MenuManager(Form sent)
        {
            current = sent;
        }

        public void init(MenuStrip objectSent)
        {
            //top menu line color
            objectSent.BackColor = Color.DarkSlateGray;

            //(for each loop works the same as how it looks to work)
            // iterate through each horizontal item (only one in this case: Menu)
            foreach (ToolStripMenuItem menuItem in objectSent.Items)
            {
                //iterate through the horizontal items verticle lists
                foreach (ToolStripItem item in menuItem.DropDownItems)
                {
                    //define what quit does
                    if (item.Text.Equals("Quit"))
                    {
                        //MessageBox.Show("found " + item.Text);
                        initQuit(item);
                    }

                    //MessageBox.Show("here " + item.Text);

                    //must add more parts later
                }
            }
        }

        public void initQuit(ToolStripItem itemSent)
        {
            //event is added here
            itemSent.Click += new EventHandler(quitToolStripMenuItem_Click);
        }

        public void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current.Dispose();
        }
    }
}
