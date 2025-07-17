using System;
using System.Reflection;

namespace ThreeDent.DevelopmentTools.Extensions
{
    public static class ReflectionExtension
    {
        public static bool IsDefined<T>(this MemberInfo type) where T : Attribute
        {
            return type.IsDefined(typeof(T));
        }

        public static bool IsDefined<T>(this MemberInfo type, bool inherit) where T : Attribute
        {
            return type.IsDefined(typeof(T), inherit);
        }

        public static bool IsAssignableFrom<T>(this Type type)
        {
            return type.IsAssignableFrom(typeof(T));
        }

        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            return otherType.IsAssignableFrom(type);
        }

        public static bool IsAssignableTo<T>(this Type type)
        {
            return type.IsAssignableTo(typeof(T));
        }
    }
}