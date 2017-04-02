using System;
using System.Globalization;

namespace WSMobileApp.Common.PasswordGenerator
{
    public class OneTimePasswordGenerator
    {
        /// <summary>
        /// Generates the one time password.
        /// </summary>
        /// <returns></returns>
        public static string GenerateOneTimePassword()
        {
            const string numbers = "1234567890";

            const string characters = numbers;

            const int length = 4;

            var oneTimePassword = string.Empty;

            for (var i = 0; i < length; i++)
            {
                string character;
                do
                {
                    var index = new Random().Next(0, characters.Length);

                    character = characters.ToCharArray()[index].ToString(CultureInfo.InvariantCulture);
                } while (oneTimePassword.IndexOf(character, StringComparison.Ordinal) != -1);

                oneTimePassword += character;
            }

            return oneTimePassword;
        }
    }
}
