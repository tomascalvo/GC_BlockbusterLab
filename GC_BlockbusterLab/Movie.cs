using System;
using System.Collections.Generic;
namespace GC_BlockbusterLab
{
    //CLASS DECLARATION
    public abstract class Movie
    {
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }

        public Movie(string title, Genre category, int runTime, List<string> scenes)
        {
            Title = title;
            Category = category;
            RunTime = runTime;
            Scenes = scenes;
        }
        //CONSTRUCTOR
        public Movie(string title, Genre category, int runTime)
        {
            Scenes = new List<string>();
            Scenes.Add("Default Movie.Scenes text.");
        }
        //DEFAULT CONSTRUCTOR
        public Movie() { }
        //CLASS METHODS (AN ABSTRACT CLASS MUST HAVE AT LEAST ONE ABSTRACT METHOD)
        public virtual void PrintInfo()
        {
            Console.Write($"{Title}\n{Category}\n{RunTime} minutes\n");
        }

        public void PrintScenes()
        {
            int i = 1;
            foreach(string scene in Scenes)
            {
                Console.WriteLine($"{i}. {scene}");
                i++;
            }
        }

        public abstract void Play();

        public enum Genre
        {
            Drama,
            Comedy,
            Horror,
            Romance,
            Action
        }

    }
}
