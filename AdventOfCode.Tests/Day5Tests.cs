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

        /*
            The eight-character password for the door is generated 
            one character at a time by finding the MD5 hash of some 
            Door ID (your puzzle input) and an increasing integer 
            index (starting with 0).

            A hash indicates the next character in the password if 
            its hexadecimal representation starts with five zeroes. 
            If it does, the sixth character in the hash is the next 
            character of the password.
        */
        [TestMethod]
        public void Day5Exercise1()
        {
            var adv = new AdventOfCodeDay5();
            string password = adv.DecryptAppendStrategy(Input, 8);

            Assert.AreEqual("1A3099AA", password);
        }

        /*
            Instead of simply filling in the password from left to 
            right, the hash now also indicates the position within 
            the password to fill. You still look for hashes that 
            begin with five zeroes; however, now, the sixth character 
            represents the position (0-7), and the seventh character 
            is the character to put in that position.

            A hash result of 000001f means that f is the second 
            character in the password. Use only the first result 
            for each position, and ignore invalid positions.
        */
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
