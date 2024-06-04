using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace RBACSample.Helper;

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

    public static bool VerifyPassword(SecureString enteredPassword, string storedHash)
    {
        //var saltLength = (int)Math.Ceiling((double)SaltSize * 4 / 3);
        var salt = storedHash.Substring(storedHash.Length - Base64StringSize);
        var combinedBytes = Encoding.UTF8.GetBytes(ConvertToUnsecureString(enteredPassword) + salt);

        var hashBytes = SHA256.HashData(combinedBytes);

        string enteredHash = Convert.ToBase64String(hashBytes) + salt;

        return enteredHash.Equals(storedHash);
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

        IntPtr unmanagedString = IntPtr.Zero;
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