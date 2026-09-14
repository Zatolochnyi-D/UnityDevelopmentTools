namespace DenZ.DevelopmentTools.Di
{
    public abstract class TypeWrapper<T>
    {
        protected T _value;

        public T Value => _value;

        public TypeWrapper(T value)
        {
            _value = value;
        }
    }
}