using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AdventOfCodeDay4
    {
        public AdventOfCodeDay4()
        {
        }

        public List<Room> ParseRooms(string input)
        {
            var rooms = new List<Room>();

            var inputLines = Common.GetLines(input);

            foreach (var line in inputLines)
            {
                var matches = Regex.Matches(line, @"((?:[a-zA-Z]+(?:\-)*)+)(?:\-)(\d{3})\[([a-zA-Z]+)\]");

                var room = new Room
                {
                    EncryptedName = matches[0].Groups[1].Value,
                    Sector = int.Parse(matches[0].Groups[2].Value),
                    Checksum = matches[0].Groups[3].Value
                };

                rooms.Add(room);
            }

            return rooms;
        }

        public class Room
        {
            public string EncryptedName { get; set; }
            public int Sector { get; set; }
            public string Checksum { get; set; }

            public Room()
            {
            }

            public bool IsRealRoom
            {
                get
                {
                    return ChecksumCalculator.Calculate(EncryptedName) == Checksum;
                }
            }

            public string DecryptedName
            {
                get
                {
                    return ShiftCypherDecryptor.Decrypt(EncryptedName, Sector);
                }
            }
        }

        public static class ChecksumCalculator
        {
            public static string Calculate(string input)
            {
                var checksum = input
                    .Replace("-", "")
                    .ToCharArray()
                    .GroupBy(x => x)
                    .Select(x => new { Char = x.Key, Count = x.Count() })
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.Char)
                    .Take(5)
                    .Select(x => x.Char)
                    .ToList();

                return string.Join("", checksum);
            }
        }

        public static class ShiftCypherDecryptor
        {
            private static Int16 NumLettersInAlphabet = 26;

            public static string Decrypt(string input, int shiftFactor)
            {
                string decrypted = "";

                foreach (char letter in input.ToCharArray())
                {
                    if (letter == '-')
                    {
                        decrypted += ' ';
                    }
                    else
                    {
                        int shiftedAndOffset = (letter + shiftFactor - 'a');

                        decrypted += (char)('a' + (shiftedAndOffset % NumLettersInAlphabet));
                    }
                }

                return decrypted;
            }
        }
    }
}
