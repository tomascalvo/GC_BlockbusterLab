using System;
using System.Collections.Generic;

namespace GC_BlockbusterLab
{
    class VHS : Movie
    {
        int CurrentTime = 0;
        public VHS(string title, Movie.Genre category, int runTime, List<string> scenes)
        {
            this.Title = title;
            this.Category = category;
            this.RunTime = runTime;
            this.Scenes = scenes;
            this.CurrentTime = 0;
        }
        public VHS() { }
        public override void Play()
        {
            CurrentTime++;
        }
        public void Rewind()
        {
            CurrentTime = 0;
        }
    }
}
