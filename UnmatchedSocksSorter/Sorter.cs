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

            Console.WriteLine("Completed in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

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

            Console.WriteLine("Completed in " + watch.ElapsedMilliseconds.ToString() + " milliseconds.");

            return matchedSocks;
        }
    }
}
