using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace RWFM.Helpers
{
    public class Authentication
    {
        public static SHA256 hasher = SHA256.Create();
        private static string HashString(string input)
        {
            StringBuilder Sb = new StringBuilder();
            
            Encoding enc = Encoding.UTF8;
            Byte[] result = hasher.ComputeHash(enc.GetBytes(input));

            foreach (Byte b in result)
            {
                Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString(); ;
        }

        public static bool CheckPassword(string hash, string password, string salt)
        {
            string calculatedHash = GetSaltedHash(password, salt);
            if (hash == calculatedHash)
            {
                return true;
            }
            return false;
        }

        public static string GetStringHash(string input)
        {
            return GetSaltedHash(input, "");
        }

        public static string GetSaltedHash(string input, string salt)
        {
            string hash = input;
            for (int i = 0; i < 15000; i++)
            {
                hash = hash + salt;
                hash = HashString(hash);
            }
            return hash;
        }
    }
}
