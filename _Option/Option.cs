namespace ThreeDent.DevelopmentTools.Options
{
    public abstract class Option<T> { internal Option() { } }

    public sealed class Some<T> : Option<T>
    {
        private readonly T value;

        public T Value => value;

        public Some(T value)
        {
            this.value = value;
        }
    }

    public sealed class None<T> : Option<T> { }
}