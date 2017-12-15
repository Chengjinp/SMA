using System;
using System.Security.Cryptography;
using System.Text;

namespace Repository.BLL
{
    public class CryptoController
    {
        public static string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        public static string GenerateSaltedHash(string plainText, string salt)
        {

            byte[] bPlainText = Encoding.ASCII.GetBytes(plainText);
            byte[] bSalt = Encoding.ASCII.GetBytes(salt);

            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[bPlainText.Length + bSalt.Length];

            for (int i = 0; i < bPlainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = bPlainText[i];
            }
            for (int i = 0; i < bSalt.Length; i++)
            {
                plainTextWithSaltBytes[bPlainText.Length + i] = bSalt[i];
            }

            var bResult = algorithm.ComputeHash(plainTextWithSaltBytes);

            return Encoding.ASCII.GetString(bResult);

        }
    }
}
