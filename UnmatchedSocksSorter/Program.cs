using System;
using UnmatchedSocksSorter.Data;

namespace UnmatchedSocksSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSocks = 0;
            string input = "";
            while (!int.TryParse(input, out numberSocks))
            {
                Console.WriteLine("How many socks should be generated? (0-1M)");
                input = Console.ReadLine();
            }
            
            var socks = SockGenerator.GenerateSocks(numberSocks);

            int count = 0;
            while (count < numberSocks)
            {
                var sock = (Sock)socks[count];
                Console.WriteLine("Sock Color:" + sock.Color + ", Length: " + sock.Length + ", Owner: " + sock.Owner);
                count++;
            }

            Console.ReadLine();
        }
    }
}
