using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class AdventOfCodeDay2
    {
        List<byte> keyCode = new List<byte>();

        public List<byte> GetKeyCode(string input, byte?[][] keyPad, Coordinate startPosition)
        {
            var inputLines = Common.GetLines(input);

            var currentPosition = startPosition;

            foreach (var line in inputLines)
            {
                var steps = line.ToCharArray();

                foreach (var step in steps)
                {
                    Direction direction = Common.Directions[step];

                    Common.Move(currentPosition, direction, 1, keyPad);
                }

                byte currentDigit = GetDigitAtPosition(keyPad, currentPosition);
                keyCode.Add(currentDigit);
            }

            return keyCode;
        }

        private byte GetDigitAtPosition(byte?[][] keyPad, Coordinate currentPosition)
        {
            return (byte)keyPad[currentPosition.X][currentPosition.Y];
        }
    }
}
