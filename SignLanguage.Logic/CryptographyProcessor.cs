using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SignLanguage.Logic
{
    public class CryptographyProcessor
    {

        public string GenerateHash(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool AreEqual(string plainTextInput, string hashedInput)
        {
            string newHashedPin = GenerateHash(plainTextInput);
            return newHashedPin.Equals(hashedInput);
        }
    }
}
