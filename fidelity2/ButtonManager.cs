using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//for any type of collection
using Microsoft.VisualBasic.PowerPacks;//need for oval shapes

namespace fidelity2
{
    class ButtonManager
    {
        //
        // Manages lists of regular and custom buttons
        //

        mainWindow mainWindow;

        //list of buttons to manage
        private List<Button> buttonList;

        //list of custom (circular) buttons to manage
        private List<OvalShape> buttonListC;

        //what the buttons can affect

        TabControl windowControls;
        Label CSLabel;

        public ButtonManager(TabControl windowControls, mainWindow mainWindow)
        {
            buttonList = new List<Button>();
            buttonListC = new List<OvalShape>();
            this.mainWindow = mainWindow;

            this.windowControls = windowControls;
        }

        public void setCS(Label label)
        {
            CSLabel = label;
        }

        public void add(Button adding)
        {
            buttonList.Add(adding);
        }

        public void add(OvalShape adding)
        {
            buttonListC.Add(adding);
        }

        public void addEvents()
        {
            /*PURPOSE:
             * Cycle through the list of button adding appropriate events
             * */

            foreach (OvalShape button in buttonListC)
            {
                /* Home buttons */
                if (button.Name.Equals("createInnerC"))
                {
                    button.Click += new EventHandler(createClicked);
                }
                else if (button.Name.Equals("searchInnerC"))
                {
                    button.Click += new EventHandler(searchClicked);
                }
                /* Create buttons */
                else if (button.Name.Equals("cancelButtonInnerC"))
                {
                    button.Click += new EventHandler(homePageClicked);//might as well just use this
                }
                else if (button.Name.Equals("saveButtonInnerC"))
                {
                    button.Click += new EventHandler(saveClicked);//might as well just use this
                }
                /* Search buttons */
                else if (button.Name.Equals("searchButtonInner1"))
                {
                    button.Click += new EventHandler(mainWindow.nowSearchingS);
                }
                else if (button.Name.Equals("searchButtonInner2"))
                {
                    button.Click += new EventHandler(mainWindow.nowSearchingS);
                }
                else if (button.Name.Equals("cancelButtonInnerS"))
                {
                    button.Click += new EventHandler(homePageClicked);//might as well just use this
                }
                /* refine buttons */
                else if (button.Name.Equals("searchButtonInnerR"))
                {
                    button.Click += new EventHandler(mainWindow.nowSearchingR);
                }
                else if (button.Name.Equals("refinePageButton"))
                {
                    button.Click += new EventHandler(refinePageClicked);
                }
                /* info buttons */
                else if (button.Name.Equals("saveButtonI"))
                {
                    button.Click += new EventHandler(changeClicked);//might as well just do this
                }
                else if (button.Name.Equals("deleteButtonI"))
                {
                    button.Click += new EventHandler(deleteClicked);//might as well just do this
                }
                else if (button.Name.Equals("cancelInnerButtonI"))
                {
                    button.Click += new EventHandler(refinePageClicked);
                }
                /* Now for the wide view */
                else if (button.Name.Equals("homePageButton"))
                {
                    button.Click += new EventHandler(homePageClicked);
                }
                else if (button.Name.Equals("searchCreatePButton"))
                {
                    button.Click += new EventHandler(createSearchPClicked);
                }
                else if (button.Name.Equals("refinePageButton"))
                {
                    button.Click += new EventHandler(refinePageClicked);
                }
                else if (button.Name.Equals("infoPageButton"))
                {
                    button.Click += new EventHandler(infoPageClicked);
                }
                /*Forward and back buttons*/
                else if (button.Name.Equals("forwardButton"))
                {
                    button.Click += new EventHandler(forwardClicked);
                }
                else if (button.Name.Equals("backButton"))
                {
                    button.Click += new EventHandler(backClicked);
                }
            }
        }

        /*--- Events ---*/

        /* Home events */
        private void createClicked(Object sender, EventArgs e)
        {
            //goes to the create page
            windowControls.SelectTab("createWindow");
        }

        private void searchClicked(Object sender, EventArgs e)
        {
            //goes to the search page
            windowControls.SelectTab("searchWindow");
        }
        /* Create Events */

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

        /* For the forward and back buttons */

        private void forwardClicked(Object sender, EventArgs e)
        {
            //Should be no errors by the internal logic earlier
            if (windowControls.SelectedTab.Name != "homeWindow" || CSLabel.Text.Equals("Create"))
            {
                windowControls.SelectTab(windowControls.SelectedIndex + 1);
            }
            else if(windowControls.SelectedTab.Name == "homeWindow" && CSLabel.Text.Equals("Search"))
            {
                windowControls.SelectTab(windowControls.SelectedIndex + 2);
            }
        }

        private void backClicked(Object sender, EventArgs e)
        {
            //Should be no errors by the internal logic earlier
            if (windowControls.SelectedTab.Name != "searchWindow")
            {
                windowControls.SelectTab(windowControls.SelectedIndex - 1);
            }
            else
            {
                windowControls.SelectTab(windowControls.SelectedIndex - 2);
            }
        }

        private void changeClicked(Object sender, EventArgs e)
        {
            /* first gets the  necessary lines into a infoItem then
             * sets the mainWindows info line to be this. Then sets
             * dataList to have the new value*/

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
