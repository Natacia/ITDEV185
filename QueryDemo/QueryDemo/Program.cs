using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace QueryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Words word = new Words();
            WriteLine("Here is a list of words. This program will identify the different parts of speech.");
            WriteLine(word.SelectList());
            Thread.Sleep(1000);

            WriteLine("\nThe nouns are: ");
            WriteLine(word.QueryNoun());

            Thread.Sleep(1000);
            WriteLine("\nThe verbs are: ");
            WriteLine(word.QueryVerb());

            Thread.Sleep(1000);
            WriteLine("\nThe adjectives are: ");
            WriteLine(word.QueryAdjective());

            WriteLine("\nPress any key to exit...");
            ReadKey();
        }
    }
}
