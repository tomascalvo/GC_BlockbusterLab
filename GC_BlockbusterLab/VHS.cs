using System;
using System.Collections.Generic;
using System.Threading;
namespace GC_BlockbusterLab
{
    //CLASS DECLARATION
    class VHS : Movie
    {
        int CurrentTime = 0;
        public VHS(string title, Genre category, int runTime, List<string> scenes)
        {
            this.Title = title;
            this.Category = category;
            this.RunTime = runTime;
            this.Scenes = scenes;
            this.CurrentTime = 0;
        }
        public VHS() { }

        //METHODS
        public override void Play()
        {
            for(int i = 0; i < Scenes.Count; i++)
            {
                Console.WriteLine(Scenes[CurrentTime]);
                Thread.Sleep(4000);
                CurrentTime++;
                if (i < Scenes.Count -1 && Blockbuster.AskYesOrNo("Keep watching?"))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (Blockbuster.AskYesOrNo($"Would you like to watch {Title} again?"))
            {
                if(RunTime == 0)
                {
                    Play();
                }
                else if(RunTime != 0)
                {
                    if (Blockbuster.AskYesOrNo($"Would you like to rewind {Title} first?"))
                    {
                        CurrentTime = 0;
                    }
                    else
                    {
                        if(RunTime < Scenes.Count)
                        {
                            Play();
                        }
                        if(RunTime >= Scenes.Count + 1)
                        {
                            for (int i = 0; i <=2; i++)
                            {
                                Console.WriteLine("CREDITS ROLL");
                                Thread.Sleep(3000);
                            }
                            Console.WriteLine("FBI WARNING");
                            Thread.Sleep(2000);
                            Console.Write("*ps");
                            for (int i = 0; i < 1000; i++)
                            {
                                Console.Write("h");
                                Thread.Sleep(25);
                            }
                            Console.Write("h*\n");
                            Thread.Sleep(2000);
                        } 
                    }
                }
            }
        }

        public void Rewind()
        {
            CurrentTime = 0;
        }
    }
}
