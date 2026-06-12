using System;

namespace DenZ.DevelopmentTools.Options
{
    public readonly struct Option<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        public bool IsSome => _hasValue;
        public bool IsNone => !_hasValue;
        public T Value => _hasValue ? _value : throw new ArgumentException("Cannot read value of None.");

        public Option(T value)
        {
            _value = value;
            _hasValue = true;
        }

        public static implicit operator Option<T>(T value)
        {
            return new(value);
        }
    }
}