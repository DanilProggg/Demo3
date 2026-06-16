using System.Security.Cryptography;
using System.Text;

namespace ClientApp;

static class PasswordHelper
{
    public static string HashPassword(string password, string salt = "Salt2026")
    {
        using SHA256 sha = SHA256.Create();
        byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
        return BitConverter.ToString(bytes).Replace("-", "");
    }
}
