using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juegodezam
{
    class Program
    {
        static void Main(string[] args)
        {
            string salida = "";

            do
            {
                Random random = new Random((int)DateTime.Now.Ticks);

                string[] wordBank = { "naranja", "pera", "manzana", "platano", "melon", "sandia", "mango", "ciruela", "cham" };

                string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
                string wordToGuessUppercase = wordToGuess.ToUpper();

                StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
                for (int i = 0; i < wordToGuess.Length; i++)
                    displayToPlayer.Append("_");

                List<char> correctGuesses = new List<char>();
                List<char> incorrectGuesses = new List<char>();

                int lives = 8;
                bool won = false;
                int lettersRevealed = 0;

                string input;
                char guess;

                while (!won && lives > 0)
                {
                    Console.Write(" adivina la palabra: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {
                        //Console.Clear();
                        Console.WriteLine("No vuelvas a ingresar la letra correcta '{0}', escoge otra", guess);

                        continue;

                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        //Console.Clear();
                        Console.WriteLine("Letra ya ingresada '{0}', Ya no la pongas !", guess);

                        continue;
                    }

                    if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }

                        if (lettersRevealed == wordToGuess.Length)
                            won = true;
                        // Console.Clear();
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("No , No esta  '{0}' ", guess);
                        lives--;
                        //Console.Clear();
                    }

                    Console.WriteLine(displayToPlayer.ToString());
                }

                if (won)
                    Console.WriteLine("GANASTE!");
                else
                    Console.WriteLine("LASTIMA! PALABRA CORRECTA '{0}'", wordToGuess);

                Console.Write("QUIERES SEGUIR JUGANDO. SI/NO  ");
                salida = Console.ReadLine();
                Console.ReadLine();
            }
            while (salida == "NO" || salida == "si");
            //System.Environment.Exit(-1);

            //Console.WriteLine("Enter para salir");
        }
    }
}
