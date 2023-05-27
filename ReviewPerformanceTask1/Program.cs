using System.Security.Cryptography;

internal class Program
{
    public static void Main(string[] args)
    {
        string? GeneratePasswordHashUsingSalt(string passwordText, byte[]? salt)

        {
            if (string.IsNullOrEmpty(passwordText) || salt == null || salt.Length < 16 )
            {
                return null;
            }
            var iterate = 10000;

            using var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);

            var hash = pbkdf2.GetBytes(20);

            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        var result = GeneratePasswordHashUsingSalt("hello",
            new byte[] { 1, 2, 3, 2, 3, 4, 3, 2, 3 });

        Console.WriteLine(result ?? "No result");
        Console.ReadKey();
    }
}
