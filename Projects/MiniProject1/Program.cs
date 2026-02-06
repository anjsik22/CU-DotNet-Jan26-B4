using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    internal class Guessing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Hangman!");
            Console.WriteLine();
            string[] words = { "APPLE", "SUNLIGHT", "FLAME", "PLANET","HOUSE" };
            Random rnd= new Random();
            string word=words[rnd.Next(words.Length)];
            int life = 6;
            int count = word.Length;
            char[] guessedWord=new char[count];
            for(int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
            List<char> usedLetters= new List<char>();
            while (life != 0)
            {
                Console.WriteLine("Word:"+ string.Join(" ",guessedWord));
                Console.WriteLine("Lives left: "+life);
                Console.WriteLine("Guessed: " +(usedLetters.Count == 0 ? "" : string.Join(", ", usedLetters)));
                Console.Write("Guess a letter: ");
                string input= Console.ReadLine().ToUpper();
                if(input.Length!=1 || !input.All(char.IsLetter))
                {
                    Console.WriteLine("Please Enter a valid letter.\n");
                    continue;
                }
                char guess = input[0];
                if (usedLetters.Contains(guess))
                {
                    Console.WriteLine($"You already guessed '{guess}'. Try again.");
                    Console.WriteLine();
                    continue;
                }
                usedLetters.Add(guess);

                bool found = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess)
                    {
                        guessedWord[i] = guess;
                        found = true;
                    }
                }
                if (found)
                {
                    Console.WriteLine("Good catch!");
                }
                else
                {
                    life--;
                    Console.WriteLine("Nope! That's not in the word.");
                }
                Console.WriteLine();
                if (!guessedWord.Contains('_'))
                {
                    Console.WriteLine("Word: " + string.Join("", guessedWord));
                    break;
                }
            }

        }
    }
}

