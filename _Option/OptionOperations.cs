using System;

namespace ThreeDent.DevelopmentTools.Options
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


        public static bool IsSome<T>(this Option<T> option)
        {
            if (option is Some<T>)
                return true;
            else
                return false;
        }

        public static bool IsNone<T>(this Option<T> option)
        {
            return !IsSome(option);
        }


        public static T ReadValue<T>(this Option<T> option)
        {
            if (option is Some<T> x)
                return x.Value;
            else
                throw new ArgumentException("Cannot read value of None.");
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

        public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate)
        {
            if (option is Some<T> x && predicate(x.Value))
                return option;
            else
                return None<T>();
        }

        public static int Count<T>(this Option<T> option)
        {
            if (option is Some<T>)
                return 1;
            else
                return 0;
        }
    }
}