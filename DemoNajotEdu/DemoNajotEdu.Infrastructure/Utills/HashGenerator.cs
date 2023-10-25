using System.Security.Cryptography;
using System.Text;

namespace DemoNajotEdu.Infrastructure.Utills
{
    public class HashGenerator
    {
        public static string Generator(string password)
        {
            const int keySize = 64;
            const int iterations = 320000;

            HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA512;


            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                 new byte[0],
                iterations,
                hashAlgorithmName,
                keySize
                );
            return Convert.ToHexString(hash);
        }
    }
}
