namespace DenZ.DevelopmentTools.Monads
{
    public static class Result
    {
        #region Create
        public static Result<T> Ok<T>(T value) => new(value);

        public static Result<T> Error<T>(string error) => new(error);

        public static Result<T> FromOption<T>(Option<T> option, string onNone) => option.IsSome ? Ok(option.ValueUnsafe) : Error<T>(onNone);
        #endregion


        #region Read
        // public static T ReadOrDefaultTo<T>(this Option<T> option, T defaultValue) => option.IsSome ? option.ValueUnsafe : defaultValue;

        // public static T ReadOrThrow<T>(this Option<T> option, Exception exception) => option.IsSome ? option.ValueUnsafe : throw exception;

        // public static T ReadOrNew<T>(this Option<T> option) where T : new() => option.IsSome ? option.ValueUnsafe : new();
        #endregion


        #region Transform/Update
        // public static void Apply<T>(this Option<T> option, Action<T> applicationFunction)
        // {
        //     if (option.IsSome)
        //         applicationFunction(option.ValueUnsafe);
        // }

        // public static Option<TOut> Map<TIn, TOut>(this Option<TIn> option, Func<TIn, TOut> mappingFunction) => option.IsSome ? Some(mappingFunction(option.ValueUnsafe)) : None<TOut>();

        // public static Option<TOut> Bind<TIn, TOut>(this Option<TIn> option, Func<TIn, Option<TOut>> bindingFunction) => option.IsSome ? bindingFunction(option.ValueUnsafe) : None<TOut>();

        // public static Option<T> Replace<T>(this Option<T> option, Func<T> replacingFunction) => option.IsNone ? Some(replacingFunction()) : option;

        // public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate) => option.IsSome && predicate(option.ValueUnsafe) ? option : None<T>();

        // public static int Count<T>(this Option<T> option) => option.IsSome ? 1 : 0;
        #endregion
    }
}