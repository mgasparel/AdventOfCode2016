using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Tests
{
    /*
        The Document indicates that you should start at the given 
        coordinates (where you just landed) and face North. Then, 
        follow the provided sequence: either turn left (L) or right (R) 
        90 degrees, then walk forward the given number of blocks, 
        ending at a new intersection.

        There's no time to follow such ridiculous instructions on foot, 
        though, so you take a moment and work out the destination. 
        Given that you can only walk on the street grid of the city, 
        how far is the shortest path to the destination?
    */
    [TestClass]
    public class Day1Tests
    {
        public static string Input;

        [TestInitialize]
        public void TestInitialize()
        {
            Input = System.IO.File.ReadAllText("Input\\Day1.txt");
        }

        [TestMethod]
        public void Day1Exercise1()
        {
            var adv = new AdventOfCodeDay1();
            List<Coordinate> path = adv.RunSequence(Input);

            Coordinate destination = path.Last();
            Coordinate crossedPath = adv.GetFirstLocationVisitedTwice();

            int distance = Math.Abs(destination.X) + Math.Abs(destination.Y);
            Assert.AreEqual(241, distance);

            Console.WriteLine($"We're {Math.Abs(destination.X) + Math.Abs(destination.Y)} blocks away!");
            Console.WriteLine($"We crossed our own path the first time at {crossedPath.X}, {crossedPath.Y}, which was {Math.Abs(crossedPath.X) + Math.Abs(crossedPath.Y)} blocks away!");
        }

        /*
            Then, you notice the instructions continue on the back of 
            the Recruiting Document. Easter Bunny HQ is actually at the 
            first location you visit twice.

            For example, if your instructions are R8, R4, R4, R8, the 
            first location you visit twice is 4 blocks away, due East.

            How many blocks away is the first location you visit twice?
        */
        [TestMethod]
        public void Day1Exercise2()
        {
            var adv = new AdventOfCodeDay1();
            List<Coordinate> path = adv.RunSequence(Input);

            Coordinate destination = path.Last();
            Coordinate crossedPath = adv.GetFirstLocationVisitedTwice();

            int distance = Math.Abs(crossedPath.X) + Math.Abs(crossedPath.Y);
            Assert.AreEqual(116, distance);

            Console.WriteLine($"We're {Math.Abs(destination.X) + Math.Abs(destination.Y)} blocks away!");
            Console.WriteLine($"We crossed our own path the first time at {crossedPath.X}, {crossedPath.Y}, which was {Math.Abs(crossedPath.X) + Math.Abs(crossedPath.Y)} blocks away!");
        }
    }
}
