using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WebServiceInteractor
{
    public static class WebService
    {
        public static SKGeliosWebService.RustourService rustourService = new SKGeliosWebService.RustourService();

        static String WebServiceKey = "2c1ef94a-07b5-4f98-9236-0432c5ba0b36";

        // Create service key
        public static String CreateServiceKey(DateTime date)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                String source = String.Concat(date.ToString("dd.MM.yyyy"), WebServiceKey);
                String hash = GetMd5Hash(md5Hash, source);

                return hash;
            }
        }

        private static String GetMd5Hash(MD5 md5Hash, String input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, String input, String hash)
        {
            // Hash the input.
            String hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;

            return false;
        }
    }
}
