using System;
using System.Collections.Generic;
namespace GC_BlockbusterLab
{
    public abstract class Movie
    {
        public string Title { get; set; }
        public Genre Category { get; set; }
        public int RunTime { get; set; }
        public List<string> Scenes { get; set; }

        public virtual void PrintInfo()
        {
            Console.Write(Title + Category + RunTime + Scenes);
        }

        public void PrintScenes()
        {

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
