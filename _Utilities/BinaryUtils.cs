using System;
using System.Runtime.CompilerServices;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class BinaryUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetSingleBitBinary(int position)
        {
            return 1 << position;
        }

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
