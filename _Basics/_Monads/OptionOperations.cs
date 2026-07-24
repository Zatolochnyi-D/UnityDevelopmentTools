using System;

namespace DenZ.DevelopmentTools.Options
{
    public static class Option
    {
        public static Option<T> Some<T>(T value)
        {
            return new Option<T>(value);
        }

        public static Option<T> None<T>()
        {
            return new Option<T>();
        }

        public static Option<T> FromPossibleNull<T>(T value) where T : class
        {
            if (value == null)
                return None<T>();
            else
                return Some(value);
        }


        public static T ReadOrDefault<T>(this Option<T> option, T defaultValue)
        {
            if (option.IsSome)
                return option.ValueUnsafe;
            else
                return defaultValue;
        }

        public static T ReadOrThrow<T>(this Option<T> option, Exception exception)
        {
            if (option.IsSome)
                return option.ValueUnsafe;
            else
                throw exception;
        }


        public static void Apply<T>(this Option<T> option, Action<T> actionFunction)
        {
            if (option.IsSome)
                actionFunction(option.ValueUnsafe);
        }

        public static Option<TOut> Map<TIn, TOut>(this Option<TIn> option, Func<TIn, TOut> mappingFunction)
        {
            if (option.IsSome)
                return Some(mappingFunction(option.ValueUnsafe));
            else
                return None<TOut>();
        }

        public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, Func<TIn, Option<TOut>> bindingFunction)
        {
            if (option.IsSome)
                return bindingFunction(option.ValueUnsafe);
            else
                return None<TOut>();
        }

        public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate)
        {
            if (option.IsSome && predicate(option.ValueUnsafe))
                return option;
            else
                return None<T>();
        }

        public static int Count<T>(this Option<T> option)
        {
            if (option.IsSome)
                return 1;
            else
                return 0;
        }
    }
}