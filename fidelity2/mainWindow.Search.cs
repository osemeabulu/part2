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
    public  partial class mainWindow
    {
        //
        // Stores all relevant objects and methods for the search window.
        //

        Boolean starsSClicked = false;
        Boolean advancedIsOpen = false;
        String standardDesc = "Description of how to enter information in a field will be here.";

        public void advancedOpen(Boolean open)
        {
            /*Purpose
             * Displays or hides the menu depending on whether
             * boolean sent in was true or false.
             * */

            advancedIsOpen = open;

            descriptionText.Text = standardDesc;

            //decide new rectangle height
            if (open == false)
            {
                buttonLastClicked = null;

                //stars cannot be clicked before now
                starsSClicked = false;

                //reset all fields
                titleEntered.Text = "";
                yearEntered.Text = "";
                directorEntered.Text = "";
                genresEntered.Text = "";
                actorsEntered.Text = "";
                otherRatingText.Text = "";

                //make advanced part invisible
                advancedCover.Visible = true;

                //make simple search top bar visible
                searchedCover1.Visible = false;
                searchedCover2.Visible = false;
                searchedCover3.Visible = false;

            }
            else
            {
                //make advanced part visible
                advancedCover.Visible = false;

                //make simple search top bar invisible
                searchedCover1.Visible = true;
                searchedCover2.Visible = true;
                searchedCover3.Visible = true;
            }

            //reinit all radio buttons
            gRadioButton.Checked = false;
            pgRadioButton.Checked = false;
            rRadioButtonS.Checked = false;
            otherRadioButton.Checked = false;

            //reinitialize the stars
            sStar10.Checked = false;
            sStar9.Checked = false;
            sStar8.Checked = false;
            sStar7.Checked = false;
            sStar6.Checked = false;
            sStar5.Checked = false;
            sStar4.Checked = false;
            sStar3.Checked = false;
            sStar2.Checked = false;
            sStar1.Checked = false;
        }

        public String findRating()
        {
            /* PURPOSE:
             * Get the Certification (rating) from which 
             * box is checked.
             * */

            String found = "";

            if (gRadioButton.Checked == true)
            {
                found = gRadioButton.Text;
            }
            else if (pgRadioButton.Checked == true)
            {
                found = pgRadioButton.Text;
            }
            else if (pg13RadioButton.Checked == true)
            {
                found = pg13RadioButton.Text;
            }
            else if (rRadioButtonS.Checked == true)
            {
                found = rRadioButtonS.Text;
            }
            else if (otherRadioButton.Checked == true)
            {
                found = otherRatingText.Text;
            }

            return found;
        }

        public void changeRadioButtonsS(RadioButton button)
        {
            /* PURPOSE: 
             * First checks (button in) all stars. Checks (button in)
             * the star clicked and unchecks all stars greater than the
             * star clicked.
             * */

            starsSClicked = true;

            sStar1.Checked = true;
            sStar2.Checked = true;
            sStar3.Checked = true;
            sStar4.Checked = true;
            sStar5.Checked = true;
            sStar6.Checked = true;
            sStar7.Checked = true;
            sStar8.Checked = true;
            sStar9.Checked = true;
            sStar10.Checked = true;

            //must all be ifs for this to work
            if (button.Name.Equals("sStar10"))
            {
                buttonLastClicked = sStar10;
            }
            if (button.Name.Equals("sStar9"))
            {
                buttonLastClicked = sStar9;
                sStar10.Checked = false;
            }
            if (button.Name.Equals("sStar8"))
            {
                buttonLastClicked = sStar8;
                sStar10.Checked = false;
                sStar9.Checked = false;
            }
            if (button.Name.Equals("sStar7"))
            {
                buttonLastClicked = sStar7;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
            }
            if (button.Name.Equals("sStar6"))
            {
                buttonLastClicked = sStar6;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
            }
            if (button.Name.Equals("sStar5"))
            {
                buttonLastClicked = star5;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
                sStar6.Checked = false;
            }
            if (button.Name.Equals("sStar4"))
            {
                buttonLastClicked = sStar4;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
                sStar6.Checked = false;
                sStar5.Checked = false;
            }
            if (button.Name.Equals("sStar3"))
            {
                buttonLastClicked = sStar3;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
                sStar6.Checked = false;
                sStar5.Checked = false;
                sStar4.Checked = false;
            }
            if (button.Name.Equals("sStar2"))
            {
                buttonLastClicked = sStar2;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
                sStar6.Checked = false;
                sStar5.Checked = false;
                sStar4.Checked = false;
                sStar3.Checked = false;
            }
            if (button.Name.Equals("sStar1"))
            {
                buttonLastClicked = sStar1;
                sStar10.Checked = false;
                sStar9.Checked = false;
                sStar8.Checked = false;
                sStar7.Checked = false;
                sStar6.Checked = false;
                sStar5.Checked = false;
                sStar4.Checked = false;
                sStar3.Checked = false;
                sStar2.Checked = false;
            }
        }

        /*-- Events and event helper methods --*/

        private void advancedClicked(Object sender, EventArgs e)
        {
            /* PURPOSE:
             * If the window is open close it
             * */

            if (advancedIsOpen == true)
            {
                advancedOpen(false);
            }
            else
            {
                advancedOpen(true);
            }
        }

        private void titleClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "Type in the full or partial title name of the movie.";
        }

        private void directorClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "Type in the full or partial name of the director.";
        }

        private void actorsClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "Each actor is seperated by a \",\". Full actor names must be entered.";
        }

        private void genresClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "Each genre is seperated by a \",\". Full genre names must be entered.";
        }

        private void yearClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "Type in one year. Year must be in the format xxxx where the x's are all digits.";
        }

        private void otherRatingClicked(Object sender, EventArgs e)
        {
            otherRadioButton.Checked = true;
            descriptionText.Text = "Type the abreviated version of the movie guidance rating. e.g. A for Approved";
        }

        private void starsSearchClicked(Object sender, EventArgs e)
        {
            descriptionText.Text = "All movies have at least one star.";
        }

        public void nowSearchingS(Object sender, EventArgs e)
        {
            Boolean noSearch = true;

            //Can choose to search by director or title in topmost search bar
            if (searchByTypeS.SelectedIndex == 0)//director
            {
                if (dataManager.updateGraph(searchByTypeS.Text, searchTextS.Text) == false)
                {
                    MessageBox.Show("No " + searchByTypeS.Text + "s were containing the string:\n|" + searchTextS.Text + "|");
                    noSearch = false;
                }
            }
            else if (searchByTypeS.SelectedIndex == 1)//title
            {
                if (dataManager.updateGraph(searchByTypeS.Text, searchTextS.Text) == false)
                {
                    MessageBox.Show("No " + searchByTypeS.Text + "s were containing the string:\n|" + searchTextS.Text + "|");
                    noSearch = false;
                }
            }

            if (!(titleEntered.Text.Equals("") && directorEntered.Text.Equals("") && actorsEntered.Text.Equals("")
                && genresEntered.Text.Equals("") && yearEntered.Text.Equals("") && starsSClicked == false && findRating().Equals("")))
            {
                noSearch = advancedOptions();
            }

            //transition page
            if (noSearch == true && windowControls.SelectedTab.Name != "refineWindow" && windowControls.SelectedTab.Name != "movieInfoWindow")
            {
                windowControls.SelectTab("refineWindow");
            }
        }

        private Boolean advancedOptions()
        {
            String name = null;
            Boolean noSearch = true;
            infoItem getValues = new infoItem(-1);
            String[] allEntries;

            //get the current rating
            if (buttonLastClicked != null)
            {
                name = buttonLastClicked.Name;
                if (Convert.ToChar(name.Substring(name.Length - 1)) == '0')//there is no zero there is only 10 (Star Wars force reference)
                {
                    getValues.Rating = "10";
                }
                else
                {
                    getValues.Rating = name.Substring(name.Length - 1) + "";
                }
            }
            else
            {
                getValues.Rating = "";
            }

            //put all the values into the getValues
            getValues.Title = titleEntered.Text;
            getValues.Director = directorEntered.Text;
            getValues.Year = yearEntered.Text;

            getValues.Certification = findRating();

            //now for the actors (a list)
            allEntries = actorsEntered.Text.Split(',');
            foreach (String actor in allEntries)//the foreach didn't work
            {
                Console.WriteLine(actor);//debugging
                getValues.addActor(actor);
            }

            //now for the genres (a list)
            allEntries = genresEntered.Text.Split(',');
            //MessageBox.Show(genreEntered.Text + "|" + allEntries[0] + "-" + allEntries[1]);
            foreach (String genre in allEntries)//the foreach didn't work
            {
                Console.WriteLine(genre);//debugging
                getValues.addGenre(genre);
            }

            /* The is ifs because multiple entries are allowed */
            if (dataManager.updateGraph(getValues) == false)
            {
                MessageBox.Show("No results for the data selected try leaving a field blank\n");
                noSearch = false;
            }

            return noSearch;
        }


    }
}
