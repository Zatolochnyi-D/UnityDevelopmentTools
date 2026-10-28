using System;

namespace DenZ.DevelopmentTools.Monads
{
    public readonly struct Result<T>
    {
        private readonly T _ok;
        private readonly string _error;
        private readonly bool _hasValue;

        public bool IsOk => _hasValue;
        public bool IsError => !_hasValue;
        public T OkUnsafe => _ok;
        public T Ok => IsOk ? _ok : throw new ArgumentException("Cannot read Ok of Error.");
        public string ErrorUnsafe => _error;
        public string Error => IsError ? _error : throw new ArgumentException("Cannot read Error of Ok.");

        public Result(T value)
        {
            _ok = value;
            _error = null;
            _hasValue = true;
        }

        public Result(string error)
        {
            _ok = default;
            _error = error;
            _hasValue = false;
        }

        public static implicit operator Result<T>(T value) => new(value);
        public static implicit operator Result<T>(string error) => new(error);
    }
}