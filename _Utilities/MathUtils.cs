using System.Collections.Generic;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class MathUtils
    {
        /// <summary>
        /// Takes decimal integer number and splits it into list of digits.
        /// </summary>
        public static List<int> SeparateDigits(int number)
        {
            List<int> leftovers = new();
            while (true)
            {
                int leftover = number % 10;
                leftovers.Add(leftover);
                if (number == leftover) break;
                number = (number - leftover) / 10;
            }
            leftovers.Reverse();
            return leftovers;
        }
    }
}