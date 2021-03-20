using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Api.Core.Security
{
    // https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2
    // https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1

    public class Pbkdf2PasswordHasher : IPasswordHasher
    {
        private const int _saltSize = 128 / 8;
        private const int _keySize = 256 / 8;

        private readonly PasswordHashOptions _options;

        public Pbkdf2PasswordHasher(IOptions<PasswordHashOptions> options)
        {
            _options = options.Value;
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[_saltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public string HashPassword(string password)
        {
            byte[] salt = GenerateSalt();
            byte[] hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, _options.Iterations, _keySize);

            string key = Convert.ToBase64String(hash);
            string saltBase64 = Convert.ToBase64String(salt);

            return $"{_options.Iterations}${saltBase64}${key}";
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            string[] parts = hashedPassword.Split('$');

            if (parts.Length != 3)
            {
                throw new FormatException("Invalid hash format. Expected '{iterations}${salt}${key}");
            }

            int iterations = Convert.ToInt32(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] key = Convert.FromBase64String(parts[2]);

            byte[] hash = KeyDerivation.Pbkdf2(providedPassword, salt, KeyDerivationPrf.HMACSHA256, iterations, _keySize);

            return hash.SequenceEqual(key);
        }
    }
}
