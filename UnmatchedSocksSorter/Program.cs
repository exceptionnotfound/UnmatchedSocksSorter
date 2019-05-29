using System;
using System.Collections.Generic;
using UnmatchedSocksSorter.Data;

namespace UnmatchedSocksSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var socks = GenerateSocks();

            char menuInput = 'a';

            Sorter sorter = new Sorter();

            while (menuInput != 'Q')
            {
                ShowMenu();

                menuInput = Console.ReadLine().ToUpper()[0];

                switch(menuInput)
                {
                    case '1':
                        socks = sorter.NaiveSort(socks);
                        CheckIfSorted(socks);
                        break;

                    case '2':
                        socks = sorter.NaivePartialSort(socks);
                        CheckIfSorted(socks);
                        break;


                    case 'L':
                        ListSocks(socks);
                        break;

                    case 'N':
                        socks = GenerateSocks();
                        break;

                    case 'Q':
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Here's your options.");
            Console.WriteLine("1 - Naive Sort");
            Console.WriteLine("2 - Naive Partial Sort");
            Console.WriteLine("L - List All Socks");
            Console.WriteLine("N - Generate New Sock Pile");
            Console.WriteLine("Q - Quit");
        }

        private static void CheckIfSorted(List<Sock> socks)
        {
            bool areSorted = SockGenerator.AreMatched(socks);
            if(!areSorted)
            {
                Console.WriteLine("WARNING - The socks are not perfectly sorted!!!");
            }
        }

        private static void ListSocks(List<Sock> socks)
        {
            int count = 0;
            while (count < socks.Count)
            {
                var sock = (Sock)socks[count];
                Console.WriteLine("Sock Color:" + sock.Color + ", Length: " + sock.Length + ", Owner: " + sock.Owner);
                count++;
            }
        }

        private static List<Sock> GenerateSocks()
        {
            int numberSocks = 0;
            string numberSocksInput = "";
            while (!int.TryParse(numberSocksInput, out numberSocks))
            {
                Console.WriteLine("How many socks should be generated? (0-1M)");
                numberSocksInput = Console.ReadLine();
            }

            return SockGenerator.GenerateSocks(numberSocks);
        }

    }
}
