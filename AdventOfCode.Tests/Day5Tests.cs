using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day5Tests
    {
        public static string Input;

        [TestInitialize]
        public void TestInitialize()
        {
            Input = System.IO.File.ReadAllText("Input\\Day5.txt");
        }

        [TestMethod]
        public void Day5Exercise1()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.DecryptAppendStrategy(Input, 8);

            Assert.AreEqual("1A3099AA", password);
        }


        [TestMethod]
        public void Day5Exercise2()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.DecryptAddAtPositionStrategy(Input, 8);

            Assert.AreEqual("694190CD", password);
        }


        [TestMethod]
        public void TestAppendStrategyAgainstSample()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.DecryptAppendStrategy("abc", 1);

            Assert.AreEqual("1", password);
        }

        [TestMethod]
        public void TestAddAtPositionStrategyAgainstSample2()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.DecryptAddAtPositionStrategy("abc", 8);

            Assert.AreEqual("05ACE8E3", password);
        }
    }
}
