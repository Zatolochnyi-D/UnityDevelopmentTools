using System;

namespace DenZ.DevelopmentTools.Monads
{
    public readonly struct Result<T>
    {
        private readonly T _ok;
        private readonly Func<Exception> _errorFactory;
        private readonly bool _hasValue;

        public bool IsOk => _hasValue;
        public bool IsError => !_hasValue;
        public T OkUnsafe => _ok;
        public T Ok => IsOk ? _ok : throw new ArgumentException("Cannot read Ok of Error.");
        public Exception ErrorUnsafe => _errorFactory();
        public Exception Error => IsError ? _errorFactory() : throw new ArgumentException("Cannot read Error of Ok.");

        public Result(T value)
        {
            _ok = value;
            _errorFactory = null;
            _hasValue = true;
        }

        public Result(Func<Exception> errorFactory)
        {
            _ok = default;
            _errorFactory = errorFactory;
            _hasValue = false;
        }

        public static implicit operator Result<T>(T value) => new(value);
        public static implicit operator Result<T>(Func<Exception> error) => new(error);
    }
}