using System;

namespace DenZ.DevelopmentTools.Monads
{
    public static class Result
    {
        #region Create
        public static Result<T> Ok<T>(T value) => new(value);

        public static Result<T> Error<T>(Func<Exception> error) => new(error);

        public static Result<T> ToResult<T>(this Option<T> option, Func<Exception> onNone) => option.IsSome ? Ok(option.ValueUnsafe) : Error<T>(onNone);
        #endregion


        #region Read
        // public static T ReadOrDefaultTo<T>(this Option<T> option, T defaultValue) => option.IsSome ? option.ValueUnsafe : defaultValue;

        // public static T ReadOrThrow<T>(this Option<T> option, Exception exception) => option.IsSome ? option.ValueUnsafe : throw exception;

        // public static T ReadOrNew<T>(this Option<T> option) where T : new() => option.IsSome ? option.ValueUnsafe : new();
        #endregion


        #region Transform/Update
        public static void Apply<T>(this Result<T> result, Action<T> applicationFunction)
        {
            if (result.IsOk)
                applicationFunction(result.OkUnsafe);
        }

        // Check Ok for condition and return it if pass, else return new error. If error - jut propagate.
        public static Result<T> Check<T>(this Result<T> result, Func<T, bool> checkFunction, Func<Exception> onCheckFailed) => result.IsOk ? (checkFunction(result.OkUnsafe) ? result : onCheckFailed) : result;

        // public static Option<TOut> Map<TIn, TOut>(this Option<TIn> option, Func<TIn, TOut> mappingFunction) => option.IsSome ? Some(mappingFunction(option.ValueUnsafe)) : None<TOut>();

        // public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, Func<TIn, Option<TOut>> bindingFunction) => option.IsSome ? bindingFunction(option.ValueUnsafe) : None<TOut>();

        // public static Option<T> Replace<T>(this Option<T> option, Func<T> replacingFunction) => option.IsNone ? Some(replacingFunction()) : option;

        // public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate) => option.IsSome && predicate(option.ValueUnsafe) ? option : None<T>();

        // public static int Count<T>(this Option<T> option) => option.IsSome ? 1 : 0;
        #endregion
    }
}