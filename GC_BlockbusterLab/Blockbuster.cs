using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace GC_BlockbusterLab
{
    //CLASS DECLARATION
    public class Blockbuster
    {
        //FIELD
        public List<Movie> inventory = new List<Movie>() { };
        //PROPERTY
        public List<Movie> Inventory { get; set; }
        //CLASS CONSTRUCTOR
        public Blockbuster()
        {
            //SET THE INITIAL VALUE FOR FIELD movies
            inventory = new List<Movie>()
            {
                #region properties
                new DVD("The Green Hornet", Movie.Genre.Action, 120, new List<string>() {"Our hero grows up with an emotionally distant father who dies under dubious circumstances.", "Our hero meets Kato, a domestic servant with an impressive command of engineering and martial arts.", "Our hero's news analyst shelters the Green Hornet from the police dragnet."}),
                new DVD("The Great Gatsby", Movie.Genre.Drama, 121, new List<string>() {"Gatsby survives the sinking of the Titanic and ascends the ranks of organized crime in the New World.", "Gatsby meets a gangster with cufflinks carved from human molars.", "Daisy accidentally runs over her husband's lover with the Rolls."}),
                new DVD("The Green Mile", Movie.Genre.Drama, 122, new List<string>() {"Our hero meets a fellow inmate who can bring vermin back from the dead.", "Our hero walks the Green Kilometer in preparation for the Green Mile.", "Our hero's faith in the system is shaken when he discovers that the mile is not in fact green, it's just that all the guards and inmates are required to wear green goggles at all times."}),
                new VHS("The Great Escape", Movie.Genre.Drama, 123, new List<string>() {"Our hero is captured by Nazis and detained at a prisoner of war camp.", "Our hero meets a ragtag group of Allied prisoners and hatches an escape plan.", "The motorcycle stunt." }),
                new VHS("The Green Lantern", Movie.Genre.Action, 124, new List<string>() { "An air force test pilot is exposed to a hitherto unseen type of radiation that augments his physical capabilities.","Against his better judgement and the Green Lantern code of conduct, our hero meets and romances his flight instructor (Kelly McGillis).", "The Green Lantern learns to resolve his differences with others not by violent confrontation, but through more oblique acts of relational aggression."}),
                new VHS("The Green Inferno", Movie.Genre.Horror, 125, new List<string>(){ "A study abroad trip to Bolivia goes awry when a single-engine aircraft full of grad students nosedives into the Amazon rainforest.", "The cannibalism part.", "Upon her return to civilization, our hero realizes that it is we who are the true savages, falsifying her account of the events that transpired and indemnifying the cannibals."}),
                //new DVD("Great Expectations", Movie.Genre.Comedy, 126),
                //new DVD("Borat", Movie.Genre.Romance, 127)
                #endregion
            };
        }
        //CLASS METHODS
        public void ExampleMethod()
        {
            Console.WriteLine("This is an example method from class Blockbuster.");
        }

        public void PrintMovies()
        {
            Console.WriteLine("\nBehold our immense inventory: ");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i].Title}");
            }
            Console.WriteLine("");
        }

        public void CheckOut()
        {
            bool loop = true;
            while (loop)
            {
                PrintMovies();

                Console.WriteLine("Which movie would you like to check out?");
                string regEx = "\\b[1-" + $"{inventory.Count}" + "]\\b";
                if (Blockbuster.ValidationLoop("a movie index", regEx, out int inventoryIndex))
                Console.WriteLine($"\nYou have selected {inventory[inventoryIndex - 1].Title}.\n");
                try
                {
                    inventory[inventoryIndex - 1].PrintInfo();
                }
                catch (IndexOutOfRangeException e1)
                {
                    inventoryIndex = 1;
                    Console.WriteLine(e1.Message);
                }
                catch (Exception e2)
                {
                    inventoryIndex = 1;
                    Console.WriteLine(e2.Message);
                }
                if (AskYesOrNo($"\nWould you like to watch {inventory[inventoryIndex - 1].Title}?\n"))
                {
                    inventory[inventoryIndex - 1].Play();
                }
                else
                {
                    Console.WriteLine("We're almost out of that movie, anyway.");
                }
                if(AskYesOrNo("Would you like to check out another movie?"))
                {
                    loop = true;
                } else
                {
                    loop = false;
                }
            }
            Console.WriteLine("Thanks for visiting this relic of a bygone era. Take some CBD on your way out.");
        }

        public static bool AskYesOrNo(string question)
        {
            bool loop = true;
            int counter = 0;
            while (loop && counter < 3)
            {
                Console.WriteLine(question);
                string response = Console.ReadLine().ToLower();
                Regex yesTrue = new Regex(@"\b((y(es)?)|\b(t(rue)?))\b");
                Regex noFalse = new Regex(@"\b((n(o)?)|(f(alse)?))\b");
                try
                {
                    if (yesTrue.IsMatch(response))
                    {
                        loop = false;
                        return true;
                    }
                    if (noFalse.IsMatch(response))
                    {
                        loop = false;
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                        counter++;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Response attempts exhausted.");
                }
            }
            return false;
        }

        public static bool ValidateWRegEx(string valueDescription, string regExString, string input)
        {
            Regex regEx = new Regex($@"{regExString}");

            if (regEx.IsMatch(input))
            {
                //Console.WriteLine($"{input} is a {valueDescription}.");
                return true;
            }
            else
            {
                //Console.WriteLine($"{input} is not a {valueDescription}.");
                return false;
            }
        }

        public static bool ValidationLoop(string valueModifier, string valueDescription, string regEx, out int result)
        {
            bool valid = false;
            string input = null;
            int counter = 0;
            while (!valid && counter <= 2)
            {
                Console.WriteLine($"Enter {valueModifier} {valueDescription}: ");
                input = Console.ReadLine().Trim();
                if (ValidateWRegEx(valueDescription, regEx, input))
                {
                    result = int.Parse(input);
                    valid = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                    counter++;
                }
            }
            result = -1;
            return false;
        }

        public static bool ValidationLoop(string valueDescription, string regEx, out int result)
        {
            bool valid = false;
            string input = null;
            int counter = 0;
            while (!valid && counter <= 2)
            {
                Console.WriteLine($"Enter {valueDescription}: ");
                input = Console.ReadLine().Trim();
                if (ValidateWRegEx(valueDescription, regEx, input))
                {
                    result = int.Parse(input);
                    valid = true;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Invalid entry. {2 - counter} attempts remaining.");
                    counter++;
                }
            }
            result = -1;
            return false;
        }
    }
}