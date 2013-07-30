using System;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Collections.Generic;

namespace fidelity2
{
    public class GraphManager
    {
        //
        // Keeps track of the graph of movies in the refine tab. This includes
        // all variables that can manipulate the graph. And includes the
        // trackbars that can manipulate the graph. 
        //

        private Chart graph;
        private xmlData data;

        //items that can manipulate the graph
        private TrackBar starsBar;
        private TrackBar yearsBarMin;
        private TrackBar yearsBarMax;

        private List<Button> genreButtons;
        private List<Int32> genresClicked;//array that stores if a button is clicked or not

        //variables that define the graph
        private Size origSize;
        private Size bigSize;
        private Point origPoint;
        private Point bigPoint;
        private mainWindow window;
        private Boolean graphBig;
        private Label movieNum;

        private ToolTip toolTip;


        public GraphManager(mainWindow window)
        {
            this.window = window;

            genreButtons = new List<Button>();
            genresClicked = new List<int>();
        }

        public void add(Chart graph, xmlData data, ToolTip toolTip)
        {
            this.graph = graph;
            this.data = data;
            this.toolTip = toolTip;

            origSize = graph.Size;
            origPoint = graph.Location;
            bigSize = new Size((int)(graph.Size.Width * 1.75), (int)(graph.Size.Height * 1.75));
            bigPoint = new Point(origPoint.X - 185,origPoint.Y - 75);

            graphBig = false;
        }

        public void add(TrackBar bar)
        {
            //I assuming there is only 2 trackbars that can be added
            if (bar.Name.Equals("starsBar"))
            {
                starsBar = bar;
                starsBar.ValueChanged += new EventHandler(starValueChanged);//reduces code by adding here
            }
            else if (bar.Name.Equals("yearsBarMin"))
            {
                yearsBarMin = bar;
                yearsBarMin.ValueChanged += new EventHandler(yearsMinValueChanged);
            }
            else
            {
                yearsBarMax = bar;
                yearsBarMax.ValueChanged += new EventHandler(yearsMaxValueChanged);
            }
        }

        public void loadPoints()
        {
            /*PURPOSE:
             * Loads all the data points into the graph point by point
             * */

            infoItem temp;
            //ToolTip pointTip;

            //movieNum.Text = "0";
            for (int count = 0; count < data.Size(); count++)
            {
                //get each point
                temp = data.get(count);

                //load each point into the graph (via X and Y coordinates)
                graph.Series[0].Points.AddXY(Double.Parse(temp.Year), Double.Parse(temp.Rating));
                graph.Series[0].Points[count].ToolTip = temp.Title;
                if (count == 3049)
                {
                    Console.Write("w");
                }

                //incement movie num
                movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
            }
        }

        public void addPoint(infoItem adding)
        {
            graph.Series[0].Points.AddXY(Double.Parse(adding.Year), Double.Parse(adding.Rating));
            graph.Series[0].Points[adding.ID].ToolTip = adding.Title;

            //incement movie num
            movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
        }

        public void removePoint(infoItem deleting)
        {
            //set point off screen (equivalent to removing)
            graph.Series[0].Points[deleting.ID].SetValueXY(-1,-1);

            //incement movie num
            movieNum.Text = (Int32.Parse(movieNum.Text) - 1).ToString();
        }

        public void updatePoints()
        {
            /*PURPOSE:
             * Loads all the data points into the graph point by point
             * */

            infoItem temp;
            //ToolTip pointTip;

            movieNum.Text = "0";
            for (int count = 0; count < data.Size(); count++)
            {
                //get each point
                temp = data.get(count);

                //load each point into the graph (via X and Y coordinates)
                graph.Series[0].Points[count].SetValueXY(Double.Parse(temp.Year), Double.Parse(temp.Rating));
                graph.Series[0].Points[count].ToolTip = temp.Title;

                //incement movie num
                movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
            }
        }

        public Boolean updatePoints(String criteria,String value)
        {
            /*PURPOSE:
             * display all points in the data that are conform
             * to all the criteria sent. Returns false if no
             * points could be displayed. Also if only one point
             * was found goes directly to that info page.
             * */

            infoItem temp = null;
            infoItem foundItem = null;
            Boolean displayPoint = true;
            int found = 0;

            //update everyPoint if it meets the criteria
            movieNum.Text = "0";
            for (int count = 0; count < data.Size(); count++)
            {
                //get each point
                temp = data.get(count);

                //see if the point matches the criteria to be displayed
                if (criteria.Equals("Title"))
                {
                    if (!temp.Title.ToLower().Contains(value.ToLower()))
                    {
                        displayPoint = false;
                    }
                    else
                    {
                        displayPoint = true;
                    }
                }
                else if (criteria.Equals("Director"))
                {
                    if (!temp.Director.ToLower().Contains(value.ToLower()))
                    {
                        displayPoint = false;
                    }
                    else
                    {
                        displayPoint = true;
                    }
                }
                else if (criteria.Equals("Rating"))
                {
                    //see if the point matches the criteria to be displayed
                    if (!temp.Rating.Equals(value))
                    {
                        displayPoint = false;
                    }
                   else
                   {
                        displayPoint = true;
                   }
                }

                if (displayPoint == true)
                {
                    //load each point into the graph (via X and Y coordinates)
                    graph.Series[0].Points[count].SetValueXY(Double.Parse(temp.Year), Double.Parse(temp.Rating));
                    graph.Series[0].Points[count].ToolTip = temp.Title;

                    found++;

                    foundItem = temp;

                    //incement movie num
                    movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
                }
                else//set point value off screen
                {
                    graph.Series[0].Points[count].SetValueXY(-1,-1);
                }
            }

            //determine number of points found
            if (found < 1)
            {
                displayPoint = false;
            }
            else//multiple points so goes to refine screen eventually
            {
                displayPoint = true;
            }

            if (found == 1)
            {
                window.setDataPoint(foundItem);//if only one entry it will always be the last
                window.getWindowControls().SelectTab("movieInfoWindow");
            }

            return displayPoint;
        }

        public Boolean updatePoints(infoItem item)
        {
            /*PURPOSE
             * Displays all points that meet all non-empty
             * criteria in item.
             * */

            infoItem temp = null;
            infoItem foundItem = null;
            Boolean displayPoint = true;
            int found = 0;

            //update everyPoint if it meets the criteria
            movieNum.Text = "0";
            for (int count = 0; count < data.Size(); count++)
            {
                displayPoint = true;

                //get each point
                temp = data.get(count);

                //see if the point matches the set of items sent
                if (!item.Rating.Equals(""))
                {
                    if (!temp.Rating.Equals(item.Rating))
                    {
                        displayPoint = false;
                    }
                }
                if (!item.Title.Equals(""))
                {
                    if (!temp.Title.ToLower().Contains(item.Title.ToLower()))
                    {
                        displayPoint = false;
                    }
                }
                if (!item.Director.Equals(""))
                {
                    if (!temp.Director.ToLower().Contains(item.Director.ToLower()))
                    {
                        displayPoint = false;
                    }
                }
                if (!item.Year.Equals(""))
                {
                    if (!temp.Year.Equals(item.Year))
                    {
                        displayPoint = false;
                    }
                }
                if (!item.Certification.Equals(""))
                {
                    if (!item.Certification.Equals(temp.Certification))
                    {
                        displayPoint = false;
                    }
                }
                if (item.genreSize() > 0 && !item.getGenre(0).Equals(""))
                {
                    if (temp.genreSize() >= item.genreSize())
                    {
                        //contains all actors sent
                        for (int count2 = 0; count2 < item.genreSize(); count2++)
                        {
                            if (temp.hasGenre(item.getGenre(count2)) == false)
                            {
                                displayPoint = false;
                                break;//only one false is needed
                            }
                        }
                    }
                    else
                    {
                        displayPoint = false;
                    }
                }
                if (item.actorSize() > 0 && temp.actorSize() >= item.actorSize() && !item.getActor(0).Equals(""))
                {
                    if (temp.actorSize() >= item.actorSize())
                    {
                        //contains all actors sent
                        for (int count2 = 0; count2 < item.actorSize(); count2++)
                        {
                            if (temp.hasActor(item.getActor(count2)) == false)
                            {
                                displayPoint = false;
                                break;//only one false is needed
                            }
                        }
                    }
                    else
                    {
                        displayPoint = false;
                    }
                }

                if (displayPoint == true)
                {
                    //load each point into the graph (via X and Y coordinates)
                    graph.Series[0].Points[count].SetValueXY(Double.Parse(temp.Year), Double.Parse(temp.Rating));
                    graph.Series[0].Points[count].ToolTip = temp.Title;

                    found++;

                    foundItem = temp;

                    //incement movie num
                    movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
                }
                else//set point value off screen
                {
                    graph.Series[0].Points[count].SetValueXY(-1, -1);
                }
            }

            //determine number of points found
            if (found < 1)
            {
                displayPoint = false;
            }
            else//multiple points so goes to refine screen eventually
            {
                displayPoint = true;
            }

            if (found == 1)
            {
                window.setDataPoint(foundItem);//if only one entry it will always be the last
                window.getWindowControls().SelectTab("movieInfoWindow");
            }

            return displayPoint;
        }

        public void addEvents()
        {
            //need to make the graph visible, so click to make larger also if a point is there go to movie info instead
            graph.MouseClick += new MouseEventHandler(graphClicked);
        }

        /*-- Events --*/

        private void starValueChanged(Object sender, EventArgs e)
        {
            /* PURPOSE:
             * Changes the y axis so only values above a certian
             * star are shown. And sets interval.
             * */

            if (starsBar.Value < 10)
            {
                graph.ChartAreas[0].AxisY.Minimum = starsBar.Value;
            }
        }

        private void yearsMinValueChanged(Object sender, EventArgs e)
        {
           /* PURPOSE:
            * Changes the x axis so only values above a certian
            * year are shown. And sets interval.
            * */

            int yearsValue = (yearsBarMin.Value * 10) + 1930;

            if (yearsBarMax.Value > yearsBarMin.Value)
            {
                //The yearBar must be converted into a 1930 - 2010 range
                graph.ChartAreas[0].AxisX.Minimum = yearsValue;
            }
            //min value is the next tick, so when moving this move, move back min value if possible
            else if (yearsBarMax.Value < yearsBarMax.Maximum)
            {
                yearsBarMax.Value++;
                graph.ChartAreas[0].AxisX.Minimum = yearsValue;
            }
            //stops sliders from passing each other
            else
            {
                yearsBarMin.Value--;
            }

            //divide up the interval so there is always 10 ticks
            graph.ChartAreas[0].AxisX.Interval = yearsBarMax.Value - yearsBarMin.Value;
        }

        private void yearsMaxValueChanged(Object sender, EventArgs e)
        {
            /* PURPOSE:
             * Changes the x axis so only values beliw a certian
             * year are shown. And sets interval.
             * */

            int yearsValue = (yearsBarMax.Value * 10) + 1930;

            if (yearsBarMax.Value > yearsBarMin.Value)
            {
                graph.ChartAreas[0].AxisX.Maximum = yearsValue;
            }
            //max value is the next tick, so when moving this move, move forward max value if possible
            else if (yearsBarMax.Value > yearsBarMax.Minimum)
            {
                yearsBarMin.Value--;
                graph.ChartAreas[0].AxisX.Maximum = yearsValue;
            }
            //stops sliders from passing each other
            else
            {
                yearsBarMax.Value++;
            }

            //divide up the interval so there is always 10 ticks
            graph.ChartAreas[0].AxisX.Interval = yearsBarMax.Value - yearsBarMin.Value;
        }

        private void graphClicked(Object sender, MouseEventArgs e)
        {
            /*PURPOSE:
             * If a point was not clicked on make the graph larger. If it was
             * find what the points information was and transition to the refine
             * results page.
             * */

            DataPoint foundPoint = null;
            Double valueX = 0;
            Double valueY = 0;

            //find what the point corresponds to in terms of value coordinates (axis's define these) //NOTE: may be glitchy
            valueX = graph.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            valueX = round(valueX);
            valueY = graph.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
            valueY = round(valueY);

            //find if there is a point where user clicked (must cycle through all points)
            foreach (DataPoint point in graph.Series[0].Points)
            {
                if (point.XValue == (Double)valueX && point.YValues[0] == (Double)valueY)
                {
                    foundPoint = point;
                    break;//for efficiency
                }
            }

            //get foundPoints values and transition
            if (foundPoint != null)
            {
                window.setDataPoint(data.get(foundPoint.ToolTip));
                window.getWindowControls().SelectTab("movieInfoWindow"); 
            }
            //now just resize the graph depending on its current state
            else
            {
                if (graphBig == true)
                {
                    resetGraphSize();
                }
                else if (graphBig == false)
                {
                    graph.Size = bigSize;
                    graph.Location = bigPoint;
                    graphBig = true;

                    //set background back to transparent
                    graph.BorderSkin.PageColor = Color.Transparent;

                    //make all the points bigger
                    graph.Series[0].MarkerSize = 7;
                }
            }
        }

        public void resetGraphSize()
        {
            graph.Size = origSize;
            graph.Location = origPoint;
            graphBig = false;

            //set background back to normal
            graph.BorderSkin.PageColor = Color.Wheat;

            //restore point size
            graph.Series[0].MarkerSize = 5;
        }

        public void resetControls()
        {
            if (graphBig == true)
            {
                resetGraphSize();
            }
        }

        public void addmovieNum(Label movieNum)
        {
            this.movieNum = movieNum;
        }

        public void addGenreButton(Button added)
        {
            added.Click += new EventHandler(genreClicked);
            genreButtons.Add(added);
            genresClicked.Add(0);
        }

        public void genreClicked(Object sender, EventArgs e)
        {
            int index = 0;

            index = genreButtons.IndexOf((Button)sender);

            //button not clicked
            if(genresClicked[index] == 0)
            {
                ((Button)sender).BackColor = Color.LimeGreen;
                genresClicked[index] = 1;
            }
            else
            {
                ((Button)sender).BackColor = Color.DarkOrange;
                genresClicked[index] = 0;
            }

            updateFromGenres();
        }

        public void resetGenresClicked()
        {
            for (int count = 0; count < genresClicked.Count; count++)
            {
                genresClicked[count] = 0;
            }
        }

        private void updateFromGenres()
        {
            /* Checks and rejects any points that don't
             * contain a specific genre */

            infoItem temp;
            Boolean displayPoint = true;
            Boolean foundGenre = false;
            int count2 = 0;

            //each point
            movieNum.Text = "0";
            for (int count = 0; count < data.Size(); count++)
            {
                //get each point
                temp = data.get(count);

                displayPoint = true;

                //see if the point matches the criteria to be displayed
                count2 = 0;
                foreach(Button button in genreButtons)
                {
                    if(genresClicked[count2] == 1)
                    {
                        //see if the point matches the criteria to be displayed
                        foundGenre = false;
                        for (int count3 = 0; count3 < temp.genreSize(); count3++)
                        {
                            if(button.Text == temp.getGenre(count3))
                            {
                                foundGenre = true;
                                break;//for efficiency
                            }
                        }

                        if(foundGenre == false)
                        {
                            displayPoint = false;
                        }
                    }
                    count2++;
                }

                if (displayPoint == true)
                {
                    //load each point into the graph (via X and Y coordinates)
                    graph.Series[0].Points[count].SetValueXY(Double.Parse(temp.Year), Double.Parse(temp.Rating));
                    graph.Series[0].Points[count].ToolTip = temp.Title;

                    movieNum.Text = (Int32.Parse(movieNum.Text) + 1).ToString();
                }
                else//set point value off screen
                {
                    graph.Series[0].Points[count].SetValueXY(-1, -1);

                    //incement movie num
                    //movieNum.Text = (Int32.Parse(movieNum.Text) - 1).ToString();
                }
            }

            graph.Invalidate();

        }

        //auxillary method (may be needed)
        public Double round(Double number)
        {
            /* PURPOSE:
             * Defines how close a click has to be to a circle
             * to be considered clicking on the circle. The margin
             * is determined by how big the graph is. This is because
             * the bigger the graph the bigger the points.
             * */

            Double difference = 0;
            Double overTolerance = 0.88;//how close greater than a dot in value
            Double underTolerance = 0.11;

            if (graphBig == false)
            {
                overTolerance = 0.88;//greater precision = greater number
                underTolerance = 0.11;//greater precision = lesser number
            }

            difference = number - (int)number;

            if (difference < underTolerance)
            {
                number = (int)number;//value is the floor
            }
            else if (difference > overTolerance)
            {
                number = (int)number + 1;//value is the cieling
            }

            return number;
        }

        public void Redraw()
        {
            graph.Invalidate();
        }
    }
}
