using System;

namespace ThreeDent.DevelopmentTools.Option
{
    public static class Option
    {
        public static Option<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }

        public static Option<T> None<T>()
        {
            return new None<T>();
        }

        public static Option<T> FromPossibleNull<T>(T value)
        {
            if (value == null)
                return new None<T>();
            else
                return new Some<T>(value);
        }


        public static T DefaultWith<T>(this Option<T> option, T defaultValue)
        {
            if (option is Some<T> x)
                return x.Value;
            else
                return defaultValue;
        }


        public static void Iterate<T>(this Option<T> option, Action<T> actionFunction)
        {
            if (option is Some<T> x)
                actionFunction(x.Value);
        }

        public static Option<TOutput> Map<TInput, TOutput>(this Option<TInput> option, Func<TInput, TOutput> mappingFunction)
        {
            if (option is Some<TInput> x)
                return Some(mappingFunction(x.Value));
            else
                return None<TOutput>();
        }
    }
}