using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;//need for oval shapes management

namespace fidelity2
{
    public partial class mainWindow
    {
        //
        // Class Contains Elements common to all tabs and elements to
        // manipulate the tabs.
        //

        //general tab vars
        private RadioButton buttonLastClicked = new RadioButton();
        private infoItem dataPoint = new infoItem(-1);//used to store data that is being sent to a tab window or sent from a tab window

        public void initTabs()
        {
            /* PURPOSE:
             * Set all tab variables that change with a
             * users actions to their default values
             * */

            //cycle through all tabs modifying each in the same way
            for (int count = 0; count < windowControls.TabCount; count++)
            {
                //all blue gradient background for now
                ((TabPage)windowControls.GetControl(count)).BackgroundImage = Image.FromFile(path + "\\images\\background.bmp");
            }

            //set the title of the first tab
            titleText.Text = "Home";

            initEvents();

            //make all buttons except home invisible
            searchCreateLabel.Visible = false;
            searchCreatePButton.Visible = false;
            refineLabel.Visible = false;
            refinePageButton.Visible = false;
            movieInfoLabel.Visible = false;
            infoPageButton.Visible = false;

            //make back and forwards semi circles invisible
            forwardButton.Visible = false;
            backButton.Visible = false;

            //make all star button unchecked
            star1.AutoCheck = false;
            star2.AutoCheck = false;
            star3.AutoCheck = false;
            star4.AutoCheck = false;
            star5.AutoCheck = false;
            star6.AutoCheck = false;
            star7.AutoCheck = false;
            star8.AutoCheck = false;
            star9.AutoCheck = false;
            star10.AutoCheck = false;

            sStar1.AutoCheck = false;
            sStar2.AutoCheck = false;
            sStar3.AutoCheck = false;
            sStar4.AutoCheck = false;
            sStar5.AutoCheck = false;
            sStar6.AutoCheck = false;
            sStar7.AutoCheck = false;
            sStar8.AutoCheck = false;
            sStar9.AutoCheck = false;
            sStar10.AutoCheck = false;

            cStar1.AutoCheck = false;
            cStar2.AutoCheck = false;
            cStar3.AutoCheck = false;
            cStar4.AutoCheck = false;
            cStar5.AutoCheck = false;
            cStar6.AutoCheck = false;
            cStar7.AutoCheck = false;
            cStar8.AutoCheck = false;
            cStar9.AutoCheck = false;
            cStar10.AutoCheck = false;
        }

        public void initEvents()
        {
            /* PURPOSE:
             * Initializes all events fpr all relevant tab components
             * */

            //common to all tabs
            windowControls.Selected += new TabControlEventHandler(pageChanged);

            //for the search tab
            advancedBgTitle.Click += new EventHandler(advancedClicked);
            advancedSearchLabel.Click += new EventHandler(advancedClicked);

            titleEntered.Click += new EventHandler(titleClicked);
            directorEntered.Click += new EventHandler(directorClicked);
            actorsEntered.Click += new EventHandler(actorsClicked);
            genresEntered.Click += new EventHandler(genresClicked);
            yearEntered.Click += new EventHandler(yearClicked);
            starsSearch.Click += new EventHandler(starsSearchClicked);
            otherRatingText.Click += new EventHandler(otherRatingClicked);
            otherRadioButton.Click += new EventHandler(otherRatingClicked);

            //for infoTab (all of these must be mouseclick not just click)
            stars.MouseClick += new MouseEventHandler(starsClicked);
            starsSearch.MouseClick += new MouseEventHandler(starsClicked);
            starsCreate.MouseClick += new MouseEventHandler(starsClicked);
        }

        /*-- Events and event helpers --*/

        public void pageChanged(Object sender, TabControlEventArgs e)
        {
            /* PURPOSE:
             * Defines what objects that are not in a specific tab do, when
             * a tab is changed. Also updates any info from a previous tab
             * into the current tab if needed.
             * */

            titleText.Text = windowControls.SelectedTab.Text;

            /*set all button colors to wheat */
            setColor(homePageButton, homeLabel, Color.Wheat);
            setColor(searchCreatePButton, searchCreateLabel, Color.Wheat);
            setColor(refinePageButton, refineLabel, Color.Wheat);
            setColor(infoPageButton, movieInfoLabel, Color.Wheat);

            dataManager.resetGraphSize();

            //set all genre buttons in refine to their regular colors
            resetGenreButtons();

            //reset all fields in search
            advancedOpen(false);

            //Now see what each tab does
            if (windowControls.SelectedTab.Name.Equals(homeWindow.Name))
            {
                /* wide view circles */

                //set all button colors that are not home to wheat and home button to limeGreen
                setColor(homePageButton, homeLabel, Color.LimeGreen);

                /* Back/forward half circles */

                backButton.Visible = false;//no page above the home page ever
                //if there is any circle ahead of home display it (in this case only search and create)
                if (wideCirclesVisible.Contains(searchWindow.Name) == true || wideCirclesVisible.Contains(createWindow.Name) == true)
                {
                    forwardButton.Visible = true;
                }
                else
                {
                    forwardButton.Visible = false;
                }
            }
            else if (windowControls.SelectedTab.Name.Equals(createWindow.Name))
            {
                /* wide view circles */

                //if search was open must close other windows wideview circles
                if (searchCreateLabel.Text.Equals("Search"))
                {
                    refineLabel.Visible = false;
                    refinePageButton.Visible = false;
                    movieInfoLabel.Visible = false;
                    infoPageButton.Visible = false;

                    //erase both back button records
                    wideCirclesVisible.Remove(refineWindow.Name);
                    wideCirclesVisible.Remove(movieInfoWindow.Name);
                }
                else
                {
                    wideCirclesVisible.Remove(refineWindow.Name);
                    wideCirclesVisible.Remove(movieInfoWindow.Name);
                }

                //create and search use the same circle so the label name must be changed each time
                searchCreateLabel.Text = "Create";
                setColor(searchCreatePButton, searchCreateLabel, Color.LimeGreen);

                searchCreatePButton.Visible = true;
                searchCreateLabel.Visible = true;

                /* Back/forward half circles */
                updateBackForward(windowControls.SelectedTab);
            }
            else if (windowControls.SelectedTab.Name.Equals(searchWindow.Name))
            {
                /* wide view circles */

                //create and search use the same circle so the label name must be changed each time
                searchCreateLabel.Text = "Search";
                setColor(searchCreatePButton, searchCreateLabel, Color.LimeGreen);

                searchCreatePButton.Visible = true;
                searchCreateLabel.Visible = true;

                 /* Back/forward half circles */
                updateBackForward(windowControls.SelectedTab);
            }
            else if (windowControls.SelectedTab.Name.Equals(refineWindow.Name))
            {
                /* wide view circles */

                setColor(refinePageButton, refineLabel, Color.LimeGreen);

                refinePageButton.Visible = true;
                refineLabel.Visible = true;

                /* Back/forward half circles */
                updateBackForward(windowControls.SelectedTab);

                //update the current search bar to reflect the previous one
                searchByTypeR.SelectedIndex = searchByTypeS.SelectedIndex;
                searchTextR.Text = searchTextS.Text;

                //reinialize the genre button color manager array
                dataManager.resetGenresClicked();
            }
            else if (windowControls.SelectedTab.Name.Equals(movieInfoWindow.Name))
            {
                /* wide view circles */

                setColor(infoPageButton, movieInfoLabel, Color.LimeGreen);

                infoPageButton.Visible = true;
                movieInfoLabel.Visible = true;

                /* Back/forward half circles */
                updateBackForward(windowControls.SelectedTab);

                /* load all the data into all the textboxes */

                if (dataPoint.Certification != null && dataPoint.Certification.Equals("Approved"))
                {
                    dataPoint.Certification = "A";
                }

                infoTitleText.Text = dataPoint.Title;
                infoRating.Text = dataPoint.Certification;
                infoDirectorText.Text = dataPoint.Director;
                infoActorText.Text = dataPoint.getActors();
                infoGenreText.Text = dataPoint.getGenres();
                infoYearText.Text = dataPoint.Year;
                infoLengthText.Text = dataPoint.Length;
                infoPlotText.Text = dataPoint.Plot;

                //set the rating
                buttonFromRating(Int32.Parse(dataPoint.Rating));
            }
        }

        private void updateBackForward(TabPage currTab)
        {
            /* PURPOSE: 
             * Updates back and forward half circles for current screen. Does this by
             * deciding which circle should be displayed when.
             * */

            //Add the current tab to the list of visible if it is not selected
            if (wideCirclesVisible.Contains(currTab.Name) == false)
            {
                wideCirclesVisible.Add(currTab.Name);
            }

            if (backButton.Visible == false)
            {
                backButton.Visible = true;
            }

            //see if there is more pages than this current index (basically the definition of the forward button)
            if (!currTab.Name.Equals(movieInfoWindow.Name) && !currTab.Name.Equals(createWindow.Name) &&
                wideCirclesVisible.IndexOf(currTab.Name) + 1 < wideCirclesVisible.Count &&
                wideCirclesVisible.Contains(wideCirclesVisible[wideCirclesVisible.IndexOf(currTab.Name) + 1]))
            {
                forwardButton.Visible = true;
            }
            else
            {
                forwardButton.Visible = false;
            }

        }

        private void resetGenreButtons()
        {
            dramaButton.BackColor = Color.DarkOrange;
            mysteryButton.BackColor = Color.DarkOrange;
            comedyButton.BackColor = Color.DarkOrange;
            horrorButton.BackColor = Color.DarkOrange;
            sciFiButton.BackColor = Color.DarkOrange;
            actionButton.BackColor = Color.DarkOrange;
            musicButton.BackColor = Color.DarkOrange;
        }

        public void starsClicked(Object sender, MouseEventArgs e)
        {
            /* PURPOSE:
             * Set all stars above the checked star to non-checked, this
             * handles every type of star bar.
             * */

            if (((Panel)sender).GetChildAtPoint(e.Location) != null)//they missed the click
            {
                if ((Panel)sender == stars)
                {
                    changeRadioButtonsI((RadioButton)((Panel)sender).GetChildAtPoint(e.Location));
                }
                else if ((Panel)sender == starsSearch)
                {
                    changeRadioButtonsS((RadioButton)((Panel)sender).GetChildAtPoint(e.Location));
                }
                else
                {
                    changeRadioButtonsC((RadioButton)((Panel)sender).GetChildAtPoint(e.Location));
                }
            }   
        }

        /*-- Getters and Setters --*/

        private void setColor(OvalShape setting, Label settingL, Color color)
        {
            setting.BackColor = color;
            settingL.BackColor = color;
        }

        public void setDataPoint(infoItem dataPoint)
        {
            this.dataPoint = dataPoint;
        }

        public infoItem getInfoItem()
        {
            /* PURPOSE:
             * Gets data from the infoItem and sends back.
             */

            return dataPoint;
        }
    }
}
