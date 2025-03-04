using System.Security.Cryptography;

namespace hlzn.util;

public static class CryptoExtensions
{
   const int keySize = 256;
   const int iterations = 100000; // Increased iteration count
   const int saltSize = 16; // 128 bits

   public static string HashedPassword(this string password, out byte[] salt)
   {
      HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512; // Use SHA-512
      salt = new byte[saltSize];
      using (var rng = RandomNumberGenerator.Create())
      {
         rng.GetBytes(salt);
      }

      using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm))
      {
         byte[] hash = pbkdf2.GetBytes(keySize / 8);
         return Convert.ToHexString(hash);
      }
   }

   public static bool HasValidPassword(this string password, string hash, byte[] salt)
   {
      HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512; // Use SHA-512
      using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm))
      {
         byte[] hashBytes = pbkdf2.GetBytes(keySize / 8);
         return CryptographicOperations.FixedTimeEquals(hashBytes, Convert.FromHexString(hash));
      }
   }
}