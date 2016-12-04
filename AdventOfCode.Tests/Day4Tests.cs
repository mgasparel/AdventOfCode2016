using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static AdventOfCode.AdventOfCodeDay4;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode.Tests
{

    [TestClass]
    public class Day4Tests
    {
        public static string Input;

        [TestInitialize]
        public void TestInitialize()
        {
            Input = System.IO.File.ReadAllText("Input\\Day4.txt");
        }

        /*
            Each room consists of an encrypted name (lowercase letters 
            separated by dashes) followed by a dash, a sector ID, and 
            a checksum in square brackets.

            A room is real (not a decoy) if the checksum is the five 
            most common letters in the encrypted name, in order, with 
            ties broken by alphabetization. For example:

            aaaaa-bbb-z-y-x-123[abxyz] is a real room because the 
            most common letters are a (5), b (3), and then a tie 
            between x, y, and z, which are listed alphabetically.
        */
        [TestMethod]
        public void Day4Exercise1()
        {
            var adv = new AdventOfCodeDay4();
            List<Room> rooms = adv.ParseRooms(Input);

            var validSectorSum = rooms.Where(x => x.IsRealRoom).Sum(x => x.Sector);

            Assert.AreEqual(158835, validSectorSum);
        }

        /*
            To decrypt a room name, rotate each letter forward through 
            the alphabet a number of times equal to the room's sector 
            ID. A becomes B, B becomes C, Z becomes A, and so on. 
            Dashes become spaces.

            For example, the real name for qzmt-zixmtkozy-ivhz-343 
            is very encrypted name.

            What is the sector ID of the room where North Pole 
            objects are stored?
         */
        [TestMethod]
        public void Day4Exercise2()
        {
            var adv = new AdventOfCodeDay4();
            List<Room> rooms = adv.ParseRooms(Input);

            foreach(var room in rooms)
            {
                Debug.Print(room.DecryptedName);
            }

            var northPole = rooms
                .Where(x => x.DecryptedName.Contains("north"))
                .First();

            Assert.AreEqual(993, northPole.Sector);
        }

        [TestMethod]
        public void TestShiftCypher()
        {
            var room = new Room
            {
                EncryptedName = "nvrgfezqvu-avccpsvre-crsfirkfip",
                Sector = 217,
                Checksum = "abdfs"
            };

            Assert.AreEqual("weaponized jellybean laboratory", room.DecryptedName);
        }
    }
}
