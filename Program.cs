using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Add_Function
{
    class Program
    {
        const int ComputerFindNumberMode = 1;
        const int HumanFindNumberMode = 2;
        static void Main(string[] args)
        {
            do
            {
                Play(SelectMode());
            } while (PlayAgain());
        }

        private static void Play(int mode)
        {
            Console.Clear();
            bool notFound = true;
            int numberOfAttempts = 1;
            decimal lowerLimit = 1;
            decimal upperLimit = 20;
            if (mode == ComputerFindNumberMode)
            {
                int number = 10;
                Console.WriteLine("Pensez à un nombre entre 1 et 20... Appuie sur une touche quand tu es prêt");
                Console.ReadKey();
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Est-ce que le nombre chois vaut {number}? \n" +
                        "Si oui, appuyez sur (o) \n" +
                        "Si plus haut appuyez sur (h) \n" +
                        "Si plus bas appuyez sur (b)");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.O:
                            notFound = false;
                            Console.Clear();
                            Console.WriteLine($"Le nombre était {number} \nJ'ai trouvé en {numberOfAttempts} essai{(numberOfAttempts > 1 ? "s" : "")}");
                            break;
                        case ConsoleKey.H:
                            lowerLimit = number;
                            number = (int)Math.Ceiling(lowerLimit + (upperLimit - lowerLimit) / 2);
                            break;
                        case ConsoleKey.B:
                            upperLimit = number;
                            number = (int)Math.Floor(lowerLimit + (upperLimit - lowerLimit) / 2);
                            break;
                        default:
                            Console.WriteLine("Mauvaise touche, retour au menu principal");
                            Console.ReadKey();
                            notFound = false;
                            break;
                    }
                    numberOfAttempts++;
                }
                while (notFound);
            }
            else
            {
                var random = new Random();
                int number = random.Next(1, 20);
                Console.WriteLine("J'ai pensé à un nombre entre un et vingt. Appuie sur une touche quand tu es prêt...");
                Console.ReadKey();
                do
                {
                    Console.Write($"Entre un nombre : ");
                    if (int.TryParse(Console.ReadLine(), out int userNumber))
                    {
                        Console.Clear();
                        if (userNumber > 20 || userNumber < 1)
                        {
                            Console.WriteLine("Ce n'est pas un nombre entre 1 et 20.... essaie encore.");
                        }
                        else if (userNumber > number)
                        {
                            Console.WriteLine("Plus bas.");

                        }
                        else if (userNumber < number)
                        {
                            Console.WriteLine("Plus haut.");

                        }
                        else
                        {
                            Console.WriteLine($"Le nombre était {number} \nVous avez trouvé en {numberOfAttempts} essai{(numberOfAttempts > 1 ? "s" : "")}");
                            notFound = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ce n'est pas un nombre entre 1 et 20.... essaie encore.");
                    }
                    numberOfAttempts++;
                }
                while (notFound);
            }
        }

        static bool PlayAgain()
        {
            Console.Clear();
            Console.Write("On refait une partie (oui/non) : ");
            return "oui" == Console.ReadLine();
        }

        static int SelectMode()
        {
            Console.Clear();
            Console.Write("Quel mode voulez-vous utiliser? \n" +
                "(1) L'ordinateur trouve le nombre \n" +
                "(2) Tu trouves le nombre \n");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    return ComputerFindNumberMode;
                case ConsoleKey.D2:
                    return HumanFindNumberMode;
                default:
                    return SelectMode();
            }
        }
    }
}