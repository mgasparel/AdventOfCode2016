using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AdventOfCodeDay5
    {
        public string GetPassword(string input, int iterations)
        {
            Crypto hasher = new Crypto();

            var doorIdChars = new List<char>();
            int hashIndex = 1;
            while (doorIdChars.Count < iterations)
            {
                string hashInput = input + hashIndex++;

                string hexString = hasher.ComputeMD5Hash(hashInput);

                if (hexString[0] == '0' && hexString[1] == '0' && hexString[2] == '0' && hexString[3] == '0' && hexString[4] == '0')
                {
                    doorIdChars.Add(hexString[5]);
                }
            }

            return new string(doorIdChars.ToArray());
        }

        public string GetPassword2(string input, int iterations)
        {
            Crypto hasher = new Crypto();

            var doorIdChars = new Dictionary<int, char>();
            int hashIndex = 1;
            while (doorIdChars.Count < iterations)
            {
                string hashInput = input + hashIndex++;

                string hexString = hasher.ComputeMD5Hash(hashInput);

                if (hexString[0] == '0' && hexString[1] == '0' && hexString[2] == '0' && hexString[3] == '0' && hexString[4] == '0')
                {
                    if (int.TryParse(hexString[5].ToString(), out int position) && position <= 7 && !doorIdChars.ContainsKey(position))
                    {
                        doorIdChars.Add(position, hexString[6]);
                    }
                }
            }

            return new string(doorIdChars.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
        }
    }
}
