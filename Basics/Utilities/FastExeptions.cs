using System;
using UnityEngine;

namespace DenZ.DevelopmentTools
{
    public static class FastExeptions
    {
        public static Exception NonExistentEnumValue<T>() where T : Enum
        {
            return new Exception($"Non-existent value of {typeof(T)} enum was given.");
        }
    }
}
