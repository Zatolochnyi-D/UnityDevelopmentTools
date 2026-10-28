using System;

namespace DenZ.DevelopmentTools.Monads
{
    public static class Option
    {
        #region Create
        public static Option<T> Some<T>(T value) => new(value);

        public static Option<T> None<T>() => new();

        public static Option<T> FromPossibleNull<T>(T value) where T : class => value != null ? Some(value) : None<T>();
        #endregion


        #region Read
        public static T ReadOrDefaultTo<T>(this Option<T> option, T defaultValue) => option.IsSome ? option.ValueUnsafe : defaultValue;

        public static T ReadOrThrow<T>(this Option<T> option, Exception exception) => option.IsSome ? option.ValueUnsafe : throw exception;

        public static T ReadOrThrow<T>(this Option<T> option, Func<Exception> exceptionFactory) => option.IsSome ? option.ValueUnsafe : throw exceptionFactory();

        public static T ReadOrNew<T>(this Option<T> option) where T : new() => option.IsSome ? option.ValueUnsafe : new();
        #endregion


        #region Transform/Update
        public static Option<T> Evaluate<T>(this Option<T> option, Action<T> applicationFunction)
        {
            if (option.IsSome)
                applicationFunction(option.ValueUnsafe);
            return option;
        }

        public static Option<T> OrElse<T>(this Option<T> option, Action applicationFunction)
        {
            if (option.IsNone)
                applicationFunction();
            return option;
        }

        public static Option<TOut> Map<TIn, TOut>(this Option<TIn> option, Func<TIn, TOut> mappingFunction) => option.IsSome ? Some(mappingFunction(option.ValueUnsafe)) : None<TOut>();

        public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, Func<TIn, Option<TOut>> bindingFunction) => option.IsSome ? bindingFunction(option.ValueUnsafe) : None<TOut>();

        public static Option<T> Replace<T>(this Option<T> option, Func<T> replacingFunction) => option.IsNone ? Some(replacingFunction()) : option;

        public static Option<T> BindReplace<T>(this Option<T> option, Func<Option<T>> replacingFunction) => option.IsNone ? replacingFunction() : option;

        public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate) => option.IsSome && predicate(option.ValueUnsafe) ? option : None<T>();

        public static int Count<T>(this Option<T> option) => option.IsSome ? 1 : 0;
        #endregion
    }
}