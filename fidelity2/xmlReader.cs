using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace fidelity2
{
    //
    // This class reads and manipulates an xml file
    //

    class xmlReader
    {
        private XmlDocument movies;
        private xmlData dataList;//2d list
        private FileStream file;
        private String fileName;

        public xmlReader(xmlData listSent, XmlDocument movies)
        {
            this.movies = movies;
            dataList = listSent;
        }

        public void loadXml(String fileName)
        {
            /* PURPOSE:
             * loads the sent xml file and adds all the data from
             * it to the sent in listView.
             */
            this.fileName = fileName;
            file = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            int count = 0;
            infoItem temp = new infoItem(count);//-1 indicates an invalid infoItem

            movies.Load(file);

            foreach (XmlElement item in movies.SelectNodes(@"movielist/movie"))
            {
                count++;//only used for infoItem ID's

                //always 1 title, year, certification, director and rating
                temp.Title = item["title"].InnerText;
                temp.Year = item["year"].InnerText;
                temp.Length = item["length"].InnerText;
                temp.Director = item["director"].InnerText;
                temp.Rating = item["rating"].InnerText;

                if (item["certification"] != null)
                {
                    temp.Certification = item["certification"].InnerText;
                }
                if (item["plot"] != null)
                {
                    temp.Plot = item["plot"].InnerText;
                }

                //loop through genres and actor reading in all of them
                foreach (XmlElement subItem in item.GetElementsByTagName("genre"))
                {
                    temp.addGenre(subItem.InnerText);
                }

                foreach (XmlElement subItem in item.GetElementsByTagName("actor"))
                {
                    temp.addActor(subItem.InnerText);
                }

                if(count == 3058)
                {
                    Console.Write("");
                }

                dataList.addIgnoreDuplicates(temp);
                temp = new infoItem(count);
            }

            //have to do this to allow multiple file openings
            //file.Close();
        }

        public void updateXML(infoItem dataPoint,String type)
        {
            /* PURPOSE:
             * loads data from the dataList into the XML file.
             * */

            int index = -1;
            int count = 0;

            //find point to change
            index = dataPoint.ID;

             //get each individual element if need to delete or edit a certian point
            if (!type.Equals("Add"))
            {
                //loop until the right node was reached INEFFICIENT
                foreach (XmlElement item in movies.SelectNodes(@"movielist/movie"))
                {
                    if (count == index && type.Equals("Edit"))
                    {
                        editEntry(item, dataPoint);

                        break;
                    }
                    else if (count == index && type.Equals("Delete"))
                    {
                        //item removes itself
                        item.ParentNode.RemoveChild(item);

                        break;
                    }
                    count++;
                }
            }
            //add an entry to the end
            else
            {
                addEntry(dataPoint);
            }
        }

        /* UpdateXML helper method */
        private void addEntry(infoItem dataPoint)
        {
            /* PURPOSE:
             * Updates an XML file by placing a new entry based
             * on the dataPoint sent.
             * */

            XmlNode newNode;
            //child nodes
            XmlNode titleNode;
            XmlNode yearNode;
            XmlNode lengthNode;
            XmlNode directorNode;
            XmlNode ratingNode;
            XmlNode certificationNode;
            XmlNode plotNode;
            XmlNode addingNode;//for copying into all the actors

            //create parent node
            newNode = movies.CreateNode(XmlNodeType.Element, "movie", null);

            //create child nodes
            titleNode = movies.CreateNode(XmlNodeType.Element, "title", null);
            titleNode.InnerText = dataPoint.Title;
            yearNode = movies.CreateNode(XmlNodeType.Element, "year", null);
            yearNode.InnerText = dataPoint.Year;
            lengthNode = movies.CreateNode(XmlNodeType.Element, "length", null);
            lengthNode.InnerText = dataPoint.Length;
            directorNode = movies.CreateNode(XmlNodeType.Element, "director", null);
            directorNode.InnerText = dataPoint.Director;
            ratingNode = movies.CreateNode(XmlNodeType.Element, "rating", null);
            ratingNode.InnerText = dataPoint.Rating;
            certificationNode = movies.CreateNode(XmlNodeType.Element, "certification", null);
            certificationNode.InnerText = dataPoint.Certification;
            plotNode = movies.CreateNode(XmlNodeType.Element, "plot", null);
            plotNode.InnerText = dataPoint.Plot;

            //add child nodes to the parent
            newNode.AppendChild(titleNode);
            newNode.AppendChild(yearNode);
            newNode.AppendChild(lengthNode);
            newNode.AppendChild(directorNode);
            newNode.AppendChild(ratingNode);
            newNode.AppendChild(certificationNode);
            newNode.AppendChild(plotNode);

            //loop to add all genres
            for (int count = 0; count < dataPoint.genreSize(); count++ )
            {
                addingNode = movies.CreateNode(XmlNodeType.Element, "genre", null);
                addingNode.InnerText = dataPoint.getGenre(count);
                newNode.AppendChild(addingNode);
            }

            //loop to add all actors
            for (int count = 0; count < dataPoint.actorSize(); count++)
            {
                addingNode = movies.CreateNode(XmlNodeType.Element, "actor", null);
                addingNode.InnerText = dataPoint.getActor(count);
                newNode.AppendChild(addingNode);
            }

            //add node to collection
            movies.DocumentElement.AppendChild(newNode);
        }

        /* UpdateXML helper method */
        private void editEntry(XmlElement item, infoItem dataPoint)
        {
            /* PURPOSE:
             * Modifies all elements for a node in the XML file. If there
             * is data for a node that doesn't exist it is created eith the
             * data.
             * */

            int subCount = 0;//sub item count
            XmlElement newElement;//element that is added of a certian element of data isn't present in the XML file

            item["title"].InnerText = dataPoint.Title;
            item["year"].InnerText = dataPoint.Year;
            item["length"].InnerText = dataPoint.Length;
            item["director"].InnerText = dataPoint.Director;
            item["rating"].InnerText = dataPoint.Rating;

            if (item["certification"] != null)
            {
                item["certification"].InnerText = dataPoint.Certification;
            }
            //add a certification if one was entered earlier
            else if (dataPoint.Certification != null)
            {
                //create the element and add the data to it
                newElement = movies.CreateElement("certification");
                newElement.InnerText = dataPoint.Certification;

                //add the item to the end of the current node (order will not matter in the end)
                item.AppendChild(newElement);
            }

            //edit or create a new plot entry
            if (item["plot"] != null)
            {
                item["plot"].InnerText = dataPoint.Plot;
            }
            else if (dataPoint.Certification != null)
            {
                //create the element and add the data to it
                newElement = movies.CreateElement("plot");
                newElement.InnerText = dataPoint.Plot;

                //add the item to the end of the current node (order will not matter in the end)
                item.AppendChild(newElement);
            }

            //loop and read into both sets of actors and genres
            foreach (XmlElement subItem in item.GetElementsByTagName("genre"))
            {
                subItem.InnerText = dataPoint.getGenre(subCount);
                subCount++;
            }

            subCount = 0;
            foreach (XmlElement subItem in item.GetElementsByTagName("actor"))
            {
                subItem.InnerText = dataPoint.getActor(subCount);
                subCount++;
            }
        }

        public void updateXML()
        {
            /* PURPOSE:
             * Closes file saves all data and then opens the file
             * for further reading. Used for reset mainly.
             * */

            file.Close();
            File.WriteAllText(fileName, "");

            //open the file and read in contents now
            file = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            movies.Save(file);
        }

        public void saveFile()
        {
            /* PURPOSE:
             * Clears current file and adds whats in the current
             * XML document to the file. Then closes the file.
             * */

            //remove all contents of the original xml file (have to close to do this)
            file.Close();
            File.WriteAllText(fileName, "");

            //open the file and read in contents now
            file = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            movies.Save(file);

            file.Close();
        }

    }
}
