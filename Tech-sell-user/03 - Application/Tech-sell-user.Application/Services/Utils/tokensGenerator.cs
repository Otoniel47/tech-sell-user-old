using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tech_sell_user.Application.Services.Utils
{
    public class tokensGenerator
    {
        public static string GenerateRandomToken()
        {
            byte[] salt = new byte[128];
            using (var rngCsp = new RNGCryptoServiceProvider())
                rngCsp.GetNonZeroBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public static (string saltInBase64, string passwordEncripted) GenerateHashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
                rngCsp.GetNonZeroBytes(salt);

            var saltInBase64 = Convert.ToBase64String(salt);

            password = System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)));

            return (saltInBase64, password);
        }

        public static string GenerateRandomMd5()
        {
            byte[] randomBytes = new byte[128];
            using (var rngCsp = new RNGCryptoServiceProvider())
                rngCsp.GetNonZeroBytes(randomBytes);

            var md5 = MD5.Create();

            var data = md5.ComputeHash(randomBytes);

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}