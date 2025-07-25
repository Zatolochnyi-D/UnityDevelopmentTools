using System;

namespace ThreeDent.DevelopmentTools.Option
{
    public readonly struct Option<T>
    {
        private readonly T value;
        private readonly bool hasValue;

        public bool IsSome => hasValue;
        public bool IsNone => !hasValue;
        public T Value => hasValue ? value : throw new ArgumentException("Cannot read value of None.");

        public Option(T value)
        {
            this.value = value;
            hasValue = true;
        }
    }
}