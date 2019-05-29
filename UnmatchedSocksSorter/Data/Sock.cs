using System;
using System.Collections.Generic;
using System.Text;

namespace UnmatchedSocksSorter.Data
{
    public class Sock
    {
        public SockColor Color { get; set; }
        public SockOwner Owner { get; set; }
        public SockLength Length { get; set; }
    }

    public enum SockColor
    {
        Red,
        Blue,
        Green,
        Black,
        White
    }

    public enum SockLength
    {
        NoShow, //Disappears beneath the shoe line
        Ankle, //Shows over shoe line, covers ankle
        Crew //Comes partway up the calf, but no higher than halfway
    }

    public enum SockOwner
    {
        AdultMan,
        AdultWoman,
        Child
    }
}
