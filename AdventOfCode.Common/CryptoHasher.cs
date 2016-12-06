using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class CryptoHasher
    {
        public MD5 Hasher { get; set; }

        public CryptoHasher()
        {
            Hasher = MD5.Create();
        }

        public string ComputeMD5Hash(string input)
        {
            byte[] hash = Hasher.ComputeHash(Encoding.ASCII.GetBytes(input));

            return ByteArrayToHexString(hash);
        }

        private string ByteArrayToHexString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
