using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace RBACSample.Shared.Helpers;

public class PasswordHasher
{
    private const int Base64StringSize = 24;
    private const int SaltSize = 16;

    public static string HashPassword(SecureString password)
    {
        if (password.Length == 0)
        {
            throw new ArgumentException("Password cannot be empty.");
        }

        var salt = GenerateSalt();

        var combinedBytes = Encoding.UTF8.GetBytes(ConvertToUnsecureString(password) + salt);

        var hashBytes = SHA256.HashData(combinedBytes);

        string hashedPassword = Convert.ToBase64String(hashBytes) + salt;

        return hashedPassword;
    }

    public static string HashPassword(string password)
    {
        if (password.Length == 0)
        {
            throw new ArgumentException("Password cannot be empty.");
        }

        var salt = GenerateSalt();

        var combinedBytes = Encoding.UTF8.GetBytes(password + salt);

        var hashBytes = SHA256.HashData(combinedBytes);

        string hashedPassword = Convert.ToBase64String(hashBytes) + salt;

        return hashedPassword;
    }

    public static bool VerifyPassword(SecureString enteredPassword, string storedHash)
    {
        var salt = storedHash[^Base64StringSize..];
        var combinedBytes = Encoding.UTF8.GetBytes(ConvertToUnsecureString(enteredPassword) + salt);

        var hashBytes = SHA256.HashData(combinedBytes);

        string enteredHash = Convert.ToBase64String(hashBytes) + salt;

        return enteredHash.Equals(storedHash);
    }

    public static bool SSEqual(SecureString a, SecureString b)
    {
        if (a.Length != b.Length)
            return false;

        var ptrA = Marshal.SecureStringToBSTR(a);
        var ptrB = Marshal.SecureStringToBSTR(b);

        try
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (Marshal.ReadByte(ptrA, i) != Marshal.ReadByte(ptrB, i))
                    return false;
            }
        }
        finally
        {
            Marshal.ZeroFreeBSTR(ptrA);
            Marshal.ZeroFreeBSTR(ptrB);
        }

        return true;
    }

    private static string GenerateSalt(int saltSize = SaltSize)
    {
        var randomNumberGenerator = RandomNumberGenerator.Create();

        var saltBytes = new byte[saltSize];
        randomNumberGenerator.GetBytes(saltBytes);

        return Convert.ToBase64String(saltBytes);
    }

    private static string ConvertToUnsecureString(SecureString secureString)
    {
        ArgumentNullException.ThrowIfNull(secureString);

        nint unmanagedString = nint.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }
}