using System;
using System.Collections.Generic;
namespace GC_BlockbusterLab
{
    //CLASS DECLARATION
    class Blockbuster
    {
        ////FIELD
        private List<Movie> movies;
        //PROPERTY
        public List<Movie> Movies { get; set; }
        //CLASS CONSTRUCTOR
        public Blockbuster()
        {
            //SET THE INITIAL VALUE FOR FIELD movies
            movies = new List<Movie>()
            {
                new DVD("The Green Hornet", Movie.Genre.Action, 120, new List<string>() {"Our hero grows up with an emotionally distant father who dies under dubious circumstances", "Our hero meets Kato, a domestic servant with extraordinary mastery of engineering and martial arts.", "Our hero's news analyst shelters the Green Hornet from the police dragnet."}),
                new DVD("The Great Gatsby", Movie.Genre.Drama, 121, new List<string>() {"Gatsby survives the sinking of the Titanic and ascends the ranks of organized crime in the New World.", "Gatsby meets a gangster with cufflinks carved from human molars.", "Daisy accidentally runs over her husband's lover with the Rolls."}),
                new DVD("The Green Mile", Movie.Genre.Drama, 122, new List<string>() {"Our hero meets a fellow inmate who can bring vermin back from the dead.", "Our hero walks the Green Kilometer in preparation for the Green Mile.", "Our hero's faith in the system is shaken when he discovers that the mile is not in fact green, it's just that all the guards and inmates are required to wear green goggles at all times."}),
                new VHS("The Great Escape", Movie.Genre.Drama, 123, new List<string>() {"Our hero is captured by Nazis and detained at a prisoner of war camp.", "Our hero meets a ragtag group of Allied prisoners and hatches an escape plan.", "The motorcycle stunt." }),
                new VHS("The Green Lantern", Movie.Genre.Action, 124, new List<string>() { "An air force test pilot is exposed to a hitherto unseen type of radiation that augments his physical capabilities.","Against his better judgement and the Green Lantern code of conduct, our hero meets and romances his flight instructor (Kelly McGillis).", "The Green Lantern learns to resolve his differences with others not by violent confrontation, but through more oblique acts of relational aggression."}),
                new VHS("The Green Inferno", Movie.Genre.Horror, 125, new List<string>(){ "A study abroad trip to Bolivia goes awry when a single-engine aircraft full of grad students nosedives into the Amazon rainforest.", "The cannibalism part.", "Upon her return to civilization, our hero realizes that it is we who are the true savages, falsifying her account and indemnifying the cannibals."}),
                //new DVD("Great Expectations", Movie.Genre.Comedy, 126),
                //new DVD("Borat", Movie.Genre.Romance, 127)
            };
        }
        public static void PrintMovies()
        {
            for (int i = 0; i < Movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}.");
                Movies[i].PrintInfo();
            }
        }

        public static void CheckOut()
        {
            PrintMovies(Movies);
            Console.WriteLine("Which movie would you like to check out? Enter index.");
            string response = Console.ReadLine();
            int index = int.Parse(response) - 1;
            Console.WriteLine($"You have selected {Movies[index].Title}.");
            Movies[index].PrintInfo();
        }
    }
}