using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnmatchedSocksSorter.Data;

namespace UnmatchedSocksSorter
{
    public class Sorter
    {
        public List<Sock> NaiveSort(List<Sock> unmatchedSocks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Idea here is that we take the first sock n, find it's match, 
            //and switch the position of the match with the position of the sock n + 1.
            List<Sock> matchedSocks = new List<Sock>();
            while(unmatchedSocks.Any())
            {
                //Get the sock at the top of the pile
                Sock currentSock = unmatchedSocks[0];
                unmatchedSocks.Remove(currentSock);
                Sock matchingSock;

                //Iterate through the unmatched socks to find the next one that matches.
                foreach(var tempSock in unmatchedSocks)
                {
                    if(tempSock.Color == currentSock.Color
                       && tempSock.Length == currentSock.Length
                       && tempSock.Owner == currentSock.Owner)
                    {
                        matchingSock = tempSock;
                        unmatchedSocks.Remove(tempSock);
                        matchedSocks.Add(currentSock);
                        matchedSocks.Add(tempSock);
                        break;
                    }
                }
            }

            watch.Stop();

            Console.WriteLine("Completed Naive Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }

        public List<Sock> NaivePartialSort(List<Sock> unmatchedSocks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //Idea here is that we take the first sock n, find it's match, 
            //and switch the position of the match with the position of the sock n + 1.
            List<Sock> matchedSocks = new List<Sock>();
            while (unmatchedSocks.Any())
            {
                //Get the sock at the top of the pile
                Sock currentSock = unmatchedSocks[0];
                unmatchedSocks.Remove(currentSock);
                Sock matchingSock;

                //Iterate through the unmatched socks to find the next one that matches, ignoring color and length.
                foreach (var tempSock in unmatchedSocks)
                {
                    if (tempSock.Owner == currentSock.Owner)
                    {
                        matchingSock = tempSock;
                        unmatchedSocks.Remove(tempSock);
                        matchedSocks.Add(currentSock);
                        matchedSocks.Add(tempSock);
                        break;
                    }
                }
            }

            watch.Stop();

            Console.WriteLine("Completed Naive Partial Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }

        /// <summary>
        /// Let's take the socks and sort them into smaller piles, then sort those piles into smaller piles, and so on.
        /// </summary>
        /// <param name="socks"></param>
        /// <returns></returns>
        public List<Sock> OneLevelPileSort(List<Sock> socks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var colorSortedSocks = SplitByColor(socks);

            List<Sock> matchedSocks = new List<Sock>();
            matchedSocks.AddRange(NaiveSort(colorSortedSocks[0]));
            matchedSocks.AddRange(NaiveSort(colorSortedSocks[1]));
            matchedSocks.AddRange(NaiveSort(colorSortedSocks[2]));
            matchedSocks.AddRange(NaiveSort(colorSortedSocks[3]));
            matchedSocks.AddRange(NaiveSort(colorSortedSocks[4]));

            watch.Stop();
            Console.WriteLine("Completed One-Level Pile Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }

        public List<Sock> ThreeLevelPileSort(List<Sock> socks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            var colorSortedSocks = SplitByColor(socks);

            List<Sock> matchedSocks = new List<Sock>();
            foreach (var colorSortedPile in colorSortedSocks)
            {
                var lengthSortedPiles = SplitByLength(colorSortedPile);
                foreach(var lengthSortedPile in lengthSortedPiles)
                {
                    var ownerSortedPiles = SplitByOwner(lengthSortedPile);
                    foreach(var ownerSortedPile in ownerSortedPiles)
                    {
                        foreach(var sock in ownerSortedPile)
                        {
                            matchedSocks.Add(sock);
                        }
                    }
                }
            }

            watch.Stop();
            Console.WriteLine("Completed Three-Level Pile Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }

        public List<List<Sock>> SplitByColor(List<Sock> socks)
        {
            List<List<Sock>> colorSortedSocks = new List<List<Sock>>();

            //Initialize the lists
            colorSortedSocks.Add(new List<Sock>());//0 Red
            colorSortedSocks.Add(new List<Sock>());//1 Blue
            colorSortedSocks.Add(new List<Sock>());//2 Green
            colorSortedSocks.Add(new List<Sock>());//3 Black
            colorSortedSocks.Add(new List<Sock>());//4 White

            foreach (var sock in socks)
            {
                switch (sock.Color)
                {
                    case SockColor.Red:
                        colorSortedSocks[0].Add(sock);
                        break;

                    case SockColor.Blue:
                        colorSortedSocks[1].Add(sock);
                        break;

                    case SockColor.Green:
                        colorSortedSocks[2].Add(sock);
                        break;

                    case SockColor.Black:
                        colorSortedSocks[3].Add(sock);
                        break;

                    case SockColor.White:
                        colorSortedSocks[4].Add(sock);
                        break;
                }
            }

            return colorSortedSocks;
        }

        public List<List<Sock>> SplitByLength(List<Sock> socks)
        {
            List<List<Sock>> colorSortedSocks = new List<List<Sock>>();

            //Initialize the lists
            colorSortedSocks.Add(new List<Sock>());//0 NoShow
            colorSortedSocks.Add(new List<Sock>());//1 Ankle
            colorSortedSocks.Add(new List<Sock>());//2 Crew

            foreach (var sock in socks)
            {
                switch (sock.Length)
                {
                    case SockLength.NoShow:
                        colorSortedSocks[0].Add(sock);
                        break;

                    case SockLength.Ankle:
                        colorSortedSocks[1].Add(sock);
                        break;

                    case SockLength.Crew:
                        colorSortedSocks[2].Add(sock);
                        break;
                }
            }

            return colorSortedSocks;
        }

        public List<List<Sock>> SplitByOwner(List<Sock> socks)
        {
            List<List<Sock>> colorSortedSocks = new List<List<Sock>>();

            //Initialize the lists
            colorSortedSocks.Add(new List<Sock>());//0 AdultMan
            colorSortedSocks.Add(new List<Sock>());//1 AdultWoman
            colorSortedSocks.Add(new List<Sock>());//2 Child

            foreach (var sock in socks)
            {
                switch (sock.Owner)
                {
                    case SockOwner.AdultMan:
                        colorSortedSocks[0].Add(sock);
                        break;

                    case SockOwner.AdultWoman:
                        colorSortedSocks[1].Add(sock);
                        break;

                    case SockOwner.Child:
                        colorSortedSocks[2].Add(sock);
                        break;
                }
            }

            return colorSortedSocks;
        }

        public List<Sock> SpecialSort(List<Sock> socks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            watch.Stop();
            Console.WriteLine("Completed Special Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");
            Console.WriteLine("Nobody cares about matching socks anyway.");
            return socks;
        }

        public List<Sock> DictionarySort(List<Sock> unmatchedSocks)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Sock> matchedSocks = new List<Sock>();

            var waitingForMatch = new Dictionary<(SockOwner, SockColor, SockLength), Sock>();
            while (unmatchedSocks.Any())
            {
                int index = unmatchedSocks.Count - 1;
                var sock = unmatchedSocks[index];
                unmatchedSocks.RemoveAt(index);

                var key = (sock.Owner, sock.Color, sock.Length);
                if (waitingForMatch.TryGetValue(key, out var matchingSock))
                {
                    matchedSocks.Add(sock);
                    matchedSocks.Add(matchingSock);
                    waitingForMatch.Remove(key);
                }
                else
                {
                    waitingForMatch.Add(key, sock);
                }
            }

            watch.Stop();
            Console.WriteLine("Completed Dictionary Sort in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }
    }
}
