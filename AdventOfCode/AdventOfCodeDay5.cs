using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class AdventOfCodeDay5
    {
        private string DecryptWith(string input, int iterations, Action<Dictionary<int, char>, string> implementation)
        {
            CryptoHasher hasher = new CryptoHasher();

            var doorIdChars = new Dictionary<int, char>();
            int hashIndex = 1;
            while (doorIdChars.Count < iterations)
            {
                string hashInput = input + hashIndex++;

                string hexString = hasher.ComputeMD5Hash(hashInput);

                if (hexString[0] == '0' && 
                    hexString[1] == '0' && 
                    hexString[2] == '0' && 
                    hexString[3] == '0' && 
                    hexString[4] == '0')
                {
                    implementation(doorIdChars, hexString);
                }
            }

            return new string(doorIdChars.OrderBy(x => x.Key).Select(x => x.Value).ToArray());
        }

        public string DecryptAddAtPositionStrategy(string input, int iterations)
        {
            return DecryptWith(input, iterations, (chars, hash) =>
            {
                if (int.TryParse(hash[5].ToString(), out int position) == false) return;

                if (position <= 7 && !chars.ContainsKey(position))
                {
                    chars.Add(position, hash[6]);
                }
            });
        }

        public string DecryptAppendStrategy(string input, int iterations)
        {
            return DecryptWith(input, iterations, (chars, hash) =>
            {
                int nextIndex = chars.Keys.Count + 1;
                chars.Add(nextIndex, hash[5]);
            });
        }
    }
}
