using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        //Recieve and store guesses
        static int AskForGuess()
        {
            var target = new Random().Next(1, 101);
            var guess = 0;
            var count = 0;

            Console.WriteLine("In 5 tries, guess the number I am thinking of...Please pick a number between 1 and 100");
            while (guess != target && count < 5)
            {
                int.TryParse(Console.ReadLine(), out guess);
                NoRepeats(guess);

                if (guess > target)
                {
                    Console.WriteLine("Too High");
                }
                else if (guess < target)
                {
                    Console.WriteLine("Too Low");
                }
                else
                {
                    Console.WriteLine("Ayyyyyyyy, you got it!");
                }
                count++;                //counts guesses made
                pastGuess.Add(guess);   //stores guesses in list
            }
            return guess;
        }

        //Cannot guess an int twice
        static bool NoRepeats(int guess)
        {
            var wasAlreadyGuess = false;
            foreach (var answer in pastGuess)
            {
                if (answer == guess)
                {
                    wasAlreadyGuess = true;
                }
            }
            if (wasAlreadyGuess)
            {
                Console.WriteLine("You already guessed that, fool");
            }
            return wasAlreadyGuess;
        }

        //list of guesses
        static List<int> pastGuess = new List<int>();

        //display list of guesses
        static void PrintList()
        {
            Console.WriteLine("You have guessed: ");
            pastGuess.ForEach(Console.WriteLine);
        }

        //main digs
        static void Main(string[] args)
        {
            var guess = AskForGuess();

            PrintList();
        }


    }
}

