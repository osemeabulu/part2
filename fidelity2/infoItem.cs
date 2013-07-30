using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fidelity2
{
    public class infoItem
    {
        //
        // Represents one node and all its elements from
        // the XML file.
        //


        String title;
        String year;
        String length;
        String certification;
        String director;
        String rating;
        String plot;
        List<String> genres;
        List<String> actors;
        int id;//makes infoItem a lot easier to manage

        public infoItem(int id)
        {
            genres = new List<string>();
            actors = new List<string>();

            this.id = id;
        }

        public Boolean hasActor(String actor)
        {
            Boolean hasActor = false;

            foreach (String item in actors)
            {
                if (actor.ToLower().Equals(item.ToLower()))
                {
                    hasActor = true;
                    break;//for efficiency
                }
            }

            return hasActor;
        }

        public int actorSize()
        {
            return actors.Count;
        }

        public void clearActors()
        {
            actors = new List<string>();
        }

        public void setActor(int index, String actor)
        {
            actors[index] = actor;
        }

        public void addActor(String actor)
        {
            actors.Add(actor);
        }

        /*-- getters and setters --*/

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String Year
        {
            get { return year; }
            set { year = value; }
        }

        public String Length
        {
            get { return length; }
            set { length = value; }
        }

        public String Certification
        {
            get { return certification; }
            set { certification = value; }
        }

        public String Director
        {
            get { return director; }
            set { director = value; }
        }

        public String Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public String Plot
        {
            get { return plot; }
            set { plot = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String getGenre(int index)
        {
            return genres[index];
        }

        public void setGenre(int index, String genre)
        {
            genres[index] = genre;
        }

        public void addGenre(String genre)
        {
            genres.Add(genre);
        }

        public String getGenres()
        {
            //makes the actors display neater

            String genresFinal = null;
            int count = 0;

            foreach (String genre in genres)
            {
                genresFinal += genre;

                if (count < genres.Count - 1)
                {
                    genresFinal += ",";
                }

                count++;
            }

            return genresFinal;
        }

        public Boolean hasGenre(String genre)
        {
            Boolean hasGenre = false;

            foreach (String item in genres)
            {
                if (genre.ToLower().Equals(item.ToLower()))
                {
                    hasGenre = true;
                    break;//for efficiency
                }
            }

            return hasGenre;
        }

        public int genreSize()
        {
            return genres.Count;
        }

        public void clearGenres()
        {
            genres = new List<string>();
        }

        public String getActor(int index)
        {
            return actors[index];
        }

        public String getActors()
        {
            //makes the actors display neater

            String actorsFinal = null;
            int count = 0;

            if (actors != null)//it is possible for a movie entry to have no actors
            {
                foreach (String actor in actors)
                {
                    actorsFinal += actor;

                    if (count < actors.Count - 1)
                    {
                        actorsFinal += ",";
                    }

                    count++;
                }
            }

            return actorsFinal;
        }

        //for testing
        public override string ToString()
        {
            string returns = null;

            returns += title + "\n" + year + "\n" + length + "\n" + certification + "\n" + director + "\n" + rating + '\n';

            foreach (string item in genres)
            {
                returns += item + "|";
            }
            returns += "\n";

            foreach (string item in actors)
            {
                returns += item + "|";
            }

            return returns;
        }
    }
}
