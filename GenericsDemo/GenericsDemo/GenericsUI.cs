using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GenericsDemo
{
    class GenericsUI

    {
        public void Start() { 
        int size;
        WriteLine("Hello! Please enter size of the stack: ");
            size = int.Parse(ReadLine());

        Stack<string> stack = new Stack<string>(size);

            bool repeat = true;
            while (repeat)
            {

                int choice = PromptForChoice();
                switch (choice)
                {
                    case 1:
                        {
                            WriteLine("Enter item to Push: ");
                            string temp = ReadLine();
                            int result = stack.Push(temp);
                            if (result != -1)
                            {
                                WriteLine("Element Pushed into Stack!");
                            }
                            else
                            {
                                WriteLine("Stack Overflow!");
                            }
                            break;
                        }
                    case 2:
                        {                         
                                string result = stack.Pop();
                                if (result != null)
                                {
                                    WriteLine("Deleted Element: " + result);
                                }
                                else
                                {
                                    WriteLine("Stack Underflow!");
                                }
                            break;
                        }
                    case 3:
                        {
                            string[] Elements = stack.Get();
                            WriteLine("======================================");
                            WriteLine("S  T  A  C  K   C  O  N  T  E  N  T");
                            WriteLine("======================================");
                            foreach (string str in Elements)
                            {
                                WriteLine("\t\t" + str);
                            }
                            break;
                        }
                    case 4:
                        {
                            WriteLine("\nPress any key to exit");
                            repeat = false;
                            break;
                        }
                    default:
                        {
                            WriteLine("Please enter a valid choice!");
                            break;
                        }
                }
            
            }

        }



        public int PromptForChoice() //user input
            {
            int prompt;

                WriteLine("\nPlease enter your choice: " +
                   "\n 1 - Push" +
                   "\n 2 - Pop" +
                   "\n 3 - Print Stack" +
                   "\n 4 - Exit");
            while (!int.TryParse(ReadLine(), out prompt))
            {
                WriteLine("That was invalid. Enter a valid choice.");
            }
            
          
            return prompt;

}
    }
}
