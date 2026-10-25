using System;
using System.Runtime.CompilerServices;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class FastExeptions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Exception NonExistentEnumValue<T>() where T : Enum => new($"Non-existent value of {typeof(T)} enum was given.");
    }
}