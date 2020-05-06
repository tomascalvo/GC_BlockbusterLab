using System;
using System.Collections.Generic;
namespace GC_BlockbusterLab
{
    public class DVD : Movie
    {
        private int CurrentTime = 0;
        public DVD(string title, Movie.Genre category, int runTime, List<string> scenes)
        {
            this.Title = title;
            this.Category = category;
            this.RunTime = runTime;
            this.Scenes = scenes;
            this.CurrentTime = 0;
        }
        public DVD() { }

        public override void Play()
        {
            Console.WriteLine("What scene would you like to watch?");
            Console.WriteLine(Scenes.ToString());
            string selection = Console.ReadLine().ToLower().Trim();
            if (Scenes.Contains(selection))
            {
                foreach (string scene in Scenes)
                {
                    if (selection == scene)
                    {
                        Console.WriteLine(scene);
                    }
                }

            }
        }
    }
}