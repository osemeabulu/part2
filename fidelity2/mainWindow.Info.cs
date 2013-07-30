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
        // This class deals with all objects and events relating to
        // the info window.
        //

        public void changedClicked()
        {
            /* PURPOSE
             * When changed is clicked all data is loaded into the dataPoint
             * object for further processing. The dataPoint is added to dataList
             * which changes a current node in this case. The XML is then
             * updated. Finally the graph is updated.
             * */

            String name = null;
            String[] allEntries;//just used for string parsing

            //changes the data if year,star rating and title
            if (!infoYearText.Text.Equals("") && !(infoTitleText.Text.Equals("") || infoTitleText.Text.Equals("Enter Title Here")))
            {

                //read in data
                dataPoint.Title = infoTitleText.Text;
                dataPoint.Certification = infoRating.Text;
                dataPoint.Director = infoDirectorText.Text;
                dataPoint.Year = infoYearText.Text;
                dataPoint.Length = infoLengthText.Text;
                dataPoint.Plot = infoPlotText.Text;

                //now for the actors (a list)
                allEntries = infoActorText.Text.Split(',');
                dataPoint.clearActors();//must do before re-adding
                foreach (String actor in allEntries)//the foreach didn't work
                {
                    Console.WriteLine(actor);//debugging
                    dataPoint.addActor(actor);
                }

                //now for the genres (a list)
                allEntries = infoGenreText.Text.Split(',');
                dataPoint.clearGenres();//must do before re-adding
                foreach (String genre in allEntries)//the foreach didn't work
                {
                    Console.WriteLine(genre);//debugging
                    dataPoint.addGenre(genre);
                }

                //now get the stars
                name = buttonLastClicked.Name;
                if (Convert.ToChar(name.Substring(name.Length - 1)) == '0')//there is no zero there is only 10 (Star Wars force reference)
                {
                    dataPoint.Rating = "10";
                }
                else
                {
                    dataPoint.Rating = Convert.ToChar(name.Substring(name.Length - 1)) + "";
                }

                dataList.add(dataPoint);//add takes care of duplicate testing

                //need to update the XML
                xmlReader.updateXML(dataPoint, "Edit");

                //update the graph
                dataManager.updateGraph();

                MessageBox.Show("Movie entry saved");
            }
            else
            {
                MessageBox.Show(" year and or title was not filled in");
            }
        }

        public void deleteClicked()
        {
            /* PURPOSE:
             * Deletes the datapoint from the datalist then updates the
             * XML. Finally the graph is updated.
             * */

            if (dataList.delete(dataPoint) == true)
            {
                //remove the data from the XML document page
                xmlReader.updateXML(dataPoint, "Delete");

                //update the graph
                dataManager.removePoint(dataPoint);
                dataManager.updateGraph();

                MessageBox.Show("Entry was deleted");
            }
            else
            {
                MessageBox.Show("Entry was not deleted because it doesn't exist");
            }
        }

        public void nowSearchingR(Object sender, EventArgs e)
        {
            /*PURPSOSE
             * Update Graph based on search criteria.
             * */

            //Can choose to search by director or title in topmost search bar
            if (searchByTypeR.SelectedIndex == 0)//director
            {
                if (dataManager.updateGraph(searchByTypeR.Text, searchTextR.Text) == false)
                {
                    MessageBox.Show("No " + searchByTypeR.Text + "s were containing the string:\n|" + searchTextR.Text + "|");
                }
            }
            else if (searchByTypeR.SelectedIndex == 1)//title
            {
                if (dataManager.updateGraph(searchByTypeR.Text, searchTextR.Text) == false)
                {
                    MessageBox.Show("No " + searchByTypeR.Text + "s were containing the string:\n|" + searchTextR.Text + "|");
                }
            }

            //points only update on screen change
            dataManager.getGraph().Redraw();
        }

        public void buttonFromRating(int rating)
        {
            /*PURPOSE:
             * From a rating select a radio button. Which
             * will auto select other radio buttons. This
             * method applies to all radio button panels.
             * */

            if (rating == 1)
            {
                changeRadioButtonsI(star1);
            }
            else if (rating == 2)
            {
                changeRadioButtonsI(star2);
            }
            else if (rating == 3)
            {
                changeRadioButtonsI(star3);
            }
            else if (rating == 4)
            {
                changeRadioButtonsI(star4);
            }
            else if (rating == 5)
            {
                changeRadioButtonsI(star5);
            }
            else if (rating == 6)
            {
                changeRadioButtonsI(star6);
            }
            else if (rating == 7)
            {
                changeRadioButtonsI(star7);
            }
            else if (rating == 8)
            {
                changeRadioButtonsI(star8);
            }
            else if (rating == 9)
            {
                changeRadioButtonsI(star9);
            }
            else if (rating == 10)
            {
                changeRadioButtonsI(star10);
            }
        }

        public void changeRadioButtonsI(RadioButton button)
        {
            /*PURPOSE: 
             * First checks (button in) all stars. Checks (button in)
             * the star clicked and unchecks all stars greater than the
             * star clicked.
             * */

            star1.Checked = true;
            star2.Checked = true;
            star3.Checked = true;
            star4.Checked = true;
            star5.Checked = true;
            star6.Checked = true;
            star7.Checked = true;
            star8.Checked = true;
            star9.Checked = true;
            star10.Checked = true;

            //must all be ifs for this to work
            if (button.Name.Equals("star10"))
            {
                buttonLastClicked = star10;
            }
            if (button.Name.Equals("star9"))
            {
                buttonLastClicked = star9;
                star10.Checked = false;
            }
            if (button.Name.Equals("star8"))
            {
                buttonLastClicked = star8;
                star10.Checked = false;
                star9.Checked = false;
            }
            if (button.Name.Equals("star7"))
            {
                buttonLastClicked = star7;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
            }
            if (button.Name.Equals("star6"))
            {
                buttonLastClicked = star6;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
            }
            if (button.Name.Equals("star5"))
            {
                buttonLastClicked = star5;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
                star6.Checked = false;
            }
            if (button.Name.Equals("star4"))
            {
                buttonLastClicked = star4;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
                star6.Checked = false;
                star5.Checked = false;
            }
            if (button.Name.Equals("star3"))
            {
                buttonLastClicked = star3;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
                star6.Checked = false;
                star5.Checked = false;
                star4.Checked = false;
            }
            if (button.Name.Equals("star2"))
            {
                buttonLastClicked = star2;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
                star6.Checked = false;
                star5.Checked = false;
                star4.Checked = false;
                star3.Checked = false;
            }
            if (button.Name.Equals("star1"))
            {
                buttonLastClicked = star1;
                star10.Checked = false;
                star9.Checked = false;
                star8.Checked = false;
                star7.Checked = false;
                star6.Checked = false;
                star5.Checked = false;
                star4.Checked = false;
                star3.Checked = false;
                star2.Checked = false;
            }
        }

    }
}
