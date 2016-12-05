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
            string password = adv.GetPassword(Input, 8);

            Assert.AreEqual("1A3099AA", password);
        }

        [TestMethod]
        public void TestCryptoAgainstSample()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.GetPassword("abc", 1);

            Assert.AreEqual("1", password);
        }
    }
}
