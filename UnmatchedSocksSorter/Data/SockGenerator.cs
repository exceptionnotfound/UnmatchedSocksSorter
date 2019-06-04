using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnmatchedSocksSorter.Data
{
    public static class SockGenerator
    {
        public static List<Sock> GenerateSocks(int max)
        {
            int count = 0;

            List<Sock> socks = new List<Sock>(max);

            //Generate a certain number of pairs of socks
            while(count < max)
            {
                var pair = GeneratePair();
                socks.Add(pair[0]);
                socks.Add(pair[1]);
                count = count + 2;
            }

            return socks.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private static List<Sock> GeneratePair()
        {
            List<Sock> pair = new List<Sock>();

            Random random = new Random();

            var sockOwner = random.Next(0, 3);
            var sockColor = random.Next(0, 5);
            var sockLength = random.Next(0, 3);

            var sock = new Sock()
            {
                Owner = (SockOwner)sockOwner,
                Color = (SockColor)sockColor,
                Length = (SockLength)sockLength
            };

            pair.Add(sock);
            
            pair.Add(sock);

            return pair;
        }

        public static bool AreMatched(List<Sock> socks)
        {
            bool areMatched = true;
            for(int i = 0; i < socks.Count; i = i + 2)
            {
                var firstSock = socks[i];
                var secondSock = socks[i + 1];

                areMatched = areMatched 
                             && firstSock.Color == secondSock.Color 
                             && firstSock.Owner == secondSock.Owner 
                             && firstSock.Length == secondSock.Length;

                if (areMatched == false) break;
            }

            return areMatched;
        }
    }
}
