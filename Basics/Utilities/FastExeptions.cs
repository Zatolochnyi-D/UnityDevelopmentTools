using System;

namespace DenZ.DevelopmentTools.Utilities
{
    public static class FastExeptions
    {
        public static Exception NonExistentEnumValue<T>() where T : Enum => new($"Non-existent value of {typeof(T)} enum was given.");
    }
}
