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
        // Handles all relevant objects and events for the create page.
        //

        public void savedClicked()
        {
            /* PURPOSE:
             * Saves the data to the dataPont if the year, 
             * star rating and title were specified.
             * */

            String name = null;
            String[] allEntries;
            infoItem addingPoint = new infoItem(dataList.Size());//add item at the end

            //first must get the current rating to check
            if (buttonLastClicked != null)
            {
                name = buttonLastClicked.Name;
                if (Convert.ToChar(name.Substring(name.Length - 1)) == '0')//there is no zero there is only 10 (Star Wars force reference)
                {
                    addingPoint.Rating = "10";
                }
                else
                {
                    addingPoint.Rating = name.Substring(name.Length - 1) + "";
                }
            }
            else
            {
                addingPoint.Rating = "";
            }

            //check if the 3 essential coordinates were specified
            if (!createYearText.Text.Equals("") && !addingPoint.Rating.Equals("") && !(createTitleText.Text.Equals("") || createTitleText.Text.Equals("Enter Title Here")))
            {
                addingPoint.Title = createTitleText.Text;
                addingPoint.Certification = createRatingText.Text;
                addingPoint.Director = createDirectorText.Text;
                addingPoint.Year = createYearText.Text;
                addingPoint.Length = createLengthText.Text;
                addingPoint.Plot = createPlotText.Text;

                //now for the actors (a list)
                allEntries = createActorText.Text.Split(',');
                addingPoint.clearActors();//must do before re-adding
                foreach (String actor in allEntries)//the foreach didn't work
                {
                    Console.WriteLine(actor);//debugging
                    addingPoint.addActor(actor);
                }

                //now for the genres (a list)
                allEntries = createGenreText.Text.Split(',');
                addingPoint.clearGenres();//must do before re-adding
                foreach (String genre in allEntries)//the foreach didn't work
                {
                    Console.WriteLine(genre);//debugging
                    addingPoint.addGenre(genre);
                }

                /* Now update graph and XML */

                //add takes care of duplicate testing
                if (dataList.add(addingPoint) == true)//NOTE: true is cannot add in this case
                {
                    MessageBox.Show("There is already an entry named \"" + addingPoint.Title + "\" saved.");
                }
                else
                {
                    //need to update the XML
                    xmlReader.updateXML(addingPoint, "Add");

                    //update the graph
                    dataManager.addPoint(addingPoint);

                    MessageBox.Show("Movie Entry Created");
                }
            }
            //data is not valid
            else
            {
                MessageBox.Show("Year and or stars and or title were not specified");
            }
        }

        public void changeRadioButtonsC(RadioButton button)
        {
            /* PURPOSE: 
             * First checks (button in) all stars. Checks (button in)
             * the star clicked and unchecks all stars greater than the
             * star clicked.
             * */

            cStar1.Checked = true;
            cStar2.Checked = true;
            cStar3.Checked = true;
            cStar4.Checked = true;
            cStar5.Checked = true;
            cStar6.Checked = true;
            cStar7.Checked = true;
            cStar8.Checked = true;
            cStar9.Checked = true;
            cStar10.Checked = true;

            //must all be ifs for this to work
            if (button.Name.Equals("cStar10"))
            {
                buttonLastClicked = cStar10;
            }
            if (button.Name.Equals("cStar9"))
            {
                buttonLastClicked = cStar9;
                cStar10.Checked = false;
            }
            if (button.Name.Equals("cStar8"))
            {
                buttonLastClicked = cStar8;
                cStar10.Checked = false;
                cStar9.Checked = false;
            }
            if (button.Name.Equals("cStar7"))
            {
                buttonLastClicked = cStar7;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
            }
            if (button.Name.Equals("cStar6"))
            {
                buttonLastClicked = cStar6;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
            }
            if (button.Name.Equals("cStar5"))
            {
                buttonLastClicked = cStar5;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
                cStar6.Checked = false;
            }
            if (button.Name.Equals("cStar4"))
            {
                buttonLastClicked = cStar4;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
                cStar6.Checked = false;
                cStar5.Checked = false;
            }
            if (button.Name.Equals("cStar3"))
            {
                buttonLastClicked = cStar3;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
                cStar6.Checked = false;
                cStar5.Checked = false;
                cStar4.Checked = false;
            }
            if (button.Name.Equals("cStar2"))
            {
                buttonLastClicked = cStar2;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
                cStar6.Checked = false;
                cStar5.Checked = false;
                cStar4.Checked = false;
                cStar3.Checked = false;
            }
            if (button.Name.Equals("cStar1"))
            {
                buttonLastClicked = cStar1;
                cStar10.Checked = false;
                cStar9.Checked = false;
                cStar8.Checked = false;
                cStar7.Checked = false;
                cStar6.Checked = false;
                cStar5.Checked = false;
                cStar4.Checked = false;
                cStar3.Checked = false;
                cStar2.Checked = false;
            }
        }
    }
}
