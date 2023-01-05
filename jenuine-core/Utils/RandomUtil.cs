using System;
using System.Text;

namespace Its.Jenuiue.Core.Utils
{
    public class RandomUtil
    {
        private static readonly Random random = new Random();

        public static int RandomNumber(int min, int max)
        {  
            return random.Next(min, max);  
        }

        public static string RandomString(int size, bool lowerCase = false)  
        {  
            var builder = new StringBuilder(size);

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';  
            const int lettersOffset = 26; // A...Z or a..z: length=26  
        
            for (var i = 0; i < size; i++)
            {
                var @char = (char) random.Next(offset, offset + lettersOffset);
                builder.Append(@char);  
            }  

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
