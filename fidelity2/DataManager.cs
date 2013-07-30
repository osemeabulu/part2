using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//for any type of collection
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;//need for oval shapes

namespace fidelity2
{
    public class DataManager
    {
        // This class handles all post design changes to code
        // 
        // Note: managers may have to be given the whole window instead
        // of a tab in some instances.
        //

        private mainWindow mainWindow;

        //managing subcontents
        private ButtonManager buttonManager;//also considers custom buttons
        private LabelManager labelManager;
        private GraphManager graphManager;//manages the only chart which is in the refine tab

        public DataManager(mainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            //the subclass initializations
            buttonManager = new ButtonManager(mainWindow.getWindowControls(),mainWindow);
            labelManager = new LabelManager(mainWindow.getWindowControls(),mainWindow);
            graphManager = new GraphManager(mainWindow);
        }

        public void addControl(Object added)
        {
            /* adds controls to be managed*/

            if (added is Button)
            {
                graphManager.addGenreButton((Button)added);
            }
            else if (added is OvalShape)
            {
                buttonManager.add((OvalShape)added);
            }
            else if (added is Label)
            {
                labelManager.add((Label)added);

                //makes things much more efficient
                if ( ((Label)added).Name.Equals("searchCreateLabel") )
                {
                    buttonManager.setCS((Label)added);
                }
            }
            else if (added is Chart)
            {
                graphManager.add(mainWindow.getGraph(), mainWindow.getXML(), mainWindow.getToolTip());
                graphManager.loadPoints();//might as well load for the first time
            }
            else if(added is TrackBar)
            {
                graphManager.add((TrackBar)added);
            }
            else
            {
                MessageBox.Show("Item is not ready to be implemented refer to dataManager");
            }
        }

        public void addEvents()
        {
            /* calls each managers method to add events */
            buttonManager.addEvents();
            labelManager.addEvents();
        }

        public void resetControls()
        {
            graphManager.resetControls();
        }

        public void resetGraphSize()
        {
            graphManager.resetGraphSize();
        }

        public void resetGenresClicked()
        {
            graphManager.resetGenresClicked();
        }

        public GraphManager getGraph()
        {
            return graphManager;
        }

        public void addPoint(infoItem addPoint)
        {
            graphManager.addPoint(addPoint);
        }

        public void removePoint(infoItem deleting)
        {
            graphManager.removePoint(deleting);
        }

        public void updateGraph()
        {
            graphManager.updatePoints();
        }

        public Boolean updateGraph(String criteria, String value)
        {
            return graphManager.updatePoints(criteria, value);
        }

        public Boolean updateGraph(infoItem entryValues)
        {
            return graphManager.updatePoints(entryValues);
        }
    }
}
