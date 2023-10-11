using System.Security.Cryptography;
using System.Text;

namespace ModsenBookLibrary.Application.Helpers;
internal static class HashHelper
{
    public static string GetPasswordHash(string password)
    {
        var byteString = Encoding.UTF8.GetBytes(password);

        using var shaManager = SHA256.Create();
        var byteHash = shaManager.ComputeHash(byteString);

        var hash = BitConverter.ToString(byteHash).Replace("-", string.Empty);

        return hash;
    }
}
