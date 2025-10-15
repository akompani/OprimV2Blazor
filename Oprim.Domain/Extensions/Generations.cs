using System.Security.Cryptography;

namespace Oprim.Domain.Extensions;

public static class Generations
{
    public static string GenerateOtp()
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        var value = BitConverter.ToInt32(bytes, 0) & int.MaxValue; 
        return (value % 100000).ToString("D5"); 
    }
}