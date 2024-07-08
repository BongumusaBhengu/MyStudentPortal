using System.Security.Cryptography;
using System.Text;

namespace MyStudentPortal.Application.Common
{
    public static class PasswordEncryption
    {
        /// <summary>
        /// The salt
        /// </summary>
        private static readonly byte[] _salt = Encoding.ASCII.GetBytes("YourSaltValue");

        /// <summary>
        /// The iterations
        /// </summary>
        private static readonly int _iterations = 10000;

        /// <summary>
        /// Encrypts the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static byte[] EncryptPassword(string password)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(password, _salt, _iterations);
            return SHA256.HashData(Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var newHashedPassword = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var newHashedPasswordBase64 = Convert.ToBase64String(newHashedPassword);

            return newHashedPasswordBase64 == hashedPassword;
        }
    }
}