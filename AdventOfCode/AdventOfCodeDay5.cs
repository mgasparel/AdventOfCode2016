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

            string doorId = "";
            int hashIndex = 1;
            while (doorId.Length < iterations)
            {
                string hashInput = input + hashIndex++;

                string hexString = hasher.ComputeMD5Hash(hashInput);

                if (hexString[0] == '0' && hexString[1] == '0' && hexString[2] == '0' && hexString[3] == '0' && hexString[4] == '0')
                    doorId += hexString[5];
            }

            return doorId;
        }
    }
}
