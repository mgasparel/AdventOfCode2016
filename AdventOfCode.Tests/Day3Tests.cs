using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day3Tests
    {
        public static string Input;

        [TestInitialize]
        public void TestInitialize()
        {
            Input = System.IO.File.ReadAllText("Input\\Day3.txt");
        }

        /*
            The design document gives the side lengths of each 
            triangle it describes, but... 5 10 25? Some of 
            these aren't triangles. You can't help but mark 
            the impossible ones.

            In a valid triangle, the sum of any two sides must 
            be larger than the remaining side. For example, 
            the "triangle" given above is impossible, 
            because 5 + 10 is not larger than 25.

            In your puzzle input, how many of the listed 
            triangles are possible?
        */
        [TestMethod]
        public void Day3Exercise1()
        {
            var adv = new AdventOfCodeDay3();
            var triangles = adv.ParseTrianglePerRow(Input);

            var validTriangleCount = triangles.Count(x => x.IsValid);

            Assert.AreEqual(1032, validTriangleCount);
        }

        /*
            Now that you've helpfully marked up their design 
            documents, it occurs to you that triangles are 
            specified in groups of three vertically. Each set 
            of three numbers in a column specifies a triangle. 
            Rows are unrelated.
        */
        [TestMethod]
        public void Day3Exercise2()
        {
            var adv = new AdventOfCodeDay3();
            var triangles = adv.ParseTriangleTriplets(Input);

            var validTriangleCount = triangles.Count(x => x.IsValid);

            Assert.AreEqual(1838, validTriangleCount);
        }

        [TestMethod]
        public void IfTriangleHasAdjacentSidesShorterThanSelf_TriangleIsNotValid()
        {
            var triangle = new Triangle(new int[]{ 1, 1, 5 });

            Assert.AreEqual(false, triangle.IsValid);
        }

        [TestMethod]
        public void IfTriangleHasAdjacentSidesLongerThanSelf_TriangleIsValid()
        {
            var triangle = new Triangle(new int[] { 1, 1, 1 });

            Assert.AreEqual(true, triangle.IsValid);
        }

        [TestMethod]
        public void IfTriangleHasAdjacentSidesEqualToSelf_TriangleIsNotValid()
        {
            var triangle = new Triangle(new int[] { 1, 1, 2 });

            Assert.AreEqual(false, triangle.IsValid);
        }
    }
}
