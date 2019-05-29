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

            while (menuInput != 'Q')
            {
                ShowMenu();

                menuInput = Console.ReadLine()[0];

                switch(menuInput)
                {
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
            Console.WriteLine("Here's your options.");
            Console.WriteLine("L - List All Socks");
            Console.WriteLine("N - Generate New Sock Pile");
            Console.WriteLine("Q - Quit");
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
