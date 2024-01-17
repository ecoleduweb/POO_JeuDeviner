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