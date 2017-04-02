
using System;

namespace WSMobileApp.Common.PasswordGenerator
{
    public class GenrateRandomPassword
    {
        public static string RandomPassword()
        {
            var chars = DateTime.Now.ToString("hhmmss");
            var stringChars = new char[4];

            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }
    }
}
