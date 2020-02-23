using System;
using System.Collections.Generic;
using static System.Console;

namespace IteratorDemo
{
    class Program
    {
        public static IEnumerable<string> GetList()
        {

            List<string> starWarsFranchise = new List<string>
            {
                "The Rise of the Skywalker",
                "Rogue One",
                "Solo",
                "The Force Awakens",
                "Return of the Jedi",
                "The Empire Strikes Back",
                "A New Hope",
                "Revenge of the Sith",
                "Attack of the Clones",
                "The Phantom Menace"
            };

            foreach (var movie in starWarsFranchise)
            {
                yield return movie;  
            }
        }
        public static void Main(string[] args)
        {
           

            string message = "Do you know any Star Wars movie?" +
            "\nHere's a list: \n";

            for (int i = 0; i < message.Length; i++)
            {
                Write(message[i]);
                System.Threading.Thread.Sleep(80);
            }

            IEnumerable<string> starWarsMovies = GetList();
            int counter = 1; 
            foreach (var movie in starWarsMovies)  
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine(counter + "................" + movie, ForegroundColor);
                ResetColor();
                WriteLine(",_(|=|       .-=o=-.     --~~~=:>[XXXXXXXXX]>");
                System.Threading.Thread.Sleep(100);
                counter++;
            }
            System.Threading.Thread.Sleep(100);
            WriteLine("\nThat's all for now. Hit any key to exit!");
            ReadKey();
        }
    }
}

