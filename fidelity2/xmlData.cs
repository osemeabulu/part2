using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fidelity2
{
    //
    // Manages a list of nodes from the XML file.
    //

    public class xmlData
    {
        private List<infoItem> data;//each list item represents a node from the XML file.

        public xmlData()
        {
            data = new List<infoItem>();
        }

        public Boolean add(infoItem item)
        {
            /* PURPOSE:
             * If the item sents old version is present
             * replace it with the data sent. If it is not
             * present check if it's a duplicate, if not
             * add the item. If so return false to indicate
             * an error.
             * */

            Boolean duplicate = false;

            //first see if item is already present (NOT a check for duplicity)
            if(data.Count - 1 >= item.ID)//may not need to be -1
            {
                data[item.ID] = item;
            }
            //now check for an identically titled item
            else
            {
                foreach (infoItem dataItem in data)
                {
                    if(dataItem.Title.ToLower().Equals(item.Title.ToLower()))
                    {
                        duplicate = true;
                        break;//for efficiency
                    }
                }

                //if there is no duplicate add the item to datalist
                if (duplicate == false)
                {
                    data.Add(item);
                }
            }

            return duplicate;
        }

        public void addIgnoreDuplicates(infoItem item)
        {
            /* PURPOSE:
             * Allows For duplicates, just adds to the end.
             * Need this method because XML file has duplicates.
             * */

            data.Add(item);
        }

        public Boolean delete(infoItem item)
        {
            /*PURPOSE:
             * First decrements all ID's above the given item. Then finds
             * the given item and deletes it. If it can't delete the
             * item false is sent back
             * */

            Boolean delete = true;

            //must find if the data exists (User can double click without saving)
            if (data.Contains(item))
            {
                //decrement all above points
                for (int count = 0; count < data.Count - data.IndexOf(item) - 1; count++)
                {
                    data[count].ID--;
                }

                data.Remove(item);
            }
            else
            {
                delete = false;
            }

            return delete;
        }

        public infoItem get(int index)
        {
            return data[index];
        }

        public infoItem get(String title)
        {
            infoItem itemFound = null;

            foreach (infoItem item in data)
            {
                if (item.Title == title)
                {
                    itemFound = item;
                    break;
                }
            }

            return itemFound;
        }

        public int Size()
        {
            return data.Count;
        }

        //for debugging
        public override string ToString()
        {
            String returns = null;

            foreach (infoItem item in data)
            {
                returns += item + "\n";
            }

            return returns;
        }
    }
}
