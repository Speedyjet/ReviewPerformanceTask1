using System.Security.Cryptography;
public class MyClass
{
    public static void Main()
    {
        MyClass c = new MyClass();
        c.GeneratePasswordHashUsingSalt("hello", new byte[] { 1, 2, 3, 2, 3, 4, 3, 2, 3, 4, 3, 2, 3, 4, 4, 3, 2, 3, 3, 4, 4, 3, 2, 2, 3, 3 });
    }
    public string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)

    {
        if (string.IsNullOrEmpty(passwordText) || salt == null)
        {
            return null;
        }
        var iterate = 10000;

        using var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);

        byte[] hash = pbkdf2.GetBytes(20);

        byte[] hashBytes = new byte[36];

        Array.Copy(salt, 0, hashBytes, 0, 16);

        Array.Copy(hash, 0, hashBytes, 16, 20);

        var passwordHash = Convert.ToBase64String(hashBytes);

        return passwordHash;



    }
}