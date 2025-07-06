namespace ThreeDent.DevelopmentTools.Exceptions
{
    [System.Serializable]
    public class SingletonMissingException : System.Exception
    {
        public SingletonMissingException() { }
        public SingletonMissingException(string message) : base(message) { }
        public SingletonMissingException(string message, System.Exception inner) : base(message, inner) { }
        protected SingletonMissingException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
