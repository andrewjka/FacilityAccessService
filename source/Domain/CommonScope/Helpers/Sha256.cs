using System;
using System.Security.Cryptography;

namespace Domain.CommonScope.Helpers;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return Convert.ToHexString(hash);
        }
    }
}