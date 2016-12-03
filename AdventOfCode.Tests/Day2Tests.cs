using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day2Tests
    {
        private static string Input;

        [TestInitialize]
        public void TestInitialize()
        {
            Input = System.IO.File.ReadAllText("Input\\Day2.txt");
        }

        /*
            The document goes on to explain that each button to be 
            pressed can be found by starting on the previous button 
            and moving to adjacent buttons on the keypad: U moves 
            up, D moves down, L moves left, and R moves right. Each 
            line of instructions corresponds to one button, starting 
            at the previous button (or, for the first line, the "5" 
            button); press whatever button you're on at the end of 
            each line. If a move doesn't lead to a button, ignore it.

            You can't hold it much longer, so you decide to figure 
            out the code as you walk to the bathroom. 
            
            You picture a keypad like this:

            1 2 3
            4 5 6
            7 8 9
        */
        [TestMethod]
        public void Day2Exercise1()
        {
            byte?[][] keyPad = {
                new byte?[]{ 0x7, 0x8, 0x9 },
                new byte?[]{ 0x4, 0x5, 0x6 },
                new byte?[]{ 0x1, 0x2, 0x3 } };

            var adv = new AdventOfCodeDay2();
            var keyCode = adv.GetKeyCode(Input, keyPad, new Coordinate { X = 1, Y = 1 });

            var code = BitConverter.ToString(keyCode.ToArray());

            Assert.AreEqual("05-06-09-08-03", code);
        }

        /*
            You finally arrive at the bathroom (it's a several 
            minute walk from the lobby so visitors can behold 
            the many fancy conference rooms and water coolers on 
            this floor) and go to punch in the code. Much to your 
            bladder's dismay, the keypad is not at all like you 
            imagined it. Instead, you are confronted with the 
            result of hundreds of man-hours of 
            bathroom-keypad-design meetings:

                1
              2 3 4
            5 6 7 8 9
              A B C
                D
        */
        [TestMethod]
        public void Day2Exercise2()
        {
            byte?[][] keyPad = {
                new byte?[]{ null, null, 0xD, null, null },
                new byte?[]{ null, 0xA , 0xB, 0xC , null },
                new byte?[]{ 0x5 , 0x6 , 0x7, 0x8 , 0x9  },
                new byte?[]{ null, 0x2 , 0x3, 0x4 , null },
                new byte?[]{ null, null, 0x1, null, null }
            };

            var adv = new AdventOfCodeDay2();
            var keyCode = adv.GetKeyCode(Input, keyPad, new Coordinate { X = 2, Y = 0 });

            var code = BitConverter.ToString(keyCode.ToArray());

            Assert.AreEqual("08-0B-08-0B-01", code);
        }
    }
}
