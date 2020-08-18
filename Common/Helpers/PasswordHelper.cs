using System;
using System.Collections.Generic;

namespace Common.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateUniqueKey(int length)
        {
            if (length < 16)
            {
                length = 16;
            }
            var key = $"{(DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds * 100).ToString("F0")}";
            key = key.PadLeft(16, '0');

            List<char> chars = new List<char>(length);
            for (int i = 0; i < key.Length; i++)
            {
                chars.Insert(i, key[i]);
            }

            string randomChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = chars.Count; i < length; i++)
            {
                chars.Insert(i, randomChars[random.Next(0, randomChars.Length)]);
            }

            return new string(chars.ToArray());
        }
        public static string GenerateRandomPassword(int length, bool requireDigit, bool requireNonAlphanumeric)
        {
            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789",    // all 
                "0123456789",                   // digits
                "!@$?_-"                        // non-alphanumeric
            };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>(length);

            string rcs = randomChars[0];
            for (int i = chars.Count; i < length; i++)
            {
                chars.Insert(i, rcs[rand.Next(0, rcs.Length)]);
            }

            if (requireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);
            }

            if (requireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
