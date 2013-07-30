using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.PowerPacks;//need for oval shapes management
using System.Xml;

namespace fidelity2
{
    public partial class mainWindow : FormOutline
    {
        //
        // Class defines all elements essential to making
        // the windows transitions and manipulating the
        // windows.
        //

        protected String path = Application.StartupPath;

        protected DataManager dataManager;

        private helpMain help;

        private xmlReader xmlReader;
        private XmlDocument moviesPage;//now easy to modify if there is changes
        private xmlData dataList;

        //global defining variables
        protected const int wideViewCircles = 4;
        private String xmlLocation;

        //a bunch of global modifying top values
        protected List<String> wideCirclesVisible;

        public mainWindow()
        {
            InitializeComponent();

            dataManager = new DataManager(this);

            initAll();
        }

        public void initAll()
        {
            //can't have this continually getting bigger
            dataManager.resetControls();

            help = new helpMain();

            xmlLocation = path + "\\resources\\movies.xml";

            //need this for panel background image consistency
            this.BackgroundImage = Image.FromFile(path + "\\images\\background.bmp");
            wideCirclesVisible = new List<String>();
            wideCirclesVisible.Add(homeWindow.Name);//home is always visible

            //Application always starts at the home page
            windowControls.SelectedTab = homeWindow;

            //no point to manage this it always stays the same
            initMenu();

            initButtons();

            initLabels();

            //don't really need a seperate manager for just 1 item
            searchByTypeS.SelectedIndex = 1;
            searchByTypeR.SelectedIndex = 1;

            //add the events to all the controls
            dataManager.addEvents();

            initXML();

            initGraph();

            initTrackBars();

            initTabs();

            //key handlers, window closing etc.
            initFormEvents();
        }

        /*-- Menu Events --*/

        private void initMenu()
        {
            quitToolStripMenuItem.Click +=new EventHandler(quitClicked);
            helpToolStripMenuItem.Click += new EventHandler(helpClicked);
            resetToolStripMenuItem.Click += new EventHandler(resetClicked);
        }

        private void helpClicked(Object sender, EventArgs e)
        {
            help.Show();
        }

        private void quitClicked(Object sender, EventArgs e)
        {
            appClose();
        }

        private void resetClicked(Object sender, EventArgs e)
        {
            //also XML file now needs to be reread
            xmlReader.saveFile();

            help.Hide();

            help = new helpMain();

            //need this for panel background image consistency
            this.BackgroundImage = Image.FromFile(path + "\\images\\background.bmp");
            wideCirclesVisible = new List<String>();
            wideCirclesVisible.Add(homeWindow.Name);//home is always visible

            //set to the home window
            windowControls.SelectTab(homeWindow);
            searchByTypeS.SelectedIndex = 1;
            searchByTypeR.SelectedIndex = 1;

            //set the wide view to only display home
            setColor(homePageButton, homeLabel, Color.LimeGreen);
            setColor(searchCreatePButton, searchCreateLabel, Color.Wheat);
            setColor(refinePageButton, refineLabel, Color.Wheat);
            setColor(infoPageButton, movieInfoLabel, Color.Wheat);

            searchCreatePButton.Visible = false;
            searchCreateLabel.Visible = false;
            refineLabel.Visible = false;
            refinePageButton.Visible = false;
            movieInfoLabel.Visible = false;
            infoPageButton.Visible = false;
        }

        /*--- Work on the buttons ---*/

        private void initButtons()
        {
            /* Home buttons */
            dataManager.addControl(createInnerC);
            dataManager.addControl(searchInnerC);

            /* Create buttons */
            dataManager.addControl(cancelButtonInnerC);
            dataManager.addControl(saveButtonInnerC);

            /* Search buttons */
            dataManager.addControl(searchButtonInner1);
            dataManager.addControl(searchButtonInner2);
            dataManager.addControl(cancelButtonInnerS);

            /* Refine buttons */
            dataManager.addControl(dramaButton);
            dataManager.addControl(comedyButton);
            dataManager.addControl(horrorButton);
            dataManager.addControl(sciFiButton);
            dataManager.addControl(mysteryButton);
            dataManager.addControl(musicButton);
            dataManager.addControl(actionButton);
            dataManager.addControl(searchButtonInnerR);

            /* Info buttons */
            dataManager.addControl(saveButtonI);
            dataManager.addControl(deleteButtonI);
            dataManager.addControl(cancelInnerButtonI);

            /* Forward and back half circles */
            dataManager.addControl(forwardButton);
            dataManager.addControl(backButton);

            /* Wide View Buttons */
            dataManager.addControl(homePageButton);
            dataManager.addControl(searchCreatePButton);
            dataManager.addControl(refinePageButton);
            dataManager.addControl(infoPageButton);
        }

        private void initLabels()
        {
            /* Home labels */
            dataManager.addControl(createText);
            dataManager.addControl(searchText);

            /* Create labels */
            dataManager.addControl(cancelLabel);
            dataManager.addControl(saveLabel);

            /* Search labels */
            dataManager.addControl(searchLabelS1);
            dataManager.addControl(searchLabelS2);
            dataManager.addControl(cancelLabelS);

            /* info buttons */
            dataManager.addControl(savelabelI);
            dataManager.addControl(deleteLabelI);
            dataManager.addControl(searchLabelR);
            dataManager.addControl(cancelLabelI);

            /* Wide view labels */
            dataManager.addControl(homeLabel);
            dataManager.addControl(searchCreateLabel);
            dataManager.addControl(refineLabel);
            dataManager.addControl(movieInfoLabel);
        }

        private void initXML()
        {
            /* PURPOSE:
             * Creates an object to store XML and objects that revolve around
             * storing the XML. Then loads the XML data into the xml storage
             * object, at the specified location.
             * */

            dataList = new xmlData();
            moviesPage = new XmlDocument();
            xmlReader = new xmlReader(dataList, moviesPage);

            //This is so the movie num text can be easily
            dataManager.getGraph().addmovieNum(movieNum);

            xmlReader.loadXml(xmlLocation);
        }

        private void initGraph()
        {
            dataManager.addControl(refineGraph);

            //load the events (like mouse over)
            dataManager.getGraph().addEvents();
        }

        private void initTrackBars()
        {
            //all in the refine tab (they are for the graph)
            dataManager.addControl(yearsBarMin);
            dataManager.addControl(yearsBarMax);
            dataManager.addControl(starsBar);
        }

        public ToolTip getToolTip()
        {
            return toolTip1;
        }

        /*-- Events --*/

        public void initFormEvents()
        {
            this.FormClosing += new FormClosingEventHandler(appClosing);
            endTimer.Tick += new EventHandler(closeForm);

        }

        public void appClosing(Object sender,FormClosingEventArgs e)
        {
            /*PURPOSE:
             * Cancels the form closing and sends ending messages.
             * */

            e.Cancel = true;

            appClose();
        }

        //just makes the above method more accessable to multiple methods
        public void appClose()
        {
            /*PURPOSE:
             * Covers the screen with a ending message panel that has as it's
             * background the ending message. Starts a timer to give form closing
             * a slight delay. This garrantees the image is drawn first.
             * */

            endingPanel.UseWaitCursor = true;

            //cover the screen with the panel
            endingPanel.BringToFront();
            endingPanel.Visible = true;
            endingPanel.Size = this.Size;

            //give the panel a message (must be in the form of an image, text labels don't load here)
            endingPanel.BackgroundImage = Image.FromFile(path + "\\images\\endImage.bmp");

            endTimer.Enabled = true;
        }

        public void closeForm(Object sender, EventArgs e)
        {
            /*PURPOSE
             * Saves the XML file, stops the timer, and
             * closing the application securely.
             * */

            xmlReader.saveFile();

            endTimer.Enabled = false;

            this.Dispose();
        }

        /*-- essential getters and setters --*/

        public TabControl getWindowControls()
        {
            return windowControls;
        }

        public Chart getGraph()
        {
            return refineGraph;
        }

        public xmlData getXML()
        {
            return dataList;
        }

        public Size getScreenSize()
        {
            return this.Size;
        }
    }
}
