using System;
using static System.Console;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericsUI gen = new GenericsUI();
            gen.Start();
            ReadKey();
        }
    }
}
