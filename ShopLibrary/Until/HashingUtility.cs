using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ShopLibrary
{
    public static class HashingUtility
    {
        public static string HashingPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            //sha1.k
            byte[] encriptedBytes = sha1.ComputeHash(passwordBytes);
            return Convert.ToBase64String(encriptedBytes);
        }

        public static bool HashComparison(string password, string hash)
        {
            return (HashingPassword(password) == hash);
        }
    }
}
