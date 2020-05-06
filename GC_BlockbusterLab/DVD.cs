using System;
using System.Collections.Generic;
namespace GC_BlockbusterLab
{
    //CLASS DECLARATION
    class DVD : Movie
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
            Console.WriteLine("\nWhat scene would you like to watch?\n");
            int i = 1;
            foreach(string scene in Scenes)
            {
                Console.WriteLine($"Scene {i}:\n{scene}\n");
                i++;
            }
            string regEx = "\\b[1-" + $"{Scenes.Count}" + "]\\b";
            //Console.WriteLine($"Scene number regular expression is \"{regEx}\".");
            if (Blockbuster.ValidationLoop("which scene you would like to watch", regEx, out int sceneNumber))
            {
                Console.WriteLine($"Scene {sceneNumber}:\n {Scenes[sceneNumber-1]}");
            }
            if (Blockbuster.AskYesOrNo($"\nWould you like to watch another scene from {Title}?"))
            {
                Play();
            }
        }
    }
}