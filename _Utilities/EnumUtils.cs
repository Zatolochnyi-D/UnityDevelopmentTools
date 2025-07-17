using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreeDent.DevelopmentTools.Utilities
{
    public static class EnumUtils
    {
        /// <summary>
        /// Extracts content of specified enum as list of values of this enum type.
        /// </summary>
        /// <typeparam name="T">Target enum.</typeparam>
        public static IEnumerable<T> GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}