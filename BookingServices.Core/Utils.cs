using System.Security.Cryptography;

namespace BookingServices.Core;

public class Utils
{
    private const int SaltSize = 16; // You can adjust the salt size as needed
    private const int Iterations = 10000; // You can adjust the number of iterations as needed

    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Derive a key using PBKDF2
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes for a 256-bit key
            byte[] hashBytes = new byte[SaltSize + 32];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, 32);

            return Convert.ToBase64String(hashBytes);
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extract the salt and hash from the stored password
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Derive a key using PBKDF2 with the stored salt
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
        {
            byte[] hash = pbkdf2.GetBytes(32); // 32 bytes for a 256-bit key

            // Compare the computed hash with the stored hash
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false; // Passwords don't match
                }
            }
        }

        return true; // Passwords match
    }

}
