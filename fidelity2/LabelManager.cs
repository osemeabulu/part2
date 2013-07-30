using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//for any type of collection
using Microsoft.VisualBasic.PowerPacks;//need for oval shapes

namespace fidelity2
{
    class LabelManager
    {
         //
         // Manages lists of regular and custom labels
         //

        mainWindow mainWindow;

        //list of buttons to manage
        private List<Label> labelList;
        private Label CSLabel;

        //what the buttons can affect

        TabControl windowControls;

        public LabelManager(TabControl windowControls, mainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            labelList = new List<Label>();

            this.windowControls = windowControls;
        }

        public void add(Label adding)
        {
            labelList.Add(adding);
        }

        public void addEvents()
        {
            /* PURPOSE:
             * Cycle through the list of lables and add appropriate events 
             */

            foreach (Label label in labelList)
            {
                /* Home Labels */
                if (label.Name.Equals("createText"))
                {
                    label.Click += new EventHandler(createClicked);
                }
                else if (label.Name.Equals("searchText"))
                {
                    label.Click += new EventHandler(searchClicked);
                }
                /* Create Labels */
                else if (label.Name.Equals("cancelLabel"))
                {
                    label.Click += new EventHandler(homePageClicked);//might as well just do this
                }
                else if (label.Name.Equals("saveLabel"))
                {
                    label.Click += new EventHandler(saveClicked);//might as well just do this
                }
                /* Search Labels */
                else if (label.Name.Equals("searchLabelS1"))
                {
                    label.Click += new EventHandler(mainWindow.nowSearchingS);
                }
                else if (label.Name.Equals("searchLabelS2"))
                {
                    label.Click += new EventHandler(mainWindow.nowSearchingS);
                }
                else if (label.Name.Equals("cancelLabelS"))
                {
                    label.Click += new EventHandler(homePageClicked);//might as well just do this
                }
                /* info Labels */
                else if (label.Name.Equals("savelabelI"))
                {
                    label.Click += new EventHandler(changeClicked);//might as well just do this
                }
                else if (label.Name.Equals("deleteLabelI"))
                {
                    label.Click += new EventHandler(deleteClicked);//might as well just do this
                }
                else if (label.Name.Equals("searchLabelR"))
                {
                    label.Click += new EventHandler(mainWindow.nowSearchingR);
                }
                else if (label.Name.Equals("cancelLabelI"))
                {
                    label.Click += new EventHandler(refinePageClicked);
                }
                /* Now for the wide view */
                else if (label.Name.Equals("homeLabel"))
                {
                    label.Click += new EventHandler(homePageClicked);
                }
                else if (label.Name.Equals("searchCreateLabel"))
                {
                    CSLabel = label;
                    label.Click += new EventHandler(createSearchPClicked);
                }
                else if (label.Name.Equals("refineLabel"))
                {
                    label.Click += new EventHandler(refinePageClicked);
                }
                else if (label.Name.Equals("movieInfoLabel"))
                {
                    label.Click += new EventHandler(infoPageClicked);
                }
            }
        }

        /*--- Events ---*/

        public void createClicked(Object sender, EventArgs e)
        {
            //goes to the create page
            windowControls.SelectTab("createWindow");
        }

        public void searchClicked(Object sender, EventArgs e)
        {
            //goes to the search page
            windowControls.SelectTab("searchWindow");
        }

        /* For the wide view */
        private void homePageClicked(Object sender, EventArgs e)
        {
            //goes to the home page if not currently here
            if (windowControls.SelectedTab.Name != "homeWindow")
            {
                windowControls.SelectTab("homeWindow");
            }
        }

        private void createSearchPClicked(Object sender, EventArgs e)
        {
            //sees if in the search or the create page
            if (CSLabel.Text.Equals("Create"))
            {
                //goes to the create page if not currently here
                if (windowControls.SelectedTab.Name != "createWindow")
                {
                    windowControls.SelectTab("createWindow");
                }
            }
            else
            {
                //goes to the search page if not currently here
                if (windowControls.SelectedTab.Name != "searchWindow")
                {
                    windowControls.SelectTab("searchWindow");
                }
            }
        }

        private void refinePageClicked(Object sender, EventArgs e)
        {
            //goes to the refine page if not currently here
            if (windowControls.SelectedTab.Name != "refineWindow")
            {
                windowControls.SelectTab("refineWindow");
            }
        }

        private void infoPageClicked(Object sender, EventArgs e)
        {
            //goes to the info page if not currently here
            if (windowControls.SelectedTab.Name != "movieInfoWindow")
            {
                windowControls.SelectTab("movieInfoWindow");
            }
        }

        private void changeClicked(Object sender, EventArgs e)
        {
            /* PURPOSE:
             * deals with change (saved now) being clicked.
             */

            mainWindow.changedClicked();
        }

        private void deleteClicked(Object sender, EventArgs e)
        {
            mainWindow.deleteClicked();
        }

        private void saveClicked(Object sender, EventArgs e)
        {
            mainWindow.savedClicked();
        }

    }
}

