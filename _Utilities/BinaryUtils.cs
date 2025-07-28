using System;
using UnityEngine;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class BinaryUtils
    {
        /// <summary>
        /// Returns integer value that represents binary number of 0's and one 1 on provided position.
        /// </summary>
        public static int GetSingleBitBinary(int position)
        {
            return 1 << position;
        }

        /// <summary>
        /// Reparates integer number into array of 0's and 1's in little endian format.
        /// </summary>
        public static int[] SeparateBinary(int binaryNumber, int length)
        {
            if (GetSingleBitBinary(length) <= binaryNumber)
                throw new ArgumentException("Provided number is higher than length of word.");

            int[] result = new int[length];
            for (int i = length - 1; i >= 0; i--)
            {
                int singleBit = GetSingleBitBinary(i);
                if (binaryNumber - singleBit < 0)
                {
                    result[^(i + 1)] = 0;
                }
                else
                {
                    binaryNumber -= singleBit;
                    result[^(i + 1)] = 1;
                }
            }
            return result;
        }
    }
}
